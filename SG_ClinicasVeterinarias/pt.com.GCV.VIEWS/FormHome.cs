
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
using SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Listas;
using SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Manipulation_of_the_Form;
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
            FormEmploye form = new FormEmploye();
            form.ShowDialog();
        }

        private void formProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProduto form = new FormProduto(Utils.SQL_INSERT, null);
            form.ShowDialog();
        }

        private void formMedicalRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFichaMed form = new FormFichaMed();
            form.ShowDialog();
        }

        private void listClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
           ListaClinete form = new ListaClinete();
            form.ShowDialog();
        }

        private void listUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaUser form = new ListaUser();
            form.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users form = new Users(1);
            form.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1(1);
            form.ShowDialog();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product form = new Product();
            form.ShowDialog();
        }

        private void medicalFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MedicalFile form = new MedicalFile();
            form.ShowDialog();
        }

        private void employesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employe form = new Employe();
            form.ShowDialog();
        }

        private void animalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Animals form = new Animals();
            form.ShowDialog();
        }
    }
}
