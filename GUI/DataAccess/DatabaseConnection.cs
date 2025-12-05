using Oracle.ManagedDataAccess.Client;
using System;

namespace GUI.DataAccess
{
  public class DatabaseConnection
  {
    private static readonly string WalletLocation = @"C:\Users\DELL\Desktop\db-project\wallet";
    private static readonly string TnsAdmin = @"C:\Users\DELL\Desktop\db-project\wallet";
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
  }
}