namespace Radix
{
    public class RadixTree<T>
    {
        private RadixNode<string> root;

        public RadixTree()
        {
            root = new RadixNode<string>(default);
        }

        public void Insert(RadixNode<T> node)
        {
            Insert(node.Value);
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
            root.Children[key].IsWord = true;
        }

        public bool Search(T value)
        {
            string valueToFind = value.ToString();
            char key = valueToFind[0];
            if (!root.Children.ContainsKey(key))
            {
                return false;
            }

            for (RadixNode<string> temp = root.Children[key]; temp.Value != null && valueToFind.Length > 0; temp = temp.Children[key])
            {
                if (valueToFind.StartsWith(temp.Value))
                {
                    valueToFind = GetSubstring(valueToFind, temp.Value);
                }

                if (valueToFind.Length == 0 && temp.IsWord)
                {
                    return true;
                }

                if (temp.Children.IndexOfKey(valueToFind[0]) == -1)
                {
                    return false;
                }

                key = valueToFind[0];
            }

            return true;
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

        private static string GetSubstring(string stringValue, string radix)
        {
            return stringValue[radix.Length..];
        }

        private void Add(ref string value, ref char key)
        {
            if (value.StartsWith(root.Children[key].Value))
            {
                for (RadixNode<string> temp = root.Children[key]; temp.Value != null && value.Length > 0; temp = temp.Children[key])
                {
                    value = GetSubstring(value, temp.Value);
                    key = value[0];

                    if (temp.Children.Count == 0 || !temp.Children.ContainsKey(key))
                    {
                        temp.Children.Add(key, new RadixNode<string>(value));
                        temp.Children[key].IsWord = true;
                        return;
                    }

                    if (value.StartsWith(temp.Children[key].Value))
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