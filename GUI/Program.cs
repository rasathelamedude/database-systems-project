using GUI.DataAccess;
using GUI.Forms;
using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Test database connection on startup
            if (!DatabaseConnection.TestConnection())
            {
                // Connection failed - user already saw error message
                return; // Exit application
            }

            // Connection successful - start the app
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}