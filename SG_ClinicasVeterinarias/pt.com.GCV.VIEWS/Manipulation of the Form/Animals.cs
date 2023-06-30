using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Manipulation_of_the_Form
{
    public partial class Animals : Form
    {
        SQLClientes SQLClientes = new SQLClientes();
        List<Animal> animallist = new List<Animal>();

        private Animal selectedanimal;

        public Animals()
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
        

        private void search_Click(object sender, EventArgs e)
        {

            // Buscar ID à textBox
            int id;
            if (!int.TryParse(textBoxId.Text, out id))
            {
                MessageBox.Show("Insira um valor de id válido.");
                return;
            }

            // Faz a pesquisa

                    // Limpa a listView
                    listView2.Items.Clear();


                    List<Animal> animalList = SQLAnimais.getAll();

                    // Encontra o Cliente
                    Animal animal = animalList.FirstOrDefault(c => c.Id == id);

                    if (animal != null)
                    {
                        // Adiciona o Cliente a partir da linha
                        ListViewItem row = new ListViewItem(new[]
                        {
                            animal.Id.ToString(),
                            animal.NomeDono,
                            animal.DataNasc.ToString(),
                            animal.DataFal.ToString(),
                            animal.DataUltimaCons.ToString(),
                            animal.TipoAnimal.ToString(),
                            animal.Raca,
                            animal.Sexo.ToString(),
                            animal.Peso.ToString()
                    });
                        listView2.Items.Add(row);
                    }
                    else
                    {
                        MessageBox.Show("animal não encontrado.");
                    }
            
        }

        private void Remove_Click(object sender, EventArgs e)
        {

            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("animal não selecionado.");
                return;
            }

            // Extrai o id
            int id;
            if (!int.TryParse(listView2.SelectedItems[0].SubItems[0].Text, out id))
            {
                MessageBox.Show("Id inválido.");
                return;
            }

            // Confirmar o remover
            DialogResult result = MessageBox.Show("Tens a certeza que queres remover este animal?", "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Faz a operação delete
                bool success = SQLAnimais.Delete(id);

                if (success)
                {
                    MessageBox.Show("Animal removido com sucesso.");
                    // Remove o cliente
                    listView2.SelectedItems[0].Remove();
                }
                else
                {
                    MessageBox.Show("Falha ao remover Animal.");
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {

            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Animal não selecionado.");
                return;
            }

            // Extrai id 
            int id;
            if (!int.TryParse(listView2.SelectedItems[0].SubItems[0].Text, out id))
            {
                MessageBox.Show("Id inválido.");
                return;
            }

            // Busca a informação do cliente
            selectedanimal = SQLAnimais.GetById(id);

            if (selectedanimal != null)
            {
                // Display the details in the appropriate input controls
                guna2ComboBoxOwner.Text = selectedanimal.NomeDono;
                guna2ComboBoxTypeAnimal.Text = selectedanimal.TipoAnimal;
                guna2TextBoxRace.Text = selectedanimal.Raca;
                guna2ComboBoxSex.Text = selectedanimal.Sexo.ToString();
                guna2TextBoxWeight.Text = selectedanimal.Peso.ToString();
                Date_of_Birth.Text = selectedanimal.DataNasc.ToString();
                Date_Death.Text = selectedanimal.DataFal.ToString();
                last_visit.Text = selectedanimal.DataUltimaCons.ToString();
            }
            else
            {
                MessageBox.Show("Animal não encontrado.");
            }
        }

        private void confirm_edit_Click(object sender, EventArgs e)
        {

            if (selectedanimal == null)
            {
                MessageBox.Show("Selecione na lista o animais para Editar.");
                return;
            }

            // Atualiza a informação do cliente
            selectedanimal.NomeDono = guna2ComboBoxOwner.Text;
            selectedanimal.DataNasc = Date_of_Birth.Value;
            selectedanimal.DataFal = Date_Death.Value;
            selectedanimal.DataUltimaCons = last_visit.Value;
            selectedanimal.TipoAnimal = guna2ComboBoxTypeAnimal.Text;
            selectedanimal.Raca = guna2TextBoxRace.Text;
            selectedanimal.Sexo = guna2ComboBoxSex.Text;
            if (int.TryParse(guna2TextBoxWeight.Text, out int weight))
            {
                selectedanimal.Peso = weight;
            }
            else
            {
                MessageBox.Show("weight inválido.");
                return;
            }


            // Faz a atualização na base de dados
            bool success = SQLAnimais.UpdateAnimal(selectedanimal);

            if (success)
            {
                MessageBox.Show("Animal editado com sucesso.");
                // Limpa os dados apos atualizar
                guna2TextBoxRace.Clear();
                guna2TextBoxWeight.Clear();

                selectedanimal = null;
            }
            else
            {
                MessageBox.Show("Falha ao editar Animal.");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Animals_Load(object sender, EventArgs e)
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
