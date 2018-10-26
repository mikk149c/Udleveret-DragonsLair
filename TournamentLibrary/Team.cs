using System;
using System.Collections.Generic;

namespace TournamentLib
{
    public class Team : IEquatable<Team>
	{
        public string Name { get; set; }

        public Team(string teamName)
        {
            Name = teamName;
        }

        public override string ToString()
        {
            return Name;
        }

		public bool Equals(Team other)
		{
			return Name == other.Name;
		}
	}
}
