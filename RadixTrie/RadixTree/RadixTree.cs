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
            if (!root.HasChildren)
            {
                
            }

           
           
        }
    }
}