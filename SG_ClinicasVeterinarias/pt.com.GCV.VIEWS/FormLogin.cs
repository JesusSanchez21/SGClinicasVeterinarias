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
using static SG_ClinicasVeterinarias.Setting.Utils;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS
{
    public partial class FormLogin : Form
    {
        private User user = null;
        public FormLogin()
        {
            InitializeComponent();
            
        }


        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox textBox = (Guna.UI2.WinForms.Guna2TextBox)sender;
            textBox.PasswordChar = 'ඞ';
            textBox.UseSystemPasswordChar = true;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
        private bool FormDataValidation()
        {
            if (IsEmpty(textBoxEmail.Text))
            {
                MessageBox.Show(
                "Campo email não pode estar vazio.",
                "Dados Inválidos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
               );
                return false;
            }

            if (!IsEmail(textBoxEmail.Text))
            {
                MessageBox.Show(
                "Campo email não está no formato correto.",
                "Dados Inválidos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
               );
                return false;
            }

            if (IsEmpty(textBoxPassword.Text))
            {
                MessageBox.Show(
                "Campo Password incorreto, por favor coloque corretamente",
                "Dados Inválidos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
               );
                return false;
            }
     
            return true;
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            if (FormDataValidation())
            {
                try
                {
                    this.user = SQLUser.GetUserByEmailAndPassword(new User(textBoxEmail.Text, textBoxPassword.Text));

                    if (user != null)
                    {
                        openMainScreen();
                    }
                    else
                    {
                        MessageBox.Show(
                        "Email ou senha incorretos, por favor verifique.",
                        "Utilizador não encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                       );
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao efetuar o login, entre em contato com o Adm. da aplicação");
                }

            }
        }
        
       private void openMainScreen()
       {
           FormHome FormHome = new FormHome(this.user);
           this.Hide();
           FormHome.ShowDialog();
           this.Show();
       }

        private void SignUp_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            this.Hide();
            formRegister.Show();
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
