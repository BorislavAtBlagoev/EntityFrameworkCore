
using System.ComponentModel.DataAnnotations;

using static CodeFirst.Data.DataValidations.Diagnose;

namespace CodeFirst.Data.Models
{
    public class Diagnose
    {
        public int DiagnoseId { get; set; }

        [MaxLength(maxNameLength)]
        public string Name { get; set; }

        [MaxLength(maxCommentLength)]
        public string Comments { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
