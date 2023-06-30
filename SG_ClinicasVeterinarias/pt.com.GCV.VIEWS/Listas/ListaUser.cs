using System;
using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Listas
{
    public partial class ListaUser : Form
    {
        List<User> userlist = new List<User>();
        public ListaUser()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
