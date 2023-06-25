
using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using SG_ClinicasVeterinarias.Setting;
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
        private User user;
        public FormHome(User userLogged)
        {
            this.user = userLogged;
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void formClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCliente formcliente = new FormCliente(Utils.SQL_INSERT,null);
            formcliente.ShowDialog();
           
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
            FormEmploye form = new FormEmploye(Utils.SQL_INSERT,null);
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
