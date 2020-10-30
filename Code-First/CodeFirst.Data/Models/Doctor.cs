using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static CodeFirst.Data.DataValidations.Doctor;

namespace CodeFirst.Data.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [MaxLength(maxNameLength)]
        public string Name { get; set; }

        [MaxLength(maxSpecialtyLength)]
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; } 
            = new HashSet<Visitation>();
    }
}
