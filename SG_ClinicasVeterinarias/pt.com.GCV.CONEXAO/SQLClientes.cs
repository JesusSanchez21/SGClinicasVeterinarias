using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;
using System.Collections.Generic;
using System;

namespace SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO
{
    internal class SQLClientes
    {
        static public void Insert(Cliente cliente)
        {
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "INSERT INTO \"cliente\" "
                        + "(nome, email, telefone, dataNasc, nif) "
                        + "VALUES (@nome, @email, @telefone, @dataNasc, @nif);";
                        //sqlCommand.Parameters.Add(new SqlParameter("@id", cliente.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@nome", cliente.Nome));
                        sqlCommand.Parameters.Add(new SqlParameter("@email", cliente.Email));
                        sqlCommand.Parameters.Add(new SqlParameter("@telefone", cliente.Telefone));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataNasc", cliente.DataNasc));
                        sqlCommand.Parameters.Add(new SqlParameter("@nif", cliente.Nif));


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

        internal static List<Cliente> getAll()
        {
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    //instancia para permitir comandos 
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        string query = "Select * from clientes;";
                        //defining o tipo de comando
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);


                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                cliente = new Cliente(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["nome"].ToString(),
                                    reader["email"].ToString(),
                                    int.Parse(reader["telefone"].ToString()),
                                    (DateTime)reader["dataNasc"],
                                    int.Parse(reader["nif"].ToString())
                                );
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

            return clientes;
        }

        internal static Cliente getClienteById(int id)
        {
            Cliente cliente = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        // Define a query
                        string query = "SELECT * FROM clientes WHERE id = @id;";
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        // Adiciona o parametro
                        sqlCommand.Parameters.AddWithValue("@id", id);

                        // Executa a query
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cliente = new Cliente(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["nome"].ToString(),
                                    reader["email"].ToString(),
                                    int.Parse(reader["telefone"].ToString()),
                                    (DateTime)reader["dataNasc"],
                                    int.Parse(reader["nif"].ToString())
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving cliente by ID: " + ex.Message);
            }

            return cliente;
        }

        internal static bool updateCliente(Cliente cliente)
        {
            bool success = false;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    // Create SQL command
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        // Cria a query
                        string query = "UPDATE clientes SET nome = @nome, nif = @nif, email = @email, telefone = @telefone,dataNasc = @dataNasc  WHERE id = @id;";
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        // Adiciona os parametros
                        sqlCommand.Parameters.AddWithValue("@nome", cliente.Nome);
                        sqlCommand.Parameters.AddWithValue("@morada", cliente.Nif);
                        sqlCommand.Parameters.AddWithValue("@email", cliente.Email);
                        sqlCommand.Parameters.AddWithValue("@telefone", cliente.Telefone);
                        sqlCommand.Parameters.AddWithValue("@dataNasc", cliente.DataNasc);
                        sqlCommand.Parameters.AddWithValue("@id", cliente.Id);

                        // Execute a query update
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error updating cliente: " + ex.Message);
            }

            return success;
        }

        internal static bool deleteCliente(int id)
        {
            bool success = false;

            try
            {

                using (DbConnection conn = OpenConnection())
                {
                    // Cria o comando SQL
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {

                        string query = "DELETE FROM clientes WHERE id = @id;";
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        // Adiciona o parametro
                        sqlCommand.Parameters.AddWithValue("@id", id);

                        // Executa a query delete
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting cliente: " + ex.Message);
            }

            return success;
        }
    }
}
