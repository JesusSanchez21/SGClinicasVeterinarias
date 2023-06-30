using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;

namespace SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO
{

    public class SQLficha
    {
        #region Create
        static public void Insert(Ficha ficha)
        {
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "INSERT INTO \"fichas\" "
                        + "(animal_Id, colaborador_Id, diagnostico, peso, observacoes, prescricao, quantPrescricao, proxVisita) "
                        + "VALUES (@animal_Id, @colaborador_Id, @diagnostico, @peso, @observacoes, @prescricao, @quantPrescricao, @proxVisita);";
                        //sqlCommand.Parameters.Add(new SqlParameter("@id", ficha.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@animal_Id", ficha.Animal_Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@colaborador_Id", ficha.Colaborador_Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@diagnostico", ficha.Diagnostico));
                        sqlCommand.Parameters.Add(new SqlParameter("@peso", ficha.Peso));
                        sqlCommand.Parameters.Add(new SqlParameter("@observacoes", ficha.Observacoes));
                        sqlCommand.Parameters.Add(new SqlParameter("@prescricao", ficha.Prescricao));
                        sqlCommand.Parameters.Add(new SqlParameter("@quantPrescricao", ficha.QuantPrescricao));
                        sqlCommand.Parameters.Add(new SqlParameter("@proxVisita", ficha.ProxVisita));

                        if (sqlCommand.ExecuteNonQuery() != 1)
                        {
                            throw new System.Exception("[SQLficha] - Ocorreu um erro na query sql");
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
        public static List<Ficha> getAll()
        {
            List<Ficha> fichas = new List<Ficha>();
            Ficha ficha = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    //instancia para permitir comandos 
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        string query = "Select * from fichas;";
                        //defining o tipo de comando
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);


                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ficha = new Ficha(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["animal_Id"].ToString(),
                                    reader["colaborador_id"].ToString(),
                                    reader["diagnostico"].ToString(),
                                    int.Parse(reader["peso"].ToString()),
                                    reader["observacoes"].ToString(),
                                    reader["prescricao"].ToString(),
                                    int.Parse(reader["quantPrescricao"].ToString()),
                                    (DateTime)reader["proxVisita"]);
                                fichas.Add(ficha);
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

            return fichas;

        }

        #endregion

        #region GetByID
        internal static Ficha GetById(int Id)
        {
            Ficha ficha = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        sqlCommand.CommandText = "SELECT * FROM fichas where ID=@id;";
                        sqlCommand.Parameters.Add(new SqlParameter("@id", Id));

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ficha = new Ficha(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["animal_Id"].ToString(),
                                    reader["colaborador_id"].ToString(),
                                    reader["diagnostico"].ToString(),
                                    int.Parse(reader["peso"].ToString()),
                                    reader["observacoes"].ToString(),
                                    reader["prescricao"].ToString(),
                                    int.Parse(reader["quantPrescricao"].ToString()),
                                    (DateTime)reader["proxVisita"]
                                    );

                            }
                        }

                        //TODO add relationship here
                        //Ficha.Client = SQLClient.GetClientById(Ficha.Client.Id);
                    }
                }

                // Se Entidade tem FKs, completar o objeto extraído com o objeto fk, com um get(id) à SQL respetiva
                //Ficha.CategoriaFicha = SQLcategoriaFicha.Get(Convert.ToInt32(Ficha.CategoriaFicha.ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLFicha - get() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLFicha - Get() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLFicha - Get() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
                return null;
            }
            return ficha;
        }
        #endregion

        #region Update
        internal static bool UpdateFicha(Ficha ficha)
        {
            bool success = false;
            try
            {
                using (DbConnection conn = OpenConnection())
                {

                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "UPDATE fichas SET" +
                            " Name = @animal_id," +
                            " Email = @colaborador_Id," +
                            " Diagnostico = @diagnostico" +
                            " Peso = @peso" +
                            " Observacoes = @observacoes" +
                            " Prescricao = @prescricao" +
                            " QuantPrescricao = @quantPrescricao" +
                            " ProxVisita = @proxVisita" +
                            " WHERE ID = @id";
                        sqlCommand.Parameters.Add(new SqlParameter("@id", ficha.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@animal_id", ficha.Animal_Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@colaborador_Id", ficha.Colaborador_Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@diagnostico", ficha.Diagnostico));
                        sqlCommand.Parameters.Add(new SqlParameter("@peso", ficha.Peso));
                        sqlCommand.Parameters.Add(new SqlParameter("@observacoes", ficha.Observacoes));
                        sqlCommand.Parameters.Add(new SqlParameter("@prescricao", ficha.Prescricao));
                        sqlCommand.Parameters.Add(new SqlParameter("@quantPrescricao", ficha.QuantPrescricao));
                        sqlCommand.Parameters.Add(new SqlParameter("@proxVisita", ficha.ProxVisita));

                        // Execute a query update
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLFicha - update() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLFicha - update() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLFicha - update() - Catch",   // Título
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

                        string query = "DELETE FROM fichas WHERE id = @id;";
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
                Console.WriteLine("Erro: SQLFicha - delete() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLFicha - delete() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLFicha - delete() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
            }
            return success;
        }

        #endregion
    }
}
