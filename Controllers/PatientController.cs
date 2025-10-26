using Csharp3_A3.Models;
using Csharp3_A3.Services;
using Csharp3_A3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Csharp3_A3.Controllers
{
	public class PatientController : Controller
	{
		//Services
		private readonly PatientService _patientService;
		private readonly StaffService _staffService;
		private readonly AccountService _accountService;

		public PatientController(PatientService patientService, StaffService staffService, AccountService accountService)
		{
			_patientService = patientService;
			_staffService = staffService;
			_accountService = accountService;
		}

		[HttpGet]
		public async Task<IActionResult> PatientPortal(string? section)
		{
			var staffRetrieved = await _staffService.GetAllAsync();
			var selectStaffList = new SelectList(staffRetrieved, "Id", "Name");
			var patientPortalViewModel = new PatientPortalViewModel 
			{ 
				ActiveSection = string.IsNullOrEmpty(section) ? "Profile" : section,
				SelectStaffList = selectStaffList
			};

			var username = User.Identity?.Name;

			if (username == null)
				return Forbid();

			var user = await _accountService.GetByUserNameAsync(username);

			if (user?.PatientId != null)
			{
				patientPortalViewModel.CurrentPatient = await _patientService.GetByIdAsync(user.PatientId.Value);
				patientPortalViewModel.MedicalHistory = await _patientService.GetMedicalHistoryByPatientIdAsync(user.PatientId.Value);
				patientPortalViewModel.Appointments = await _patientService.GetAppointmentsByPatientIdAsync(user.PatientId.Value);
			}

			return View(patientPortalViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> BookAppointment(PatientPortalViewModel model)
		{
			await _patientService.UpdateAppointmentsAsync(model.CurrentPatient.Id, model.Appointment);
			return RedirectToAction(nameof(PatientPortal), new { section = "Appointments" });
		}
	}
}
