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
        public void AddChild(string stringValue) // daca aceasta metoda a fost apleala are radacina comuna cu primii copii ai radacinii
        {
            const char notMatched = '\u0000';
            var index = children.IndexOfKey(stringValue[0]);
            var key = children.GetKeyAtIndex(index);
            bool matched = IsPerfectMatch(ref stringValue, children[key], out char next);



            //string valueOfSibling = children[stringValue[0]].value.ToString(); // valoare nodului cu cheie comuna
            //if (stringValue.StartsWith(valueOfSibling)) // au aceeasi radacina comuna (mar) 
            //{
            //    var leftOver = GetSubstring(stringValue, valueOfSibling); //  iana
            //    var commonRadix = children[stringValue[0]]; // in copii lui trb sa caut pana cand raman fara litere in substring

            //    commonRadix.children.Add(leftOver[0], new RadixNode<string>(leftOver));
            //}
        }
        private bool IsPerfectMatch(ref string leftOver, RadixNode<string> existingNode, out char next)
        {
            string existingNodeValue = (existingNode.value).ToString(); //ia
                                                                        // ia ..............<..........iana --> trb split
            if (existingNodeValue.Length < leftOver.Length && leftOver.StartsWith(existingNodeValue))
            {
                string subsString = GetSubstring(leftOver, existingNodeValue);
                // na
                leftOver = subsString;//na
                if (existingNode.children.Count == 0) // nu mai avem copii mai departe deci nu avem ce alte prefixe sa cautam inseram ce a ramas
                {
                    existingNode.children.Add(leftOver[0], new RadixNode<string>(leftOver));
                    existingNode.children[leftOver[0]].IsWord = true;
                    next = default(char);   // '\u0000'
                    return true; // a fost perfect match

                }
                else // daca  mai are copii .. cautam  daca are cheie comuna cu ce a ramas (na)
                {
                    int indexOfNextKey = existingNode.children.IndexOfKey(leftOver[0]);
                    if (indexOfNextKey > -1)
                    {
                        next = existingNode.children.GetKeyAtIndex(indexOfNextKey); // n 
                        return true;
                    }
                }
            }

            next = default;
            return false; // daca a fost fals trebuie facut split la nodul repsectiv
        }
        private string GetSubstring(string stringValue, string valueOfSibling)
        {
            return stringValue[valueOfSibling.Length..];
        }

    }
}
