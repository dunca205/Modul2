using System;

namespace Soccer
{
    public class Team
    {
        private readonly string teamName;
        private readonly int teamPoints;

        public Team(string teamName, int teamPoints)
        {
            this.teamName = teamName;
            this.teamPoints = teamPoints;
        }

        public bool IsDifferentTeam(Team team)
        {
            return this.teamName != team.teamName;
        }

        public bool ComparePoints(Team that)
        {
            return this.teamPoints > that.teamPoints;
        }

        static void Main()
        {
        }
    }
}