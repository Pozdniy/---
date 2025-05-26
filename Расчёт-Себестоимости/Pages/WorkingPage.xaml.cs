using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.IO;
using Расчёт_Себестоимости.Home;
using System;

namespace Расчёт_Себестоимости.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkingPage.xaml
    /// </summary>
    public partial class WorkingPage : Page
    {
        private Furniture _currentFurniture = new Furniture();


        public WorkingPage(Furniture selectedFurniture)
        {
            InitializeComponent();
            if (selectedFurniture != null)
                _currentFurniture = selectedFurniture;

            DataContext = _currentFurniture;
            Home.ConnectDB.connectDB = new CalculationEntities();

            var furniture = ConnectDB.connectDB.Furniture.Where(x=> x.IdType == 1).ToList();
            var chair = ConnectDB.connectDB.Furniture.Where(x => x.IdType == 2).ToList();
            var table = ConnectDB.connectDB.Furniture.Where(x => x.IdType == 3).ToList();
            lvBed.ItemsSource = furniture;
            lvChair.ItemsSource=chair;
            lvTable.ItemsSource = table;
        }

        private void imgAdd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new AddFurniture(null));
        }

        private void lblChair_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lvBed.Visibility = Visibility.Hidden;
            lvChair.Visibility = Visibility.Visible;
            lvTable.Visibility = Visibility.Hidden;
        }

        private void lblBed_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lvBed.Visibility = Visibility.Visible;
            lvChair.Visibility = Visibility.Hidden;
            lvTable.Visibility = Visibility.Hidden;
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void lvBed_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.IdFurniture = Convert.ToInt32(tbIdFur.Text);   
            Home.FormNavigate.mainFrame.Navigate(new InformationPage(null));
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new AddFurniture((sender as System.Windows.Controls.Button).DataContext as Furniture));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvBed.SelectedIndex >= 0)
                lvBed.Items.Remove(lvBed.SelectedIndex);
            else
                System.Windows.MessageBox.Show("No contact was selected.");

        }

        private void imgTable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lvBed.Visibility = Visibility.Hidden;
            lvChair.Visibility = Visibility.Hidden;
            lvTable.Visibility = Visibility.Visible;
        }

        private void lvChair_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.IdFurniture = Convert.ToInt32(tbIdChair.Text);
            Home.FormNavigate.mainFrame.Navigate(new InformationPage(null));
        }

        private void lvTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.IdFurniture = Convert.ToInt32(tbIdTable.Text);
            Home.FormNavigate.mainFrame.Navigate(new InformationPage(null));
        }

        private void imgEdit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new EditingPage());
        }
    }
}
