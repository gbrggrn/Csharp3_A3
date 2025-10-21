using Csharp3_A3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Csharp3_A3.Controllers
{
	public class NewsController : Controller
	{
		private readonly NewsService _newsService;

		public NewsController(NewsService newsService) 
		{
			_newsService = newsService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var newsItems = await _newsService.GetAllAsync();
			return View(newsItems);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _newsService.DeleteAsync(id);
			return RedirectToAction("NewsManagement", "News");
		}
	}
}
