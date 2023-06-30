using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;
using System.Linq;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Manipulation_of_the_Form
{
    public partial class Users : Form
    {

        public int Table { get; set; }
        List<User> userlist = new List<User>();

        private User selectedUser;
        public Users( int table)
        {
            Table = table;
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {

            userlist = SQLUser.getAll();

            //Definir colunas
            // Definição dos nomes das colunas
            listView2.Columns[0].Text = "#";
            listView2.Columns[1].Text = "Nome";
            listView2.Columns[2].Text = "Email";
            listView2.Columns[3].Text = "Password";


            // Definição das colunas da listview. 
            // NOTA: Os valores percentuais da largura das colunas tem de somar 100
            listView2.Columns[0].Width = (15 * listView2.Width) / 100; // ID -> sempre escondido
            listView2.Columns[1].Width = (10 * listView2.Width) / 100;
            listView2.Columns[2].Width = (15 * listView2.Width) / 100;
            listView2.Columns[3].Width = (15 * listView2.Width) / 100;


            foreach (User user in userlist)
            {
                ListViewItem row = new ListViewItem(new[] {
                            user.Id.ToString(),
                            user.Name.ToString(),
                            user.Email.ToString(),
                            user.Password.ToString()
                        });
                listView2.Items.Add(row);
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("User não selecionado.");
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
            DialogResult result = MessageBox.Show("Tens a certeza que queres remover este User?", "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Faz a operação delete
                bool success = SQLUser.DeleteUser(id);

                if (success)
                {
                    MessageBox.Show("User removido com sucesso.");
                    // Remove o cliente
                    listView2.SelectedItems[0].Remove();
                }
                else
                {
                    MessageBox.Show("Falha ao remover User.");
                }
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


                    List<User> UserList = SQLUser.getAll();

                    // Encontra o user
                    User user = UserList.FirstOrDefault(c => c.Id == id);

                    if (user != null)
                    {
                        // Adiciona o user a partir da linha
                        ListViewItem row = new ListViewItem(new[]
                        {
                    user.Id.ToString(),
                    user.Name,
                    user.Email,
                    user.Password,
                });
                        listView2.Items.Add(row);
                    }
                    else
                    {
                        MessageBox.Show("User não encontrado.");
                    }
                    break;
                default:

                    break;
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
            selectedUser = SQLUser.GetById(id);

            if (selectedUser != null)
            {
                // Display the details in the appropriate input controls
                textBoxName.Text = selectedUser.Name;
                textBoxEmail.Text = selectedUser.Email;
                textBoxPassword.Text = selectedUser.Password;

            }
            else
            {
                MessageBox.Show("Cliente não encontrado.");
            }
        }

        private void confirm_edit_Click(object sender, EventArgs e)
        {
            if (selectedUser == null)
            {
                MessageBox.Show("Selecione na lista o user para Editar.");
                return;
            }

            // Atualiza a informação do cliente
            selectedUser.Name = textBoxName.Text;
            selectedUser.Email = textBoxEmail.Text;
            selectedUser.Password = textBoxPassword.Text;
            

            // Faz a atualização na base de dados
            bool success = SQLUser.UpdateUser(selectedUser);

            if (success)
            {
                MessageBox.Show("User editado com sucesso.");
                // Limpa os dados apos atualizar
                textBoxName.Clear();
                textBoxEmail.Clear();
                textBoxPassword.Clear();
                selectedUser = null;
            }
            else
            {
                MessageBox.Show("Falha ao editar User.");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
