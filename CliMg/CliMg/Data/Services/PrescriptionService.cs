using CliMg.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CliMg.Data.Services
{
    public class PrescriptionService
    {
        private readonly MedContext _context;

        public PrescriptionService(MedContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that returns all the patients
        /// </summary>
        /// <returns></returns>
        public async Task<List<Patient>> GetPatientListAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        /// <summary>
        /// Method that returns all the prescriptions
        /// </summary>
        /// <returns></returns>
        public async Task<List<Prescription>> GetAllPrescriptionsAsync()
        {
            return await _context.Prescriptions.ToListAsync();
        }

        /// <summary>
        /// Method that returns a prescription by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _context.Prescriptions.FindAsync(id);
        }

        /// <summary>
        /// Method that adds a prescription
        /// </summary>
        /// <param name="prescription"></param>
        /// <returns></returns>
        public async Task<Prescription> AddPrescriptionAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }

        /// <summary>
        /// Method that updates a prescription
        /// </summary>
        /// <param name="prescription"></param>
        /// <returns></returns>
        public async Task<Prescription> UpdatePrescriptionAsync(Prescription prescription)
        {
            _context.Entry(prescription).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return prescription;
        }

        /// <summary>
        /// Method that deletes a prescription by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeletePrescriptionByIdAsync(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method that deletes a prescription
        /// </summary>
        /// <param name="prescription"></param>
        /// <returns></returns>
        public async Task DeletePrescriptionAsync(Prescription prescription)
        {
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method that returns all the Prescriptions of a patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<Prescription>> GetPrescriptionsByPatientIdAsync(int patientId)
        {
            return await _context.Prescriptions.Where(p => p.PatientId == patientId).ToListAsync();
        }
    }
}
