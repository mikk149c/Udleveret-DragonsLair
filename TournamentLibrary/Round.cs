using System.Collections.Generic;

namespace TournamentLib
{
    public class Round
    {
        private List<Match> matches = new List<Match>();
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
			for (int i = 0; i < matches.Count; i++)
			{
				if (teamName1 == matches[i].FirstOpponent.Name || teamName1 == matches[i].SecondOpponent.Name)
				{
					if (teamName2 == matches[i].FirstOpponent.Name || teamName2 == matches[i].SecondOpponent.Name)
					{
						return matches[i];
					}
				}
			}
            return null;
        }

        public bool IsMatchesFinished()
        {
			for (int i = 0; i < matches.Count; i++)
			{
				if (matches[i].Winner == null)
				{
					return false;
				}
			}
            return true;
        }

        public List<Team> GetWinningTeams()
        {
			List<Team> temp = new List<Team>();
			for (int i = 0; i < matches.Count; i++)
			{
				temp.Add(matches[i].Winner);
			}
            return temp;
        }

        public List<Team> GetLosingTeams()
        {
			List<Team> temp = new List<Team>();
			for (int i = 0; i < matches.Count; i++)
			{
				if (matches[i].FirstOpponent != matches[i].Winner)
				{
					temp.Add(matches[i].FirstOpponent);
				}
				else if (matches[i].SecondOpponent != matches[i].Winner)
				{
					temp.Add(matches[i].FirstOpponent);
				}
			}
			return temp;
		}
    }
}
