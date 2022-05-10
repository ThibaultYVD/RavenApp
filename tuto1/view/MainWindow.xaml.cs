using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using tuto1.view;
using tuto1.ViewModel;

namespace tuto1.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        private string login = "admin";
        private string mdp = "admin";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string leLogin = tb_login.Text;
            string lemdp = PswdBox_mdp.Password;


            if (leLogin == login && lemdp == mdp)
            {
                
                GestionDB GestionDBWin = new GestionDB();
                Close();
                GestionDBWin.Show();
            }
            else
            {
                MessageBox.Show("Mauvais identifants");
            }
        }
        private void btn_quitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btn_image_Click(object sender, RoutedEventArgs e)
        {

        }
     
    }
}
