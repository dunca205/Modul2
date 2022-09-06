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

        public Team TeamAtPosition(Team position)
        {
            Team team = new Team(teamName: "", teamPoints: 0, teamPosition: 0);
            for (int i = 0; i < soccerTeams.Length - 1; i++)
            {
                if (position.IsSamePosition(soccerTeams[i]))
                {
                    team = soccerTeams[i];
                }
            }

            return team;
        }

        public int TeamAtName(Team teamToFind)
        {
            int indexPosition = 0;

            for (int i = 0; i < soccerTeams.Length; i++)
            {
                if (!soccerTeams[i].IsSameTeamName(teamToFind))
                {
                    teamToFind = soccerTeams[i];
                    indexPosition = i + 1;
                }
            }

            return indexPosition;
        }

        static void Main()
        {
        }
    }
}
