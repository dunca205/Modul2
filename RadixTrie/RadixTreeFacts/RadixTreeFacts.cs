global using Xunit;
namespace RadixTree
{
    public class RadixTreeFacts
    {
        [Fact]
        public void Test1()
        {
            var tree = new RadixTree<string>();
            tree.Insert("ana");
            tree.Insert("are");
        }
    }
}