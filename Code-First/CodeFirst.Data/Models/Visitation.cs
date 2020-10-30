
using System;
using System.ComponentModel.DataAnnotations;

using static CodeFirst.Data.DataValidations.Visitation;

namespace CodeFirst.Data.Models
{
    public class Visitation
    {
        public int VisitationId { get; set; }
        public DateTime Date { get; set; }

        [MaxLength(maxCommentLength)]
        public string Comment { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
