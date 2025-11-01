using Csharp3_A3.Models.Enums;

namespace Csharp3_A3.Models
{
	public class Appointment
	{
		public int Id { get; set; }
		public string Reason { get; set; } = string.Empty;
		public DateTime DateOfAppointment { get; set; }
		public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

		public int PatientId { get; set; }
		public Patient? Patient { get; set; }

		public int StaffId { get; set; }
		public Staff? Staff { get; set; }
	}
}
