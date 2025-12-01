using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace GUI.DataAccess
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

          using (var cmd = new OracleCommand("SELECT 'Connected to Oracle Cloud!' FROM DUAL", conn))
          {
            var result = cmd.ExecuteScalar();
            MessageBox.Show(
                $"✓ Database connection successful!\n\nResult: {result}",
                "Connection Test",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
          }

          return true;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            $"✗ Database connection failed!\n\nError: {ex.Message}\n\nCheck:\n" +
            "1. Wallet path in DatabaseConnection.cs\n" +
            "2. DataSource name in tnsnames.ora\n" +
            "3. ADMIN password is correct\n" +
            "4. Oracle.ManagedDataAccess.Core package installed",
            "Connection Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
        return false;
      }
    }
  }
}