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
        Produto produtos { get; set; }
        public FormProduto(int sqlAction, Produto produtos)
        {
            this.produtos = produtos;
            InitializeComponent();
        }

        private void FormProduto_Load(object sender, EventArgs e)
        {

          Save.Text = "Insert";

        }

        private void FillForm(Produto produtos)
        {

            //if product is null jumps out of the method
            if (produtos == null)
            {

                this.produtos = new Produto();

                this.produtos.TipoProd = guna2TextBoxTypeProduct.Text;
                this.produtos.DescProd = guna2TextBoxDesproduct.Text;
                this.produtos.PrecoUnit = int.Parse(guna2TextBoxPrice.Text);
                this.produtos.QuantArmazem = int.Parse(guna2TextBoxStock.Text);

            }

            //fill the product data
            guna2TextBoxTypeProduct.Text = this.produtos.TipoProd;
            guna2TextBoxDesproduct.Text = this.produtos.DescProd;
            guna2TextBoxPrice.Text = this.produtos.PrecoUnit.ToString();
            guna2TextBoxStock.Text = this.produtos.QuantArmazem.ToString();
        }
        private void DisableFields()
        {
            guna2TextBoxTypeProduct.Enabled = false;
            guna2TextBoxDesproduct.Enabled = false;
            guna2TextBoxPrice.Enabled = false;
            guna2TextBoxStock.Enabled = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (FormDataValidation(out Produto produtos))
            {
                produtos.TipoProd = guna2TextBoxTypeProduct.Text;
                produtos.PrecoUnit = int.Parse(guna2TextBoxPrice.Text);
                produtos.DescProd = guna2TextBoxDesproduct.Text;
                produtos.QuantArmazem = int.Parse(guna2TextBoxStock.Text);

                SQLProduto.Insert(produtos);
            }
            MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #region Utils
        private bool FormDataValidation(out Produto produtos)
        {
            produtos = new Produto();
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

            if (!IsNumber(guna2TextBoxStock.Text))
            {
                MessageBox.Show(
                 "Campo TextBoxstock incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            if (!IsNumber(guna2TextBoxPrice.Text))
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




        #endregion

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
