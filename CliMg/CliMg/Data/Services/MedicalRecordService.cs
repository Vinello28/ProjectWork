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

        //metodi CRUD per Record
        public async Task<List<Record>> GetAllMedicalRecordsAsync()
        {
            return await _context.MedicalRecords.ToListAsync();
        }
        public async Task<Record> GetMedicalRecordByIdAsync(int id)
        {
            return await _context.MedicalRecords.FindAsync(id);
        }

        public async Task<Record> AddMedicalRecordAsync(Record medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
            await _context.SaveChangesAsync();
            return medicalRecord;
        }

        public async Task<Record> UpdateMedicalRecordAsync(Record medicalRecord)
        {
            _context.Entry(medicalRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicalRecord;
        }

        public async Task DeleteMedicalRecordAsync(int id)
        {
            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            _context.MedicalRecords.Remove(medicalRecord);
            await _context.SaveChangesAsync();
        }

        //metodo che ritorna tutti i MedicalRecord di un paziente
        public async Task<List<Record>> GetMedicalRecordsByPatientIdAsync(int patientId)
        {
            return await _context.MedicalRecords.Where(mr => mr.Patient.PatientId== patientId).ToListAsync();
        }

    }
}
