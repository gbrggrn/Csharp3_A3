using Csharp3_A3.Models;

namespace Csharp3_A3.ViewModels
{
	public class AppointmentsViewModel
	{
		public Staff? Staff { get; set; }
		public Patient? Patient { get; set; }
		public List<Appointment> Appointments { get; set; }
	}
}
