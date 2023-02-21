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
            Assert.True(tree.Search("maria"));
        }

        [Fact]
        public void AddNodeWithCommonRadicalandSearchTheLongest()
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
            Assert.True(tree.Search("marianara"));
            
        }

        [Fact]
        public void SearchForExistingValue_WhitchIsNotMarkedAsWord()
        {
            var tree = new RadixTree<string>();
            tree.Insert("mar");
            tree.Insert("margine");
            tree.Insert("margea");
            tree.Insert("merge");
            Assert.False(tree.Search("marg"));
        }

        [Fact]
        public void AddPhoneNumbers_SearchForFirstAddedNumber()
        {
            var tree = new RadixTree<int>();
            tree.Insert(747999852);
            tree.Insert(747888952);
            tree.Insert(747999853);
            tree.Insert(747988234);
            Assert.True(tree.Search(747999852));
        }
    }
}