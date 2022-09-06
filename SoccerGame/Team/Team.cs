using System;

namespace Soccer
{
    public class Team
    {
        private readonly string teamName;
        private readonly int teamPoints;
        private readonly int teamPosition;

        public Team(string teamName, int teamPoints, int teamPosition)
        {
            this.teamName = teamName;
            this.teamPoints = teamPoints;
            this.teamPosition = teamPosition;
        }

        public bool IsSameTeamName(Team that)
        {
            return this.teamName == that.teamName;
        }

        public bool ComparePoints(Team that)
        {
            return this.teamPoints > that.teamPoints;
        }

        public bool IsSamePosition(Team that)
        {
            return this.teamPosition == that.teamPosition;
        }
    }
}