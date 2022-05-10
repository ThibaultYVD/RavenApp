using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Windows;
using tuto1.view;
using tuto1.ViewModel;

namespace tuto1.view
{
    /// <summary>
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public partial class Ajouter : Window
    {
        MySqlConnection cn = new MySqlConnection("server=localhost;user=root;database=raven;port=3306;password=");

        public Ajouter()
        {
            InitializeComponent();
        }   

        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tb_nomAdd.Text) || String.IsNullOrEmpty(tb_prixAdd.Text) || String.IsNullOrEmpty(tb_imageAdd.Text))
            {
                MessageBox.Show("Il faut renseigner tout les champs !");
            }
            

            else
            {
                string nom = tb_nomAdd.Text;
                int prix = Convert.ToInt32(tb_prixAdd.Text);
                string image = tb_imageAdd.Text;

                MySqlCommand cmd = new MySqlCommand("INSERT INTO produits (nom, prix, image) VALUES (@nom, @prix, @image)", cn);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prix", prix);
                cmd.Parameters.AddWithValue("@image", image);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ajouté");
                }
                catch (SqlException a)
                {
                    Console.WriteLine("Une erreur est survenue " + a.ToString());
                }
                finally
                {
                    cmd.Parameters.Clear();
                    //listBox.ItemsSource = cvm.GetlesProduits();
                    cn.Close();
                }

            }
        }

        private void btn_quitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
