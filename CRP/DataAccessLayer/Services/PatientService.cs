using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class PatientService
    {
        protected readonly ClmanagerContext _context;

        public PatientService(ClmanagerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to get all the patients from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        /// <summary>
        /// Method to get a patient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Patient?> GetPatientById(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        /// <summary>
        /// Method to get all the patients of a doctor
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public async Task<List<Patient>> GetPatientsByDoctorId(string doctorId)
        {
            //fa una join con medical records per ottenere i pazienti di un dottore
            return await _context.Patients
                .Join(_context.MedicalRecords,
                               p => p.PatientId,
                                              mr => mr.PatientId,
                                                             (p, mr) => new { p, mr })
                .Where(x => x.mr.DoctorId == doctorId)
                .Select(x => x.p)
                .ToListAsync();
        }


        /// <summary>
        /// Method to add a new patient to the database
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<Patient> AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        /// <summary>
        /// Method to update a patient in the database
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<Patient> UpdatePatient(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return patient;
        }

        /// <summary>
        /// Method to delete a patient from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Method to check if a patient exists in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }


    }
}
