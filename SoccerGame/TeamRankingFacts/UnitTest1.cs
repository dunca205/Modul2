namespace Soccer
{
    public class RankingFacts
    {
        [Fact]
        public void AddANewTeam_InitialRankingWillHaveOneMoreTeam()
        {
            Team[] echipe = new Team[2];
            echipe[0] = new Team(teamName:"FCSB", teamPoints:2);
            echipe[1] = new Team(teamName:"Dinamo", teamPoints:3);
            Ranking InitialRanking = new Ranking(echipe);
            Team steaua = new Team(teamName:"Steaua", teamPoints:10);
            Assert.NotEqual(echipe, InitialRanking.AddNewTeam(steaua));
        }
        [Fact]
        public void AddAnExistingTeam_InitialRankingWillBeTheSame()
        {
            Team[] teams = new Team[2];
            teams[0] = new Team(teamName:"FCSB", teamPoints:2);
            teams[1] = new Team(teamName:"Dinamo", teamPoints:3);
            Ranking InitialRanking = new Ranking(teams);
            Assert.Equal(teams, InitialRanking.AddNewTeam(teams[0]));
        }
        [Fact]
        public void ReturnDetailsForCertainPosition_ShouldReturnNameAndPoints()
        {
            int position = 1;
            Team[] teams = new Team[3];
            teams[0] = new Team(teamName:"FCSB", teamPoints:4);
            teams[1] = new Team(teamName:"Dinamo", teamPoints:3);
            teams[2] = new Team(teamName: "Rapid", teamPoints: 2);
            Ranking teamsRanking = new Ranking(teams);
            Assert.Equal(teams[0], teamsRanking.ReportDetailsForCertainPosition(1));

        }
        [Fact]
        public void ReturnDetailsForCertainTeamName_ShouldReturnPointsAndPosition()
        { 
            Team[] teams = new Team[3];
            teams[0] = new Team(teamName: "FCSB", teamPoints: 4);
            teams[1] = new Team(teamName: "Dinamo", teamPoints: 3);
            teams[2] = new Team(teamName: "Rapid", teamPoints: 2);
            Ranking teamsRanking = new Ranking(teams);
            Assert.Equal((teams[0], 1), teamsRanking.ReportDetailsForCertainTeamName("FCSB"));

        }
    }
}