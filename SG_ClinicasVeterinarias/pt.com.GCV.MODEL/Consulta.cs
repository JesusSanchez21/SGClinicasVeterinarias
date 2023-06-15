using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_ClinicasVeterinarias.pt.com.GCV.MODEL
{
    public class Consulta
    {

        public int Id { get; set; }
        public string NomeDono { get; set; } //Isto devia ser a cena da foreign key que ns
        public string Animal_Id { get; set; } //TMB devia ser uma foreign key para a info do aniaml
        public string TipoConsulta { get; set; }
        public int Colaborador_Id { get; set; } // TMB devia ser uma foreign key para a info do animal
        public int Cliente_Telefone { get; set; } //Tmb devia ser uma foreign key para a info do dono
        public DateTime DataConsulta { get; set; } //Tem de ter Hora e min

        public Consulta()
        {

        }
        public Consulta(int id)
        {
            Id = id;
        }

        public Consulta(int id, string nomeDono, string animal_Id, string tipoConsulta, int colaborador_Id, int cliente_Telefone, DateTime dataConsulta)
        {
            Id = id;
            NomeDono = nomeDono;
            Animal_Id = animal_Id;
            TipoConsulta = tipoConsulta;
            Colaborador_Id = colaborador_Id;
            Cliente_Telefone = cliente_Telefone;
            DataConsulta = dataConsulta;
        }


    }
}
