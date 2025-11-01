namespace Csharp3_A3.Helpers
{
	public class StringHelpers
	{
		public static string Truncate(string value, int maxLength)
		{
			if (string.IsNullOrEmpty(value)) return value;
			return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
		}
	}
}
