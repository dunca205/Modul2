namespace Soccer
{
    public class RankingFacts
    {
        /* [Fact]
         public void AddOneMoreTeam()
         {
             Team[] initialTeams = new Team[2];
             initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2);
             initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);
             Ranking oldRanking = new Ranking(initialTeams);
             Team teamSteaua = new Team(teamName: "Steaua", teamPoints: 2);

             Team[] teams = new Team[3];
             teams[0] = initialTeams[0];
             teams[1] = initialTeams[1];
             teams[2] = teamSteaua;
             Ranking newRanking = new (teams);

             oldRanking.Add(teamSteaua);

             Assert.Equal(oldRanking,oldRanking);
         }*/
        [Fact]
        public void FindTeamAtCertainPosition()
        {
            Team[] initialTeams = new Team[3];
            initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2);
            initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);
            initialTeams[2] = new Team(teamName: "Steaua", teamPoints: 2);
            Ranking Ranking = new Ranking(initialTeams);
            Assert.Equal(initialTeams[0], Ranking.TeamAtPosition(1));
        }
        [Fact]
        public void FindPositionForCertainTeam()
        {
            Team[] initialTeams = new Team[3];
            initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2);
            initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);
            initialTeams[2] = new Team(teamName: "Steaua", teamPoints: 2);
            Ranking Ranking = new Ranking(initialTeams);
            Assert.Equal(3, Ranking.PositionForCertainTeam(initialTeams[2]));

        }
        /* [Fact]
         public void BubbleSortRanking()
         {
             Team[] initialTeams = new Team[3];
             initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2);
             initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);
             initialTeams[2] = new Team(teamName: "Steaua", teamPoints: 1);
             Ranking unsorted = new Ranking(initialTeams);
             unsorted.SortRanking();

             Team[] afterSort = new Team[3];
             afterSort[0] = new Team(teamName: "Dinamo", teamPoints: 3);
             afterSort[1] = new Team(teamName: "FCSB", teamPoints: 2);
             afterSort[2] = new Team(teamName: "Steaua", teamPoints: 1);
             Ranking sorted = new Ranking(afterSort);
             Assert.Equal(unsorted, sorted);
         }
        [Fact]
        public void UpdateScore()
        {
            Team[] initialTeams = new Team[3];
            initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2);
            initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);
            initialTeams[2] = new Team(teamName: "Steaua", teamPoints: 1);
            Ranking initialScore = new Ranking(initialTeams);
            Team[] afterMatch = new Team[3];
            afterMatch[0] = new Team(teamName: "Dinamo", teamPoints: 6);
            afterMatch[1] = new Team(teamName: "FCSB", teamPoints: 2);
            afterMatch[2] = new Team(teamName: "Steaua", teamPoints: 3);
            Ranking updatedRanking = new Ranking(afterMatch);
            string match = "Dinamo-Steaua 3:2";
            initialScore.UpdateRanking(match);
            Assert.Equal(updatedRanking, initialScore);
        }
        */

    }
}