using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;

namespace SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO
{
    internal class SQLProduto
    {
        static public void Insert(Produto produto)
        {
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "INSERT INTO \"produtos\" "
                        + "(tipoProd, descProd, quantArmazem, precoUnit, estado) "
                        + "VALUES (@tipoProd, @descProd, @quantArmazem, @precoUnit, @estado);";
                        //sqlCommand.Parameters.Add(new SqlParameter("@codProd", produto.CodProd));
                        sqlCommand.Parameters.Add(new SqlParameter("@tipoProd", produto.TipoProd));
                        sqlCommand.Parameters.Add(new SqlParameter("@descProd", produto.DescProd));
                        sqlCommand.Parameters.Add(new SqlParameter("@quantArmazem", produto.QuantArmazem));
                        sqlCommand.Parameters.Add(new SqlParameter("@precoUnit", produto.PrecoUnit));


                        if (sqlCommand.ExecuteNonQuery() != 1)
                        {
                            throw new System.Exception("[SQLCliente] - Ocorreu um erro na query sql");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
