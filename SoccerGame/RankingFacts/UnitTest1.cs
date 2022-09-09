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
        public void UpdateMatchScore()
        {
            Team[] initialTeams = new Team[3];
            initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2);
            initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);//3
            initialTeams[2] = new Team(teamName: "Steaua", teamPoints: 1);//5
            Ranking ranking = new Ranking();
            ranking.Add(initialTeams[0]);
            ranking.Add(initialTeams[1]);
            ranking.Add(initialTeams[2]);

            Assert.True(initialTeams[1].ComparePoints(initialTeams[2])); // dinamo are mai multe puncte decat steaua 

            ranking.UpdateMatchScore(initialTeams[1], initialTeams[2], 0, 4);

            Assert.True(initialTeams[2].ComparePoints(initialTeams[1])); // steaua are mai multe puncte decat dinamo dupa meci
        }
        [Fact]
        public void UpdateRanking_With0MorePointsAfterMatch()
        {
            Team[] initialTeams = new Team[3];
            initialTeams[0] = new Team(teamName: "FCSB", teamPoints: 2); // dupa meci fcsb va avea tot 3 p
            initialTeams[1] = new Team(teamName: "Dinamo", teamPoints: 3);// dupa meci diano va avea tot 3 p
            initialTeams[2] = new Team(teamName: "Steaua", teamPoints: 1);
            Ranking ranking = new Ranking();
            ranking.Add(initialTeams[0]);
            ranking.Add(initialTeams[1]);
            ranking.Add(initialTeams[2]);
            ranking.UpdateMatchScore(initialTeams[0], initialTeams[1], 0, 0); // dupa update ar trebui doar resort clasamentul initialTeams

            Assert.True(initialTeams[0].ComparePoints(initialTeams[1])); // pe pozitia 1(initialTeams[0] trebuie sa fie Diamo cu 3 p, iar pozitia 2 initialTeams[1] Fcsb cu 2 p 
        }

    }
}