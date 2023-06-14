using System;

namespace SG_ClinicasVeterinarias.pt.com.GCV.MODEL
{
    public class Animal
    {
        public int Id { get; set; }
        public string NomeDono { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataFal { get; set; }
        public DateTime DataUltimaCons { get; set; }
        public string TipoAnimal { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public int Peso { get; set; }
        public string RacaPai { get; set; }
        public string RacaMae { get; set; }
        /// <summary>
        /// public int Cliente_id { get; set; }
        /// public Cliente cliente { get; set; }
        /// </summary>


        public Animal()
        {

        }

        public Animal(int id)
        {
            Id = id;
        }
        public Animal(int id, string nomeDono, DateTime dataNasc, DateTime dataFal, DateTime dataUltimaCons, string tipoAnimal, string raca, char sexo, int peso)
        {
            Id = id;
            NomeDono = nomeDono;
            DataNasc = dataNasc;
            DataFal = dataFal;
            DataUltimaCons = dataUltimaCons;
            TipoAnimal = tipoAnimal;
            Raca = raca;
            Sexo = sexo;
            Peso = peso;

        }
        public Animal(int id, string nomeDono, DateTime dataNasc, DateTime dataFal, DateTime dataUltimaCons, string tipoAnimal, string raca, char sexo, int peso, string racaMae, string racaPai)
        {
            Id = id;
            NomeDono = nomeDono;
            DataNasc = dataNasc;
            DataFal = dataFal;
            DataUltimaCons = dataUltimaCons;
            TipoAnimal = tipoAnimal;
            Raca = raca;
            Sexo = sexo;
            Peso = peso;
            RacaPai = racaPai;
            RacaMae = racaMae;
            
        }
    }
}

