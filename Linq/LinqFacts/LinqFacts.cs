global using Xunit;
namespace LinqExercise
{
    public class LinqFacts
    {
        [Fact]
        public void CountVowels()
        {
            var vowels = new Linq("aeiouAEIOU");
           
            Assert.Equal(10, vowels.VowelsCount());
        }

        [Fact]
        public void CountConsonat() 
        {
            var constant = new Linq("cccbbbnnnaei");
            Assert.Equal(9, constant.ConsonatCount());
        }

        [Fact]   
        public void FindFirstNonRepetableLetter()
        {
          
        }
        
        
    }
}