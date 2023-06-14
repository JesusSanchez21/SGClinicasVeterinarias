using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_ClinicasVeterinarias.pt.com.GCV.DAO
{
    internal class SqLConnection
    {
        static string workingDirectory = Environment.CurrentDirectory;
        static internal int DBMSactive { get; set; } = 2;
        static string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        static internal SqlConnection conn_sqlserver = null;
        public static string clipboardText = null;
        // LocalDB -Instância local SQL Server express do Visual Studio.
        static private readonly string sqlConnStringBdLocal = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={projectDirectory}\pt.com.GCV.CONEXAO\Database.mdf;Integrated Security=True";


        static internal DbConnection OpenConnection()
        {
            CloseAllConnections(false);

            try
            {
                conn_sqlserver = new SqlConnection(sqlConnStringBdLocal);
                conn_sqlserver.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }

            return conn_sqlserver;
        }
        static internal void CloseAllConnections(bool dbmsActiveNull)
        {

            if (conn_sqlserver != null)
            {
                conn_sqlserver.Close();
                conn_sqlserver = null;
            }
        }

    }
}
