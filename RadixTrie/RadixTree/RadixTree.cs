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
            int parent = FindParent(root.Children, value);
            if (parent == -1)
            {
                NormalInsertion(root, value);
                return;
            }

            Add(value, root.Children.GetKeyAtIndex(parent));
        }

        public void Add(T value, T key)
        {
            RadixNode<T> parent = root.Children[key];
            RadixNode<T> grandParent = root;
            int matched = parent.CompareTo(value);
            while (matched != -1)
            {
                if (matched == 0)
                {
                    value = Subtract(key, value, out _, out T commonRadix);
                    int parentIndex = FindParent(parent.Children, value);
                    if (parentIndex != -1)
                    {
                        key = parent.Children.GetKeyAtIndex(parentIndex);
                        grandParent = parent;
                        parent = parent.Children[key];
                    }
                    else
                    {
                        NormalInsertion(parent, value);
                        break;
                    }
                }

                if (matched == 1)
                {
                   SplitNode(ref grandParent, key, value);
                   break;
                }

                matched = parent.CompareTo(value);
            }
        }

        public void NormalInsertion(RadixNode<T> parentNode, T value)
        {
            parentNode.Children.Add(value, new RadixNode<T>(default));
            parentNode.Children[value].Value = value;
            parentNode.Children[value].IsWord = true;
        }

        public int FindParent(SortedList<T, RadixNode<T>> list, T value)
        {
            int found = -1;
            foreach (var child in list)
            {
                found = child.Value.CompareTo(value);
                if (found == 0 || found == 1)
                {
                    return list.IndexOfKey(child.Key);
                }
            }

            return found;
        }

        private static void SplitNode(ref RadixNode<T> parent, T key, T newValue)
        {
            RadixNode<T> newNode;
            T newValueLeft = Subtract(key, newValue, out T newValueOfParentKey, out T commonRadix);
            newNode = new RadixNode<T>(commonRadix);
            if (newValueLeft.ToString().Length == 0)
            {
                // daca avem margine si adaugam mar, impartim margine in mar si gine.., si marcam mar ca fiind cuvant
                newNode.IsWord = true;
                newNode.Children.Add(newValueOfParentKey, parent.Children[key]);
                newNode.Children[newValueOfParentKey].Value = newValueOfParentKey;
                newNode.Children[newValueOfParentKey].IsWord = parent.Children[key].IsWord;
            }
            else
            {
                newNode.Children.Add(newValueLeft, new RadixNode<T>(default));
                newNode.Children[newValueLeft].Value = newValueLeft;
                newNode.Children[newValueLeft].IsWord = true;
                newNode.Children.Add(newValueOfParentKey, parent.Children[key]);
                newNode.Children[newValueOfParentKey].Value = newValueOfParentKey;
                newNode.Children[newValueOfParentKey].IsWord = parent.Children[key].IsWord;
            }

            parent.Children.Remove(key);

            parent.Children.Add(newNode.Value, newNode);
        }

        private static T Subtract(T parentKey, T newValue, out T newValueOfParentKey, out T commonRadix)
        {
            var parent = parentKey.ToString();
            var kid = newValue.ToString();
            string commonRadixS = "";
            for (int i = 0; i < parent.Length && i < kid.Length; i++)
            {
                if (parent[i] != kid[i])
                {
                    break;
                }

                commonRadixS += parent[i];
            }

            string parentKeyLeftOver = parent[commonRadixS.Length..];
            string newValueLeftOver = kid[commonRadixS.Length..];
            newValueOfParentKey = (T)Convert.ChangeType(parentKeyLeftOver, typeof(T));
            commonRadix = (T)Convert.ChangeType(commonRadixS, typeof(T));
            return (T)Convert.ChangeType(newValueLeftOver, typeof(T));
        }
    }
}