using Csharp3_A3.Data;
using Csharp3_A3.DataAccess;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3.Services
{
	public class StaffService
	{
		private readonly StaffRepository _staffRepository;

		public StaffService(StaffRepository staffRepository) => _staffRepository = staffRepository;

		public async Task<List<Staff>> GetAllAsync() => await _staffRepository.GetAllAsync();

		public async Task<Staff?> GetByIdAsync(int id) => await _staffRepository.GetByIdAsync(id);

		public async Task<List<Appointment>> GetAllAppointmentsByIdAsync(int staffId) => await _staffRepository.GetAllAppointmentsByIdAsync(staffId);

		public async Task<List<MedicalHistory>> GetRelevantMedicalHistoryByIdAsync(int staffId) => await _staffRepository.GetRelevantMedicalHistoryByIdAsync(staffId);
	}
}
