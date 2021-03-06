﻿using System;
using System.Collections.Generic;

namespace DragonsLair
{
    public class Menu
    {
        private Controller control = new Controller();
        
        public void Show()
        {
            bool running = true;
            do
            {
                ShowMenu();
                string choice = GetUserChoice();
                switch (choice)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        ShowScore();
                        break;
                    case "2":
                        ScheduleNewRound();
                        break;
                    case "3":
                        SaveMatch();
                        break;
					case "4":
						RegistreTeam();
						break;
					case "5":
						showTeams();
						break;
					case "6":
						showUnplayedMatches();
						break;
					default:
                        Console.WriteLine("Ugyldigt valg.");
                        Console.ReadLine();
                        break;
                }
            } while (running);
        }

		private void ShowMenu()
        {
            Console.WriteLine("Dragons Lair");
            Console.WriteLine();
            Console.WriteLine("1. Præsenter turneringsstilling");
            Console.WriteLine("2. Planlæg runde i turnering");
            Console.WriteLine("3. Registrér afviklet kamp");
			Console.WriteLine("4. Registrér hold");
			Console.WriteLine("5. Vis hold");
			Console.WriteLine("6. Vis uafiklet kampe");
			Console.WriteLine("");
            Console.WriteLine("0. Exit");
        }

        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }
        
        private void ShowScore()
        {
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Clear();
            control.ShowScore(tournamentName);
        }

        private void ScheduleNewRound()
        {
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Clear();
            control.ScheduleNewRound(tournamentName);
        }

        private void SaveMatch()
        {
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Write("Angiv vinderhold: ");
            string winner = Console.ReadLine();
            Console.Clear();
            control.SaveMatch(tournamentName, winner);
		}

		private void RegistreTeam()
		{
			Console.Write("Angiv navn på turnering: ");
			string tournamentName = Console.ReadLine();
			Console.WriteLine("Angive navnde på de hold der ønskes registreret, slut med en tom linje: ");
			string team;
			List<string> teams = new List<string>();
			while ((team = Console.ReadLine()).Length != 0)
				teams.Add(team);
			Console.Clear();
			control.AddTeams(tournamentName, teams);
		}

		private void showTeams()
		{
			Console.Write("Angiv navn på turnering: ");
			string tournamentName = Console.ReadLine();
			control.ShowTeams(tournamentName);
		}

		private void showUnplayedMatches()
		{
			Console.Write("Angiv navn på turnering: ");
			string tournamentName = Console.ReadLine();
			control.ShowUnplayedMatches(tournamentName);
		}
	}
}