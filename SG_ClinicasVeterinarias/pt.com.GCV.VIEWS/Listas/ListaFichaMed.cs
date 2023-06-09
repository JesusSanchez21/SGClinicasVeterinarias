﻿using SG_ClinicasVeterinarias.pt.com.GCV.CONEXAO;
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
    public partial class ListaFichaMed : Form
    {
        List<Ficha> fichalist = new List<Ficha>();
        public ListaFichaMed()
        {
            InitializeComponent();
        }

        private void ListaFichaMed_Load(object sender, EventArgs e)
        {

            fichalist = SQLficha.getAll();

            //Definir colunas
            // Definição dos nomes das colunas
            listView2.Columns[0].Text = "#"; // ID -> sempre escondido
            listView2.Columns[1].Text = "Animal_Id";
            listView2.Columns[2].Text = "Colaborador";
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
                            ficha.ColabNome.ToString(),
                            ficha.Diagnostico.ToString(),
                            ficha.Peso.ToString(),
                            ficha.Observacoes.ToString(),
                            ficha.Prescricao.ToString(),
                            ficha.QuantPrescricao.ToString(),
                            ficha.ProxVisita.ToString(),
                        });
                listView2.Items.Add(row);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
