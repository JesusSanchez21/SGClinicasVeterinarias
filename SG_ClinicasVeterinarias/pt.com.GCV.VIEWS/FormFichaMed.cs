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
    public partial class FormFichaMed : Form
    {
        public int SQLAction = -1;

        Ficha ficha { get; set; }

        public FormFichaMed()
        {
            InitializeComponent();
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
                ficha.ProxVisita = NextVisit.Value;


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
    }
}
