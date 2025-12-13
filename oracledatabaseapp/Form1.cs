using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace OracleDatabaseApp
{
    public partial class MainForm : Form
    {
        private TextBox txtHost;
        private TextBox txtPort;
        private TextBox txtServiceName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtQuery;
        private Button btnConnect;
        private Button btnExecute;
        private DataGridView dgvResults;
        private Label lblStatus;
        private OracleConnection connection;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Oracle Database Query Tool";
            this.Size = new System.Drawing.Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Connection Group
            GroupBox grpConnection = new GroupBox
            {
                Text = "Database Connection",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(860, 120)
            };

            Label lblHost = new Label { Text = "Host:", Location = new System.Drawing.Point(10, 25), AutoSize = true };
            txtHost = new TextBox { Location = new System.Drawing.Point(100, 22), Size = new System.Drawing.Size(150, 20), Text = "localhost" };

            Label lblPort = new Label { Text = "Port:", Location = new System.Drawing.Point(270, 25), AutoSize = true };
            txtPort = new TextBox { Location = new System.Drawing.Point(310, 22), Size = new System.Drawing.Size(60, 20), Text = "1521" };

            Label lblService = new Label { Text = "Service Name:", Location = new System.Drawing.Point(10, 55), AutoSize = true };
            txtServiceName = new TextBox { Location = new System.Drawing.Point(100, 52), Size = new System.Drawing.Size(150, 20), Text = "ORCL" };

            Label lblUser = new Label { Text = "Username:", Location = new System.Drawing.Point(270, 55), AutoSize = true };
            txtUsername = new TextBox { Location = new System.Drawing.Point(350, 52), Size = new System.Drawing.Size(120, 20) };

            Label lblPass = new Label { Text = "Password:", Location = new System.Drawing.Point(490, 55), AutoSize = true };
            txtPassword = new TextBox { Location = new System.Drawing.Point(560, 52), Size = new System.Drawing.Size(120, 20), PasswordChar = '*' };

            btnConnect = new Button { Text = "Connect", Location = new System.Drawing.Point(700, 50), Size = new System.Drawing.Size(100, 25) };
            btnConnect.Click += BtnConnect_Click;

            grpConnection.Controls.AddRange(new Control[] { lblHost, txtHost, lblPort, txtPort, lblService, txtServiceName, lblUser, txtUsername, lblPass, txtPassword, btnConnect });

            // Query Group
            GroupBox grpQuery = new GroupBox
            {
                Text = "SQL Query",
                Location = new System.Drawing.Point(10, 140),
                Size = new System.Drawing.Size(860, 120)
            };

            txtQuery = new TextBox
            {
                Location = new System.Drawing.Point(10, 25),
                Size = new System.Drawing.Size(840, 60),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Text = "SELECT * FROM your_table_name"
            };

            btnExecute = new Button { Text = "Execute Query", Location = new System.Drawing.Point(700, 90), Size = new System.Drawing.Size(150, 25), Enabled = false };
            btnExecute.Click += BtnExecute_Click;

            grpQuery.Controls.AddRange(new Control[] { txtQuery, btnExecute });

            // Results
            Label lblResults = new Label { Text = "Query Results:", Location = new System.Drawing.Point(10, 270), AutoSize = true };

            dgvResults = new DataGridView
            {
                Location = new System.Drawing.Point(10, 295),
                Size = new System.Drawing.Size(860, 320),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Status
            lblStatus = new Label
            {
                Location = new System.Drawing.Point(10, 625),
                Size = new System.Drawing.Size(860, 20),
                Text = "Status: Not connected",
                ForeColor = System.Drawing.Color.Red
            };

            this.Controls.AddRange(new Control[] { grpConnection, grpQuery, lblResults, dgvResults, lblStatus });
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={txtHost.Text})(PORT={txtPort.Text}))(CONNECT_DATA=(SERVICE_NAME={txtServiceName.Text})));User Id={txtUsername.Text};Password={txtPassword.Text};";

                connection = new OracleConnection(connectionString);
                connection.Open();

                lblStatus.Text = "Status: Connected successfully!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                btnExecute.Enabled = true;
                btnConnect.Text = "Disconnect";
                btnConnect.Click -= BtnConnect_Click;
                btnConnect.Click += BtnDisconnect_Click;

                MessageBox.Show("Connected to Oracle Database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Status: Connection failed";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Connection Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }

            lblStatus.Text = "Status: Disconnected";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            btnExecute.Enabled = false;
            btnConnect.Text = "Connect";
            btnConnect.Click -= BtnDisconnect_Click;
            btnConnect.Click += BtnConnect_Click;
            dgvResults.DataSource = null;
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Please connect to the database first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuery.Text))
            {
                MessageBox.Show("Please enter a SQL query!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OracleCommand cmd = new OracleCommand(txtQuery.Text, connection);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvResults.DataSource = dt;
                lblStatus.Text = $"Status: Query executed successfully! Rows returned: {dt.Rows.Count}";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Status: Query execution failed";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Query Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
            base.OnFormClosing(e);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}