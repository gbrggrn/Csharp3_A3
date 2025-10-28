using Csharp3_A3.Models;
using Csharp3_A3.Services;
using Csharp3_A3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
			var user = await _accountService.GetUserWithRoleByUsernameAsync(username);
			var model = new AppointmentsViewModel();

			if (User.IsInRole("Staff"))
			{
				model.Staff = await _staffService.GetByIdAsync(user.StaffId.Value);
				model.Appointments = await _appointmentService.GetAppointmentsByStaffIdAsync(model.Staff!.Id);
			}
			else if (User.IsInRole("Patient"))
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

		[HttpGet]
		public async Task<IActionResult> AddAppointment()
		{
			var username = User.Identity?.Name;
			if (username == null)
				return Forbid();

			var currentUser = await _accountService.GetUserWithRoleByUsernameAsync(username);
			if (currentUser == null)
				return Forbid();

			var patientsList = await _patientService.GetAllAsync();
			var staffList = await _staffService.GetAllAsync();

			Patient? patient = null;
			Staff? staff = null;

			if (User.IsInRole("Patient"))
			{
				patient = await _userService.GetPatientByUserAsync(currentUser);
			}
			else if (User.IsInRole("Staff"))
			{
				staff = await _userService.GetStaffByUserAsync(currentUser);
			}

			var model = new AddAppointmentViewModel()
			{
				Patient = patient,
				Staff = staff,
				SelectPatients = new SelectList(patientsList, "Id", "Name"),
				SelectStaff = new SelectList(staffList, "Id", "Name")
			};

			return View(model);
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

		[HttpPost]
		public async Task<IActionResult> AddAppointment(AddAppointmentViewModel model)
		{
			var username = User.Identity?.Name;
			if (username == null)
				return Forbid();

			var currentUser = await _accountService.GetUserWithRoleByUsernameAsync(username);
			if (currentUser == null)
				return Forbid();

			if (currentUser.PatientId != null)
				model.Appointment.PatientId = (int)currentUser.PatientId;
			if (currentUser.StaffId != null)
				model.Appointment.StaffId = (int)currentUser.StaffId;

			await _appointmentService.AddAppointmentAsync(model.Appointment);

			return RedirectToAction("Index", "Appointments");
		}
	}
}
