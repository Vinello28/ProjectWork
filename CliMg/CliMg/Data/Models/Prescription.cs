using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliMg.Data.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrescriptionId { get; set; }

        [Required]
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }

        [Required]
        public string Drug { get; set; }

        [Required]
        public int Dosage { get; set; }

        [Required]
        public string Frequency { get; set; }

        [Required]
        public DateTime Duration { get; set; }

        public string Notes { get; set; }
    }
}
