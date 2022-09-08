using System;

namespace Soccer
{
    public class Team
    {
        private readonly string teamName;
        private int teamPoints;

        public Team(string teamName, int teamPoints)
        {
            this.teamName = teamName;
            this.teamPoints = teamPoints;
        }

        public bool ComparePoints(Team that)
        {
            return this.teamPoints > that.teamPoints;
        }

        public void UpdateScore(int newScore)
        {
            teamPoints += newScore;
        }
    }
}