global using Xunit;
namespace RadixTree
{
    public class RadixTreeFacts
    {
        [Fact]
        public void AddNodesWithSameRadical()
        {
            var tree = new RadixTree<string>();
            tree.Insert("mar");
            tree.Insert("margine");
            tree.Insert("maria");
            tree.Insert("cristina");
            tree.Insert("mariana");

        }
    }
}