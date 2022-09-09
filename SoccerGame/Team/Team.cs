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

        public void UpdateScore(Team concurentTeam, int teamAwayNewPoints, int newpoints)
        {
            const int winPoints = 3;
            const int equalityPoints = 1;
            if (newpoints == teamAwayNewPoints && newpoints == 1)
            {
                this.teamPoints += equalityPoints;
            }
            else if
            (newpoints > teamAwayNewPoints)
            {
                this.teamPoints += winPoints;
            }
            else if (teamAwayNewPoints > newpoints)
            {
                this.teamPoints -= winPoints;
            }
        }
    }
}