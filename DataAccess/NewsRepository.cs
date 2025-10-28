using Csharp3_A3.Data;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3.DataAccess
{
	public class NewsRepository
	{
		private readonly AppDbContext _context;

		public NewsRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<NewsItem>> GetAllAsync()
		{
			return await _context.NewsItems.ToListAsync();
		}

		public async Task<NewsItem?> GetByIdAsync(int id)
		{
			return await _context.NewsItems.FirstOrDefaultAsync(n => n.Id == id);
		}

		public async Task AddAsync(NewsItem item)
		{
			await _context.NewsItems.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(NewsItem item)
		{
			_context.NewsItems.Remove(item);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(NewsItem item)
		{
			_context.NewsItems.Update(item);
			await _context.SaveChangesAsync();
		}
	}
}
