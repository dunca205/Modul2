using System;

namespace Soccer
{
    public class Ranking
    {
        private Team[] soccerTeams;

        public Ranking(Team[] soccerTeam)
        {
            this.soccerTeams = soccerTeam;
        }

        public void Add(Team teamToAdd)
        {
           int initialLength = soccerTeams.Length;
           Array.Resize(ref soccerTeams, initialLength + 1);
           soccerTeams[soccerTeams.Length - 1] = teamToAdd;
        }

        public void SortRanking()
        {
            for (int i = 0; i < soccerTeams.Length; i++)
            {
                for (int j = 0; j < soccerTeams.Length - 1; j++)
                {
                    if (soccerTeams[j].ComparePoints(soccerTeams[j + 1]))
                    {
                        Swap(j, j + 1);
                    }
                }
            }
        }

        public void Swap(int index1, int index2)
        {
            Team temp = soccerTeams[index1];
            soccerTeams[index1] = soccerTeams[index2];
            soccerTeams[index2] = temp;
        }

        public Team TeamAtPosition(int position)
        {
            return soccerTeams[position - 1];
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
