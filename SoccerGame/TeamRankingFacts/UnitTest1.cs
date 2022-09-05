namespace Soccer
{
    public class RankingFacts
    {
        [Fact]
        public void AddANewTeam_InitialRankingWillHaveOneMoreTeam()
        {
            Team[] echipe = new Team[2];
            echipe[0] = new Team(teamName: "S", teamPoints: 2);
            echipe[1] = new Team(teamName: "A", teamPoints: 3);
            Ranking teams = new Ranking(echipe);
            Team steaua = new Team(teamName: "Steaua", teamPoints: 10);
            Assert.NotEqual(echipe, teams.AddNewTeam(steaua));

        }
        [Fact]
        public void AddAnExistingTeam_InitialRankingWillBeTheSame()
        {
            Team[] echipe = new Team[2];
            echipe[0] = new Team(teamName: "S", teamPoints: 2);
            echipe[1] = new Team(teamName: "A", teamPoints: 3);
            Ranking teams = new Ranking(echipe);
            Assert.Equal(echipe, teams.AddNewTeam(echipe[0]));

        }
    }
}