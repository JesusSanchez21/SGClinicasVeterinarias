using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;

namespace SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO
{
    internal class SQLficha
    {
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
                        + "VALUES (@colaborador_Id, @diagnostico, @peso, @observacoes, @prescricao, @quantPrescricao, @proxVisita);";
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
        internal static List<Ficha> getAll()
        {
            List<Ficha> fichas = new List<Ficha>();

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
                                Ficha ficha = new Ficha(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    int.Parse(reader["animal_Id"].ToString()),
                                    int.Parse(reader["colaborador_id"].ToString()),
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
    }
}
