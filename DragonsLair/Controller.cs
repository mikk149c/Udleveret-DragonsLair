using System;
using System.Collections.Generic;
using System.Linq;
using TournamentLib;

namespace DragonsLair
{
	public class Controller
	{
		private TournamentRepo tournamentRepository = new TournamentRepo();

		public void ShowScore(string tournamentName)
		{
			Tournament t = tournamentRepository.GetTournament(tournamentName);
			Dictionary<string, int> teams = new Dictionary<string, int>();
			List<Team> teamsFormT = t.GetTeams();
			
			for (int i = 0; i < teamsFormT.Count; i++)
			{
				teams.Add(teamsFormT[i].Name, 0);
			}
			for (int i = 0; i < t.GetNumberOfRounds(); i++)
			{
				Round r = t.GetRound(i);
				List<Team> winners = r.GetWinningTeams();
				for (int j = 0; j < winners.Count; j++)
				{
					teams[winners[j].Name]++;
				}
			}
			List < KeyValuePair<string, int> > keyValue = teams.ToList();
			keyValue = keyValue.OrderByDescending(x => x.Value).ToList();
			for (int i = 0; i < keyValue.Count; i++)
			{
				Console.WriteLine($"Name: {keyValue[i].Key}, Score: {keyValue[i].Value}");
			}
            Console.WriteLine("\n\n");
        }

	public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
	{
		// Do not implement this method
	}

	public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
	{
		// Do not implement this method
	}
}
}
