using Csharp3_A3.Data;
using Csharp3_A3.DataAccess;
using Csharp3_A3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A3.Services
{
	public class AppointmentService
	{
		private readonly AppointmentsRepository _appointmentsRepository;

		public AppointmentService(AppointmentsRepository appointmentsRepository) => _appointmentsRepository = appointmentsRepository;

		public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
		{
			return await _appointmentsRepository.GetAppointmentsByPatientIdAsync(patientId);
		}

		public async Task<List<Appointment>> GetAppointmentsByStaffIdAsync(int staffId)
		{
			return await _appointmentsRepository.GetAppointmentsByStaffIdAsync(staffId);
		}

		public async Task<Appointment?> GetAppointmentByIdAsync(int appointmentId)
		{
			//Refactored
			return await _appointmentsRepository.GetAppointmentByIdAsync(appointmentId);

			//Explicit
			/*var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
			var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == appointment.PatientId);
			var staff = await _context.Staff.FirstOrDefaultAsync(s => s.Id == appointment.StaffId);

			appointment.Staff = staff;
			appointment.Patient = patient;

			return appointment;*/
		}

		public async Task DeleteAppointmentByIdAsync(int id) => await _appointmentsRepository.DeleteAppointmentByIdAsync(id);

		public async Task AddAppointmentAsync(Appointment appointment) => await _appointmentsRepository.AddAppointmentAsync(appointment);

		public async Task UpdateAsync(Appointment appointment)
		{
			var itemToUpdate = await _appointmentsRepository.GetAppointmentByIdAsync(appointment.Id);
			if (itemToUpdate == null)
				return;

			itemToUpdate.PatientId = appointment.PatientId;
			itemToUpdate.StaffId = appointment.StaffId;
			itemToUpdate.DateOfAppointment = appointment.DateOfAppointment;
			itemToUpdate.Reason = appointment.Reason;

			await _appointmentsRepository.UpdateAppointmentAsync(itemToUpdate);
		}
	}
}
