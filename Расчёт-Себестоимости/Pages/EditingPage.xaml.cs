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
using System.Data;
using System.Data.SqlClient;

namespace Расчёт_Себестоимости.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditingPage.xaml
    /// </summary>
    public partial class EditingPage : Page
    {
        public EditingPage()
        {
            InitializeComponent();

            dgType1.ItemsSource = Home.ConnectDB.connectDB.Material.Where(x => x.IdType == 1).ToList();
            dgType2.ItemsSource = Home.ConnectDB.connectDB.Material.Where(x => x.IdType == 2).ToList();
            dgType3.ItemsSource = Home.ConnectDB.connectDB.Material.Where(x => x.IdType == 1003).ToList();
            dgType4.ItemsSource = Home.ConnectDB.connectDB.Material.Where(x => x.IdType == 1004).ToList();
            dgResources.ItemsSource = Home.ConnectDB.connectDB.Resources.Where(x => x.IdType == 1).ToList();
            dgResources2.ItemsSource = Home.ConnectDB.connectDB.Resources.Where(x => x.IdType == 2).ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new AddMaterialPage((sender as Button).DataContext as Material));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new AddMaterialPage(null));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var materialForRemoving = dgType1.SelectedItems.Cast<Material>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {materialForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    Home.ConnectDB.connectDB.Material.RemoveRange(materialForRemoving);
                    Home.ConnectDB.connectDB.SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgType1.ItemsSource = Home.ConnectDB.connectDB.Material.Where(x => x.IdType == 1).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }       
        }

        private void btnDel1_Click(object sender, RoutedEventArgs e)
        {
            var materialForRemoving = dgType2.SelectedItems.Cast<Material>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {materialForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    Home.ConnectDB.connectDB.Material.RemoveRange(materialForRemoving);
                    Home.ConnectDB.connectDB.SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgType2.ItemsSource = Home.ConnectDB.connectDB.Material.Where(x => x.IdType == 2).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnDel2_Click(object sender, RoutedEventArgs e)
        {
            var materialForRemoving = dgType3.SelectedItems.Cast<Material>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {materialForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    Home.ConnectDB.connectDB.Material.RemoveRange(materialForRemoving);
                    Home.ConnectDB.connectDB.SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgType3.ItemsSource = Home.ConnectDB.connectDB.Material.Where(x => x.IdType == 1003).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnDel3_Click(object sender, RoutedEventArgs e)
        {
            var resourcesForRemoving = dgResources.SelectedItems.Cast<Resources>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {resourcesForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    Home.ConnectDB.connectDB.Resources.RemoveRange(resourcesForRemoving);
                    Home.ConnectDB.connectDB.SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgResources.ItemsSource = Home.ConnectDB.connectDB.Resources.Where(x => x.IdType == 1).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnDel4_Click(object sender, RoutedEventArgs e)
        {
            var resourcesForRemoving = dgResources2.SelectedItems.Cast<Resources>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {resourcesForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    Home.ConnectDB.connectDB.Resources.RemoveRange(resourcesForRemoving);
                    Home.ConnectDB.connectDB.SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgResources2.ItemsSource = Home.ConnectDB.connectDB.Resources.Where(x => x.IdType == 2).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnEdit1_Click(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new AddResourcesPage((sender as Button).DataContext as Resources));
        }

        private void btnEdit1_Click_1(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new AddResourcesPage((sender as Button).DataContext as Resources));
        }

        private void btnAdd4_Click(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new AddResourcesPage(null));
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new AddMaterialPage(null));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new WorkingPage(null));
        }

        private void btnAdd_Click_2(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new AddMaterialPage(null));
        }

        private void btnDel3_Click_1(object sender, RoutedEventArgs e)
        {
            var materialForRemoving = dgType4.SelectedItems.Cast<Material>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {materialForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    Home.ConnectDB.connectDB.Material.RemoveRange(materialForRemoving);
                    Home.ConnectDB.connectDB.SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgType4.ItemsSource = Home.ConnectDB.connectDB.Material.Where(x => x.IdType == 1004).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
