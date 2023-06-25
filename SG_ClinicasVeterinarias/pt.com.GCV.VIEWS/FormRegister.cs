using System;
using System.Data.Common;
using System.Windows.Forms;
using  SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using static SG_ClinicasVeterinarias.Setting.Utils;
using SG_ClinicasVeterinarias.pt.com.GCV.DAO;
using Guna.UI2.WinForms;
using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormDataValidation())
                {
                    User user = new User(
                        -1,
                        textBoxName.Text,
                        textBoxEmail.Text,
                        textBoxPassword.Text
                    );

                    SQLUser.Insert(user);
                    var result = MessageBox.Show("Utilizador inserido com sucesso!",
                        "Conta registada", MessageBoxButtons.OK, MessageBoxIcon.None);

                    if (result == DialogResult.OK)
                    {
                        this.Close();
                        FormHome form = new FormHome(user);
                        form.ShowDialog();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                "Utilizador não inserido, por favor contate o administrador de sistema",
                "Utilizador não inserido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
               );
            }
        }
        #region formValidation
        private bool FormDataValidation()
        {
            if (IsEmpty(textBoxName.Text))
            {
                MessageBox.Show(
                "Campo nome não pode estar vazio.",
                "Dados Inválidos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
               );
                return false;
            }


            if (IsNumber(textBoxName.Text))
            {
                MessageBox.Show(
                 "Campo nome incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );
                return false;
            }


            if (!IsEmail(textBoxEmail.Text))
            {
                MessageBox.Show(
                 "Campo email incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );
                return false;
            }


            if (!IsEmail(textBoxEmail.Text))
            {
                MessageBox.Show(
                 "Campo email incorreto, por favor coloque corretamente",
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
        #endregion
    }
}
