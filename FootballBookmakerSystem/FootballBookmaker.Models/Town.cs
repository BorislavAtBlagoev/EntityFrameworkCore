
using System.Collections.Generic;

namespace FootballBookmaker.Models
{
    public class Town
    {
        public int TownId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Team> Teams { get; set; } 
            = new HashSet<Team>();
    }
}
