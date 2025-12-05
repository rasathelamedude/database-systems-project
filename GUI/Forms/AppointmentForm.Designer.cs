namespace GUI.Forms
{
  partial class AppointmentForm
  {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblPatient;
    private System.Windows.Forms.TextBox txtPatientName;
    private System.Windows.Forms.Label lblDoctor;
    private System.Windows.Forms.TextBox txtDoctorName;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.DateTimePicker dtpDate;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.TextBox txtTime;
    private System.Windows.Forms.Label lblNotes;
    private System.Windows.Forms.TextBox txtNotes;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.DataGridView dgvAppointments;
    private System.Windows.Forms.Label lblAppointments;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.lblTitle = new System.Windows.Forms.Label();
      this.lblPatient = new System.Windows.Forms.Label();
      this.txtPatientName = new System.Windows.Forms.TextBox();
      this.lblDoctor = new System.Windows.Forms.Label();
      this.txtDoctorName = new System.Windows.Forms.TextBox();
      this.lblDate = new System.Windows.Forms.Label();
      this.dtpDate = new System.Windows.Forms.DateTimePicker();
      this.lblTime = new System.Windows.Forms.Label();
      this.txtTime = new System.Windows.Forms.TextBox();
      this.lblNotes = new System.Windows.Forms.Label();
      this.txtNotes = new System.Windows.Forms.TextBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.dgvAppointments = new System.Windows.Forms.DataGridView();
      this.lblAppointments = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
      this.SuspendLayout();

      // lblTitle
      this.lblTitle.AutoSize = true;
      this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
      this.lblTitle.Location = new System.Drawing.Point(20, 20);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(300, 30);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "Appointment Management";

      // lblPatient
      this.lblPatient.AutoSize = true;
      this.lblPatient.Location = new System.Drawing.Point(20, 70);
      this.lblPatient.Name = "lblPatient";
      this.lblPatient.Size = new System.Drawing.Size(90, 15);
      this.lblPatient.TabIndex = 1;
      this.lblPatient.Text = "Patient Name:";

      // txtPatientName
      this.txtPatientName.Location = new System.Drawing.Point(140, 67);
      this.txtPatientName.Name = "txtPatientName";
      this.txtPatientName.Size = new System.Drawing.Size(300, 23);
      this.txtPatientName.TabIndex = 2;

      // lblDoctor
      this.lblDoctor.AutoSize = true;
      this.lblDoctor.Location = new System.Drawing.Point(20, 105);
      this.lblDoctor.Name = "lblDoctor";
      this.lblDoctor.Size = new System.Drawing.Size(90, 15);
      this.lblDoctor.TabIndex = 3;
      this.lblDoctor.Text = "Doctor Name:";

      // txtDoctorName
      this.txtDoctorName.Location = new System.Drawing.Point(140, 102);
      this.txtDoctorName.Name = "txtDoctorName";
      this.txtDoctorName.Size = new System.Drawing.Size(300, 23);
      this.txtDoctorName.TabIndex = 4;

      // lblDate
      this.lblDate.AutoSize = true;
      this.lblDate.Location = new System.Drawing.Point(20, 140);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new System.Drawing.Size(35, 15);
      this.lblDate.TabIndex = 5;
      this.lblDate.Text = "Date:";

      // dtpDate
      this.dtpDate.Location = new System.Drawing.Point(140, 137);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.Size = new System.Drawing.Size(300, 23);
      this.dtpDate.TabIndex = 6;

      // lblTime
      this.lblTime.AutoSize = true;
      this.lblTime.Location = new System.Drawing.Point(20, 175);
      this.lblTime.Name = "lblTime";
      this.lblTime.Size = new System.Drawing.Size(110, 15);
      this.lblTime.TabIndex = 7;
      this.lblTime.Text = "Time (e.g. 09:00 AM):";

      // txtTime
      this.txtTime.Location = new System.Drawing.Point(140, 172);
      this.txtTime.Name = "txtTime";
      this.txtTime.Size = new System.Drawing.Size(150, 23);
      this.txtTime.TabIndex = 8;
      this.txtTime.PlaceholderText = "09:00 AM";

      // lblNotes
      this.lblNotes.AutoSize = true;
      this.lblNotes.Location = new System.Drawing.Point(20, 210);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new System.Drawing.Size(41, 15);
      this.lblNotes.TabIndex = 9;
      this.lblNotes.Text = "Notes:";

      // txtNotes
      this.txtNotes.Location = new System.Drawing.Point(140, 207);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.Size = new System.Drawing.Size(300, 60);
      this.txtNotes.TabIndex = 10;

      // btnAdd
      this.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
      this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.btnAdd.ForeColor = System.Drawing.Color.White;
      this.btnAdd.Location = new System.Drawing.Point(140, 285);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(145, 35);
      this.btnAdd.TabIndex = 11;
      this.btnAdd.Text = "Add Appointment";
      this.btnAdd.UseVisualStyleBackColor = false;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

      // btnRefresh
      this.btnRefresh.Location = new System.Drawing.Point(295, 285);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(145, 35);
      this.btnRefresh.TabIndex = 12;
      this.btnRefresh.Text = "Refresh List";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

      // lblAppointments
      this.lblAppointments.AutoSize = true;
      this.lblAppointments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
      this.lblAppointments.Location = new System.Drawing.Point(20, 340);
      this.lblAppointments.Name = "lblAppointments";
      this.lblAppointments.Size = new System.Drawing.Size(180, 21);
      this.lblAppointments.TabIndex = 13;
      this.lblAppointments.Text = "All Appointments";

      // dgvAppointments
      this.dgvAppointments.AllowUserToAddRows = false;
      this.dgvAppointments.AllowUserToDeleteRows = false;
      this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvAppointments.Location = new System.Drawing.Point(20, 370);
      this.dgvAppointments.Name = "dgvAppointments";
      this.dgvAppointments.ReadOnly = true;
      this.dgvAppointments.RowHeadersWidth = 51;
      this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvAppointments.Size = new System.Drawing.Size(960, 280);
      this.dgvAppointments.TabIndex = 14;

      // AppointmentForm
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1000, 670);
      this.Controls.Add(this.dgvAppointments);
      this.Controls.Add(this.lblAppointments);
      this.Controls.Add(this.btnRefresh);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.txtNotes);
      this.Controls.Add(this.lblNotes);
      this.Controls.Add(this.txtTime);
      this.Controls.Add(this.lblTime);
      this.Controls.Add(this.dtpDate);
      this.Controls.Add(this.lblDate);
      this.Controls.Add(this.txtDoctorName);
      this.Controls.Add(this.lblDoctor);
      this.Controls.Add(this.txtPatientName);
      this.Controls.Add(this.lblPatient);
      this.Controls.Add(this.lblTitle);
      this.Name = "AppointmentForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Medical Management System - Secretary";
      ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}