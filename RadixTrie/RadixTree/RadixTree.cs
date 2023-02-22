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
                Add(stringValue, ref key);
                return;
            }

            root.Children.Add(key, new RadixNode<string>(stringValue));
            root.Children[key].IsWord = true;
        }

        public bool Search(RadixNode<T> node)
        {
            return Search(node.Value);
        }

        public bool Search(T value)
        {
            string valueToFind = value.ToString();
            char key = valueToFind[0];
            if (!root.Children.ContainsKey(key))
            {
                return false;
            }

            RadixNode<string> temp = root.Children[key];
            while (valueToFind.Length > 0)
            {
                if (valueToFind.StartsWith(temp.Value))
                {
                    valueToFind = GetSubstring(valueToFind, temp.Value);
                }

                if (valueToFind.Length == 0)
                {
                    return temp.IsWord;
                }

                if (temp.Children.IndexOfKey(valueToFind[0]) == -1)
                {
                    return false;
                }

                key = valueToFind[0];
                temp = temp.Children[key];
            }

            return true;
        }

        public void Delete(RadixNode<T> node)
        {
            Delete(node.Value);
        }

        public void Delete(T value)
        {
            // 1.  daca nodul de sters nu are deloc copii
            // 2.  daca nodul de sters are 1 copil il combinam cu nodul de sters
            // 3.  daca nodul de sters are mai multi copii modificam doar isWord
            string valueToDelete = value.ToString();
            char key = valueToDelete[0];
            if (!root.Children.ContainsKey(key))
            {
                return;
            }

            RadixNode<string> temp = root.Children[key];
            while (valueToDelete.StartsWith(temp.Value))
            {
                valueToDelete = GetSubstring(valueToDelete, temp.Value);

                key = valueToDelete[0];
                if (temp.Children.IndexOfKey(key) == -1)
                {
                    return;
                }

                if (temp.Children[key].Value == valueToDelete)
                {
                    RemoveFromParent(temp, valueToDelete);
                    if (temp.Children.Count == 1)
                    {
                        temp = CombineNodes(temp);
                    }

                    return;
                }

                temp = temp.Children[key];
            }
        }

        private static void RemoveFromParent(RadixNode<string> parentNode, string childValue)
        {
            char key = childValue[0];

            // ex avem maria si mariana, vrem sa stergem mariana -> doar stergem nodul na
            if (parentNode.Children[key].Children.Count == 0)
            {
                parentNode.Children.Remove(key);
                return;
            }

            // ex avem maria si mariana, vrem sa stergem maria... ia->iana
            if (parentNode.Children[key].Children.Count == 1)
            {
                parentNode.Children[key] = CombineNodes(parentNode.Children[key]);
                return;
            }

            // 2.  daca copilul are mai multi copii, schimbam valoarea lui isWord = false, inca avem nevoie de radicalul sau
            parentNode.Children[key].IsWord = false;
        }

        private static RadixNode<string> CombineNodes(RadixNode<string> parentNode)
        {
            char keyOfOnlyChild = parentNode.Children.GetKeyAtIndex(0);
            string combinedValue = parentNode.Value + parentNode.Children[keyOfOnlyChild].Value;
            parentNode = parentNode.Children[keyOfOnlyChild];
            parentNode.Value = combinedValue;
            return parentNode;
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

        private void Add(string value, ref char key)
        {
            // value are prefix comun
            if (value.StartsWith(root.Children[key].Value))
            {
                RadixNode<string> temp = root.Children[key];
                while (value.Length > 0)
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
                        return;
                    }

                    temp = temp.Children[key];
                }

                return;
            }

            RadixNode<string> newValue;
            SplitNode(root.Children[key], value, out newValue);
            root.Children[key] = newValue;
        }
    }
}