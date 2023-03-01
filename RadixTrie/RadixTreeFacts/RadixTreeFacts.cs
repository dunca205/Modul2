global using Xunit;
namespace Radix
{
    public class RadixTreeFacts
    {
        [Fact]
        public void CompareNodesString()
        {
            var nodeMar = new RadixNode<string>("mar");
            var nodeMargine = new RadixNode<string>("margine");
            var secondNodeMar = new RadixNode<string>("mar");
            Assert.Equal(-1, nodeMar.CompareTo(nodeMargine)); // nodul mar nu incepe cu margine
            Assert.Equal(1, nodeMargine.CompareTo(nodeMar));  // nodul margine incepe cu mar
            Assert.Equal(0, nodeMar.CompareTo(secondNodeMar)); // mar = mar
            Assert.Equal(-1, new RadixNode<string>("ola").CompareTo(nodeMar));
        }

        [Fact]
        public void CompareNodesInt()
        {
            var OneOneTwo = new RadixNode<int>(112);
            var OneOneTwoThreee = new RadixNode<int>(1123);
            var secondOneOneTwo = new RadixNode<int>(112);

            Assert.Equal(-1, OneOneTwo.CompareTo(OneOneTwoThreee));
            Assert.Equal(1, OneOneTwoThreee.CompareTo(OneOneTwo));
            Assert.Equal(0, OneOneTwo.CompareTo(secondOneOneTwo));

            var largerValue = new RadixNode<int>(21123);
            Assert.Equal(-1, largerValue.CompareTo(OneOneTwoThreee));

        }

        [Fact]
        public void NewNodeIsPrefixOfExistingNode()
        {
            var tree = new RadixTree<string>();
            tree.Insert("margine");
            tree.Insert("marginea");
            tree.Insert("mar");
        }

        [Fact]
        public void AddNodesWithSameRadicalNoNeedToSplit()
        {
            var tree = new RadixTree<string>();
            tree.Insert("mar");
            tree.Insert("cristina");
            tree.Insert("margine");
            tree.Insert("maria");
            tree.Insert("mariana");
            tree.Insert("marianara");
            tree.Insert("mere");
            //Assert.True(tree.Search("maria"));
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
            //Assert.True(tree.Search("marianara"));
        }

        [Fact]
        public void SearchForExistingValue_WhitchIsNotMarkedAsWord()
        {
            var tree = new RadixTree<string>();
            tree.Insert("mar");
            tree.Insert("margine");
            tree.Insert("margea");
            tree.Insert("merge");
            //Assert.False(tree.Search("marg"));
        }

        //[Fact]
        //public void AddPhoneNumbers_SearchForFirstAddedNumber()
        //{
        //    var tree = new RadixTree<int>();
        //    tree.Insert(747999852);
        //    tree.Insert(747888952);
        //    tree.Insert(747999853);
        //    tree.Insert(747988234);
        //    //Assert.True(tree.Search(747999852));
        //}

        [Fact]
        public void RemoveNodeWithNoChildren()
        {
            var tree = new RadixTree<string>();
            tree.Insert("mar");
            tree.Insert("margine");
            tree.Insert("maria");
            tree.Insert("mariana");
            //tree.Delete("mariana");
            //Assert.False(tree.Search("mariana"));
        }

        [Fact]
        public void RemoveNodeWithOnechild()
        {
            var tree = new RadixTree<string>();
            tree.Insert("mar");
            tree.Insert("margine");
            tree.Insert("maria");
            tree.Insert("mariana");
            //tree.Delete("maria");
            //Assert.False(tree.Search("maria"));
            //Assert.True(tree.Search("mariana"));
        }

        [Fact]
        public void RemoveNodeFromParentWith2kids()
        {
            var tree = new RadixTree<string>();
            tree.Insert("mar");
            tree.Insert("margine");
            tree.Insert("margea");
            //tree.Delete("margea");
            //Assert.False(tree.Search("margea"));
        }
    }
}