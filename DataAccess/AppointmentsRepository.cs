using Csharp3_A3.Data;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3.DataAccess
{
	public class AppointmentsRepository
	{
		private readonly AppDbContext _context;

		public AppointmentsRepository(AppDbContext context) => _context = context;

		public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
		{
			return await _context.Appointments.Where(a => a.PatientId == patientId).Include(a => a.Staff).ToListAsync();
		}

		public async Task<List<Appointment>> GetAppointmentsByStaffIdAsync(int staffId)
		{
			return await _context.Appointments.Where(a => a.StaffId == staffId).Include(a => a.Patient).ToListAsync();
		}

		public async Task<Appointment?> GetAppointmentByIdAsync(int appointmentId)
		{
			return await _context.Appointments.Include(a => a.Patient).Include(a => a.Staff).FirstOrDefaultAsync(a => a.Id == appointmentId);
		}

		public async Task DeleteAppointmentByIdAsync (int id)
		{
			await _context.Appointments.Where(a => a.Id == id).ExecuteDeleteAsync();
			await _context.SaveChangesAsync();
		}

		public async Task AddAppointmentAsync(Appointment appointment)
		{
			await _context.Appointments.AddAsync(appointment);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAppointmentAsync(Appointment appointment)
		{
			_context.Appointments.Update(appointment);
			await _context.SaveChangesAsync();
		}
	}
}
