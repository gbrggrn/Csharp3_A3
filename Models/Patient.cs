﻿namespace Csharp3_A3.Models
{
	public class Patient
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public DateTime DateOfBirth { get; set; }

		public ICollection<Appointment> Appointments { get; set; } = [];
		public ICollection<MedicalHistory> MedicalHistory { get; set; } = [];
	}
}