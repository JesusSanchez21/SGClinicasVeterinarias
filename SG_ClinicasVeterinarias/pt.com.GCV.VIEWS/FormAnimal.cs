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
    public partial class FormAnimal : Form
    {
        public int SQLAction = -1;
        SQLClientes SQLClientes = new SQLClientes();
        Animal animal { get; set; }

        public FormAnimal()
        {
            InitializeComponent();

            guna2ComboBoxOwner.DataSource = SQLClientes.getAll();
            //define nome no form
            guna2ComboBoxOwner.DisplayMember = "Name";
            //valor do item selecionado
            guna2ComboBoxOwner.ValueMember = "nome";

            //obter valor selecionado
            var selectedValue = guna2ComboBoxOwner.SelectedValue;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (FormDataValidation(out Animal animals))
            {
                animals.NomeDono = guna2ComboBoxOwner.Text;
                animals.Raca = guna2TextBoxRace.Text;
                animals.Sexo = char.Parse( guna2ComboBoxSex.Text.ToString().Substring(0,1));
                animals.Peso = int.Parse(guna2TextBoxWeight.Text);
                animals.TipoAnimal = guna2ComboBoxTypeAnimal.Text;
                animals.DataFal = Date_Death.Value;
                animals.DataNasc = Date_of_Birth.Value;
                animals.DataUltimaCons = last_visit.Value;
                

                SQLAnimais.Insert(animal);
            }
            MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool FormDataValidation(out Animal animal)
        {
            animal = new Animal();
            if (IsEmpty(guna2ComboBoxOwner.Text))
            {
                MessageBox.Show(
                 "Campo nome incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );
                return false;

            }

            if (!IsNumber(guna2TextBoxWeight.Text))
            {
                MessageBox.Show(
                 "Campo telefone incorreto, por favor coloque corretamente",
                 "Dados Inválidos",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                );

                return false;
            }

            return true;
        }
    }
}

