using Csharp3_A3.Data;

namespace Csharp3_A3.Services
{
	public class HospitalService
	{
		private readonly AppDbContext _context;

		public HospitalService(AppDbContext context)
		{
			_context = context;
		}
	}
}
