using Oracle.ManagedDataAccess.Client;
using System;

namespace MedicalManagementSystem.DataAccess
{
  public class DatabaseConnection
  {
    private static readonly string WalletLocation = @"C:\users\dell\desktop\db-project\wallet";
    private static readonly string TnsAdmin = @"C:\users\dell\desktop\db-project\wallet";

    private static readonly string DataSource = "h98hq2sct8lvcf7a_medium";

    private static readonly string UserId = "ADMIN";
    private static readonly string Password = "rocket12345@rasaTron";

    static DatabaseConnection()
    {
      // Set wallet location
      OracleConfiguration.TnsAdmin = TnsAdmin;
      OracleConfiguration.WalletLocation = WalletLocation;
    }

    public static OracleConnection GetConnection()
    {
      string connectionString = $"User Id={UserId};Password={Password};Data Source={DataSource};";
      return new OracleConnection(connectionString);
    }

    public static bool TestConnection()
    {
      try
      {
        using (var conn = GetConnection())
        {
          conn.Open();

          using (var cmd = new OracleCommand("SELECT 'Connected!' FROM DUAL", conn))
          {
            var result = cmd.ExecuteScalar();
            System.Windows.Forms.MessageBox.Show(
                $"Database connection successful!\nResult: {result}",
                "Success",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information
            );
          }

          return true;
        }
      }
      catch (Exception ex)
      {
        System.Windows.Forms.MessageBox.Show(
            $"Database connection failed!\n\nError: {ex.Message}",
            "Connection Error",
            System.Windows.Forms.MessageBoxButtons.OK,
            System.Windows.Forms.MessageBoxIcon.Error
        );
        return false;
      }
    }
  }
}