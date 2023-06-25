using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_ClinicasVeterinarias.pt.com.GCV.MODEL
{
    public class Produto
    {
        public int CodProd { get; set; } //Usei como id pq na descricao no trabalho diz q n se pode alterar ent yh, ATENÇÃO: NAO PODEM SER REMOVIDOS PRODUTO, TEM DE HAVER UM ESTADO
        public string TipoProd { get; set; }
        public string DescProd { get; set; }
        public int QuantArmazem { get; set; }
        public int PrecoUnit { get; set; }
        
        public Produto()
        {

        }

        public Produto(int codProd)
        {
            CodProd = codProd;
        }
        public Produto(int codProd, string tipoProd, string descProd, int quantArmazem, int precoUnit)
        {
            CodProd = codProd;
            TipoProd = tipoProd;
            DescProd = descProd;
            QuantArmazem = quantArmazem;
            PrecoUnit = precoUnit;
            
        }
        public Produto(string tipoProd, string descProd, int quantArmazem, int precoUnit)
        {
            TipoProd = tipoProd;
            DescProd = descProd;
            QuantArmazem = quantArmazem;
            PrecoUnit = precoUnit;

        }
    }
}
