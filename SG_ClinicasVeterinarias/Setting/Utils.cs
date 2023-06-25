using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_ClinicasVeterinarias.Setting
{
    public abstract class Utils
    {
        // Constantes para definir as operações SQL DML
        internal const int SQL_INSERT = 1;
        internal const int SQL_UPDATE = 2;
        internal const int SQL_DELETE = 3;

        // Constantes para definir os DBMS
        internal const int DBMS_NULL = 0;
        internal const int DBMS_BD_LOCAL = 2;

        // Constantes para definir as Entidades
        internal const int TABLE_USER = 1;
        internal const int TABLE_EMPLOYEE = 2;
        internal const int TABLE_CUSTOMER = 3;
        internal const int TABLE_PROSPECT = 4;

        static internal bool IsEmail(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address.Equals(email);
            }
            catch
            {
                return false;
            }
        }


        static internal bool IsNumber(String numero)
        {
            return int.TryParse(numero, out int _);
        }

        static internal bool IsEmpty(string text)
        {
            return String.IsNullOrEmpty(text);
        }

    }
}
