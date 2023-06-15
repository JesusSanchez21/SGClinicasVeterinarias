using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_ClinicasVeterinarias.pt.com.GCV.MODEL
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public int Nif { get; set; }

        public Cliente()
        {

        }

        public Cliente(int id)
        {
            Id = id;
        }

        public Cliente(int id, string nome, string email, int telefone, DateTime dataNasc, int nif)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataNasc = dataNasc;
            Nif = nif;
        }
        public Cliente( string nome, string email, int telefone, DateTime dataNasc, int nif)
        {
           
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataNasc = dataNasc;
            Nif = nif;
        }
    }
}
