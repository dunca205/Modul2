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
            int indexOfFirstTeam = PositionForCertainTeam(lessPoints);
            int indexOfSecondTeam = PositionForCertainTeam(morePoints);
            Team temp = soccerTeams[indexOfFirstTeam - 1];
            soccerTeams[indexOfFirstTeam - 1] = lessPoints;
            soccerTeams[indexOfSecondTeam - 1] = temp;
        }

        public void Add(Team teamToAdd)
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
