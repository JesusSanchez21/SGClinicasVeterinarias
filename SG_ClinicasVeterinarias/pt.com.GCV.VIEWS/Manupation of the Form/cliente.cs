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

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Manupation_of_the_Form
{

    public partial class Form1 : Form
    {

        List<Cliente> clienteLista = new List<Cliente>();

        private Cliente selectedCliente;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            clienteLista = SQLClientes.getAll();
            //Definir colunas
            // Definição dos nomes das colunas
            listView2.Columns[0].Text = "#";
            listView2.Columns[1].Text = "Nome";
            listView2.Columns[2].Text = "Morada";
            listView2.Columns[3].Text = "Email";
            listView2.Columns[4].Text = "Telefone";
            listView2.Columns[5].Text = "Nif";
            listView2.Columns[6].Text = "Date of birth";

            // Definição das colunas da listview. 
            // NOTA: Os valores percentuais da largura das colunas tem de somar 100
            listView2.Columns[0].Width = (15 * listView2.Width) / 100; // ID -> sempre escondido
            listView2.Columns[1].Width = (10 * listView2.Width) / 100;
            listView2.Columns[2].Width = (15 * listView2.Width) / 100;
            listView2.Columns[3].Width = (15 * listView2.Width) / 100;
            listView2.Columns[4].Width = (15 * listView2.Width) / 100;
            listView2.Columns[5].Width = (15 * listView2.Width) / 100;
            listView2.Columns[6].Width = (15 * listView2.Width) / 100;

            foreach (Cliente cliente in clienteLista)
            {
                ListViewItem row = new ListViewItem(new[] {
                            cliente.Id.ToString(),
                            cliente.Nome,
                            cliente.Email,
                            cliente.Telefone.ToString(),
                            cliente.Nif.ToString(),
                            cliente.DataNasc.ToString()
                        }); 
                listView2.Items.Add(row);
            }
        }
    }
}
