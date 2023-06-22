using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
           
        }

        private void formAnimalsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAnimal form = new FormAnimal();
            form.ShowDialog();
        }

        private void formEmployeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEmploye form = new FormEmploye();
            form.ShowDialog();
        }

        private void formProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProduto form = new FormProduto();
            form.ShowDialog();
        }

        private void formMedicalRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFichaMed form = new FormFichaMed();
            form.ShowDialog();
        }
    }
}
