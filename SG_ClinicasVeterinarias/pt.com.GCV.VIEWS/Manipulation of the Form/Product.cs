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

namespace SG_ClinicasVeterinarias.pt.com.GCV.VIEWS.Manipulation_of_the_Form
{
    public partial class Product : Form
    {
        List<Produto> produtoslist = new List<Produto>();

        private Produto selectedprodutos;

        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {

            produtoslist = SQLProduto.getAll();

            //Definir colunas
            // Definição dos nomes das colunas
            listView2.Columns[0].Text = "#"; // ID -> sempre escondido
            listView2.Columns[1].Text = "Type of Product";
            listView2.Columns[4].Text = "Description of the product";
            listView2.Columns[3].Text = "Quantity of stock";
            listView2.Columns[2].Text = "Price";
            

            // Definição das colunas da listview. 
            // NOTA: Os valores percentuais da largura das colunas tem de somar 100
            listView2.Columns[0].Width = (15 * listView2.Width) / 100; 
            listView2.Columns[1].Width = (10 * listView2.Width) / 100;
            listView2.Columns[2].Width = (15 * listView2.Width) / 100;
            listView2.Columns[3].Width = (15 * listView2.Width) / 100;
            listView2.Columns[4].Width = (15 * listView2.Width) / 100;

            foreach (Produto produto in produtoslist)
            {
                ListViewItem row = new ListViewItem(new[] {
                            produto.CodProd.ToString(),
                            produto.TipoProd.ToString(),
                            produto.DescProd.ToString(),
                            produto.QuantArmazem.ToString(),
                            produto.PrecoUnit.ToString(),
                        });
                listView2.Items.Add(row);
            }
        
        }

        private void search_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            int codProd;
            if (!int.TryParse(textBoxId.Text, out codProd))
            {
                MessageBox.Show("Insira um valor de id válido.");
                return;
            }

            // Faz a pesquisa
            
                    // Limpa a listView
                    listView2.Items.Clear();


                    List<Produto> ProdutoLista = SQLProduto.getAll();

                    // Encontra o Cliente
                    Produto produto = ProdutoLista.FirstOrDefault(c => c.CodProd == codProd);

                    if (produto != null)
                    {
                        // Adiciona o Cliente a partir da linha
                        ListViewItem row = new ListViewItem(new[]
                        {
                            produto.CodProd.ToString(),
                            produto.TipoProd.ToString(),
                            produto.DescProd.ToString(),
                            produto.QuantArmazem.ToString(),
                            produto.PrecoUnit.ToString(),
                    });
                        listView2.Items.Add(row);
                    }
                    else
                    {
                        MessageBox.Show("Produtos não encontrado.");
                    }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Produtos não selecionado.");
                return;
            }

            // Extrai o id
            int codProd;
            if (!int.TryParse(listView2.SelectedItems[0].SubItems[0].Text, out codProd))
            {
                MessageBox.Show("Id inválido.");
                return;
            }

            // Confirmar o remover
            DialogResult result = MessageBox.Show("Tens a certeza que queres remover este Produtos?", "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Faz a operação delete
                bool success = SQLProduto.Delete(codProd);

                if (success)
                {
                    MessageBox.Show("Produtos removido com sucesso.");
                    // Remove o cliente
                    listView2.SelectedItems[0].Remove();
                }
                else
                {
                    MessageBox.Show("Falha ao remover Produtos.");
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            // Buscar ID à textBox
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Produto não selecionado.");
                return;
            }

            // Extrai id 
            int CodProd;
            if (!int.TryParse(listView2.SelectedItems[0].SubItems[0].Text, out CodProd))
            {
                MessageBox.Show("Id inválido.");
                return;
            }

            // Busca a informação do cliente
            selectedprodutos = SQLProduto.GetById(CodProd);

            if (selectedprodutos != null)
            {
                // Display the details in the appropriate input controls
                guna2TextBoxDesproduct.Text = selectedprodutos.DescProd;
                guna2TextBoxPrice.Text = selectedprodutos.PrecoUnit.ToString();
                guna2TextBoxStock.Text = selectedprodutos.QuantArmazem.ToString();
                guna2TextBoxTypeProduct.Text = selectedprodutos.TipoProd;
            }
            else
            {
                MessageBox.Show("Produto não encontrado.");
            }
        }

        private void confirm_edit_Click(object sender, EventArgs e)
        {
            if (selectedprodutos == null)
            {
                MessageBox.Show("Selecione na lista o produto para Editar.");
                return;
            }

            // Atualiza a informação do cliente
            guna2TextBoxDesproduct.Text = selectedprodutos.DescProd;
            guna2TextBoxTypeProduct.Text = selectedprodutos.TipoProd;

            if (int.TryParse(guna2TextBoxStock.Text, out int quantArm))
            {
                selectedprodutos.QuantArmazem = quantArm;
            }
            else
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            if (int.TryParse(guna2TextBoxPrice.Text, out int Preco))
            {
                selectedprodutos.PrecoUnit = Preco;
            }
            else
            {
                MessageBox.Show("Preço inválido.");
                return;
            }

            // Faz a atualização na base de dados
            bool success = SQLProduto.UpdateProduto(selectedprodutos);

            if (success)
            {
                MessageBox.Show("Produto editado com sucesso.");
                // Limpa os dados apos atualizar
                guna2TextBoxDesproduct.Clear();
                guna2TextBoxTypeProduct.Clear();
                guna2TextBoxPrice.Clear();
                guna2TextBoxStock.Clear();


                selectedprodutos = null;
            }
            else
            {
                MessageBox.Show("Falha ao editar cliente.");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
