using Csharp3_A3.Data;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3.DataAccess
{
	public class UserRepository
	{
		private readonly AppDbContext _context;

		public UserRepository(AppDbContext context) => _context = context;

		public async Task<Staff?> GetStaffByUserAsync(User user)
		{
			return await _context.Staff.FirstOrDefaultAsync(s => s.Id == user.StaffId);
		}

		public async Task<Patient?> GetPatientByUserAsync(User user)
		{
			return await _context.Patients.FirstOrDefaultAsync(p => p.Id == user.PatientId);
		}
	}
}
