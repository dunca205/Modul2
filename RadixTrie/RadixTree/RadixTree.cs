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
            int parentFound = FindParent(root.Children, value);
            if (parentFound == -1)
            {
                root.Children.Add(value, new RadixNode<T>(default));
                root.Children[value].IsWord = true;
                return;
            }

            Add(value, root.Children.GetKeyAtIndex(parentFound));
        }

        public void Add(T value, T key)
        {
            RadixNode<T> parent = root.Children[key];
            SortedList<T, RadixNode<T>> parentList = root.Children;
            int matched = Compare(key, value);
            while (matched != -1)
            {
                if (matched == 0)
                {
                    value = Substract(key, value, out _, out T commonRadix);
                    if (parent.Children.Count == 0)
                    {
                        NormalInsertion(parent, value);
                        return;
                    }

                    int parentIndex = FindParent(parent.Children, value);
                    if (parentIndex != -1)
                    {
                        key = parent.Children.GetKeyAtIndex(parentIndex);
                        parentList = parent.Children;
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
                   SplitNode(ref parentList, key, value);
                   break;
                }

                matched = Compare(key, value);
            }
        }

        public void NormalInsertion(RadixNode<T> parentNode, T value)
        {
            parentNode.Children.Add(value, new RadixNode<T>(default));
            parentNode.Children[value].IsWord = true;
        }

        public int Compare(T? x, T? y)
        {
            string existStr = x.ToString();
            string newStr = y.ToString();
            string left = "";

            for (int i = 0; i < existStr.Length && i < newStr.Length; i++)
            {
                if (newStr[i] != existStr[i])
                {
                    break;
                }

                left += newStr[i];
            }

            if (left.Length.CompareTo(existStr.Length) == 0)
            {
                return 0; // x este prefix perfect pt y
            }
            else if (left.Length.CompareTo(existStr.Length) == -1 && left.Length > 0)
            {
                return 1; // x este prefix partial pentru y
            }

            return -1;
        }

        public int FindParent(SortedList<T, RadixNode<T>> list, T value)
        {
            int found = -1;
            foreach (var child in list)
            {
                found = Compare(child.Key, value);
                if (found == 0 || found == 1)
                {
                    return list.IndexOfKey(child.Key);
                }
            }

            return found;
        }

        private static void SplitNode(ref SortedList<T, RadixNode<T>> parent, T key, T newValue)
        {
            T newValueLeft = Substract(key, newValue, out T newValueOfParentKey, out T commonRadix);

            var newNode = new RadixNode<T>(commonRadix);
            newNode.Children.Add(newValueLeft, new RadixNode<T>(default));
            newNode.Children.Add(newValueOfParentKey, parent[key]);
            parent[key] = newNode;
        }

        private static T Substract(T parentKey, T newValue, out T newValueOfParentKey, out T commonRadix)
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