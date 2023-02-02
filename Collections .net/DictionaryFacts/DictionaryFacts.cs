using SonarAnalyzer.Rules.CSharp;
using Xunit;
namespace Dictionary
{
    public class DictionaryFacts
    {
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
        public void SetValueForInexistentKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar[12] = "f";
            Assert.True(dictionar.ContainsKey(12));
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
            Assert.False(dictionar.TryGetValue(4, out string value));
        }

        [Fact]
        public void AddPairsToDictionary()
        {
            var dictionar = new Dictionary<int, string>(5);
            var pair1 = new KeyValuePair<int, string>(1, "a");
            var pair5 = new KeyValuePair<int, string>(12, "e");
            var pair6 = new KeyValuePair<int, string>(18, "f");

            var sameKeyDifferetValue = new KeyValuePair<int, string>(12, "s");


            dictionar.Add(pair1);
            dictionar.Add(pair5);

            Assert.True(dictionar.ContainsKey(12));
            Assert.False(dictionar.Contains(sameKeyDifferetValue));

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
            Assert.Equal("caedb", values);
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
            Assert.Equal("c", array[0].Value);
        }

        [Fact]
        public void RemoveAllElementsFromABucket()
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
            Assert.False(dictionar.Keys.Contains(7));
            Assert.False(dictionar.Keys.Contains(2));
            Assert.False(dictionar.Keys.Contains(12));
            Assert.Equal(2, dictionar.Count);
        }

        [Fact]
        public void CheckEnumeratorAfterRemoving()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");//0 -> bucket 1
            dictionar.Add(2, "b");//1 -> bucket 2 -> remove
            dictionar.Add(10, "c");//2 -> bucket 0
            dictionar.Add(7, "d");//3 -> bucket2 -> remove
            dictionar.Add(12, "e");//4 -> bucket 2 -> remove
            dictionar.Remove(7);
            dictionar.Remove(2);
            dictionar.Remove(12);
            var enumerator = dictionar.GetEnumerator();
            int count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }
            Assert.Equal(2, count);

        }
        [Fact]
        public void ClearList()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            dictionar.Clear();
            Assert.False(dictionar.ContainsKey(1));
            Assert.False(dictionar.Values.Contains("a"));

        }
        [Fact]
        public void ArgumentNullException_AddingElementWithNullKey()
        {
            var dictionar = new Dictionary<string, string>(5);
            Assert.Throws<ArgumentNullException>(() => dictionar.Add(key: null, value: "a"));
        }
        [Fact]
        public void ArgumentException_AddingElementWithExistingKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");

            Assert.Throws<ArgumentException>(() => dictionar.Add(key: 1, value: "c"));
        }
        [Fact]
        public void NotSuportedException_AddingWhenDictionaryIsFull()
        {
            var dictionar = new Dictionary<int, string>(3);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            Assert.Throws<InvalidOperationException>(() => dictionar.Add(key: 3, value: "c"));

        }

        [Fact]
        public void ArgumentNullException_CheckingIfDictionarContainsNullKey()
        {
            var dictionar = new Dictionary<string, string>(5);
            dictionar.Add("b", "a");
            Assert.Throws<ArgumentNullException>(() => dictionar.ContainsKey(key: default));
        }

        [Fact]
        public void ArgumentOutOfRangeException_WhenIndexIsLessThanZero()
        {
            var dictionar = new Dictionary<int, string>(5);
            var array = new KeyValuePair<int, string>[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => dictionar.CopyTo(array, -1));
        }

        [Fact]
        public void ArgumentException_WhenArraySizeIsLessThanTheNumberOfElements()
        {
            var dictionar = new Dictionary<int, string>(6);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            var array = new KeyValuePair<int, string>[5];
            Assert.Throws<ArgumentException>(() => dictionar.CopyTo(array, 2));
        }

        [Fact]
        public void RemoveNonExistentKey()
        {
            var dictionar = new Dictionary<int, string>(6);
            dictionar.Add(1, "a");
            Assert.False( dictionar.Remove(2));
        }

        [Fact]
        public void InvalidOperationException_WhenRemovingAnNulltKey()
        {
            var dictionar = new Dictionary<string, string>(6);
            dictionar.Add("1", "a");
            Assert.Throws<ArgumentNullException>(() => dictionar.Remove(null));
        }
        [Fact]
        public void TryGetValueForNullKey()
        {
            var dictionar = new Dictionary<string, string>(3);
            Assert.Throws<ArgumentNullException>(() => dictionar.TryGetValue(null, out string value));
        }

        [Fact]
        public void GetValueForNullAndInexistentKey()
        {
            var dictionar = new Dictionary<string, string>(3);
            Assert.Throws<ArgumentNullException>(() => dictionar[null]);
            Assert.Throws<KeyNotFoundException>(() => dictionar["a"]);
        }
        [Fact]
        public void SetValueForNullKey()
        {
            var dictionar = new Dictionary<string, string>(3);
            Assert.Throws<ArgumentNullException>(() => dictionar[null] = "a");
        }
    }
}