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
using System.Windows.Forms;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Listas
{
    public partial class ListaAnimal : Form
    {
        List<Animal> animallist = new List<Animal>();
        public ListaAnimal()
        {
            InitializeComponent();
        }

        private void ListaAnimal_Load(object sender, EventArgs e)
        {

            animallist = SQLAnimais.getAll();

            //Definir colunas
            // Definição dos nomes das colunas     , , , , , , , 
            listView2.Columns[0].Text = "#"; // ID -> sempre escondido
            listView2.Columns[1].Text = "nomeDono";
            listView2.Columns[2].Text = "dataNasc";
            listView2.Columns[3].Text = "dataFal";
            listView2.Columns[4].Text = "dataUltimaCons";
            listView2.Columns[5].Text = "tipoAnimal";
            listView2.Columns[6].Text = "raca";
            listView2.Columns[7].Text = "sexo";
            listView2.Columns[8].Text = "peso";


            // Definição das colunas da listview. 
            // NOTA: Os valores percentuais da largura das colunas tem de somar 100
            listView2.Columns[0].Width = (15 * listView2.Width) / 100;
            listView2.Columns[1].Width = (10 * listView2.Width) / 100;
            listView2.Columns[2].Width = (15 * listView2.Width) / 100;
            listView2.Columns[3].Width = (15 * listView2.Width) / 100;
            listView2.Columns[4].Width = (15 * listView2.Width) / 100;
            listView2.Columns[5].Width = (15 * listView2.Width) / 100;
            listView2.Columns[6].Width = (15 * listView2.Width) / 100;
            listView2.Columns[7].Width = (15 * listView2.Width) / 100;
            listView2.Columns[8].Width = (15 * listView2.Width) / 100;

            foreach (Animal animal in animallist)
            {
                ListViewItem row = new ListViewItem(new[] {
                            animal.Id.ToString(),
                            animal.NomeDono.ToString(),
                            animal.DataNasc.ToString(),
                            animal.DataFal.ToString(),
                            animal.DataUltimaCons.ToString(),
                            animal.TipoAnimal.ToString(),
                            animal.Raca.ToString(),
                            animal.Sexo.ToString(),
                            animal.Peso.ToString(),
                        });
                listView2.Items.Add(row);
            }
        }
    }
}
