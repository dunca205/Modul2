using Xunit;
namespace Soccer
{
    public class TeamFacts
    {
        [Fact]
        public void HasMorePoints()
        {
            var cfrCluj = new Team(teamName: "CFRCJ", teamPoints: 15);
            var uCluj = new Team(teamName: "UCluj", teamPoints: 11);
            Assert.True(cfrCluj.ComparePoints(uCluj));
        }
        [Fact]
        public void UpddateScoreForOneTeam()
        {
            var cfrCluj = new Team(teamName: "CFRCJ", teamPoints: 15);
            var uCluj = new Team(teamName: "UCluj", teamPoints: 14);
            cfrCluj.UpdateScore(uCluj, 1, 0);
            
            Assert.False(cfrCluj.ComparePoints(uCluj));

        }
    }
}