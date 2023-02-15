using System.Windows.Markup;
using System.Xml.Linq;

namespace RadixTree
{
    public class RadixNode<T>
    {
        private string value;
        private SortedList<char, RadixNode<string>> children;
        public RadixNode(string value)
        {
            this.value = value;
            bool isWord = false; // se face true dupa insertie
            children = new SortedList<char, RadixNode<string>>();
        }

        public SortedList<char, RadixNode<string>> Children { get { return children; } }
        public string Value { get => this.value; set => this.value = value; }
        public char Key { get => value[0]; }
        public bool IsWord { get; set; }
        public void AddChild(string stringValue) // daca aceasta metoda a fost apleala are radacina comuna cu primii copii ai radacinii
        {
            var index = children.IndexOfKey(stringValue[0]);
            var key = children.GetKeyAtIndex(index);
            var next = new RadixNode<string>("");
            bool matched = true; /*= IsPerfectMatch(ref stringValue, children[key], out next);*/
            for (var node = children[key];stringValue.Length > 0; node = next)
            {
                matched = IsPerfectMatch(ref stringValue, node, ref next);
            }

            if (!matched && stringValue.Length > 0) 
            {
                var newRadix = new RadixNode<string>(default);
                SplitNode(children[key], stringValue, out newRadix);
                children[key] = newRadix;
            }

        }
        private bool IsPerfectMatch(ref string leftOver, RadixNode<string> existingNode, ref RadixNode<string> next)
        {
            string existingNodeValue = existingNode.value; 
                                                                        
            if (existingNodeValue.Length < leftOver.Length && leftOver.StartsWith(existingNodeValue))
            {
                string subsString = GetSubstring(leftOver, existingNodeValue);
                leftOver = subsString;
                int indexOfNextKey = existingNode.children.IndexOfKey(leftOver[0]);
                if (existingNode.children.Count == 0 || indexOfNextKey == -1)
                {
                    existingNode.children.Add(leftOver[0], new RadixNode<string>(leftOver));
                    existingNode.children[leftOver[0]].IsWord = true;
                    leftOver = "";
                    return true; 

                }
                else if (indexOfNextKey > -1)
                {
                    var key =  existingNode.children.GetKeyAtIndex(indexOfNextKey); 
                    next = existingNode.children[key];
                    return true;
                }
            }

            return false; 
        }
        private void SplitNode(RadixNode<string> existingNode,string value, out RadixNode<string> newRadix)
        {
            // ex : Mar - ia- na
            //          - gine
            //  add:Merge
            // 
            //  commonRadix = M;
            //  existingNodeLeftOver = ar 
            //         leftoverValue = erge
            //  new Node = commonRadix(m)
            //      add Child( existing node, si schimba valoarea lui existing node cu leftoverul sau)
            //             M - ar - ia -na
            //               - gine
            //             M - erge
            string existingNodeValue = existingNode.Value;
            string commonRadix = "";
            int i = 0;
            while (existingNodeValue[i] == value[i])
            { 
                commonRadix += existingNodeValue[i];
                i++;
            }
            string existigNodeLeftOver = GetSubstring(existingNodeValue, commonRadix);
            string leftOverValue = GetSubstring(value, commonRadix);
            newRadix = new RadixNode<string>(commonRadix); // m 
            existingNode.value = existigNodeLeftOver; // actualizam cu noul radical ar, si key va deveni astfel a
            newRadix.children.Add(existigNodeLeftOver[0], existingNode); // adauga ar
            newRadix.children.Add(leftOverValue[0], new RadixNode<string>(leftOverValue));
           
        }
        private string GetSubstring(string stringValue, string valueOfSibling)
        {
            return stringValue[valueOfSibling.Length..];
        }

    }
}
