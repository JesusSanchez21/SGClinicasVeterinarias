using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;

namespace SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO
{
    public class SQLAnimais
    {
        #region Create
        static public void Insert(Animal animals)
        {
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "INSERT INTO \"animais\" "
                        + "(nomeDono, dataNasc, dataFal, dataUltimaCons, tipoAnimal, raca, sexo, peso) "
                        + "VALUES (@nomeDono, @dataNasc, @dataFal, @dataUltimaCons, @tipoAnimal, @raca, @sexo, @peso);";
                        //sqlCommand.Parameters.Add(new SqlParameter("@id", animal.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@nomeDono", animals.NomeDono));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataNasc", animals.DataNasc));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataFal", animals.DataFal));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataUltimaCons", animals.DataUltimaCons));
                        sqlCommand.Parameters.Add(new SqlParameter("@tipoAnimal", animals.TipoAnimal));
                        sqlCommand.Parameters.Add(new SqlParameter("@raca", animals.Raca));
                        sqlCommand.Parameters.Add(new SqlParameter("@sexo", animals.Sexo));
                        sqlCommand.Parameters.Add(new SqlParameter("@peso", animals.Peso));


                        if (sqlCommand.ExecuteNonQuery() != 1)
                        {
                            throw new System.Exception("[SQLAnimais] - Ocorreu um erro na query sql");
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
        public static List<Animal> getAll()
        {
            List<Animal> animais = new List<Animal>();
            Animal animals = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    //instancia para permitir comandos 
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        string query = "Select * from animais;";
                        //defining o tipo de comando
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);


                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                animals = new Animal(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["nomeDono"].ToString(),
                                    (DateTime)reader["dataNasc"],
                                    (DateTime)reader["dataFal"],
                                    (DateTime)reader["dataUltimaCons"],
                                    reader["tipoAnimal"].ToString(),
                                    reader["raca"].ToString(),
                                    reader["sexo"].ToString(),
                                    int.Parse(reader["peso"].ToString()));
                                animais.Add(animals);
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

            return animais;

        }

        #endregion

        #region GetByID
        internal static Animal GetById(int id)
        {
            Animal animals = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        sqlCommand.CommandText = "SELECT * FROM animais where id =@id;";
                        sqlCommand.Parameters.Add(new SqlParameter("@id", id));

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                animals = new Animal(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["nomeDono"].ToString(),
                                    (DateTime)reader["dataNasc"],
                                    (DateTime)reader["dataFal"],
                                    (DateTime)reader["dataUltimaCons"],
                                    reader["tipoAnimal"].ToString(),
                                    (reader["raca"].ToString()),
                                    reader["sexo"].ToString(),
                                    int.Parse(reader["peso"].ToString()));
                            }
                        }

                        //TODO add relationship here
                        //Animal.Client = SQLClient.GetClientById(Animal.Client.Id);
                    }
                }

                // Se Entidade tem FKs, completar o objeto extraído com o objeto fk, com um get(id) à SQL respetiva
                //Animal.CategoriaAnimal = SQLcategoriaAnimal.Get(Convert.ToInt32(Animal.CategoriaAnimal.ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLAnimal - get() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLAnimais - Get() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLAnimais - Get() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
                return null;
            }
            return animals;
        }
        #endregion

        #region Update
        internal static bool UpdateAnimal(Animal animals)
        {
            bool success = false;
            try
            {
                using (DbConnection conn = OpenConnection())
                {

                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "UPDATE animais SET" +
                            " NomeDono = @nomeDono," +
                            " DataNasc = @dataNasc," +
                            " DataFal = @dataFal," +
                            " DataUltimaCons = @dataUltimaCons," +
                            " TipoAnimal = @tipoAnimal," +
                            " Raca = @raca," +
                            " Sexo = @sexo," +
                            " Peso = @peso" +
                            " WHERE ID = @id";
                        sqlCommand.Parameters.Add(new SqlParameter("@id", animals.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@nomeDono", animals.NomeDono));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataNasc", animals.DataNasc));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataFal", animals.DataFal));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataUltimaCons", animals.DataUltimaCons));
                        sqlCommand.Parameters.Add(new SqlParameter("@tipoAnimal", animals.TipoAnimal));
                        sqlCommand.Parameters.Add(new SqlParameter("@raca", animals.Raca));
                        sqlCommand.Parameters.Add(new SqlParameter("@sexo", animals.Sexo));
                        sqlCommand.Parameters.Add(new SqlParameter("@peso", animals.Peso));

                        // Execute a query update
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLAnimal - update() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLAnimal - update() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLAnimal - update() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
            }
            return success;
        }
        #endregion

        #region Delete
        internal static bool Delete(int id)
        {
            bool success = false;
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {

                        string query = "DELETE FROM animais WHERE id = @id;";
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
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLAnimal - delete() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLAnimal - delete() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLAnimal - delete() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
            }
            return success;
        }

        #endregion

    }
}
