using CliMg.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CliMg.Data.Services
{
    public class AppointmentService
    {
        private readonly MedContext _context;

        public AppointmentService(MedContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to get all appointments
        /// </summary>
        /// <returns></returns>
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        /// <summary>
        /// Method to get an appointment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        /// <summary>
        /// Method to add an appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<Appointment> AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        /// <summary>
        /// Method to update an appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return appointment;
        }

        /// <summary>
        /// Method to delete an appointment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to get all appointments of a patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            return await _context.Appointments.Where(a => a.Patient.PatientId == patientId).ToListAsync();
        }

        /// <summary>
        /// Method to get all appointments in a certain date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<List<Appointment>> GetAppointmentsByDateAsync(DateTime date)
        {
            return await _context.Appointments.Where(a => a.Date == date).ToListAsync();
        }

        /// <summary>
        /// Method to get all Patients
        /// </summary>
        /// <returns></returns>
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }
        
    }
}
