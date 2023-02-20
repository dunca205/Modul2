namespace Radix
{
    public class RadixTree<T>
    {
        private RadixNode<T> root;

        public RadixTree()
        {
            root = new RadixNode<T>(default);
        }

        public void Insert(T value)
        {
            string stringValue = value.ToString();
            char key = stringValue[0];
            if (root.Children.ContainsKey(stringValue[0]))
            {
                Add(ref stringValue, ref key);
                return;
            }

            root.Children.Add(key, new RadixNode<string>(stringValue));
        }

        private static void SplitNode(RadixNode<string> existingNode, string value, out RadixNode<string> newNode)
        {
            string existingNodeValue = existingNode.Value;
            string commonRadix = "";
            for (int i = 0; i < existingNodeValue.Length && i < value.Length && existingNodeValue[i] == value[i]; i++)
            {
                commonRadix += existingNodeValue[i];
            }

            existingNodeValue = GetSubstring(existingNodeValue, commonRadix);
            value = GetSubstring(value, commonRadix);
            newNode = new RadixNode<string>(commonRadix);
            newNode.Children.Add(value[0], new RadixNode<string>(value));
            newNode.Children[value[0]].IsWord = true;
            existingNode.Value = existingNodeValue;
            newNode.Children.Add(existingNodeValue[0], existingNode);
        }

        private static string GetSubstring(string stringValue, string valueOfRadix)
        {
            return stringValue[valueOfRadix.Length..];
        }

        private void Add(ref string value, ref char key)
        {
            if (value.StartsWith(root.Children[key].Value))
            {
                for (RadixNode<string> temp = root.Children[key]; temp.Value != null && value.Length > 0; temp = temp.Children[key])
                {
                    value = GetSubstring(value, temp.Value);
                    key = value[0];

                    if (temp.Children.Count == 0 || !temp.Children.ContainsKey(key)) // daca nodul nu mai are copii sau copii nu au cheia respectiva 
                    {
                        temp.Children.Add(key, new RadixNode<string>(value));
                        return;
                    }

                    if (value.StartsWith(temp.Children[key].Value)) // prefix comun
                    {
                        key = value[0];
                    }
                    else
                    {
                        RadixNode<string> newNode;
                        SplitNode(temp.Children[key], value, out newNode);
                        temp.Children[key] = newNode;
                        value = "";
                        return;
                    }
                }

                return;
            }

            RadixNode<string> newValue;
            SplitNode(root.Children[key], value, out newValue);
            root.Children[key] = newValue;
        }
    }
}