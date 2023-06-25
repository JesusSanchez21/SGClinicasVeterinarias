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
    public partial class FormProduto : Form
    {
        public int SQLAction = -1;
        Produto products { get; set; } = null;
        public FormProduto(int sqlAction, Produto products)
        {
            this.products = products;
            SQLAction = sqlAction;
            InitializeComponent();
        }

        private void FormProduto_Load(object sender, EventArgs e)
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
                        SQLProduto.Insert(products);
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
            if (IsEmpty(guna2TextBoxTypeProduct.Text))
            {
                MessageBox.Show(
                 "Campo TextBox Type Product está vazio, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            if (IsEmpty(guna2TextBoxDesproduct.Text))
            {
                MessageBox.Show(
                 "Campo TextBox descripção produtos está vazio , por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            if (IsNumber(guna2TextBoxStock.Text))
            {
                MessageBox.Show(
                 "Campo TextBoxstock incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            if (IsNumber(guna2TextBoxPrice.Text))
            {
                MessageBox.Show(
                 "Campo TextBoxPrice incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            return true;
        }


        private void FillForm(Produto products)
        {

            //if employee is null jumps out of the method
            if (products == null)
            {

                this.products = new Produto();

                this.products.TipoProd = guna2TextBoxTypeProduct.Text;
                this.products.DescProd = guna2TextBoxDesproduct.Text;
                this.products.PrecoUnit = int.Parse(guna2TextBoxPrice.Text);
                this.products.QuantArmazem = int.Parse(guna2TextBoxStock.Text);

            }

            //fill the employee data
            guna2TextBoxTypeProduct.Text = this.products.TipoProd;
            guna2TextBoxDesproduct.Text = this.products.DescProd;
            guna2TextBoxPrice.Text = this.products.PrecoUnit.ToString();
            guna2TextBoxStock.Text = this.products.QuantArmazem.ToString();
        }
        private void DisableFields()
        {
            guna2TextBoxTypeProduct.Enabled = false;
            guna2TextBoxDesproduct.Enabled = false;
            guna2TextBoxPrice.Enabled = false;
            guna2TextBoxStock.Enabled = false;
        }
        #endregion
    }
}
