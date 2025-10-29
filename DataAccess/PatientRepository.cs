using Csharp3_A3.Data;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3.DataAccess
{
	public class PatientRepository
	{
		private readonly AppDbContext _context;

		public PatientRepository(AppDbContext context) => _context = context;

		public async Task<List<Patient>> GetAllAsync() => await _context.Patients.ToListAsync();

		public async Task<Patient?> GetByIdAsync(int id) => await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);

		public async Task AddAsync(Patient patient)
		{
			await _context.Patients.AddAsync(patient);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Patient patient)
		{
			_context.Patients.Update(patient);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAppointmentAsync(Patient patient, Appointment appointment)
		{
			patient.Appointments.Add(appointment);
			await _context.SaveChangesAsync();
		}

		public async Task<List<MedicalHistory>> GetMedicalHistoryByPatientIdAsync(int patientId)
		{
			return await _context.MedicalHistories.Where(m => m.PatientId == patientId).ToListAsync();
		}
	}
}
