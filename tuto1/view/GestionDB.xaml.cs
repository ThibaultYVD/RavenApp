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
using System.Windows.Shapes;
using tuto1.View;
using tuto1.ViewModel;

namespace tuto1.view
{
    /// <summary>
    /// Logique d'interaction pour Gestion_DB.xaml
    /// </summary>
    public partial class GestionDB : Window
    {
        ClientViewModel cvm = new ClientViewModel();
        public GestionDB()
        {
            InitializeComponent();
            listBox.ItemsSource = cvm.GetlesProduits();
        }
        
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox.ItemsSource = cvm.GetlesProduits();
            //MessageBox.Show(" " + listBox.SelectedIndex);
            if (listBox.SelectedIndex == -1)
            {
                cvm.setLeProduit(cvm.GetlesProduits()[0]);
            }
            else
            {
                cvm.setLeProduit(cvm.GetlesProduits()[listBox.SelectedIndex]);
            }
        }

        private void btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            if (cvm.getLeProduit() != null)
            {
                cvm.Update(cvm.getLeProduit());
            }
            else
            {
                cvm.setLeProduit(new model.produits());
                cvm.getLeProduit().id = Convert.ToInt32(tb_id.Text);
                cvm.getLeProduit().nom = tb_nom.Text;
                cvm.getLeProduit().prix = tb_prix.Text;
                cvm.getLeProduit().image = tb_image.Text;
                MessageBox.Show(cvm.getLeProduit().nom.ToString());
                if (cvm.Insert(cvm.getLeProduit()))
                {
                    listBox.ItemsSource = cvm.GetlesProduits();
                }
            }
        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (cvm.Delete(cvm.getLeProduit()))
            {
                cvm.GetlesProduits().Remove(cvm.getLeProduit());
                if (listBox.SelectedIndex == -1)
                {
                    listBox.SelectedIndex = 0;
                    cvm.setLeProduit(cvm.GetlesProduits()[listBox.SelectedIndex]);
                }
                listBox.ItemsSource = cvm.GetlesProduits(); //Pour raffraichir
            }
        }

        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            Ajouter ajouterWin = new Ajouter();
            ajouterWin.Show();
        }

        private void btn_rafraichir_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = cvm.GetlesProduits();
        }

        private void btn_deconnecter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
            
        }

        private void tb_nom_TextChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
