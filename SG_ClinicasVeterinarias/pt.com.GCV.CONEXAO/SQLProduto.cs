using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System.Collections.Generic;
using System;
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
                        + "(tipoProd, descProd, quantArmazem, precoUnit) "
                        + "VALUES (@tipoProd, @descProd, @quantArmazem, @precoUnit);";
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
        internal static List<Produto> getAll()
        {
            List<Produto> produtos = new List<Produto>();

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    //instancia para permitir comandos 
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        string query = "Select * from produtos;";
                        //defining o tipo de comando
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);


                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Produto produto = new Produto(
                                    reader.GetInt32(reader.GetOrdinal("codProd")),
                                    reader["tipoProd"].ToString(),
                                    reader["descProd"].ToString(),
                                    int.Parse(reader["quantArmazem"].ToString()),
                                    int.Parse(reader["precoUnit"].ToString()));
                                produtos.Add(produto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Um erro ocorreu -  contacte do administrador de sistema." + ex.Message);
                return null;
            }

            return produtos;

        }
    }
}
