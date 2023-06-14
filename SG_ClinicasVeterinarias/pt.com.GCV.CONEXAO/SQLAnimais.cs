using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
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
                        + "(nomeDono, dataNasc, dataFal, dataUltimaCons, tipoAnimal, raca, sexo, peso, racaPai, racaMae) "
                        + "VALUES (@nomeDono, @dataNasc, @dataFal, @dataUltimaCons, @tipoAnimal, @raca, @sexo, @peso, @racaPai, @racaMae);";
                        //sqlCommand.Parameters.Add(new SqlParameter("@id", animal.Id));
                        sqlCommand.Parameters.Add(new SqlParameter("@nomeDono", animal.NomeDono));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataNasc", animal.DataNasc));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataFal", animal.DataFal));
                        sqlCommand.Parameters.Add(new SqlParameter("@dataUltimaCons", animal.DataUltimaCons));
                        sqlCommand.Parameters.Add(new SqlParameter("@tipoAnimal", animal.TipoAnimal));
                        sqlCommand.Parameters.Add(new SqlParameter("@raca", animal.Raca));
                        sqlCommand.Parameters.Add(new SqlParameter("@sexo", animal.Sexo));
                        sqlCommand.Parameters.Add(new SqlParameter("@peso", animal.Peso));
                        sqlCommand.Parameters.Add(new SqlParameter("@racaPai", animal.RacaPai));
                        sqlCommand.Parameters.Add(new SqlParameter("@racaMae", animal.RacaMae));


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
