using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using static SG_ClinicasVeterinarias.pt.com.GCV.DAO.SqLConnection;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Manipulation_of_the_Form
{
    public partial class Users : Form
    {

        List<User> userlist = new List<User>();

        private User selectedUser;
        public Users()
        {
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


            // Definição das colunas da listview. 
            // NOTA: Os valores percentuais da largura das colunas tem de somar 100
            listView2.Columns[0].Width = (15 * listView2.Width) / 100; // ID -> sempre escondido
            listView2.Columns[1].Width = (10 * listView2.Width) / 100;
            listView2.Columns[2].Width = (15 * listView2.Width) / 100;


            foreach (User user in userlist)
            {
                ListViewItem row = new ListViewItem(new[] {
                            user.Id.ToString(),
                            user.Name.ToString(),
                            user.Email.ToString()
                        });
                listView2.Items.Add(row);
            }
        }
    }
}
