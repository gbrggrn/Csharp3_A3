using Csharp3_A3.Data;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3.DataAccess
{
	public class ContentRepository
	{
		private readonly AppDbContext _context;

		public ContentRepository(AppDbContext context) => _context = context;

		public async Task<PageContent?> GetContentBySlugAsync(string slug) => await _context.PageContents.Include(pc => pc.Cards).FirstOrDefaultAsync(pc => pc.Slug == slug);
	}
}
