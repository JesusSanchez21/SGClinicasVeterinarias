using System;

namespace SG_ClinicasVeterinarias.pt.com.GCV.MODEL
{
    public class Colaborador
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public int Nif { get; set; }
        public char TipoColab { get; set; }
        public string Funcao { get; set; }
        public DateTime DataIniColab { get; set; }
        public DateTime DataFimColab { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        /// <summary>
        ///  FALTA DISPONIBILIDADE HORARIA MAS NS COMO FAZER
        /// </summary>


        public Colaborador()
        {

        }

        public Colaborador(int id)
        {
            Id = id;
        }

        public Colaborador(int id, string nome, DateTime dataNasc, int nif, char tipoColab, string funcao, DateTime dataIniColab, DateTime dataFimColab, int telefone, string email)
        {
            Id = id;
            Nome = nome;
            DataNasc = dataNasc;
            Nif = nif;
            TipoColab = tipoColab;
            Funcao = funcao;
            DataIniColab = dataIniColab;
            DataFimColab = dataFimColab;
            Telefone = telefone;
            Email = email;
        }
    }
}