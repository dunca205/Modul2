namespace Soccer
{
    public class Ranking
    {
        private Team[] SoccerTeams;

        public Ranking(Team[] SoccerTeam)
        {
            this.SoccerTeams = SoccerTeam;

        }

        public Team[] AddNewTeam(Team teamToAdd)
        {
            bool isDifferentTeam = true;
            for (int i = 0; i < SoccerTeams.Length; i++)
            {
                if (!SoccerTeams[i].IsDifferentTeamName(teamToAdd))
                {
                    isDifferentTeam = false;
                }
            }

            if (isDifferentTeam)
            {
                int initialLength = SoccerTeams.Length;
                Array.Resize(ref SoccerTeams, initialLength + 1);
                SoccerTeams[SoccerTeams.Length - 1] = teamToAdd;
            }

            return SoccerTeams;

        }
        public Team ReportDetailsForCertainPosition(int position)
        {
            Team team = new Team(teamName:"", teamPoints: 0);
            for (int i = 0; i < SoccerTeams.Length - 1; i++)
            {
                if (position == i + 1)
                {
                    team = SoccerTeams[i];
                }
            }

            return team;
        }
        public (Team,int) ReportDetailsForCertainTeamName(string teamName)
        {
            Team TeamToFind = new Team(teamName: teamName, teamPoints: 0);
            int indexPosition = 0;

            for (int i = 0; i < SoccerTeams.Length; i++)
            {
                if (!SoccerTeams[i].IsDifferentTeamName(TeamToFind))
                {
                    TeamToFind = SoccerTeams[i];
                    indexPosition = i + 1;
                }
                
            }

            return (TeamToFind, indexPosition);
           
        }

        static void Main()
        {
        }
    }
}