using Microsoft.AspNetCore.Mvc.Rendering;
using Csharp3_A3.Models;
using Csharp3_A3.Models.Enums;

namespace Csharp3_A3.ViewModels
{
	public class AddAppointmentViewModel
	{
		public Patient? Patient { get; set; }
		public Staff? Staff { get; set; }
		public SelectList? SelectPatients { get; set; }
		public SelectList? SelectStaff { get; set; }
		public SelectList StatusList { get; set; } = new(Enum.GetValues(typeof(AppointmentStatus)));
		public Appointment Appointment { get; set; } = new();
	}
}
