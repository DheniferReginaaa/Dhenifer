using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica interna para WindowConsulta.xaml
    /// </summary>
    public partial class WindowConsulta : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public WindowConsulta()
        {
            InitializeComponent();
            Conexao();
            carregarDados();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }



        private void carregarDados()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from contato", conexao);
            var reader = cmd.ExecuteReader();

            List<Object> lista = new List<Object>();

            while (reader.Read())
            {
                var contato = new
                {
                    Nome = reader.GetString(1),
                    Data = reader.GetString(2),
                    Sexo = reader.GetString(3), 
                    Email = reader.GetString(4),
                    Telefone = reader.GetString(5), 
                };

                lista.Add(contato);
            }

            dgvContato.ItemsSource = lista;
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            carregarDados();
        }
    }
}
