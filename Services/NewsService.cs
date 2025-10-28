using Csharp3_A3.DataAccess;
using Csharp3_A3.Models;

namespace Csharp3_A3.Services
{
	public class NewsService
	{
		private readonly NewsRepository _newsRepository;

		public NewsService(NewsRepository newsRepository) => _newsRepository = newsRepository;

		public async Task<List<NewsItem>> GetAllAsync() => await _newsRepository.GetAllAsync();

		public async Task<NewsItem?> GetByIdAsync(int id) => await _newsRepository.GetByIdAsync(id);

		public async Task AddAsync(NewsItem item)
		{
			await _newsRepository.AddAsync(item);
		}

		public async Task UpdateAsync(NewsItem item)
		{
			var itemToUpdate = await _newsRepository.GetByIdAsync(item.Id);
			if (itemToUpdate == null)
				return;

			itemToUpdate.Title = item.Title;
			itemToUpdate.Content = item.Content;
			itemToUpdate.ImagePath = item.ImagePath;
			itemToUpdate.Url = item.Url;

			await _newsRepository.UpdateAsync(itemToUpdate);
		}

		public async Task DeleteAsync(int id)
		{
			var item = await _newsRepository.GetByIdAsync(id);
			if (item != null)
			{
				await _newsRepository.DeleteAsync(item);
			}
		}
	}
}
