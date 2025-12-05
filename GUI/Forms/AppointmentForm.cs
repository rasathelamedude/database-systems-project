using System;
using System.Windows.Forms;
using GUI.DataAccess;
using GUI.Models;

namespace GUI.Forms
{
  public partial class AppointmentForm : Form
  {
    private readonly AppointmentRepository repository;

    public AppointmentForm()
    {
      InitializeComponent();
      repository = new AppointmentRepository();
      LoadAppointments();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      // Validate inputs
      if (string.IsNullOrWhiteSpace(txtPatientName.Text))
      {
        MessageBox.Show("Please enter patient name", "Validation Error",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (string.IsNullOrWhiteSpace(txtDoctorName.Text))
      {
        MessageBox.Show("Please enter doctor name", "Validation Error",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (string.IsNullOrWhiteSpace(txtTime.Text))
      {
        MessageBox.Show("Please enter appointment time", "Validation Error",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      try
      {
        var appointment = new Appointment
        {
          PatientName = txtPatientName.Text.Trim(),
          DoctorName = txtDoctorName.Text.Trim(),
          AppointmentDate = dtpDate.Value.Date,
          AppointmentTime = txtTime.Text.Trim(),
          Notes = txtNotes.Text.Trim()
        };

        repository.AddAppointment(appointment);

        MessageBox.Show("Appointment added successfully!", "Success",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        ClearForm();
        LoadAppointments();
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error adding appointment: {ex.Message}", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      LoadAppointments();
    }

    private void LoadAppointments()
    {
      try
      {
        var appointments = repository.GetAllAppointments();
        dgvAppointments.DataSource = null;
        dgvAppointments.DataSource = appointments;

        // Format columns
        if (dgvAppointments.Columns.Count > 0)
        {
          dgvAppointments.Columns["AppointmentId"].HeaderText = "ID";
          dgvAppointments.Columns["PatientName"].HeaderText = "Patient Name";
          dgvAppointments.Columns["DoctorName"].HeaderText = "Doctor";
          dgvAppointments.Columns["AppointmentDate"].HeaderText = "Date";
          dgvAppointments.Columns["AppointmentTime"].HeaderText = "Time";
          dgvAppointments.Columns["Notes"].HeaderText = "Notes";
          dgvAppointments.Columns["CreatedAt"].HeaderText = "Created";

          dgvAppointments.Columns["AppointmentDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
          dgvAppointments.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error loading appointments: {ex.Message}", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void ClearForm()
    {
      txtPatientName.Clear();
      txtDoctorName.Clear();
      txtTime.Clear();
      txtNotes.Clear();
      dtpDate.Value = DateTime.Now;
      txtPatientName.Focus();
    }
  }
}