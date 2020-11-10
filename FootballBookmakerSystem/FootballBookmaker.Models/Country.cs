
using System.Collections.Generic;

namespace FootballBookmaker.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public ICollection<Town> Towns { get; set; } 
            = new HashSet<Town>();
    }
}
