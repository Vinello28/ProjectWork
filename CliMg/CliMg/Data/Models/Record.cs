using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliMg.Data.Models
{
    public class Record
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }

        [Required]
        public string Diagnosis { get; set; }

        [Required]
        public string Symptoms { get; set; }

        [Required]
        public string Treatment { get; set; }

        public string Notes { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }


        
    }
}
