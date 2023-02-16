global using Xunit;
namespace Radix
{
    public class RadixTreeFacts
    {
        [Fact]
        public void AddNodesWithSameRadicalNoNeedToSplit()
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
            tree.Insert("margea");
            tree.Insert("merge");
            tree.Insert("minune");
            tree.Insert("maria");
            tree.Insert("mariana");
            tree.Insert("marianara");
            tree.Insert("munte");
            tree.Insert("miracol");

        }
    }
}