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
using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS
{
    public partial class FormFichaMed : Form
    {
        /*SQLAnimais = new SQLAnimais();
        SQLColaboradores = new SQLColaboradores();
        */
         Ficha ficha { get; set; }

        public FormFichaMed()
        {
            InitializeComponent();
            /*

            guna2ComboBoxIdAnimal.DataSource = SQLAnimais.getAll();
            //define nome no form
            guna2ComboBoxIdAnimal.DisplayMember = "idAnimal";
            //valor do item selecionado
            guna2ComboBoxIdAnimal.ValueMember = "id";

            //obter valor selecionado
            var selectedValue1 = guna2ComboBoxIdAnimal.SelectedValue;
            
            guna2ComboBoxIdColab.DataSource = SQLColaboradores.getAll();
            //define nome no form
            guna2ComboBoxIdColab.DisplayMember = "idColab";
            //valor do item selecionado
            guna2ComboBoxIdColab.ValueMember = "id";

            //obter valor selecionado
            var selectedValue2 = guna2ComboBoxIdColab.SelectedValue; */
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (FormDataValidation(out Ficha ficha))
            {
                ficha.Animal_Id = guna2ComboBoxIdAnimal.SelectedIndex;
                ficha.Colaborador_Id = guna2ComboBoxIdColab.SelectedIndex;
                ficha.Diagnostico = Diagnosis.Text;
                ficha.Peso = int.Parse(guna2TextBoxWeight.Text);
                ficha.Observacoes = Observation.Text;
                ficha.Prescricao = guna2TextBoxPresciprtion.Text;
                ficha.QuantPrescricao = int.Parse(guna2TextBoxQnt.Text);


                SQLficha.Insert(ficha);
            }
            MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool FormDataValidation(out Ficha ficha)
        {
            ficha = new Ficha();

            if (IsEmpty(Diagnosis.Text))
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
            if (!IsNumber(guna2TextBoxQnt.Text))
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
