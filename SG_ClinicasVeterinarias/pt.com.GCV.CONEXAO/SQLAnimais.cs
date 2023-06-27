using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;

namespace SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO
{
    internal class SQLAnimais
    {
        static public void Insert(Animal animal)
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
                        sqlCommand.Parameters.Add(new SqlParameter("@nomeDono", animal.NomeDono));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataNasc", animal.DataNasc));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataFal", animal.DataFal));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataUltimaCons", animal.DataUltimaCons));
                        sqlCommand.Parameters.Add(new SqlParameter("@tipoAnimal", animal.TipoAnimal));
                        sqlCommand.Parameters.Add(new SqlParameter("@raca", animal.Raca));
                        sqlCommand.Parameters.Add(new SqlParameter("@sexo", animal.Sexo));
                        sqlCommand.Parameters.Add(new SqlParameter("@peso", animal.Peso));


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
        internal static List<Animal> getAll()
        {
            List<Animal> animais = new List<Animal>();

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
                                Animal animal = new Animal(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader["nomeDono"].ToString(),
                                    (DateTime)reader["dataNasc"],
                                    (DateTime)reader["dataFal"],
                                    (DateTime)reader["dataUltimaCons"],
                                    reader["tipoAnimal"].ToString(),
                                    reader["raca"].ToString(),
                                    char.Parse(reader["sexo"].ToString()),
                                    int.Parse(reader["peso"].ToString()));
                                animais.Add(animal);
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
    }
}
