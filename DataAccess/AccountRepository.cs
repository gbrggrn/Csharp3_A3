using Csharp3_A3.Data;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3.DataAccess
{
	public class AccountRepository
	{
		private readonly AppDbContext _context;

		public AccountRepository(AppDbContext context) => _context = context;

		public async Task<User?> GetUserByUsernameAsync(string username)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
		}

		public async Task<User?> GetUserWithRoleByUsernameAsync(string username)
		{
			return await _context.Users
				.Include(u => u.Patient)
				.Include(u => u.Staff)
				.FirstOrDefaultAsync(u => u.Username == username);
		}
	}
}
