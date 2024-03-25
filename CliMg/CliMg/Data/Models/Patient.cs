using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliMg.Data.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        //navprop
        public List<Record> Records { get; set; }

        public List<Appointment> Appointments { get; set; }

        public List<Prescription> Prescriptions { get; set; }


        /// <summary>
        /// Returns the age of the patient
        /// </summary>
        /// <returns></returns>
        public int Age()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

    }
}
