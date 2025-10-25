using Csharp3_A3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Csharp3_A3.Controllers
{
	public class ContentController : Controller
	{
		private readonly ContentService _contentService;
		public ContentController(ContentService contentService)
		{
			_contentService = contentService;
		}

		public async Task<IActionResult> Accidents()
		{
			var content = await _contentService.GetContentBySlugAsync("accidents");
			return View(content);
		}

		public async Task<IActionResult> Injuries()
		{
			var content = await _contentService.GetContentBySlugAsync("injuries");
			return View(content);
		}

		public async Task<IActionResult> Child()
		{
			var content = await _contentService.GetContentBySlugAsync("child");
			return View(content);
		}

		public async Task<IActionResult> Pregnant()
		{
			var content = await _contentService.GetContentBySlugAsync("pregnant");
			return View(content);
		}

		public async Task<IActionResult> Ailments()
		{
			var content = await _contentService.GetContentBySlugAsync("ailments");
			return View(content);
		}

		public async Task<IActionResult> Diseases()
		{
			var content = await _contentService.GetContentBySlugAsync("diseases");
			return View(content);
		}

		public async Task<IActionResult> Examination()
		{
			var content = await _contentService.GetContentBySlugAsync("examination");
			return View(content);
		}

		public async Task<IActionResult> Treatments()
		{
			var content = await _contentService.GetContentBySlugAsync("treatments");
			return View(content);
		}

		public async Task<IActionResult> Exercise()
		{
			var content = await _contentService.GetContentBySlugAsync("exercise");
			return View(content);
		}

		public async Task<IActionResult> Nutrition()
		{
			var content = await _contentService.GetContentBySlugAsync("nutrition");
			return View(content);
		}
		public async Task<IActionResult> Wellness()
		{
			var content = await _contentService.GetContentBySlugAsync("wellness");
			return View(content);
		}
	}
}
