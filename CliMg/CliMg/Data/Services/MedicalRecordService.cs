using CliMg.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CliMg.Data.Services
{
    public class MedicalRecordService
    {
        private readonly MedContext _context;


        public MedicalRecordService(MedContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that returns all the MedicalRecords
        /// </summary>
        /// <returns></returns>
        public async Task<List<Record>> GetAllMedicalRecordsAsync()
        {
            return await _context.MedicalRecords.ToListAsync();
        }

        /// <summary>
        /// Method that returns a MedicalRecord by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Record> GetMedicalRecordByIdAsync(int id)
        {
            return await _context.MedicalRecords.FindAsync(id);
        }


        /// <summary>
        /// Method that adds a MedicalRecord
        /// </summary>
        /// <param name="medicalRecord"></param>
        /// <returns></returns>
        public async Task<Record> AddMedicalRecordAsync(Record medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
            await _context.SaveChangesAsync();
            return medicalRecord;
        }

        /// <summary>
        /// Method that updates a MedicalRecord
        /// </summary>
        /// <param name="medicalRecord"></param>
        /// <returns></returns>
        public async Task<Record> UpdateMedicalRecordAsync(Record medicalRecord)
        {
            _context.Entry(medicalRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicalRecord;
        }

        /// <summary>
        /// Method that deletes a MedicalRecord
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteMedicalRecordByIdAsync(int id)
        {
            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            _context.MedicalRecords.Remove(medicalRecord);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method that deletes a MedicalRecord
        /// </summary>
        /// <param name="medicalRecord"></param>
        /// <returns></returns>
        public async Task DeleteMedicalRecordAsync(Record medicalRecord)
        {
            _context.MedicalRecords.Remove(medicalRecord);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method that returns all the MedicalRecords of a patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<Record>> GetMedicalRecordsByPatientIdAsync(int patientId)
        {
            return await _context.MedicalRecords.Where(mr => mr.Patient.PatientId== patientId).ToListAsync();
        }

        
        /// <summary>
        /// Method that returns all the Patients
        /// </summary>
        /// <returns></returns>
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

    }
}
