namespace SoccerFacts
{
    public class TeamFacts
    {
        [Fact]
        public void HasMorePoints()
        {
            var Team1 = new Soccer.Team(teamName: "CFRCJ", teamPoints: 15);
            var Team2 = new Soccer.Team(teamName: "UCluj", teamPoints: 11);
            Assert.True(Team1.ComparePoints(Team2));
        }
        [Fact]
        public void IsDifferentTeam()
        {
            var Team1 = new Soccer.Team(teamName: "CFRCJ", teamPoints: 15);
            Soccer.Team Team2 = new Soccer.Team(teamName: "UCluj", teamPoints: 11);
            Assert.True(Team1.IsDifferentTeam(Team2));
        }
    }
}