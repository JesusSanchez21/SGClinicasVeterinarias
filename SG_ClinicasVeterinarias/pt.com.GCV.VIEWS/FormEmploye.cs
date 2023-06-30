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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static SG_ClinicasVeterinarias.Setting.Utils;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS
{
    public partial class FormEmploye : Form
    {
        public int SQLAction = -1;

        Colaborador colab { get; set; }

        public FormEmploye()
        {
            InitializeComponent();
        }


        private void Save_Click(object sender, EventArgs e)
        {
            if (FormDataValidation(out Colaborador colab))
            {
                colab.TipoColab = TypeWorker.Text;
                colab.Email = guna2TextBoxEmail.Text;
                colab.Nome = guna2TextBoxName.Text;
                colab.Telefone = int.Parse(guna2TextBoxTelefone.Text);
                colab.Funcao = guna2TextBoxFuncion.Text;
                colab.Nif = int.Parse(guna2TextBoxNif.Text);
                colab.DataIniColab = guna2DateTimePickerStartedWorkl.Value;
                colab.DataNasc = Date_of_Birth.Value;


                SQLColaboradores.Insert(colab);
            }
            MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #region Utils


        private bool FormDataValidation(out Colaborador colab)
        {
            colab = new Colaborador();

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

            if (!IsNumber(guna2TextBoxTelefone.Text))
            {
                MessageBox.Show(
                 "Campo telefone incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            if (!IsNumber(guna2TextBoxNif.Text))
            {
                MessageBox.Show(
                 "Campo Nif incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            return true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
#endregion