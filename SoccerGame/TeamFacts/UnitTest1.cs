namespace Soccer
{
    public class TeamFacts
    {
        [Fact]
        public void HasMorePoints()
        {
            var Team1 = new Team(teamName: "CFRCJ", teamPoints: 15, teamPosition: 0);
            var Team2 = new Team(teamName: "UCluj", teamPoints: 11, teamPosition: 0);
            Assert.True(Team1.ComparePoints(Team2));
        }

        [Fact]
        public void IsDifferentTeam()
        {
            var Team1 = new Team(teamName: "CFRCJ", teamPoints: 15, teamPosition: 0);
            Team Team2 = new Team(teamName: "UCluj", teamPoints: 11, teamPosition: 0);
            Assert.False(Team1.IsSameTeamName(Team2));
        }
    }
}