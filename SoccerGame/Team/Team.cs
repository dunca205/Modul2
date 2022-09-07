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

        public int TeamPoints()
        {
            return teamPoints;
        }

        public bool ComparePoints(Team that)
        {
            return this.teamPoints > that.teamPoints;
        }

        public bool HasSameName(string name)
        {
            return this.teamName == name;
        }
    }
}