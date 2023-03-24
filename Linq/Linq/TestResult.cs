namespace Linq
{
    public class TestResult
    {
        public TestResult(string id, string familyId, int score)
        {
            this.Id = id;
            this.FamilyId = familyId;
            this.Score = score;
        }

        public string Id { get; set; }

        public string FamilyId { get; set; }

        public int Score { get; set; }

        public static IEnumerable<TestResult> GetFamilyRepresentantBasedOnScore(IEnumerable<TestResult> members)

          => members.GroupBy(family => family.FamilyId).
             Select(representant => representant.MaxBy(family => family.Score));
    }
}
