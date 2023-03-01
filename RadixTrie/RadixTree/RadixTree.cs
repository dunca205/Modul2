using System.Net.Http.Headers;

namespace Radix
{
    public class RadixTree<T>
        where T : IComparable<T>
    {
        private RadixNode<T> root;

        public RadixTree()
        {
            root = new RadixNode<T>(default);
        }

        public void Insert(T val)
        {
            RadixNode<T> value = new RadixNode<T>(val);
            int parent = FindParent(root.Children, value);
            if (parent == -1)
            {
                NormalInsertion(ref root, value);
                return;
            }

            Add(value, root.Children.GetKeyAtIndex(parent));
        }

        public void Add(RadixNode<T> newNode, T key)
        {
            RadixNode<T> parent = root.Children[key];

            RadixNode<T> grandParent = root;

            int matched = newNode.CompareTo(parent);
            while (matched != -1)
            {
                if (matched == 1)
                {
                    newNode.Value = Subtract(key, newNode.Value, out T parentValueAfter, out T commonRadix);
                    if (parent.Children.Count == 0)
                    {
                        NormalInsertion(ref parent, newNode);
                        return;
                    }

                    int parentIndex = FindParent(parent.Children, newNode);
                    if (parentIndex != -1)
                    {
                        key = parent.Children.GetKeyAtIndex(parentIndex);
                        grandParent = parent;
                        parent = parent.Children[key];
                    }
                    else
                    {
                        SplitNode(ref grandParent, key, newNode);
                        break;
                    }
                }

                NormalInsertion(ref parent, newNode);

                matched = parent.CompareTo(newNode);
            }
        }

        public void NormalInsertion(ref RadixNode<T> parentNode, RadixNode<T> value)
        {
            parentNode.Children.Add(value.Value, value);
            parentNode.Children[value.Value].IsWord = true;
        }

        public int FindParent(SortedList<T, RadixNode<T>> list, RadixNode<T> value)
        {
            int found = -1;
            foreach (var child in list)
            {
                found = value.CompareTo(child.Value);
                if (found == 0 || found == 1)
                {
                    return list.IndexOfKey(child.Key);
                }
            }

            return found;
        }

        private static void SplitNode(ref RadixNode<T> parent, T key, RadixNode<T> newValue)
        {
            RadixNode<T> newNode;
            T newValueLeft = Subtract(key, newValue.Value, out T newValueOfParentKey, out T commonRadix);
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

                newNode.Children.Add(newValueOfParentKey, new RadixNode<T>(default));
                newNode.Children[newValueOfParentKey].Value = newValueOfParentKey;
                newNode.Children[newValueOfParentKey].IsWord = parent.Children[key].IsWord;
                if (parent.Children[key].Children.Count > 0)
                {
                    newNode.Children[newValueOfParentKey].Children = parent.Children[key].Children;
                }
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