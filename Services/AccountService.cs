using Csharp3_A3.DataAccess;
using Csharp3_A3.Models;

namespace Csharp3_A3.Services
{
	public class AccountService
	{
		private readonly AccountRepository _accountRepository;

		public AccountService(AccountRepository accountRepository) => _accountRepository = accountRepository;

		public async Task<User?> AuthenticateAsync(string username, string password)
		{
			var user = await _accountRepository.GetUserByUsernameAsync(username);

			//Return null if user can not be found or password is wrong
			if (user == null || user.Password != password)
				return null;

			//Return user if found and password is correct
			return user;
		}

		public async Task<User?> GetUserWithRoleByUsernameAsync(string username)
		{
			return await _accountRepository.GetUserWithRoleByUsernameAsync(username);
		}
	}
}
