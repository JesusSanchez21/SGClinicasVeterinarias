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
    public partial class FormEmploye :  Form
    {
        public int SQLAction = -1;

        Colaborador colab { get; set; } = null;
        public FormEmploye(int sqlAction, Colaborador colab)
        {
            this.colab = colab;
            SQLAction = sqlAction;
            InitializeComponent();
        }

    

        private void FormEmploye_Load(object sender, EventArgs e)
        {

            switch (SQLAction)
            {
                case SQL_INSERT:
                    Save.Text = "Inserir";
                    break;
                case SQL_UPDATE:
                    Save.Text = "Editar";
                    break;
                case SQL_DELETE:
                    Save.Text = "Remover";
                    break;
                default:
                    MessageBox.Show("Operação não permitida.");
                    break;
            }

        }

        private void Save_Click(object sender, EventArgs e)
        {
            switch (SQLAction)
            {
                case SQL_INSERT:

                    if (FormDataValidation())
                    {
                        FillForm(null);
                        SQLColaboradores.Insert(colab);
                        this.Close();
                    }
                    break;
                    /*
                case SQL_UPDATE:
                    buttonAction.Text = "Editar";
                    if (FormDataValidation())
                    {
                        Employee employee = new Employee(this.employee.Cod, cbName.Text, textBoxDepartment.Text, textBoxPhoneNo.Text);

                        SQLEmployee.Update(employee);
                        this.Close();
                    }
                    break;
                case SQL_DELETE:
                    buttonAction.Text = "Remover";
                    DisableFields();
                    FillForm(employee);

                    var result = MessageBox.Show($"Deseja mesmo eliminar o registo Cod[{employee.Cod}] - {employee.Name}", "Confirmação de remover", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        SQLEmployee.Delete(employee);
                    }
                    this.Close();
                    break;*/
                default:

                    MessageBox.Show("Ação não permitida", "Por favor faça uma ação que seja permitida.",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    break;
            }

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
                 "Campo telefone incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            if (IsNumber(guna2TextBoxNif.Text))
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


        private void FillForm(Colaborador colab)
        {

            //if employee is null jumps out of the method
            if (colab == null)
            {

                this.colab = new Colaborador();

                this.colab.Nome = guna2TextBoxName.Text;
                this.colab.Email = guna2TextBoxEmail.Text;
                this.colab.Funcao = guna2TextBoxFuncion.Text;
                this.colab.TipoColab = char.Parse(TypeWorker.Text);
                this.colab.Nif = int.Parse(guna2TextBoxNif.Text);
                this.colab.Telefone = int.Parse(guna2TextBoxTelefone.Text);

            }

            //fill the employee data
            guna2TextBoxName.Text = this.colab.Nome;
            guna2TextBoxEmail.Text = this.colab.Email;
            guna2TextBoxNif.Text = this.colab.Nif.ToString();
            guna2TextBoxTelefone.Text = this.colab.Telefone.ToString();
        }
        private void DisableFields()
        {
            guna2TextBoxName.Enabled = false;
            guna2TextBoxEmail.Enabled = false;
            guna2TextBoxNif.Enabled = false;
            Date_of_Birth.Enabled = false;
            guna2TextBoxFuncion.Enabled = false;
            guna2DateTimePickerStartedWorkl.Enabled = false;
            TypeWorker.Enabled = false;
            guna2TextBoxTelefone.Enabled = false;
        }
        #endregion
    }
}
