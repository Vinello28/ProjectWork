using CliMg.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CliMg.Data.Services
{
    public class PatientService
    {
        private readonly MedContext _context;

        public PatientService(MedContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to get all patients
        /// </summary>
        /// <returns></returns>
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        /// <summary>
        /// Method to get a patient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        /// <summary>
        /// Method to add a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        /// <summary>
        /// Method to update a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return patient;
        }

        /// <summary>
        /// Method to delete a patient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeletePatientByIdAsync(int id)
        {
            var prescriptions = await _context.Prescriptions.Where(p => p.PatientId == id).ToListAsync();
            foreach (var prescription in prescriptions)
            {
                _context.Prescriptions.Remove(prescription);
            }
            await _context.SaveChangesAsync();

            var appointments = await _context.Appointments.Where(a => a.Patient.PatientId == id).ToListAsync();
            foreach (var appointment in appointments)
            {
                _context.Appointments.Remove(appointment);
            }
            await _context.SaveChangesAsync();

            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task DeletePatientAsync(Patient patient)
        {
            var prescriptions = await _context.Prescriptions.Where(p => p.PatientId == patient.PatientId).ToListAsync();
            foreach (var prescription in prescriptions)
            {
                _context.Prescriptions.Remove(prescription);
            }
            await _context.SaveChangesAsync();

            var appointments = await _context.Appointments.Where(a => a.Patient.PatientId == patient.PatientId).ToListAsync();
            foreach (var appointment in appointments)
            {
                _context.Appointments.Remove(appointment);
            }
            await _context.SaveChangesAsync();

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

    }
}
