using Csharp3_A3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Csharp3_A3.ViewModels
{
	public class PatientPortalViewModel
	{
		public string ActiveSection { get; set; } = "Profile";
		public Patient CurrentPatient { get; set; } = new();
		public List<MedicalHistory> MedicalHistory { get; set; } = [];
		public List<Appointment> Appointments { get; set; } = [];
		public Appointment Appointment { get; set; } = new();
		public required SelectList SelectStaffList { get; set; }
	}
}
