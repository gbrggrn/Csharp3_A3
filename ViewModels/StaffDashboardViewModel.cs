using Csharp3_A3.Models;

namespace Csharp3_A3.ViewModels
{
	public class StaffDashboardViewModel
	{
		public Staff? CurrentStaff { get; set; }
		public List<Patient> Patients { get; set; } = [];
		public List<Appointment> Appointments { get; set; } = [];
		public List<MedicalHistory> MedicalHistory { get; set; } = [];
		public Patient? SelectedPatient { get; set; }
		public string ActiveTab { get; set; } = "tab1";
	}
}
