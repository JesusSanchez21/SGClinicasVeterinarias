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
    internal class SQLUser
    {
        #region Create

        /// <summary>
        /// Adiciona um novo registo à tabela
        /// </summary>
        // <param name="user"></param>
        static public void Insert(User user)
        {
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "INSERT INTO \"Users\""
                        + "(name, email, password)"
                        + "VALUES(@name, @email, @password);";
                        //sqlCommand.Parameters.Add(new SqlParameter("@id", user.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@name", user.Name));
                        sqlCommand.Parameters.Add(new SqlParameter("@email", user.Email));
                        sqlCommand.Parameters.Add(new SqlParameter("@password", user.Password));

                        if (sqlCommand.ExecuteNonQuery() != 1)
                        {
                            throw new InvalidProgramException("SQLUser - add() - SQLServer Local: ");
                        }
                    }

                }
                //CloseAllConnections(true);
            }
            catch (Exception exeption)
            {
                MessageBox.Show(
                    "SQLUser - Add() - \n The connection to the database was lost: \n" + exeption.ToString(),
                    "SQLUser - Add() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
            }
        }
        #endregion

        #region Read
        internal static List<User> getAll()
        {
            List<User> users = new List<User>();   // Lista Principal
            String query = "";


            //Execução do SQL DML sob controlo do try catch
            try
            {
                // Abre ligação ao DBMS Ativo
                using (DbConnection conn = OpenConnection())
                {
                    query = "SELECT * FROM Users;";

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = query;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                User user = new User(
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader["Name"].ToString(),
                                    reader["Email"].ToString(),
                                    reader["Password"].ToString());
                                users.Add(user);
                            }
                        }
                    }

                }

                // adding relationship if exists
                //TODO add the relationship here with the client
                //foreach (User user in users)
                //{
                //    User.Client = SQLClient.Get(Convert.ToInt32(User.Client.Id));

                //}
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLuser - getAll() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLuser - GetAll() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLuser - GetAll() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
                return null;
            }
            return users;
        }

        /// <summary>
        /// Obtem um registo completo da tabela através do seu id, converte para obj e devolve.
        /// Há várias ligações - Processo:
        /// 1 - Ligação BD - Extrai o registo BD.
        /// 2 - Completa os objeto da lista principal, preenchendo os obj FK, com base nas listas FK
        ///     Usa um ciclo para correr a lista principal e um ciclo ou obj FK
        /// </summary>
        /// <returns>Devolve um objeto preenchido ou NULL</returns>
        internal static User GetById(int Id)
        {
            User user = null;

            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        sqlCommand.CommandText = "SELECT * FROM Users where ID=@id;";
                        sqlCommand.Parameters.Add(new SqlParameter("@id", Id));

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User(
                                    reader.GetInt32(reader.GetOrdinal("ID")),
                                    reader["Name"].ToString(),
                                    reader["Email"].ToString(),
                                    reader["Password"].ToString());

                            }
                        }

                        //TODO add relationship here
                        //User.Client = SQLClient.GetClientById(User.Client.Id);
                    }
                }

                // Se Entidade tem FKs, completar o objeto extraído com o objeto fk, com um get(id) à SQL respetiva
                //User.CategoriaUser = SQLcategoriaUser.Get(Convert.ToInt32(User.CategoriaUser.ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLUser - get() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLUser - Get() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLUser - Get() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
                
            }
            return user;
        }

        public static User GetUserByEmailAndPassword(User user)
        {
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = ((SqlConnection)conn);

                        sqlCommand.CommandText = "SELECT * FROM Users " +
                                                 "Where Email=@email AND Password=@password;";
                        sqlCommand.Parameters.Add(new SqlParameter("@email", user.Email));
                        sqlCommand.Parameters.Add(new SqlParameter("@password", user.Password));

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["Name"].ToString(),
                                    reader["Email"].ToString(),
                                    reader["Password"].ToString());

                            }
                            else
                            {
                                return null;
                            }
                        }

                        //TODO add relationship here
                        //User.Client = SQLClient.GetClientById(User.Client.Id);
                    }
                }

                // Se Entidade tem FKs, completar o objeto extraído com o objeto fk, com um get(id) à SQL respetiva
                //User.CategoriaUser = SQLcategoriaUser.Get(Convert.ToInt32(User.CategoriaUser.ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLUser - get() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLUser - Get() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLUser - Get() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
                return null;
            }
            return user;
        }

        #endregion

        #region Update
        internal static bool UpdateUser(User user)
        {
            bool success = false;
            try
            {
                using (DbConnection conn = OpenConnection())
                {

                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "UPDATE Users SET" +
                            " Name = @name," +
                            " Email = @email," +
                            " password = @password" +
                            " WHERE ID = @id";
                        sqlCommand.Parameters.Add(new SqlParameter("@id", user.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@name", user.Name));
                        sqlCommand.Parameters.Add(new SqlParameter("@email", user.Email));
                        sqlCommand.Parameters.Add(new SqlParameter("@password", user.Password));

                        // Execute a query update
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLUser - update() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLUser - update() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLUser - update() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
            }
            return success;
        }
        #endregion

        #region Delete
        internal static bool DeleteUser(int id)
        {
            bool success = false;
            try
            {
                using (DbConnection conn = OpenConnection())
                {
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
            catch (Exception e)
            {
                Console.WriteLine("Erro: SQLUser - delete() - \n" + e.ToString());
                MessageBox.Show(
                    "SQLUser - delete() - \n Ocorreram problemas com a ligação à Base de Dados: \n" + e.ToString(),
                    "SQLUser - delete() - Catch",   // Título
                    MessageBoxButtons.OK,       // Botões
                    MessageBoxIcon.Error  // Icon
                );
            }
            return success;
        }
    }
    #endregion
}
