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
                    if (soccerTeams[j + 1].ComparePoints(soccerTeams[j]))
                    {
                        Swap(j + 1, j);
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

        public void UpdateRanking(string match) // dimano-steaua 2:0
        {
            const int numberOfTeams = 2;
            string[] split = match.Split(' ');    // "dimano-Steaua " "2:0"
            string[] names = split[0].Split('-'); // "dinamo" "Steaua"
            string[] newScore = split[1].Split(':'); // "2" "0"
            for (int j = 0; j < numberOfTeams; j++)
            {
                for (int i = 0; i < soccerTeams.Length; i++)
                {
                    if (soccerTeams[i].HasSameName(names[j])) // gasim echipa a carui scor trebuie actualizat
                    {
                        int pointsBeforeMatch = soccerTeams[i].TeamPoints(); // aflam cate puncte avea inainte echipa
                        soccerTeams[i] = new Team(teamName: names[j], teamPoints: pointsBeforeMatch + Convert.ToInt32(newScore[j])); // actualizam punctajul
                    }
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
