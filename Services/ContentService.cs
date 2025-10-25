using Csharp3_A3.Data;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Csharp3_A3.Services
{
	public class ContentService
	{
		private readonly AppDbContext _context;

		public ContentService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<PageContent?> GetContentBySlugAsync(string slug) => await _context.PageContents.FirstOrDefaultAsync(pc => pc.Slug == slug);
	}
}
