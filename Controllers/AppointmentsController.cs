using Csharp3_A3.Models;
using Csharp3_A3.Services;
using Csharp3_A3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Csharp3_A3.Controllers
{
	[Authorize(Roles = "Staff, Patient")]
	public class AppointmentsController : Controller
	{
		//Services
		private readonly AccountService _accountService;
		private readonly AppointmentService _appointmentService;
		private readonly PatientService _patientService;
		private readonly StaffService _staffService;
		private readonly UserService _userService;

		public AppointmentsController(AccountService accountService, AppointmentService appointmentService, PatientService patientService, StaffService staffService, UserService userService)
		{
			_accountService = accountService;
			_appointmentService = appointmentService;
			_patientService = patientService;
			_staffService = staffService;
			_userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var username = User.Identity?.Name;
			var user = await _accountService.GetByUserNameAsync(username);
			var model = new AppointmentsViewModel();

			if (User.IsInRole("Staff"))
			{
				model.Staff = await _staffService.GetByIdAsync(user.Id);
				model.Appointments = await _appointmentService.GetAppointmentsByStaffIdAsync(model.Staff!.Id);
			}
			if (User.IsInRole("Patient"))
			{
				model.Patient = await _userService.GetPatientByUserAsync(user);
				model.Appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(model.Patient!.Id);
			}
			else return Forbid();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> EditAppointment(int id)
		{
			var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

			if (appointment == null)
				throw new Exception("Appointment not found");
			else
				return View(appointment);
		}

		[HttpPost]
		public async Task<IActionResult> EditAppointment(Appointment model)
		{
			if (!ModelState.IsValid)
				return View();

			var itemToUpdate = await _appointmentService.GetAppointmentByIdAsync(model.Id);
			if (itemToUpdate == null)
				return NotFound();

			itemToUpdate.PatientId = model.PatientId;
			itemToUpdate.StaffId = model.StaffId;
			itemToUpdate.DateOfAppointment = model.DateOfAppointment;
			itemToUpdate.Reason = model.Reason;

			await _appointmentService.UpdateAsync(itemToUpdate);
			return RedirectToAction("Index", "Appointments");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
			if (appointment == null)
				return NotFound();

			await _appointmentService.DeleteAppointmentByIdAsync(id);
			return RedirectToAction("Index", "Appointments");
		}
	}
}
