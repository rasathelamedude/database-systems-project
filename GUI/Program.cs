using GUI.DataAccess; // Add this line at top
using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Test database connection before starting the app
            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show(
                    "Cannot start application without database connection.\n\nPlease check:\n" +
                    "1. Wallet location in DatabaseConnection.cs\n" +
                    "2. DataSource name matches tnsnames.ora\n" +
                    "3. Username and password are correct",
                    "Startup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return; // Exit the application
            }

            // If connection works, start the app
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
