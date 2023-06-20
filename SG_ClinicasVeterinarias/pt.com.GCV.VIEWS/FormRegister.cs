using System;
using System.Data.Common;
using System.Windows.Forms;
using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using SG_ClinicasVeterinarias.pt.com.GCV.DAO;
using Guna.UI2.WinForms;


namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

            Guna.UI2.WinForms.Guna2TextBox textBox = (Guna.UI2.WinForms.Guna2TextBox)sender;
            textBox.PasswordChar = 'ඞ';
            textBox.UseSystemPasswordChar = true;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox textBox = (Guna.UI2.WinForms.Guna2TextBox)sender;
            textBox.PasswordChar = 'ඞ';
            textBox.UseSystemPasswordChar = true;

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            
        }
    }
}
