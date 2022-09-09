using Xunit;
namespace Soccer
{
    public class RankingFacts
    {

        [Fact]
        public void FindTeamAtCertainPosition()
        {
            var fcsb = new Team(teamName: "FCSB", teamPoints: 2);
            var dinamo = new Team(teamName: "Dinamo", teamPoints: 3);
            var steaua = new Team(teamName: "Steaua", teamPoints: 2);
            Ranking ranking = new Ranking();
            ranking.Add(fcsb);
            ranking.Add(dinamo);
            ranking.Add(steaua);

            Assert.Equal(fcsb, ranking.TeamAtPosition(1));
        }
        [Fact]
        public void FindPositionForCertainTeam()
        {

            var fcsb = new Team(teamName: "FCSB", teamPoints: 2);
            var dinamo = new Team(teamName: "Dinamo", teamPoints: 3);
            var steaua = new Team(teamName: "Steaua", teamPoints: 2);
            Ranking ranking = new Ranking();
            ranking.Add(fcsb);
            ranking.Add(dinamo);
            ranking.Add(steaua);


            Assert.Equal(3, ranking.PositionForCertainTeam(steaua));
        }

        [Fact]
        public void UpdateMatchScoreWhenNobodyWon()
        {
            var fcsb = new Team(teamName: "FCSB", teamPoints: 2);
            var dinamo = new Team(teamName: "Dinamo", teamPoints: 3);
            var steaua = new Team(teamName: "Steaua", teamPoints: 1);
            Ranking ranking = new Ranking();
            ranking.Add(fcsb);
            ranking.Add(dinamo);
            ranking.Add(steaua);

            Assert.Equal(2, ranking.PositionForCertainTeam(dinamo)); 

            ranking.UpdateMatchScore(fcsb, dinamo, 0, 0);

            Assert.Equal(1, ranking.PositionForCertainTeam(dinamo)); 
        }
        [Fact]
        public void UpdateMatchScoreWhenOneTeamWon()
        {
            var fcsb = new Team(teamName: "FCSB", teamPoints: 1300);
            var dinamo = new Team(teamName: "Dinamo", teamPoints: 1500);
            Ranking ranking = new Ranking();
            ranking.Add(fcsb);
            ranking.Add(dinamo);
            

            Assert.Equal(2, ranking.PositionForCertainTeam(dinamo));

            ranking.UpdateMatchScore(fcsb, dinamo, 14, 10);

            Assert.Equal(1, ranking.PositionForCertainTeam(dinamo));
        }

        [Fact]
        public void UpdateMatchWhenOneTeamLost()
        {
            var fcsb = new Team(teamName: "FCSB", teamPoints: 1300);
            var dinamo = new Team(teamName: "Dinamo", teamPoints: 1300);
            Ranking ranking = new Ranking();
            ranking.Add(fcsb); 
            ranking.Add(dinamo); 

            ranking.UpdateMatchScore(fcsb, dinamo, 1, 2);

            Assert.Equal(1 , ranking.PositionForCertainTeam(dinamo));

        }


    }
}