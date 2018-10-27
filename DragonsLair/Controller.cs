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
			Tournament tor = tournamentRepository.GetTournament(tournamentName);
			Team[] teams = tor.GetTeams().ToArray();
			int[] scores = new int[teams.Length];

			for (int i = 0; i < tor.GetNumberOfRounds(); i++)
			{
				Round round = tor.GetRound(i);
				List<Team> winningTeams = round.GetWinningTeams();
				for (int teamI = 0; teamI < teams.Length; teamI++)
				{
					for (int winningTeamI = 0; winningTeamI < winningTeams.Count; winningTeamI++)
					{
						if (teams[teamI].Name == winningTeams[winningTeamI].Name)
						{
							scores[teamI]++;
						}
					}
				}
			}
			for (int num = scores.Max(); num >= 0; num--)
			{
				for (int i = 0; i < teams.Length; i++)
				{
					if (scores[i] == num)
					{
						Console.WriteLine($"team: {teams[i]}, Score: {scores[i]}");
					}
				}
			}

			Console.WriteLine("\n\n");
		}


		public TournamentRepo GetTournamentRepository()
		{
			return tournamentRepository;
		}


		public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
		{
			Tournament t = tournamentRepository.GetTournament(tournamentName);
			List<Team> teams = new List<Team>();
			List<Team> scrambled = new List<Team>();
			Round lastRound;
			Round newRound;
			Team oldFreeRider;
			bool isRoundFinished;
			int numberOfRounds = t.GetNumberOfRounds();

			if (numberOfRounds == 0)
			{
				lastRound = null;
				isRoundFinished = true;
			}
			else
			{
				lastRound = t.GetRound(numberOfRounds - 1);
				isRoundFinished = lastRound.IsMatchesFinished();
			}

			if (isRoundFinished)
			{
				if (lastRound == null)
				{
					teams = t.GetTeams().ToList();
				}
				else
				{
					teams = lastRound.GetWinningTeams();
					if (lastRound.FreeRider != null)
					{
						teams.Add(lastRound.FreeRider);
					}
				}

				if (teams.Count >= 2)
				{
					newRound = new Round();
					scrambled = teams.ToList();

					if (scrambled.Count % 2 != 0)
					{
						if (numberOfRounds > 0)
						{
							oldFreeRider = lastRound.FreeRider;
						}
						else
						{
							oldFreeRider = null;
						}

						int x = 0;
						Team newFreeRider;
						do
						{
							newFreeRider = scrambled[x];
							x++;
						} while (newFreeRider == oldFreeRider);

						newRound.FreeRider = newFreeRider;
						scrambled.Remove(newFreeRider);
					}

					for (int i = 0; i < scrambled.Count - 1; i += 2)
					{
						Match match = new Match();
						match.FirstOpponent = scrambled[i];
						match.SecondOpponent = scrambled[i + 1];
						newRound.AddMatch(match);
					}

					t.AddRound(newRound);

					//if (printNewMatches) ShowScore(tournamentName);
				}
				else
				{
					throw new Exception("TournamentIsFinished");
				}
			}
			else
			{
				throw new Exception("RoundNotFinished");
			}
		}


		public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
		{
			// Do not implement this method
		}
	}
}
