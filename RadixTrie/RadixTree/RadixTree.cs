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

        public void Delete(T value)
        {
            // 1.  daca parintele il are doar pe el copil => stergem copilul parintelui
            // 2.  daca parinte are 2 copii => combinam parintele cu copilul ramas
            // 3.  daca copilul are mai multi copii, schimbam valoarea lui isWord = false
            // 4.  daca copilul are doar 1 copil, combinam nodul de sters cu cel succesor
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
                    RemoveNode(ref temp, valueToDelete);
                    return;
                }

                temp = temp.Children[key];
            }
        }

        private static void RemoveNode(ref RadixNode<string> parentNode, string childValue)
        {
            char key = childValue[0];

            // 1.  daca parintele il are doar pe el copil => stergem copilul parintelui(ex avem maria , mariana si vrem sa stergem mariana
            // iar nodul de sters nu are alti copii
            if (parentNode.Children.Count == 1 && parentNode.Children[key].Children.Count == 0)
            {
                parentNode.Children.RemoveAt(0);
                return;
            }

            // 2.  daca parintele are 2 copii && copilul de sters nu mai are alti copii
            // => combinam parintele cu copilului ramas  ex avem: parinte 99 si copii 852 si 853, stergem 99852 -> parintele devine 99853
            if (parentNode.Children.Count == 2 && parentNode.Children[key].Children.Count == 1)
            {
                int indexOfKey = parentNode.Children.IndexOfKey(key); // copilul ia
                char keyOfnephew = parentNode.Children[key].Children.GetKeyAtIndex(0);
                parentNode.Children.SetValueAtIndex(indexOfKey, parentNode.Children[key].Children[keyOfnephew]);
            }

            // 2.  daca copilul are mai multi copii, schimbam valoarea lui isWord = false, inca avem nevoie de radicalul sau
            if (parentNode.Children[key].Children.Count >= 2)
            {
                parentNode.Children[key].IsWord = false;
            }

            // 3.  daca copilul are doar 1 copil, combinam nodul de sters cu cel succesor
        }

        private static void CombineNodes(RadixNode<string> parentNode)
        {
            char keyOfOnlyChild = parentNode.Children.GetKeyAtIndex(0);
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