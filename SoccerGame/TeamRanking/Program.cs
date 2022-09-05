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
                if (!this.SoccerTeams[i].IsDifferentTeam(teamToAdd))
                {
                    isDifferentTeam = false;
                }
            }

            if (isDifferentTeam)
            {
                int initialLength = SoccerTeams.Length;
                Array.Resize(ref SoccerTeams, initialLength + 1);
                this.SoccerTeams[SoccerTeams.Length - 1] = teamToAdd;
            }

            return this.SoccerTeams;

        }
        static void Main()
        {
        }
    }
}