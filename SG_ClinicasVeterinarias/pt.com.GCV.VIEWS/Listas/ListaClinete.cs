using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Listas
{
    public partial class ListaClinete : Form
    {
        List<Cliente> clienteLista = new List<Cliente>();

        public ListaClinete()
        {

            InitializeComponent();
        }

        private void ListaClinete_Load(object sender, EventArgs e)
        {
           
                    clienteLista = SQLClientes.getAll();
                    //Definir colunas
                    // Definição dos nomes das colunas
                    listView2.Columns[0].Text = "ID";
                    listView2.Columns[1].Text = "Nome";
                    listView2.Columns[2].Text = "Email";
                    listView2.Columns[3].Text = "Telefone";
                    listView2.Columns[4].Text = "Date of birth";
                    listView2.Columns[5].Text = "Nif";


                    // Definição das colunas da listview. 
                    // NOTA: Os valores percentuais da largura das colunas tem de somar 100
                    listView2.Columns[0].Width = (15 * listView2.Width) / 100; // ID -> sempre escondido
                    listView2.Columns[1].Width = (10 * listView2.Width) / 100;
                    listView2.Columns[2].Width = (15 * listView2.Width) / 100;
                    listView2.Columns[3].Width = (15 * listView2.Width) / 100;
                    listView2.Columns[4].Width = (15 * listView2.Width) / 100;
                    listView2.Columns[5].Width = (15 * listView2.Width) / 100;

                    foreach (Cliente cliente in clienteLista)
                    {
                        ListViewItem row = new ListViewItem(new[] {
                            cliente.Id.ToString(),
                            cliente.Nome,
                            cliente.Email,
                            cliente.Telefone.ToString(),
                            cliente.DataNasc.ToShortDateString(),
                            cliente.Nif.ToString()
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
