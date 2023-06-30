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
    public partial class Employe : Form
    {
        List<Colaborador> colabs = new List<Colaborador>();

        private Colaborador selectcolab ;

        public Employe()
        {
            InitializeComponent();
        }

        private void Employe_Load(object sender, EventArgs e)
        {

            colabs = SQLColaboradores.getAll();

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

            foreach (Colaborador colab in colabs)
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
           
                    // Limpa a listView
                    listView2.Items.Clear();


                    List<Colaborador> ColabLista = SQLColaboradores.getAll();

                    // Encontra o Cliente
                    Colaborador colab = ColabLista.FirstOrDefault(c => c.Id == id);

                    if (colab != null)
                    {
                        // Adiciona o Cliente a partir da linha
                        ListViewItem row = new ListViewItem(new[]
                        {
                            colab.Id.ToString(),
                            colab.Nome,
                            colab.Email,
                            colab.Telefone.ToString(),
                            colab.Nif.ToString(),
                            colab.DataIniColab.ToString(),
                            colab.TipoColab.ToString(),
                            colab.Funcao.ToString(),
                            colab.DataNasc.ToString()
                        });
                            listView2.Items.Add(row);
                    }
                    else
                    {
                        MessageBox.Show("Cliente não encontrado.");
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
        DialogResult result = MessageBox.Show("Tens a certeza que queres remover este Employe?", "Confirmação", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            // Faz a operação delete
            bool success = SQLColaboradores.deleteEmploye(id);

            if (success)
            {
                MessageBox.Show("employe removido com sucesso.");
                // Remove o cliente
                listView2.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Falha ao remover employe.");
            }
        }
    }

        private void edit_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Employe não selecionado.");
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
            selectcolab = SQLColaboradores.getColaboradorById(id);

            if (selectcolab != null)
            {
                // Display the details in the appropriate input controls
                guna2TextBoxName.Text = selectcolab.Nome;
                guna2TextBoxEmail.Text = selectcolab.Email;
                guna2TextBoxFuncion.Text = selectcolab.Funcao;
                TypeWorker.Text = selectcolab.TipoColab;
                guna2TextBoxTelefone.Text = selectcolab.Telefone.ToString();
                guna2TextBoxNif.Text = selectcolab.Nif.ToString();
                Date_of_Birth.Text = selectcolab.DataNasc.ToString();
            }
            else
            {
                MessageBox.Show("Employe não encontrado.");
            }
        }

        private void confirm_edit_Click(object sender, EventArgs e)
        {
            if (selectcolab == null)
            {
                MessageBox.Show("Selecione na lista o colaborador para Editar.");
                return;
            }

            // Atualiza a informação do cliente
            selectcolab.Nome = guna2TextBoxName.Text;
            selectcolab.Email = guna2TextBoxEmail.Text;
            selectcolab.Funcao = guna2TextBoxFuncion.Text;
            selectcolab.TipoColab = TypeWorker.Text;
            selectcolab.DataNasc = Date_of_Birth.Value;
            selectcolab.DataIniColab = guna2DateTimePickerStartedWorkl.Value;
            if (int.TryParse(guna2TextBoxTelefone.Text, out int telefone))
            {
                selectcolab.Telefone = telefone;
            }
            else
            {
                MessageBox.Show("Telefone inválido.");
                return;
            }

            if (int.TryParse(guna2TextBoxNif.Text, out int Nif))
            {
                selectcolab.Nif = Nif;
            }
            else
            {
                MessageBox.Show("Nif inválido.");
                return;
            }

            // Faz a atualização na base de dados
            bool success = SQLColaboradores.updateColaborador(selectcolab);

            if (success)
            {
                MessageBox.Show("Colaborador editado com sucesso.");
                // Limpa os dados apos atualizar
                guna2TextBoxName.Clear();
                guna2TextBoxEmail.Clear();
                guna2TextBoxFuncion.Clear();
                guna2TextBoxTelefone.Clear();
                guna2TextBoxNif.Clear();

                selectcolab = null;
            }
            else
            {
                MessageBox.Show("Falha ao editar Employe.");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
