using Csharp3_A3.Data;
using Csharp3_A3.DataAccess;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3.Services
{
	public class PatientService
	{
		private readonly PatientRepository _patientRepository;

		public PatientService(PatientRepository patientRepository) => _patientRepository = patientRepository;

		public async Task<List<Patient>> GetAllAsync() => await _patientRepository.GetAllAsync();

		public async Task<Patient?> GetByIdAsync(int id) => await _patientRepository.GetByIdAsync(id);

		public async Task AddAsync(Patient patient) => await _patientRepository.AddAsync(patient);

		public async Task UpdateAsync(Patient patient) => await _patientRepository.UpdateAsync(patient);

		public async Task UpdateAppointmentsAsync(int patientId, Appointment appointment)
		{
			var patient = await _patientRepository.GetByIdAsync(patientId);

			if (patient == null)
			{
				throw new Exception("Patient not found");
			}

			await _patientRepository.UpdateAppointmentAsync(patient, appointment);
		}

		public async Task<List<MedicalHistory>> GetMedicalHistoryByPatientIdAsync(int patientId) => await _patientRepository.GetMedicalHistoryByPatientIdAsync(patientId);
	}
}
