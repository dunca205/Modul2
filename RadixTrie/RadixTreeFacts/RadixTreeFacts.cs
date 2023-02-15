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
            tree.Insert("mariana");
        }

        [Fact]
        public void AddNodeWithCommonRadical()
        {
            var tree = new RadixTree<string>();
            tree.Insert("mar");
            tree.Insert("margine");
            tree.Insert("maria");
            tree.Insert("merge");
            tree.Insert("mare");
        }
    }
}