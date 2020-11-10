
using System.Collections.Generic;

namespace FootballBookmaker.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
        public ICollection<Team> PrimaryKitTeams { get; set; } 
            = new HashSet<Team>();
        public ICollection<Team> SecondaryKitTeams { get; set; } 
            = new HashSet<Team>();
    }
}
