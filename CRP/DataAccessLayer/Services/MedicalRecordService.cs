using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class MedicalRecordService
    {
        private readonly ClmanagerContext _context;

        public MedicalRecordService(ClmanagerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to get all medical records
        /// </summary>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetAllMedicalRecords()
        {
            return await _context.MedicalRecords.ToListAsync();
        }

        /// <summary>
        /// Method to get a medical record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MedicalRecord> GetMedicalRecord(int id)
        {
            return await _context.MedicalRecords.FindAsync(id);
        }

        /// <summary>
        /// Method to add a medical record
        /// </summary>
        /// <param name="medicalRecord"></param>
        /// <returns></returns>
        public async Task<MedicalRecord> AddMedicalRecord(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
            await _context.SaveChangesAsync();
            return medicalRecord;
        }

        /// <summary>
        /// Method to update a medical record
        /// </summary>
        /// <param name="medicalRecord"></param>
        /// <returns></returns>
        public async Task<MedicalRecord> UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            _context.Entry(medicalRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicalRecord;
        }

        /// <summary>
        /// Method to delete a medical record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteMedicalRecord(int id)
        {
            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecord == null)
            {
                return false;
            }

            _context.MedicalRecords.Remove(medicalRecord);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Method to check if a medical record exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool MedicalRecordExists(int id)
        {
            return _context.MedicalRecords.Any(e => e.RecordId == id);
        }

        /// <summary>
        /// Method to get medical records by patient id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByPatientId(int patientId)
        {
            return await _context.MedicalRecords.Where(mr => mr.PatientId == patientId).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by doctor id
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByDoctorId(string doctorId)
        {
            return await _context.MedicalRecords.Where(mr => mr.DoctorId == doctorId).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByDate(DateTime date)
        {
            return await _context.MedicalRecords.Where(mr => mr.Date == date).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by date range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _context.MedicalRecords.Where(mr => mr.Date >= startDate && mr.Date <= endDate).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by patient id and date
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByPatientIdAndDate(int patientId, DateTime date)
        {
            return await _context.MedicalRecords.Where(mr => mr.PatientId == patientId && mr.Date == date).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by doctor id and date
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByDoctorIdAndDate(string doctorId, DateTime date)
        {
            return await _context.MedicalRecords.Where(mr => mr.DoctorId == doctorId && mr.Date == date).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by patient id and date range
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByPatientIdAndDateRange(int patientId, DateTime startDate, DateTime endDate)
        {
            return await _context.MedicalRecords.Where(mr => mr.PatientId == patientId && mr.Date >= startDate && mr.Date <= endDate).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by doctor id and date range
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByDoctorIdAndDateRange(string doctorId, DateTime startDate, DateTime endDate)
        {
            return await _context.MedicalRecords.Where(mr => mr.DoctorId == doctorId && mr.Date >= startDate && mr.Date <= endDate).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by patient id and doctor id
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByPatientIdAndDoctorId(int patientId, string doctorId)
        {
            return await _context.MedicalRecords.Where(mr => mr.PatientId == patientId && mr.DoctorId == doctorId).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by patient id and doctor id and date
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="doctorId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByPatientIdAndDoctorIdAndDate(int patientId, string doctorId, DateTime date)
        {
            return await _context.MedicalRecords.Where(mr => mr.PatientId == patientId && mr.DoctorId == doctorId && mr.Date == date).ToListAsync();
        }

        /// <summary>
        /// Method to get medical records by patient id and doctor id and date range
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="doctorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<MedicalRecord>> GetMedicalRecordsByPatientIdAndDoctorIdAndDateRange(int patientId, string doctorId, DateTime startDate, DateTime endDate)
        {
            return await _context.MedicalRecords.Where(mr => mr.PatientId == patientId && mr.DoctorId == doctorId && mr.Date >= startDate && mr.Date <= endDate).ToListAsync();
        }

        
    }
}
