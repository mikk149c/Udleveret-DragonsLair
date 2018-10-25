﻿using System;
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
