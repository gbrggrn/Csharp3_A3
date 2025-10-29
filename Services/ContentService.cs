using Csharp3_A3.DataAccess;
using Csharp3_A3.Models;

namespace Csharp3_A3.Services
{
	public class ContentService
	{
		private readonly ContentRepository _contentRepository;

		public ContentService(ContentRepository contentRepository) => _contentRepository = contentRepository;

		public async Task<PageContent?> GetContentBySlugAsync(string slug) => await _contentRepository.GetContentBySlugAsync(slug);
	}
}
