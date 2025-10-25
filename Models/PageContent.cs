namespace Csharp3_A3.Models
{
	public class PageContent
	{
		public int Id { get; set; }
		public string Slug { get; set; } = string.Empty;
		public string PageTitle { get; set; } = string.Empty;
		public List<(string BodyTitle, string Body, string ImgPath)> Cards { get; set; } = [];
	}
}
