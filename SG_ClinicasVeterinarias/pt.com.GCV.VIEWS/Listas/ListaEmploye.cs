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
    public partial class ListaEmploye : Form
    {
        List<Colaborador> colablist = new List<Colaborador>();
        public ListaEmploye()
        {
            InitializeComponent();
        }

        private void ListaEmploye_Load(object sender, EventArgs e)
        {

            colablist = SQLColaboradores.getAll();

            //Definir colunas
            // Definição dos nomes das colunas
            listView2.Columns[0].Text = "#";
            listView2.Columns[1].Text = "Nome";
            listView2.Columns[2].Text = "Date of birth";
            listView2.Columns[3].Text = "Nif";
            listView2.Columns[4].Text = "Function";
            listView2.Columns[5].Text = "Start Date";
            listView2.Columns[6].Text = "Telefone";
            listView2.Columns[7].Text = "Email";
            listView2.Columns[8].Text = "Type of Employe";

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

            foreach (Colaborador colab in colablist)
            {
                ListViewItem row = new ListViewItem(new[] {
                            colab.Id.ToString(),
                            colab.Nome,
                            colab.DataNasc.ToString(),
                            colab.Nif.ToString(),
                            colab.Funcao,
                            colab.DataIniColab.ToString(),
                            colab.Telefone.ToString(),
                            colab.Email,
                            colab.TipoColab.ToString()
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
