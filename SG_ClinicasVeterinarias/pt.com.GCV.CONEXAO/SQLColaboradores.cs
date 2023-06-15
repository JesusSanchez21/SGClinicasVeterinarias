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
    internal class SQLColaboradores
    {
        static public void Insert(Colaborador colaborador)
        {
            try
            {
                using (DbConnection conn = OpenConnection())
                {
                    using (SqlCommand sqlCommand = ((SqlConnection)conn).CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "INSERT INTO \"colaboradores\" "
                        + "(nome, dataNasc, nif, tipoColab, funcao, dataIniColab, dataFimColab, telefone, email) "
                        + "VALUES (@nome, @dataNasc, @nif, @tipoColab, @funcao, @dataIniColab, @dataFimColab, @telefone, @email);";
                        //sqlCommand.Parameters.Add(new SqlParameter("@id", colaborador.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@nome", colaborador.Nome));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataNasc", colaborador.DataNasc));
                        sqlCommand.Parameters.Add(new SqlParameter("@nif", colaborador.Nif));
                        sqlCommand.Parameters.Add(new SqlParameter("@tipoColab", colaborador.TipoColab));
                        sqlCommand.Parameters.Add(new SqlParameter("@funcao", colaborador.Funcao));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataIniColab", colaborador.DataIniColab));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataFimColab", colaborador.DataFimColab));
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
    }
}
