using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static SG_ClinicasVeterinarias.Setting.Utils;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS
{
    public partial class FormCliente : Form
    {
        public int SQLAction = -1;


        Cliente clientes { get; set; } = null;

        public FormCliente()
        {
            InitializeComponent();
        }
        #region Utils


        private bool FormDataValidation()
        {
            if (IsEmpty(guna2TextBoxName.Text))
            {
                MessageBox.Show(
                 "Campo nome incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            if (!IsEmail(guna2TextBoxEmail.Text))
            {
                MessageBox.Show(
                 "Campo email incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            if (IsNumber(guna2TextBoxTelefone.Text))
            {
                MessageBox.Show(
                 "Campo Estado incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            if (IsNumber(guna2TextBoxNif.Text))
            {
                MessageBox.Show(
                 "Campo morada incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            return true;
        }


        private void FillForm(Cliente clientes)
        {

            //if employee is null jumps out of the method
            if (clientes == null)
            {

                this.clientes = new Cliente();

                this.clientes.Nome = guna2TextBoxName.Text;
                this.clientes.Email = guna2TextBoxEmail.Text;
                this.clientes.Nif =int.Parse(guna2TextBoxNif.Text);
                this.clientes.Telefone = int.Parse( guna2TextBoxTelefone.Text);

            }

            //fill the employee data
            guna2TextBoxName.Text = this.clientes.Nome;
            guna2TextBoxEmail.Text = this.clientes.Email;
            guna2TextBoxNif.Text = this.clientes.Nif.ToString();
            guna2TextBoxTelefone.Text = this.clientes.Telefone.ToString();
        }
        private void DisableFields()
        {
            guna2TextBoxName.Enabled = false;
            guna2TextBoxEmail.Enabled = false;
            guna2TextBoxNif.Enabled = false;
            guna2TextBoxTelefone.Enabled = false;
        }
        #endregion
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }
    }
}
