using System;

namespace Soccer
{
    public class Ranking
    {
        private Team[] soccerTeams;

        public Ranking()
        {
            soccerTeams = new Team[0];
        }

        private void Swap(Team lessPoints, Team morePoints)
        {
            int positionForLessPointsTeam = PositionForCertainTeam(lessPoints); // pozitia echipei cu mai putine puncte
            int positionForMorePointsTeam = PositionForCertainTeam(morePoints); // pozitia echipei cu mai multe puncte
            Team temp = soccerTeams[positionForLessPointsTeam - 1]; // temp primeste val echipei cu mai putine puncte
            soccerTeams[positionForLessPointsTeam - 1] = morePoints; // pe pozitia echipei cu mai putine puncte punem echipa cu mai multe puncte(Team lessPoints devine Team MorePoints)
            soccerTeams[positionForMorePointsTeam - 1] = temp; // pe pozitia pe care se afla echipa cu mai multe puncte punem echipa cu mai putine puncte
        }

        private void SortRanking()
        {
            for (int i = 0; i < soccerTeams.Length - 1; i++)
            {
                for (int j = 0; j < soccerTeams.Length - 1; j++)
                {
                    if (soccerTeams[j + 1].ComparePoints(soccerTeams[j]))
                    {
                        Swap(soccerTeams[j + 1], soccerTeams[j]);
                    }
                }
            }
        }

        public void Add(Team teamToAdd)
#pragma warning restore SA1202 // Elements should be ordered by access
        {
           int initialLength = soccerTeams.Length;
           Array.Resize(ref soccerTeams, initialLength + 1);
           soccerTeams[soccerTeams.Length - 1] = teamToAdd;
        }

        public Team TeamAtPosition(int position)
        {
            return soccerTeams[position - 1];
        }

        public void UpdateMatchScore(Team team1, Team team2, int newScoreTeam1, int newScoreTeam2)
        {
            for (int i = 0; i < soccerTeams.Length; i++)
            {
                if (soccerTeams[i].Equals(team1))
                {
                    soccerTeams[i].UpdateScore(newScoreTeam1);
                }
                else if (soccerTeams[i].Equals(team2))
                {
                    soccerTeams[i].UpdateScore(newScoreTeam2);
                }
            }

            SortRanking();
        }

        public int PositionForCertainTeam(Team team)
        {
            for (int i = 0; i < soccerTeams.Length; i++)
            {
                if (team.Equals(soccerTeams[i]))
                {
                    return i + 1;
                }
            }

            return -1;
        }

        static void Main()
        {
        }
    }
}
