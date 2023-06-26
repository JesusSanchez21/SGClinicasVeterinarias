using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Manupation_of_the_Form
{
    public partial class Product : Form
    {
        List<Product> produtos = new List<Product>();

        private Product selectprodutos;

        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {

            produto = SQLProduto.getAll();

            //Definir colunas
            // Definição dos nomes das colunas
            listView2.Columns[0].Text = "#";
            listView2.Columns[1].Text = "Nome";
            listView2.Columns[2].Text = "Funcion";
            listView2.Columns[3].Text = "Email";
            listView2.Columns[4].Text = "Telefone";
            listView2.Columns[5].Text = "Nif";
            listView2.Columns[6].Text = "Date of birth";
            listView2.Columns[7].Text = "Type of Employe";
            listView2.Columns[8].Text = "Start Date";

            // Definição das colunas da listview. 
            // NOTA: Os valores percentuais da largura das colunas tem de somar 100
            listView2.Columns[0].Width = (15 * listView2.Width) / 100; // ID -> sempre escondido
            listView2.Columns[1].Width = (10 * listView2.Width) / 100;
            listView2.Columns[2].Width = (15 * listView2.Width) / 100;
            listView2.Columns[3].Width = (15 * listView2.Width) / 100;
            listView2.Columns[4].Width = (15 * listView2.Width) / 100;
            listView2.Columns[5].Width = (15 * listView2.Width) / 100;
            listView2.Columns[6].Width = (15 * listView2.Width) / 100;
            listView2.Columns[7].Width = (15 * listView2.Width) / 100;
            listView2.Columns[8].Width = (15 * listView2.Width) / 100;

            foreach (Product product in produtos)
            {
                ListViewItem row = new ListViewItem(new[] {
                            product.CodProd.ToString(),
                            product.TipoProd,
                            product.DescProd,
                            product.QuantArmazem.ToString(),
                            product.PrecoUnit.ToString(),
                        });
                listView2.Items.Add(row);
            }
        }
    }
}
