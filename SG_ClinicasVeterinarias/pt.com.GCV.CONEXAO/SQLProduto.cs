using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;
using System.Windows.Forms;

namespace SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO
{
    internal class SQLProduto
    {
        #region Create
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
        #endregion

        #region Read
        public static List<Produto> getAll()
        {
            List<Produto> produtos = new List<Produto>();
            Produto produto = null;
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
                                produto = new Produto(
                                    reader.GetInt32(reader.GetOrdinal("codProd")),
                                    reader["tipoProd"].ToString(),
                                    reader["descProd"].ToString(),
                                    int.Parse(reader["quantArmazem"].ToString()),
                                    int.Parse(reader["precoUnit"].ToString())
                                    );
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
        #endregion

        #region GetByID
        internal static Produto GetById(int CodProd)
        {
            Produto produto = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        sqlCommand.CommandText = "SELECT * FROM produtos where CodProd=@codProd;";
                        sqlCommand.Parameters.Add(new SqlParameter("@codProd", CodProd));

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                produto = new Produto(
                                    reader.GetInt32(reader.GetOrdinal("codProd")),
                                    reader["tipoProd"].ToString(),
                                    reader["descProd"].ToString(),
                                    int.Parse(reader["quantArmazem"].ToString()),
                                    int.Parse(reader["precoUnit"].ToString()));

                            }
                        }

                        //TODO add relationship here
                        //Produto.Client = SQLClient.GetClientById(Produto.Client.Id);
                    }
                }

                // Se Entidade tem FKs, completar o objeto extraído com o objeto fk, com um get(id) à SQL respetiva
                //Produto.CategoriaProduto = SQLcategoriaProduto.Get(Convert.ToInt32(Produto.CategoriaProduto.ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLProduto - get() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLProduto - Get() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLProduto - Get() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
                return null;
            }
            return produto;
        }
        #endregion

        #region Update
        internal static bool UpdateProduto(Produto produto)
        {
            bool success = false;
            try
            {
                using (DbConnection conn = OpenConnection())
                {

                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "UPDATE Produtos SET" +
                            " TipoProd = @tipoProd," +
                            " DescProd = @descProd," +
                            " QuantArmazem = @quantArmazem," +
                            " PrecoUnit = @precoUnit" +
                            " WHERE CodProd = @codProd";
                        sqlCommand.Parameters.Add(new SqlParameter("@codProd", produto.CodProd));    
                        sqlCommand.Parameters.Add(new SqlParameter("@tipoProd", produto.TipoProd));
                        sqlCommand.Parameters.Add(new SqlParameter("@descProd", produto.DescProd));
                        sqlCommand.Parameters.Add(new SqlParameter("@quantArmazem", produto.QuantArmazem));
                        sqlCommand.Parameters.Add(new SqlParameter("@precoUnit", produto.PrecoUnit));
                        
                        // Execute a query update
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLProduto - update() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLProduto - update() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLProduto - update() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
            }
            return success;
        }
        #endregion

        #region Delete
        internal static bool Delete(int codProd)
        {
            bool success = false;
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {

                        string query = "DELETE FROM produtos WHERE codProd = @codProd;";
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        // Adiciona o parametro
                        sqlCommand.Parameters.AddWithValue("@codProd", codProd);

                        // Executa a query delete
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLFicha - delete() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLProdutos - delete() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLProdutos - delete() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
            }
            return success;
        }
        #endregion
    }
}

