using System;

namespace GUI.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string AppointmentTime { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}