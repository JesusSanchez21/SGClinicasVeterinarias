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

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Manipulation_of_the_Form
{

    public partial class Form1 : Form
    {
         public int Table { get; set; }

        List<Cliente> clienteLista = new List<Cliente>();

        private Cliente selectedCliente;

        public Form1(int table)
        {
            InitializeComponent();
            Table = table;
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

        private void search_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            int id;
            if (!int.TryParse(textBoxId.Text, out id))
            {
                MessageBox.Show("Insira um valor de id válido.");
                return;
            }

            // Faz a pesquisa
            switch (Table)
            {
                case 1:
                    // Limpa a listView
                    listView2.Items.Clear();


                    List<Cliente> clienteLista = SQLClientes.getAll();

                    // Encontra o Cliente
                    Cliente cliente = clienteLista.FirstOrDefault(c => c.Id == id);

                    if (cliente != null)
                    {
                        // Adiciona o Cliente a partir da linha
                        ListViewItem row = new ListViewItem(new[]
                        {
                             cliente.Id.ToString(),
                            cliente.Nome,
                            cliente.Email,
                            cliente.Telefone.ToString(),
                            cliente.Nif.ToString(),
                            cliente.DataNasc.ToString()
                    });
                            listView2.Items.Add(row);
                        }
                        else
                        {
                            MessageBox.Show("Cliente não encontrado.");
                        }
                        break;
                default:

                    break;
            }


        }

        private void Remove_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Cliente não selecionado.");
                return;
            }

            // Extrai o id
            int id;
            if (!int.TryParse(listView2.SelectedItems[0].SubItems[0].Text, out id))
            {
                MessageBox.Show("Id inválido.");
                return;
            }

            // Confirmar o remover
            DialogResult result = MessageBox.Show("Tens a certeza que queres remover este cliente?", "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Faz a operação delete
                bool success = SQLClientes.deleteCliente(id);

                if (success)
                {
                    MessageBox.Show("Cliente removido com sucesso.");
                    // Remove o cliente
                    listView2.SelectedItems[0].Remove();
                }
                else
                {
                    MessageBox.Show("Falha ao remover cliente.");
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Cliente não selecionado.");
                return;
            }

            // Extrai id 
            int id;
            if (!int.TryParse(listView2.SelectedItems[0].SubItems[0].Text, out id))
            {
                MessageBox.Show("Id inválido.");
                return;
            }

            // Busca a informação do cliente
            selectedCliente = SQLClientes.getClienteById(id);

            if (selectedCliente != null)
            {
                // Display the details in the appropriate input controls
                guna2TextBoxName.Text = selectedCliente.Nome;
                guna2TextBoxEmail.Text = selectedCliente.Email;
                guna2TextBoxTelefone.Text = selectedCliente.Telefone.ToString();
                guna2TextBoxNif.Text = selectedCliente.Nif.ToString();
                Date_of_Birth.Text = selectedCliente.DataNasc.ToString();
            }
            else
            {
                MessageBox.Show("Cliente não encontrado.");
            }
        }

        private void confirm_edit_Click(object sender, EventArgs e)
        {
            if (selectedCliente == null)
            {
                MessageBox.Show("Selecione na lista o cliente para Editar.");
                return;
            }

            // Atualiza a informação do cliente
            selectedCliente.Nome = guna2TextBoxName.Text;
            selectedCliente.Email = guna2TextBoxEmail.Text;
            if (int.TryParse(guna2TextBoxTelefone.Text, out int telefone))
            {
                selectedCliente.Telefone = telefone;
            }
            else
            {
                MessageBox.Show("Telefone inválido.");
                return;
            }

            if (int.TryParse(guna2TextBoxNif.Text, out int Nif))
            {
                selectedCliente.Nif = Nif;
            }
            else
            {
                MessageBox.Show("Nif inválido.");
                return;
            }

            // Faz a atualização na base de dados
            bool success = SQLClientes.updateCliente(selectedCliente);

            if (success)
            {
                MessageBox.Show("Cliente editado com sucesso.");
                // Limpa os dados apos atualizar
                guna2TextBoxName.Clear();
                guna2TextBoxEmail.Clear();
                guna2TextBoxTelefone.Clear();
                guna2TextBoxNif.Clear();
                selectedCliente = null;
            }
            else
            {
                MessageBox.Show("Falha ao editar cliente.");
            }
        }
    }
}
