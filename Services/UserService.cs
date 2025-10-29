using Csharp3_A3.DataAccess;
using Csharp3_A3.Models;

namespace Csharp3_A3.Services
{
	public class UserService
	{
		private readonly UserRepository _userRepository;

		public UserService(UserRepository userRepository) => _userRepository = userRepository;

		public async Task<Staff?> GetStaffByUserAsync(User user) => await _userRepository.GetStaffByUserAsync(user);

		public async Task<Patient?> GetPatientByUserAsync(User user) => await _userRepository.GetPatientByUserAsync(user);
	}
}