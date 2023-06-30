using System;

namespace SG_ClinicasVeterinarias.pt.com.GCV.MODEL
{
    public class Ficha
    {
        public int Id { get; set; }
        public string Animal_Id { get; set; }
        public string Colaborador_Id { get; set; }
        public string Diagnostico { get; set; }
        public int Peso { get; set; }
        public string Observacoes { get; set; }
        public string Prescricao { get; set; }
        public int QuantPrescricao { get; set; }
        public DateTime ProxVisita { get; set; }

        public Ficha()
        {

        }

        public Ficha(int id)
        {
            Id = id;
        }

        public Ficha(int id, string animal_Id, string colaborador_Id, string diagnostico, int peso, string observacoes, string prescricao, int quantPrescricao, DateTime proxVisita) //Falta tudo que está comentado
        {
            Id = id;
            Animal_Id = animal_Id;
            Colaborador_Id = colaborador_Id;
            Diagnostico = diagnostico;
            Peso = peso;
            Observacoes = observacoes;
            Prescricao = prescricao;
            QuantPrescricao = quantPrescricao;
            ProxVisita = proxVisita;
        }


    }
}
