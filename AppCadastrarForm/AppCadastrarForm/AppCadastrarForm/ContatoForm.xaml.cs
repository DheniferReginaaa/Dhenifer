using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppContatoForm
{
    /// <summary>
    /// Lógica interna para ContatoForm.xaml
    /// </summary>
    public partial class ContatoForm : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public ContatoForm()
        {
            InitializeComponent();
            Conexao();
            txtNome.Focus();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataNasc = dtpDataNasc.SelectedDate;

                bool _rdSexo1 = (bool) rdSexo1.IsChecked;
                var _rdSexo2 = (bool) rdSexo2.IsChecked;


                if (!(bool)rdSexo1.IsChecked && !(bool)rdSexo2.IsChecked)
                {
                    MessageBox.Show("Marque uma opção");
                }
                else
                {
                    var nome = txtNome.Text;

                    var sexo = "Feminino";
                    var telefone = txtTelefone.Text;
                    var email = txtEmail.Text;


                    if ((bool)rdSexo1.IsChecked)
                    {
                        sexo = "Masculino";
                    }


                    string query = "INSERT INTO Contato (nome_con, sexo_con, email_con, data_nasc_con, telefone_con) VALUES (@_nome, @_email, @sexo, @_data, @_telefone)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@sexo", sexo);
                    comando.Parameters.AddWithValue("@_data", dataNasc);
                    comando.Parameters.AddWithValue("@_telefone", telefone);

                    comando.ExecuteNonQuery();

                    txtNome.Clear();
                    dtpDataNasc.IsEnabled = false;
                    rdSexoGroup.Focus();
                    txtEmail.Clear();
                    txtTelefone.Clear();
                    rdSexo1.IsChecked = false;
                    rdSexo2.IsChecked = false;
                    txtNome.Focus();

                    var opcao = MessageBox.Show("Salvo com sucesso!\n" +
                        "Deseja realizar um novo cadastro?", "Informação",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);


                    if (opcao == MessageBoxResult.Yes)
                    {
                        LimparInputs();
                    }
                    else
                    {
                        this.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Ocorreram erros ao tentar salvar os dados! " +
                // $"Contate o suporte do sistema. (CAD 25)");

                MessageBox.Show(ex.Message);
            }

        }

        private void LimparInputs()
        {

        }
    }
}
