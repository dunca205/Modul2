global using Xunit;

namespace Radix
{
    public class RadixTreeFacts
    {
        [Fact]
        public void CompareNodesString()
        {
    
            //var nodeMargine = new RadixNode<string>("margine");
            //var secondNodeMar = new RadixNode<string>("mar");
            //Assert.Equal(-1, nodeMar.CompareTo(nodeMargine)); // nodul mar nu incepe cu margine
            //Assert.Equal(1, nodeMargine.CompareTo(nodeMar));  // nodul margine incepe cu mar
            //Assert.Equal(0, nodeMar.CompareTo(secondNodeMar)); // mar = mar
            //Assert.Equal(1, new RadixNode<string>("ola").CompareTo(nodeMar));
        }

        //[Fact]
        //public void CompareNodesInt()
        //{
        //    var OneOneTwo = new RadixNode<int>(112);
        //    var OneOneTwoThreee = new RadixNode<int>(1123);
        //    var secondOneOneTwo = new RadixNode<int>(112);

        //    Assert.Equal(-1, OneOneTwo.CompareTo(OneOneTwoThreee)); // 112 < 1123
        //    Assert.Equal(1, OneOneTwoThreee.CompareTo(OneOneTwo)); // 1123 > 112
        //    Assert.Equal(0, OneOneTwo.CompareTo(secondOneOneTwo)); // 11

        //    var largerValue = new RadixNode<int>(21123);
        //    Assert.Equal(1, largerValue.CompareTo(OneOneTwoThreee));
        //    // daca  am : Node a = 112;

        //    // 1. adaug   Node b = 1123 => b > a => 1;
        //    //   daca rezultatul de la compare e 1 .. eu as incerca sa caut in urmatorul nod..
        //    //   daca nodul a are copii care incep cu 3 daca nu sa il inser pe 3 la nodul a

        //    // 2. daca    Node c = 221123 => c > a => 1 trateaza la fel ..
        //    // ..... 


        //}

        //[Fact]
        //public void NewNodeIsPrefixOfExistingNode()
        //{
        //    //var one = new RadixNode<int>(1);
        //    var str = new RadixNode<string>("one");
        //    var treeStr = new RadixTree<string>();
        //    treeStr.Insert("ana");
        //    ArrayList myAL = new ArrayList(); myAL.Add('m');
        //    myAL.Add('a');
        //    myAL.Add('r');

        //}

        //[Fact]
        //public void AddNodesWithSameRadicalNoNeedToSplit()
        //{
        // var tree = new RadixTree<string>();
        // tree.Insert("cristina");{ c , r , i , s , t , i , n , a }
        //  tree.Insert("mar");      { m , a , r }
        //    tree.Insert("margine");  { m , a , r , g , i , n , e }
        //    tree.Insert("maria");    { m , a , r , i , a }
        //    tree.Insert("mariana") ; { m , a , r , i , a , n , a }
        //    tree.Insert("marianara");{ m , a , r , i , a , n , a , r , a }
        //    tree.Insert("mere");     { m , e , r , e }
        //    Assert.True(tree.Search("maria"));
        //}

        //[Fact]
        //public void AddNodeWithCommonRadicalandSearchTheLongest()
        //{
        //    var tree = new RadixTree<string>();
        //    tree.Insert("mar");
        //    tree.Insert("margine");
        //    tree.Insert("margea");
        //    tree.Insert("merge");
        //    tree.Insert("minune");
        //    tree.Insert("maria");
        //    tree.Insert("mariana");
        //    tree.Insert("marianara");
        //    tree.Insert("munte");
        //    tree.Insert("miracol");
        //    //Assert.True(tree.Search("marianara"));
        //}

        //[Fact]
        //public void SearchForExistingValue_WhitchIsNotMarkedAsWord()
        //{
        //    var tree = new RadixTree<string>();
        //    tree.Insert("mar");
        //    tree.Insert("margine");
        //    tree.Insert("margea");
        //    tree.Insert("merge");
        //    //Assert.False(tree.Search("marg"));
        //}

        ////[Fact]
        ////public void AddPhoneNumbers_SearchForFirstAddedNumber()
        ////{
        ////    var tree = new RadixTree<int>();
        ////    tree.Insert(747999852);
        ////    tree.Insert(747888952);
        ////    tree.Insert(747999853);
        ////    tree.Insert(747988234);
        ////    //Assert.True(tree.Search(747999852));
        ////}

        //[Fact]
        //public void RemoveNodeWithNoChildren()
        //{
        //    var tree = new RadixTree<string>();
        //    tree.Insert("mar");
        //    tree.Insert("margine");
        //    tree.Insert("maria");
        //    tree.Insert("mariana");
        //    //tree.Delete("mariana");
        //    //Assert.False(tree.Search("mariana"));
        //}

        //[Fact]
        //public void RemoveNodeWithOnechild()
        //{
        //    var tree = new RadixTree<string>();
        //    tree.Insert("mar");
        //    tree.Insert("margine");
        //    tree.Insert("maria");
        //    tree.Insert("mariana");
        //    //tree.Delete("maria");
        //    //Assert.False(tree.Search("maria"));
        //    //Assert.True(tree.Search("mariana"));
        //}

        //[Fact]
        //public void RemoveNodeFromParentWith2kids()
        //{
        //    var tree = new RadixTree<string>();
        //    tree.Insert("mar");
        //    tree.Insert("margine");
        //    tree.Insert("margea");
        //    //tree.Delete("margea");
        //    //Assert.False(tree.Search("margea"));
        //}
    }
}