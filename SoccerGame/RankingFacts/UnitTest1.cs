namespace Soccer
{
    public class RankingFacts
    {
       
        [Fact]
        public void FindTeamAtCertainPosition()
        {
            Team[] initialTeams = new Team[3];
            initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2);
            initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);
            initialTeams[2] = new Team(teamName: "Steaua", teamPoints: 2);
            Ranking ranking = new Ranking();
            ranking.Add(initialTeams[0]);
            ranking.Add(initialTeams[1]);
            ranking.Add(initialTeams[2]);
      
            Assert.Equal(initialTeams[0], ranking.TeamAtPosition(1));
        }
        [Fact]
        public void FindPositionForCertainTeam()
        {
            Team[] initialTeams = new Team[3];
            initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2);
            initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);
            initialTeams[2] = new Team(teamName: "Steaua", teamPoints: 2);
            Ranking ranking = new Ranking();
            ranking.Add(initialTeams[0]);
            ranking.Add(initialTeams[1]);
            ranking.Add(initialTeams[2]);

            Assert.Equal(3, ranking.PositionForCertainTeam(initialTeams[2]));
        }
        
        [Fact]
        public void UpdateScore()
        {
            Team[] initialTeams = new Team[3];
            initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2);
            initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);//3
            initialTeams[2] = new Team(teamName: "Steaua", teamPoints: 1);//4
            Ranking ranking = new Ranking();
            ranking.Add(initialTeams[0]);
            ranking.Add(initialTeams[1]);
            ranking.Add(initialTeams[2]);
            ranking.UpdateMatchScore(initialTeams[1], initialTeams[2], 0,4);

            Assert.True(initialTeams[2].ComparePoints(initialTeams[1]));
        }
       
        

    }
}