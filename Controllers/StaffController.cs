using Csharp3_A3.Models;
using Csharp3_A3.Services;
using Csharp3_A3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Csharp3_A3.Controllers
{
	public class StaffController : Controller
	{
		//Services
		private readonly StaffService _staffService;
		private readonly PatientService _patientService;
		private readonly AccountService _accountService;

		public StaffController(StaffService staffService, PatientService patientService, AccountService accountService)
		{
			_staffService = staffService;
			_patientService = patientService;
			_accountService = accountService;
		}

		[HttpGet]
		public async Task<IActionResult> StaffDashboard(int? id, string? tab)
		{
			var staffDashboardViewModel = new StaffDashboardViewModel();

			string activeTab = tab ?? "tab1";
			staffDashboardViewModel.ActiveTab = activeTab;

			var username = User.Identity?.Name;

			if (username == null)
				return Forbid();

			var user = await _accountService.GetUserWithRoleByUsernameAsync(username);

			if (user?.StaffId != null)
			{
				var currentStaff = await _staffService.GetByIdAsync(user.StaffId.Value);
				var patients = await _patientService.GetAllAsync();
				var appointments = await _staffService.GetAllAppointmentsByIdAsync(user.StaffId.Value);

				staffDashboardViewModel.CurrentStaff = currentStaff;
				staffDashboardViewModel.Patients = patients;
				staffDashboardViewModel.Appointments = appointments;
			}

			if (id.HasValue)
			{
				var selectedPatient = await _patientService.GetByIdAsync(id.Value);
				staffDashboardViewModel.SelectedPatient = selectedPatient;
				if (selectedPatient != null)
				{
					var medicalHistory = await _patientService.GetMedicalHistoryByPatientIdAsync(selectedPatient.Id);
					staffDashboardViewModel.MedicalHistory = medicalHistory;
				}
			}

			return View(staffDashboardViewModel);
		}
	}
}
