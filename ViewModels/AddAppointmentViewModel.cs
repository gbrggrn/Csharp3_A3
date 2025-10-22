using Microsoft.AspNetCore.Mvc.Rendering;
using Csharp3_A3.Models;

namespace Csharp3_A3.ViewModels
{
	public class AddAppointmentViewModel
	{
		public Patient? Patient { get; set; }
		public Staff? Staff { get; set; }
		public SelectList? SelectPatients { get; set; }
		public SelectList? SelectStaff { get; set; }
		public Appointment Appointment { get; set; } = new();
	}
}
