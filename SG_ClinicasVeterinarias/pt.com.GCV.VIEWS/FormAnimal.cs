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

        Animal animal { get; set; }

        public FormAnimal()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (FormDataValidation(out Animal animal))
            {
                animal.NomeDono = guna2ComboBoxOwner.Text;
                animal.Raca = guna2TextBoxRace.Text;
                animal.Sexo = char.Parse(guna2ComboBoxSex.Text);
                animal.Peso = int.Parse(guna2TextBoxWeight.Text);
                animal.TipoAnimal = guna2ComboBoxTypeAnimal.Text;
                animal.DataFal = Date_Death.Value;
                animal.DataNasc = Date_of_Birth.Value;
                animal.DataUltimaCons = last_visit.Value;
                

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

