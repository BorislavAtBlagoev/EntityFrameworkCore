
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static CodeFirst.Data.DataValidations.Medicament;

namespace CodeFirst.Data.Models
{
    public class Medicament
    {
        public int MedicamentId { get; set; }
        [MaxLength(maxNamelength)]
        public string Name { get; set; }
        public ICollection<PatientMedicament> Prescriptions { get; set; } 
            = new HashSet<PatientMedicament>();
    }
}
