using Csharp3_A3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Csharp3_A3.Controllers
{
	public class AppointmentController : Controller
	{
		//Services
		private readonly AccountService _accountService;
		private readonly AppointmentService _appointmentService;
		private readonly PatientService _patientService;
		private readonly StaffService _staffService;

		public AppointmentController(AccountService accountService, AppointmentService appointmentService, PatientService patientService, StaffService staffService)
		{
			_accountService = accountService;
			_appointmentService = appointmentService;
			_patientService = patientService;
			_staffService = staffService;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
