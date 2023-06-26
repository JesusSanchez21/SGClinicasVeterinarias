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
    public partial class User : Form
    {

        List<User> userlist = new List< User>();

        private User selectedUser;
        public User()
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
                            user.Name,
                            user.Email
                        });
                listView2.Items.Add(row);
            }
        }
    }
}
