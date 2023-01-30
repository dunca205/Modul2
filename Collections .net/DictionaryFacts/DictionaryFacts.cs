using Xunit;
namespace Dictionary
{
    public class DictionaryFacts
    {
        [Fact]
        public void GetBucketReturnsTheReminderBasedOnSize()
        {
            var dictionar = new Dictionary<int, string>(5);
            Assert.Equal(0, dictionar.GetBucket(10));
            Assert.Equal(1, dictionar.GetBucket(1));
            Assert.Equal(2, dictionar.GetBucket(2));
            Assert.Equal(2, dictionar.GetBucket(7));
            Assert.Equal(2, dictionar.GetBucket(12));
        }

        [Fact]
        public void AddOneElementInEachBucket()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            Assert.Equal(5, dictionar.Count);
        }

        [Fact]
        public void SearchForKeyThatIsPresentInDictioanry()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            Assert.True(dictionar.ContainsKey(1));
        }

        [Fact]
        public void SearchForKeyThatIsNotPesent()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            Assert.False(dictionar.ContainsKey(4));
        }

        [Fact]
        public void FindValueForCertainKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            Assert.Equal("d", dictionar[7]);
        }

        [Fact]
        public void SetNewValueForCertainKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar[2] = "c";
            Assert.Equal("c", dictionar[2]);
        }

        [Fact]
        public void GetValueForMissingKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            Assert.Null(dictionar[3]);
        }

        [Fact]
        public void TryGetValueForExistentKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            Assert.True(dictionar.TryGetValue(2, out var value));
            Assert.Equal("b", value);
        }

        [Fact]
        public void TryGetValueForInexistentKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            Assert.False(dictionar.TryGetValue(4, out var invalid));
            Assert.Null(invalid);
        }

        [Fact]
        public void CheckNextPointer()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            Assert.Equal(-1, dictionar.Find(2).Next);
            Assert.Equal(1, dictionar.Find(7).Next);
            Assert.Equal(3, dictionar.Find(12).Next);
        }

        [Fact]
        public void AddPairsToDictionary()
        {
            var dictionar = new Dictionary<int, string>(5);
            var pair1 = new KeyValuePair<int, string>(1, "a");
            var pair2 = new KeyValuePair<int, string>(2, "b");
            var pair3 = new KeyValuePair<int, string>(10, "c");
            var pair4 = new KeyValuePair<int, string>(7, "d");
            var pair5 = new KeyValuePair<int, string>(12, "e");
            var pair6 = new KeyValuePair<int, string>(18, "f");
            dictionar.Add(pair1); dictionar.Add(pair2); dictionar.Add(pair3);
            dictionar.Add(pair4); dictionar.Add(pair5);
            Assert.True(dictionar.Contains(pair1));
            Assert.False(dictionar.Contains(pair6));
        }

        [Fact]
        public void AddPairsAndElements()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(new KeyValuePair<int, string>(10, "c"));
            dictionar.Add(new KeyValuePair<int, string>(7, "d"));
            dictionar.Add(new KeyValuePair<int, string>(12, "e"));
            Assert.Equal(5, dictionar.Count);
        }

        [Fact]
        public void GetEnumeratorForEntrys()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            var enumerator = dictionar.GetEnumerator();
            int enumeratorElements = 0;
            string values = "";
            while (enumerator.MoveNext())
            {
                enumeratorElements++;
                values += enumerator.Current.Value;
            }
            Assert.Equal(enumeratorElements, dictionar.Count);
            Assert.Equal("abcde", values);
        }

        [Fact]
        public void CopyElementsFromDictionaryToArray()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            var array = new KeyValuePair<int, string>[5];
            dictionar.CopyTo(array, 0);
            Assert.Equal("a", array[0].Value);
        }

        [Fact]
        public void RemoveTwoElementsFromDictionar_CheckFreeIndex()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a"); //0
            dictionar.Add(2, "b"); //1
            dictionar.Add(10, "c");//2
            dictionar.Add(7, "d"); //3
            dictionar.Add(12, "e");//4
            dictionar.Remove(7);
            Assert.Equal(3, dictionar.freeIndex);
            dictionar.Remove(1);
            Assert.Equal(0, dictionar.freeIndex);
        }

        [Fact]
        public void AddNewElements_IndexOfElementsIsEqualWithIndexOfRemovedElement()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a"); //0
            dictionar.Add(2, "b"); //1
            dictionar.Add(10, "c");//2
            dictionar.Add(7, "d"); //3
            dictionar.Add(12, "e");//4

            dictionar.Remove(7);//3
            dictionar.Remove(1);//0

            dictionar.Add(17, "f"); //0

            Assert.Equal(0, dictionar.Find(17).Index);
            Assert.Equal(3, dictionar.freeIndex);

            dictionar.Add(3, "g");
            Assert.Equal(3, dictionar.Find(3).Index);
            Assert.Equal(-1, dictionar.freeIndex);
        }

        [Fact]
        public void AddNewElements_WhenRemovedElementsListIsNotEmpty()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a"); //0
            dictionar.Add(2, "b"); //1
            dictionar.Add(10, "c");//2
            dictionar.Add(7, "d"); //3
            dictionar.Add(12, "e");//4
            dictionar.Remove(7);//3
            dictionar.Remove(1);//0
            dictionar.Add(17, "f"); // intra pe 0 in bucket 2 
            Assert.Equal(4, dictionar.Find(17).Next);
            dictionar.Add(3, "g"); // intra pe 3
            
        }

        [Fact]
        public void RemoveAllElementsFromAList()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            dictionar.Remove(7);
            dictionar.Remove(2);
            dictionar.Remove(12);
            Assert.Equal(2, dictionar.Count);

        }

    }
}