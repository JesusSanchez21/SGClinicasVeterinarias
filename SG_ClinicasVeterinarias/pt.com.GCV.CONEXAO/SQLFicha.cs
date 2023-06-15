﻿using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;

namespace SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO
{
    internal class SQLFicha
    {
        internal class SQLfichas
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
                            + "(nome, email, telefone, dataNasc, nif) "
                            + "VALUES (@nome, @email, @telefone, @dataNasc, @nif);";
                            //sqlCommand.Parameters.Add(new SqlParameter("@id", ficha.Id));
                            sqlCommand.Parameters.Add(new SqlParameter("@animal_Id", ficha.Animal_Id));
                            sqlCommand.Parameters.Add(new SqlParameter("@colaborador_Id", ficha.Colaborador_Id));
                            sqlCommand.Parameters.Add(new SqlParameter("@diagnostico", ficha.Diagnostico));
                            sqlCommand.Parameters.Add(new SqlParameter("@peso", ficha.Peso));
                            sqlCommand.Parameters.Add(new SqlParameter("@observacoes", ficha.Observacoes));
                            sqlCommand.Parameters.Add(new SqlParameter("@prescricao", ficha.Prescricao));
                            sqlCommand.Parameters.Add(new SqlParameter("@quantPrescricao", ficha.QuantPrescricao));
                            sqlCommand.Parameters.Add(new SqlParameter("@proxVisita", ficha.ProxVisita));
                            //Falta tudo que esta comentado em Ficha.cs


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
        }
    }
}