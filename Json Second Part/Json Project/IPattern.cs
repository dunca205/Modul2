namespace Json
{
    public interface IPattern
    {
        public IMatch Match(string text);
    }
}
