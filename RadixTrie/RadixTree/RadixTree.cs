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
            int match = -1;
            foreach (var kid in root.Children)
            {
                match = Compare(kid.Key, value);
                if (match == 0)
                {
                    T reminder = Substract(kid.Key, value, out _, out _);
                    Add(reminder, kid.Key);
                    return;
                }

                if (match == 1)
                {
                    var C = kid.Value;
                    SplitNode(kid, kid.Key, value);
                    return;
                }
            }

            root.Children.Add(value, new RadixNode<T>(default));
            root.Children[value].IsWord = true;
        }

        public void Add(T value, T key)
        {
            var parentNode = root.Children[key];
            if (parentNode.Children.Count == 0)
            {
                parentNode.Children.Add(value, new RadixNode<T>(default));
                parentNode.Children[value].IsWord = true;
                return;
            }

            parentNode.Children.Add(value, default);
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
                return 0;
            }
            else if (left.Length.CompareTo(existStr.Length) == -1 && left.Length > 0)
            {
                return 1;
            }

            return -1;
        }

        private static void SplitNode(KeyValuePair<T, RadixNode<T>> children, T key, T newValue)
        {
            T substract = Substract(children.Key, newValue, out _, out _);
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