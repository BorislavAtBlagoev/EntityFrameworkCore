
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CodeFirst.Data.DataValidations.Patient;

namespace CodeFirst.Data.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [MaxLength(maxNameLength)]
        public string FirstName { get; set; }

        [MaxLength(maxNameLength)]
        public string LastName { get; set; }

        [MaxLength(maxAddressLength)]
        public string Address { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Email { get; set; }
        public bool HasInsurance { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; } 
            = new HashSet<PatientMedicament>();

        public ICollection<Diagnose> Diagnoses { get; set; } 
            = new HashSet<Diagnose>();

        public ICollection<Visitation> Visitations { get; set; } 
            = new HashSet<Visitation>();
    }
}
