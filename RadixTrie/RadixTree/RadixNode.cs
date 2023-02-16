namespace RadixTree
{
    public class RadixNode<T>
    {
        private string value;
        private SortedList<char, RadixNode<string>> children;

        public RadixNode(string value)
        {
            this.value = value;
            bool isWord = false;
            children = new SortedList<char, RadixNode<string>>();
        }
        public SortedList<char, RadixNode<string>> Children { get => this.children; set => this.children = value; }
        public string Value { get => this.value; set => this.value = value; }
        public char Key { get => value[0]; }
        public bool IsWord { get; set; }
        public void AddChild(string stringValue, int index)
        {
            var key = children.GetKeyAtIndex(index);
            Matching(ref stringValue, children[key]);
            // daca se potrivesc radicalii, Matching va potrivi toate silabele/literele cuvantului 

            if (stringValue.Length > 0)  // daca nu a facut Match nici cu priul radical, trebuie impartit nodul
            {
                SplitNode(children[key], stringValue, out RadixNode<string> temp);
                children[key] = temp;
            }

        }
        private void Matching(ref string newValue, RadixNode<string> existingNode)
        {
            string existingNodeValue = existingNode.value;

            if (newValue.StartsWith(existingNodeValue))// potriveste primul radical
            {
                newValue = GetSubstring(newValue, existingNodeValue);

                int indexOfNextKey = existingNode.children.IndexOfKey(newValue[0]);
                if (indexOfNextKey != -1)
                {
                    var key = existingNode.children.GetKeyAtIndex(indexOfNextKey);
                    for (RadixNode<string> matchedNode = existingNode.children[key]; newValue.Length > 0; matchedNode = matchedNode.children[key])
                    {
                        NextKey(ref matchedNode, ref newValue, ref key);
                        if (key == ' ')
                        {
                            break;
                        }
                    }
                    return;
                }

                // adaugam restul in continuarea prefixului comun
                existingNode.children.Add(newValue[0], new RadixNode<string>(newValue));
                existingNode.children[newValue[0]].IsWord = true;
                newValue = "";
                return;
            }

        }
        private void NextKey(ref RadixNode<string> existingNode, ref string leftOver, ref char key)
        {
            if (leftOver.StartsWith(existingNode.value))
            {
                leftOver = GetSubstring(leftOver, existingNode.value);

                if (existingNode.children.IndexOfKey(leftOver[0]) > -1)
                {
                    key = leftOver[0];
                    return;
                }

                existingNode.children.Add(leftOver[0], new RadixNode<string>(leftOver));
                leftOver = "";
                key = ' ';
                return;
            }

            SplitNode(existingNode, leftOver, out RadixNode<string> temp);
            {
                existingNode.children[key] = temp;
            }
            key = ' ';
            leftOver = "";
        }

        private void SplitNode(RadixNode<string> existingNode, string value, out RadixNode<string> temp)
        {
            string existingNodeValue = existingNode.Value;
            string commonRadix = "";
            int i = 0;
            while (i < existingNodeValue.Length && i < value.Length && existingNodeValue[i] == value[i])
            {
                commonRadix += existingNodeValue[i];
                i++;
            }

            string existigNodeLeftOver = GetSubstring(existingNodeValue, commonRadix);
            string leftOverValue = GetSubstring(value, commonRadix);
            // daca avem margine si adaugam margea, gine si gea=>
            //                                      g-> ((ine) && (ea))
            temp = new RadixNode<string>(commonRadix);//g
            temp.children.Add(leftOverValue[0], new RadixNode<string>(leftOverValue));//ea key:e value:ea
            temp.children[leftOverValue[0]].IsWord = true;

            temp.children.Add(existigNodeLeftOver[0], existingNode);
            temp.children[existigNodeLeftOver[0]].value = existigNodeLeftOver;
            // temp = nod cu radicalul comun dintre existingNode si value
        }
        private string GetSubstring(string stringValue, string valueOfSibling)
        {
            return stringValue[valueOfSibling.Length..];
        }

    }
}
