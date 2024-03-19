using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer.Services
{
    public class IllnessService
    {
        private readonly ClmanagerContext _context;

        public IllnessService(ClmanagerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that returns all the illnesses in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Illness>> GetAllIllnesses()
        {
            return await _context.Illnesses.ToListAsync();
        }

        /// <summary>
        /// Method that returns an illness given its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Illness?> GetIllnessById(int id)
        {
            return await _context.Illnesses.FindAsync(id);
        }

        /// <summary>
        /// Method that returns all the illnesses of a patient given its id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<Illness>> GetIllnessesByPatientId(int patientId)
        {
            return await _context.Illnesses
                .Join(_context.MedicalRecords, i => i.IllnessId, mr => mr.IllnessId, (i, mr) => new { i, mr }).Where(x => x.mr.PatientId == patientId)
                .Select(x => x.i)
                .ToListAsync();
        }

        /// <summary>
        /// Method that returns an illness given its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Illness?> GetIllnessByName(string name)
        {
            return await _context.Illnesses.FirstOrDefaultAsync(x => x.Name == name);
        }

        /// <summary>
        /// Method that adds an illness to the database
        /// </summary>
        /// <param name="illness"></param>
        /// <returns></returns>
        public async Task AddIllness(Illness illness)
        {
            _context.Illnesses.Add(illness);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method that updates an illness in the database
        /// </summary>
        /// <param name="illness"></param>
        /// <returns></returns>
        public async Task UpdateIllness(Illness illness)
        {
            _context.Entry(illness).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method that deletes an illness from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteIllness(int id)
        {
            var illness = await _context.Illnesses.FindAsync(id);
            _context.Illnesses.Remove(illness);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method that returns all the illnesses that have a symptom given its id
        /// </summary>
        /// <param name="symptomId"></param>
        /// <returns></returns>
        public async Task<List<Illness>> GetIllnessesBySymptomId(int symptomId)
        {
            return await _context.Illnesses
                .Join(_context.IllnessSymptoms, i => i.IllnessId, isy => isy.IllnessId, (i, isy) => new { i, isy }).Where(x => x.isy.SymptomId == symptomId)
                .Select(x => x.i)
                .ToListAsync();
        }

        /// <summary>
        /// Method that returns all the illnesses that have a symptom given its name
        /// </summary>
        /// <param name="symptomIds"></param>
        /// <returns></returns>
        public async Task<List<Illness>> GetIllnessesBySymptomIds(List<int> symptomIds)
        {
            if (symptomIds.Count == 0)
            {
                return new List<Illness>();
            }
            else
            {
                return await _context.Illnesses
                    .Join(_context.IllnessSymptoms, i => i.IllnessId, isy => isy.IllnessId, (i, isy) => new { i, isy }).Where(x => symptomIds.Contains((int)x.isy.SymptomId))
                    .Select(x => x.i)
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Method that returns all the illnesses that have a symptom given its name
        /// </summary>
        /// <param name="symptomNames"></param>
        /// <returns></returns>
        public async Task<List<Illness>> GetIllnessesBySymptomNames(List<string> symptomNames)
        {
            if(symptomNames.Count == 0)
            {
                return new List<Illness>();
            }
            else
            {
                return await _context.Illnesses
                    .Join(_context.IllnessSymptoms, i => i.IllnessId, isy => isy.IllnessId, (i, isy) => new { i, isy }).Where(x => symptomNames.Contains(x.isy.Symptom.Name))
                    .Select(x => x.i)
                    .ToListAsync();
            }
        }
    }
}
