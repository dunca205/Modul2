namespace Soccer
{
    public class RankingFacts
    {
        [Fact]
        public void AddOneMoreTeam()
        {
            Team[] initialTeams = new Team[2];
            initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2, teamPosition:0);
            initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3, teamPosition: 0);
            Ranking oldRanking = new Ranking(initialTeams);
            Team teamSteaua = new Team(teamName: "Steaua", teamPoints: 2, teamPosition: 0);
     
            Team[] teams = new Team[3];
            teams[0] = initialTeams[0];
            teams[1] = initialTeams[1];
            teams[2] = teamSteaua;
            Ranking newRanking = new (teams);

            oldRanking.Add(teamSteaua);

            Assert.NotEqual(oldRanking, newRanking);


        }
    }
}