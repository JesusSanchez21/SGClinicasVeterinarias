using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Listas
{
    public partial class ListaProduto : Form
    {
        List<Produto> produtoslist = new List<Produto>();
        public ListaProduto()
        {
            InitializeComponent();
        }

        private void ListaProduto_Load(object sender, EventArgs e)
        {

            produtoslist = SQLProduto.getAll();

            //Definir colunas
            // Definição dos nomes das colunas
            listView2.Columns[0].Text = "#"; // ID -> sempre escondido
            listView2.Columns[1].Text = "Type of Product";
            listView2.Columns[2].Text = "Description of the product";
            listView2.Columns[3].Text = "Quantity of stock";
            listView2.Columns[4].Text = "Price";


            // Definição das colunas da listview. 
            // NOTA: Os valores percentuais da largura das colunas tem de somar 100
            listView2.Columns[0].Width = (15 * listView2.Width) / 100;
            listView2.Columns[1].Width = (10 * listView2.Width) / 100;
            listView2.Columns[2].Width = (15 * listView2.Width) / 100;
            listView2.Columns[3].Width = (15 * listView2.Width) / 100;
            listView2.Columns[4].Width = (15 * listView2.Width) / 100;

            foreach (Produto produto in produtoslist)
            {
                ListViewItem row = new ListViewItem(new[] {
                            produto.CodProd.ToString(),
                            produto.TipoProd.ToString(),
                            produto.DescProd.ToString(),
                            produto.QuantArmazem.ToString(),
                            produto.PrecoUnit.ToString(),
                        });
                listView2.Items.Add(row);
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
