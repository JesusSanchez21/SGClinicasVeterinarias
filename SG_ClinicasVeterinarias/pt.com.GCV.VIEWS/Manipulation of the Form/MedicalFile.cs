﻿using SG_ClinicasVeterinarias.pt.com.GCV.MODEL;
using System.Collections.Generic;
using System.Windows.Forms;
using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Manipulation_of_the_Form
{
    public partial class MedicalFile : Form
    {
        List<Ficha> fichalist = new List<Ficha>();

        private Ficha selectedFicha;

        public MedicalFile()
        {
            InitializeComponent();
        }
        private void MedFile_Load(object sender, EventArgs e)
        {

            fichalist = SQLficha.getAll();

            //Definir colunas
            // Definição dos nomes das colunas
            listView2.Columns[0].Text = "#"; // ID -> sempre escondido
            listView2.Columns[1].Text = "Animal_Id";
            listView2.Columns[2].Text = "Colaborador_Id";
            listView2.Columns[3].Text = "Diagnostico";
            listView2.Columns[4].Text = "Peso";
            listView2.Columns[5].Text = "Observacoes";
            listView2.Columns[6].Text = "Prescricao";
            listView2.Columns[7].Text = "QuantPrescricao";
            listView2.Columns[8].Text = "ProxVisita";


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

            foreach (Ficha ficha in fichalist)
            {
                ListViewItem row = new ListViewItem(new[] {
                            ficha.Id.ToString(),
                            ficha.Animal_Id.ToString(),
                            ficha.Colaborador_Id.ToString(),
                            ficha.Diagnostico.ToString(),
                            ficha.Peso.ToString(),
                            ficha.Observacoes.ToString(),
                            ficha.Prescricao.ToString(),
                            ficha.QuantPrescricao.ToString(),
                        });
                listView2.Items.Add(row);
            }

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


                    List<Ficha> fichaLista = SQLficha.getAll();

                    // Encontra a ficha
                    Ficha ficha = fichaLista.FirstOrDefault(c => c.Id == id);

                    if (ficha != null)
                    {
                        // Adiciona a ficha a partir da linha
                        ListViewItem row = new ListViewItem(new[]
                        {
                            ficha.Id.ToString(),
                            ficha.Animal_Id.ToString(),
                            ficha.Colaborador_Id.ToString(),
                            ficha.Diagnostico.ToString(),
                            ficha.Peso.ToString(),
                            ficha.Observacoes,
                            ficha.Prescricao,
                            ficha.QuantPrescricao.ToString(),
                    });
                        listView2.Items.Add(row);
                    }
                    else
                    {
                        MessageBox.Show("Ficha não encontrada.");
                    }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Ficha não selecionada.");
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
            DialogResult result = MessageBox.Show("Tens a certeza que queres remover esta ficha?", "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Faz a operação delete
                bool success = SQLClientes.deleteCliente(id);

                if (success)
                {
                    MessageBox.Show("Ficha removida com sucesso.");
                    // Remove o cliente
                    listView2.SelectedItems[0].Remove();
                }
                else
                {
                    MessageBox.Show("Falha ao remover ficha.");
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Ficha não selecionado.");
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
            selectedFicha = SQLficha.GetById(id);

            if (selectedFicha != null)
            {
                // Display the details in the appropriate input controls
                guna2ComboBoxIdAnimal.Text = selectedFicha.Animal_Id.ToString();
                guna2ComboBoxIdColab.Text = selectedFicha.Colaborador_Id.ToString();
                guna2TextBoxQnt.Text = selectedFicha.QuantPrescricao.ToString();
                guna2TextBoxPresciprtion.Text = selectedFicha.Prescricao.ToString();
                Observation.Text = selectedFicha.Observacoes.ToString();
                Diagnosis.Text = selectedFicha.Diagnostico.ToString();
            }
            else
            {
                MessageBox.Show("Ficha não encontrada.");
            }
        }

        private void confirm_edit_Click(object sender, EventArgs e)
        {
            if (selectedFicha == null)
            {
                MessageBox.Show("Selecione na lista a ficha para Editar.");
                return;
            }

            // Atualiza a informação do ficha
            
            selectedFicha.Prescricao = guna2TextBoxPresciprtion.Text;
            selectedFicha.Observacoes = Observation.Text;
            selectedFicha.Diagnostico = Diagnosis.Text;
            
            if (int.TryParse(guna2TextBoxQnt.Text, out int quantPresc))
            {
                selectedFicha.QuantPrescricao = quantPresc;
            }
            else
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            if (int.TryParse(guna2ComboBoxIdAnimal.Text, out int animalId))
            {
                selectedFicha.Animal_Id = animalId;
            }
            else
            {
                MessageBox.Show("Animal_Id inválido.");
                return;
            }
            if (int.TryParse(guna2ComboBoxIdColab.Text, out int idColab))
            {
                selectedFicha.Colaborador_Id = idColab;
            }
            else
            {
                MessageBox.Show("Colaborador_Id inválido.");
                return;
            }
            if (int.TryParse(guna2TextBox2.Text, out int peso))
            {
                selectedFicha.Peso = peso;
            }
            else
            {
                MessageBox.Show("Peso inválido.");
                return;
            }

            // Faz a atualização na base de dados
            bool success = SQLficha.UpdateFicha(selectedFicha);

            if (success)
            {
                MessageBox.Show("Ficha editada com sucesso.");
                // Limpa os dados apos atualizar
                guna2TextBox2.Clear();
                guna2TextBoxPresciprtion.Clear();
                guna2TextBoxQnt.Clear();
                Diagnosis.Clear();
                Observation.Clear();

                selectedFicha = null;
            }
            else
            {
                MessageBox.Show("Falha ao editar ficha.");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
