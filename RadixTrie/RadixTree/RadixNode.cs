namespace RadixTree
{
    public class RadixNode<T>
    {
        private string value;
        private SortedList<char, RadixNode<string>> children;
        public RadixNode(string value)
        {
            this.value = value;
            bool isWord = false; // se face true dupa insertie
            children = new SortedList<char, RadixNode<string>>();
        }

        public SortedList<char, RadixNode<string>> Children { get { return children; } }
        public string Value { get => this.value; set => this.value = value; }
        public char Key { get => value[0]; }
        public bool IsWord { get; set; }
        public void AddSibling(string stringValue) // daca aceasta metoda a fost apleala are radacina comuna cu primii copii ai radacinii
        {

            string valueOfSibling = children[stringValue[0]].value.ToString(); // valoare nodului cu cheie comuna

            if (stringValue.StartsWith(valueOfSibling)) // au aceeasi radacina comuna (mar) 
            {
                var leftOver = GetSubstring(stringValue, valueOfSibling); //  iana
                var commonRadix = children[stringValue[0]]; // in copii lui trb sa caut pana cand raman fara litere in substring

                if (commonRadix.children.ContainsKey(leftOver[0])) // avem cheie cu i
                {
                    var key = commonRadix.children[leftOver[0]].Key;
                    var valueOfCommonRadix = commonRadix.children[leftOver[0]].value;
                    if (valueOfCommonRadix.Length < leftOver.Length)
                    {
                        leftOver = GetSubstring(leftOver, valueOfCommonRadix);
                    }
                    else
                    {
                        leftOver = GetSubstring(valueOfCommonRadix, leftOver);
                    }

                    commonRadix.children[key].children.Add(leftOver[0], new RadixNode<string>(leftOver));
                    return;
                }

                commonRadix.children.Add(leftOver[0], new RadixNode<string>(leftOver));
            }
        }
        private void AfterMatch(string stringValue, string stringMatch)
        {

        }
        private string GetSubstring(string stringValue, string valueOfSibling)
        {
            return stringValue[valueOfSibling.Length..];
        }

    }
}
