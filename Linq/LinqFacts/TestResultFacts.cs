using Linq;

namespace LinqFacts
{
    public class TestResultFacts
    {
        [Fact]
        public void FindMemberWithHighestScoreToRepresentEachFamilyID()
        {
            var cristina = new TestResult("Cristina", "Dunca", 111);
            var alex = new TestResult("Alex", "Pop", 100);
            var andrei = new TestResult("Andrei", "Muresan", 10);

            var familiesMembers = new[] {
                new TestResult("Alexandra", "Dunca", 100),
                cristina,
                new TestResult("Anca", "Pop", 10),
                alex,
                new TestResult("Ionela", "Dunca", 10),
               andrei
            };
            var expected = new[] { cristina, alex, andrei };


         Assert.Equal(expected,  TestResult.GetFamilyRepresentantBasedOnScore(familiesMembers));
        }
    }
}
