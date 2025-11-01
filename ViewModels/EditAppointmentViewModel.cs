using Csharp3_A3.Models;
using Csharp3_A3.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Csharp3_A3.ViewModels
{
	public class EditAppointmentViewModel
	{
		public Appointment Appointment { get; set; } = new();

		public IEnumerable<SelectListItem> StatusList { get; set; } = Enum.GetValues(typeof(AppointmentStatus))
			.Cast<AppointmentStatus>()
			.Select(s => new SelectListItem
			{
				Value = ((int)s).ToString(),
				Text = s.ToString()
			});
	}
}