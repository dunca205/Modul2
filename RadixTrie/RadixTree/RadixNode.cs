namespace Radix
{
    public class RadixNode<T>
    {
        private SortedList<char, RadixNode<string>> children;

        public RadixNode(string value)
        {
            this.Value = value;
            children = new SortedList<char, RadixNode<string>>();
        }

        public SortedList<char, RadixNode<string>> Children { get => this.children; set => this.children = value; }

        public string Value { get; set; }

        public bool IsWord { get; set; }

        public void AddChild(string stringValue, int index)
        {
            var key = children.GetKeyAtIndex(index);
            Matching(ref stringValue, children[key]);

            if (stringValue.Length == 0)
            {
                return;
            }

            SplitNode(children[key], stringValue, out RadixNode<string> temp);
            children[key] = temp;
        }

        private static string GetSubstring(string stringValue, string valueOfRadix)
        {
            return stringValue[valueOfRadix.Length..];
        }

        private static void Next(ref RadixNode<string> existingNode, ref string leftOver, ref char key)
        {
            if (leftOver.StartsWith(existingNode.Value))
            {
                leftOver = GetSubstring(leftOver, existingNode.Value);

                if (existingNode.children.IndexOfKey(leftOver[0]) > -1)
                {
                    key = leftOver[0];
                    return;
                }

                existingNode.children.Add(leftOver[0], new RadixNode<string>(leftOver));
                leftOver = "";
                key = ' ';
                return;
            }

            SplitNode(existingNode, leftOver, out RadixNode<string> temp);
            existingNode = temp;
            key = ' ';
            leftOver = "";
        }

        private static void SplitNode(RadixNode<string> existingNode, string value, out RadixNode<string> temp)
        {
            string existingNodeValue = existingNode.Value;
            string commonRadix = "";
            for (int i = 0; i < existingNodeValue.Length && i < value.Length && existingNodeValue[i] == value[i]; i++)
            {
                commonRadix += existingNodeValue[i];
            }

            existingNodeValue = GetSubstring(existingNodeValue, commonRadix);
            value = GetSubstring(value, commonRadix);

            temp = new RadixNode<string>(commonRadix);
            temp.children.Add(value[0], new RadixNode<string>(value));
            temp.children[value[0]].IsWord = true;
            existingNode.Value = existingNodeValue;
            temp.children.Add(existingNodeValue[0], existingNode);
        }

        private static void Matching(ref string newValue, RadixNode<string> existingNode)
        {
            string existingNodeValue = existingNode.Value;

            if (!newValue.StartsWith(existingNodeValue))
            {
                return;
            }

            newValue = GetSubstring(newValue, existingNodeValue);

            int indexOfNextKey = existingNode.children.IndexOfKey(newValue[0]);
            if (indexOfNextKey != -1)
            {
                var key = newValue[0];

                while (key != ' ')
                {
                    existingNode = existingNode.children[key];
                    Next(ref existingNode, ref newValue, ref key);
                }

                return;
            }

            existingNode.children.Add(newValue[0], new RadixNode<string>(newValue));
            existingNode.children[newValue[0]].IsWord = true;
            newValue = "";
        }
    }
}
