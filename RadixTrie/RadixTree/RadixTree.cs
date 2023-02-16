namespace RadixTree
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
            int indexOfnewValue = root.Children.IndexOfKey(stringValue[0]);
            if (indexOfnewValue != -1) // cheia exista si adaugam in continuarea ei
            {
                root.AddChild(stringValue, indexOfnewValue);
            }
            if (indexOfnewValue == -1) // primul copil al radacinii
            {
                root.Children.Add(stringValue[0], new RadixNode<string>(stringValue));
                root.Children[stringValue[0]].IsWord = true;
                return;
            }


        }
    }
}