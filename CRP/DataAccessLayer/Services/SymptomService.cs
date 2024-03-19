using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class SymptomService
    {
        private readonly ClmanagerContext _context;

        public SymptomService(ClmanagerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to get all the symptoms from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Symptom>> GetAllSymptoms()
        {
            return await _context.Symptoms.ToListAsync();
        }

        /// <summary>
        /// Method to get a symptom by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Symptom?> GetSymptomById(int id)
        {
            return await _context.Symptoms.FindAsync(id);
        }

        /// <summary>
        /// Method to get all the symptoms of an illness
        /// </summary>
        /// <param name="illnessId"></param>
        /// <returns></returns>
        public async Task<List<Symptom>> GetSymptomsByIllnessId(int illnessId)
        {
            return await _context.Symptoms
                .Join(_context.IllnessSymptoms,
                                   s => s.SymptomId,
                                                      isy => isy.SymptomId,
                                                                         (s, isy) => new { s, isy })
                .Where(x => x.isy.IllnessId == illnessId)
                .Select(x => x.s)
                .ToListAsync();
        }   

        /// <summary>
        /// Method to add a new symptom to the database
        /// </summary>
        /// <param name="symptom"></param>
        /// <returns></returns>
        public async Task AddSymptom(Symptom symptom)
        {
            _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Method to update a symptom in the database
        /// </summary>
        /// <param name="symptom"></param>
        /// <returns></returns>
        public async Task UpdateSymptom(Symptom symptom)
        {
            _context.Symptoms.Update(symptom);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete a symptom from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSymptom(int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null) return false;
            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Method to check if a symptom exists in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SymptomExists(int id)
        {
            return _context.Symptoms.Any(e => e.SymptomId == id);
        }

        /// <summary>
        /// Method to get all the symptoms of a record
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public async Task<List<Symptom>> GetSymptomsByRecordId(int recordId)
        {
            return await _context.Symptoms
                .Join(_context.IllnessSymptoms, s => s.SymptomId, isy => isy.SymptomId, (s, isy) => new { s, isy })
                .Join(_context.MedicalRecords, x => x.isy.IllnessId, mr => mr.IllnessId, (x, mr) => new { x, mr }).Where(x => x.mr.RecordId == recordId)
                .Select(x => x.x.s)
                .ToListAsync();
        }
    }
}
