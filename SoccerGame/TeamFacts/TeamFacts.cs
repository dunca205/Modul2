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
        public void CheckPointsAfterMatchWin()
        {
            var cfrCluj = new Team(teamName: "CFRCJ", teamPoints: 15);
            var uCluj = new Team(teamName: "UCluj", teamPoints: 15);
            cfrCluj.AddWin();
            Assert.True(cfrCluj.ComparePoints(uCluj));
        }
        [Fact]
        public void CheckPointsAfterMatchLoss()
        {
            var cfrCluj = new Team(teamName: "CFRCJ", teamPoints: 15);
            var uCluj = new Team(teamName: "UCluj", teamPoints: 15);
            cfrCluj.TakePoints();
            Assert.True(uCluj.ComparePoints(cfrCluj));
        }

    }
}