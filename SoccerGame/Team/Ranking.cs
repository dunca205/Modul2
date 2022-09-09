using System;

namespace Soccer
{
    public class Ranking
    {
        private Team[] soccerTeams;

        public Ranking()
        {
            soccerTeams = new Team[0];
        }

        public void Add(Team teamToAdd)
        {
            Array.Resize(ref soccerTeams, soccerTeams.Length + 1);
            soccerTeams[^1] = teamToAdd;
        }

        public Team TeamAtPosition(int position)
        {
            return soccerTeams[position - 1];
        }

        public void UpdateMatchScore(Team teamHome, Team teamAway, int newScoreTeamHome, int newScoreTeamAway)
        {
            for (int i = 0; i < soccerTeams.Length; i++)
            {
                if (soccerTeams[i].Equals(teamHome))
                {
                    DecideScore(PositionForCertainTeam(soccerTeams[i]) - 1, newScoreTeamHome, newScoreTeamAway);
                }
                else if (soccerTeams[i].Equals(teamAway))
                {
                    DecideScore(PositionForCertainTeam(soccerTeams[i]) - 1, newScoreTeamAway, newScoreTeamHome);
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

        private static void Main()
        {
        }

        private void DecideScore(int position, int newScore1, int newScore2)
        {
            if (newScore1 > newScore2)
            {
                soccerTeams[position].AddWin();
            }

            if (newScore1 == newScore2)
            {
                soccerTeams[position].AddDraw();
            }
            else
            {
                soccerTeams[position].TakePoints();
            }
        }

        private void Swap(int positionWithLessPoints, int positionWithMorePoints)
        {
            Team temp = soccerTeams[positionWithLessPoints];
            soccerTeams[positionWithLessPoints] = soccerTeams[positionWithMorePoints];
            soccerTeams[positionWithMorePoints] = temp;
        }

        private void SortRanking()
        {
            bool swaped = true;
            for (int i = 0; i < soccerTeams.Length - 1 && swaped; i++)
            {
                    swaped = false;
                    for (int j = i; j < soccerTeams.Length - 1; j++)
                    {
                        if (soccerTeams[j + 1].ComparePoints(soccerTeams[j]))
                        {
                            Swap(j + 1, j);
                            swaped = true;
                        }
                    }
            }
        }
    }
}
