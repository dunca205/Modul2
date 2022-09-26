namespace Json
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            this.pattern = new Sequence(new Many(element), new Many(separator), new Many(element), new Many(separator), new Many(element));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
