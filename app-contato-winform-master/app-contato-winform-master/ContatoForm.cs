using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppContatoForm
{
    public partial class ContatoForm : Form
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public ContatoForm()
        {
            InitializeComponent();

            Conexao();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

          conexao.Open();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            try
            {
                if (!rdSexo1.Checked && !rdSexo2.Checked)
                {
                    MessageBox.Show("Marque uma opção");  
                }
                else
                {

                }
                var nome = txtNome.Text;
                var email = txtEmail.Text;
                var data_nasc = dateDataNascimento.Text;
                var sexo = rdSexoGroup.Text;
                var telefone = txtTelefone.Text;

                if (rdSexo1.Checked)
                {
                    sexo = "mascolino";
                }

                string query = "INSERT INTO contato (nome_con, email_con, data_nasc_con, sexo_con, telefone_con) VALUES (@_nome, @_email, @_data_nasc, @_sexol, @_telefone)";
                var comando = new MySqlCommand(query, conexao);

                comando.Parameters.AddWithValue("@_nome", nome);
                comando.Parameters.AddWithValue("@_email", email);
                comando.Parameters.AddWithValue("@_data_nasc", data_nasc);
                comando.Parameters.AddWithValue("@_sexol", sexo);
                comando.Parameters.AddWithValue("@_telefone", telefone);

                comando.ExecuteNonQuery();
               
                txtEmail.Clear();
                txtTelefone.Clear();
                txtNome.Clear();
                dateDataNascimento.Clear();
                rdSexo1.Checked = false;
                rdSexo2.Checked = false;
                 txtNome.Focus();


            }catch(Exception ex){

             // MessageBox.Show("$ Ocorreram erros ao tentar salvar os dadows $ Contate o suporte do sistema. (CAD 25)");

                MessageBox.Show(ex.Message);
            }

        }

        private void limparinputs()
        { 
        
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }