using System;

namespace Soccer
{
    public class Team
    {
        private readonly string teamName;
        private double teamPoints;

        public Team(string teamName, int teamPoints)
        {
            this.teamName = teamName;
            this.teamPoints = teamPoints;
        }

        public bool ComparePoints(Team that)
        {
            return this.teamPoints > that.teamPoints;
        }

        public void AddWin()
        {
            const int winPoints = 3;
            this.teamPoints += winPoints;
        }

        public void AddDraw()
        {
            const int drawPoints = 1;
            this.teamPoints += drawPoints;
        }
    }
}