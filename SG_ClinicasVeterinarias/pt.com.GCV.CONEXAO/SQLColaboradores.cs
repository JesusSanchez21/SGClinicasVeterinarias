using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;

namespace SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO
{
    public class SQLColaboradores
    {
        public static void Insert(Colaborador colaborador)
        {
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "INSERT INTO \"colaboradores\" "
                        + "(nome, dataNasc, nif, tipoColab, funcao, dataIniColab, telefone, email) "
                        + "VALUES (@nome, @dataNasc, @nif, @tipoColab, @funcao, @dataIniColab, @telefone, @email);";
                        //sqlCommand.Parameters.Add(new SqlParameter("@id", colaborador.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@nome", colaborador.Nome));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataNasc", colaborador.DataNasc));
                        sqlCommand.Parameters.Add(new SqlParameter("@nif", colaborador.Nif));
                        sqlCommand.Parameters.Add(new SqlParameter("@tipoColab", colaborador.TipoColab));
                        sqlCommand.Parameters.Add(new SqlParameter("@funcao", colaborador.Funcao));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataIniColab", colaborador.DataIniColab));
                        sqlCommand.Parameters.Add(new SqlParameter("@telefone", colaborador.Telefone));
                        sqlCommand.Parameters.Add(new SqlParameter("@email", colaborador.Email));


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
        internal static List<Colaborador> getAll()
        {
            List<Colaborador> colabs = new List<Colaborador>();
            Colaborador colab = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    //instancia para permitir comandos 
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        string query = "Select * from employe;";
                        //defining o tipo de comando
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);


                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                colab = new Colaborador(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["nome"].ToString(),
                                    (DateTime)reader["dataNasc"],
                                    int.Parse(reader["nif"].ToString()),
                                    reader["tipoColab"].ToString(),
                                    reader["funcao"].ToString(),
                                    (DateTime)reader["dataInicolab"],
                                    int.Parse(reader["telefone"].ToString()),
                                     reader["email"].ToString()
                                );
                                colabs.Add(colab);
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

            return colabs;
        }

        internal static Colaborador getColaboradorById(int id)
        {
            Colaborador colab = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        // Define a query
                        string query = "SELECT * FROM employe WHERE id = @id;";
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
                                colab = new Colaborador(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["nome"].ToString(),
                                    (DateTime)reader["dataNasc"],
                                    int.Parse(reader["nif"].ToString()),
                                    reader["tipoColab"].ToString(),
                                    reader["funcao"].ToString(),
                                    (DateTime)reader["dataInicolab"],
                                    int.Parse(reader["telefone"].ToString()),
                                    reader["email"].ToString()


                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving employe by ID: " + ex.Message);
            }

            return colab;
        }

        internal static bool updateColaborador(Colaborador colab)
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
                        string query = "UPDATE employe SET nome = @nome,dataNasc = @dataNasc ,nif = @nif, tipocolab = @tipocolab, funcao = @funcao, dataIncColab = @dataIncColab, telefone = @telefone,email = @email,  WHERE id = @id;";
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        // Adiciona os parametros
                        sqlCommand.Parameters.AddWithValue("@nome", colab.Nome);
                        sqlCommand.Parameters.AddWithValue("@nif", colab.Nif);
                        sqlCommand.Parameters.AddWithValue("@tipoColab", colab.TipoColab);
                        sqlCommand.Parameters.AddWithValue("@funcao", colab.Funcao);
                        sqlCommand.Parameters.AddWithValue("@dataIniColab", colab.DataIniColab);
                        sqlCommand.Parameters.AddWithValue("@email", colab.Email);
                        sqlCommand.Parameters.AddWithValue("@telefone", colab.Telefone);
                        sqlCommand.Parameters.AddWithValue("@dataNasc", colab.DataNasc);
                        sqlCommand.Parameters.AddWithValue("@id", colab.Id);

                        // Execute a query update
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error updating employe: " + ex.Message);
            }

            return success;
        }

        internal static bool deleteEmploye(int id)
        {
            bool success = false;

            try
            {

                using (DbConnection conn = OpenConnection())
                {
                    // Cria o comando SQL
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {

                        string query = "DELETE FROM employe WHERE id = @id;";
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
                Console.WriteLine("Error deleting employe: " + ex.Message);
            }

            return success;
        }
    }
}
