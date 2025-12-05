using Oracle.ManagedDataAccess.Client;
using GUI.Models;
using System;
using System.Collections.Generic;

namespace GUI.DataAccess
{
  public class AppointmentRepository
  {
    public bool AddAppointment(Appointment appointment)
    {
      try
      {
        using (var conn = DatabaseConnection.GetConnection())
        {
          conn.Open();

          string sql = @"INSERT INTO appointments 
                                  (patient_name, doctor_name, appointment_date, appointment_time, notes)
                                  VALUES (:patient, :doctor, :date, :time, :notes)";

          using (var cmd = new OracleCommand(sql, conn))
          {
            cmd.Parameters.Add(new OracleParameter("patient", appointment.PatientName));
            cmd.Parameters.Add(new OracleParameter("doctor", appointment.DoctorName));
            cmd.Parameters.Add(new OracleParameter("date", appointment.AppointmentDate));
            cmd.Parameters.Add(new OracleParameter("time", appointment.AppointmentTime));
            cmd.Parameters.Add(new OracleParameter("notes", appointment.Notes ?? ""));

            cmd.ExecuteNonQuery();
            return true;
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"Failed to add appointment: {ex.Message}");
      }
    }

    public List<Appointment> GetAllAppointments()
    {
      var appointments = new List<Appointment>();

      try
      {
        using (var conn = DatabaseConnection.GetConnection())
        {
          conn.Open();

          string sql = @"SELECT appointment_id, patient_name, doctor_name, 
                                         appointment_date, appointment_time, notes, created_at
                                  FROM appointments 
                                  ORDER BY appointment_date DESC, appointment_time DESC";

          using (var cmd = new OracleCommand(sql, conn))
          using (var reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              appointments.Add(new Appointment
              {
                AppointmentId = reader.GetInt32(0),
                PatientName = reader.GetString(1),
                DoctorName = reader.GetString(2),
                AppointmentDate = reader.GetDateTime(3),
                AppointmentTime = reader.GetString(4),
                Notes = reader.IsDBNull(5) ? "" : reader.GetString(5),
                CreatedAt = reader.GetDateTime(6)
              });
            }
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"Failed to retrieve appointments: {ex.Message}");
      }

      return appointments;
    }
  }
}