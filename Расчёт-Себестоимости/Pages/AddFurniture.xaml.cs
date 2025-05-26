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
    /// Логика взаимодействия для AddFurniture.xaml
    /// </summary>
    public partial class AddFurniture : Page
    {

        private Furniture _currentFurniture = new Furniture();
        public AddFurniture(Furniture selectedFurniture)
        {
            InitializeComponent();
            if (selectedFurniture != null)
                _currentFurniture = selectedFurniture;

            cbType.ItemsSource = ConnectDB.connectDB.FurnitureType.ToList();
         
            DataContext = _currentFurniture;
            Home.ConnectDB.connectDB = new CalculationEntities();

         

        }

        private void btnAddFile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();
            open.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                photoFurniture.Source = new BitmapImage(new System.Uri(open.FileName));
                System.Drawing.Image image;
                image = System.Drawing.Image.FromFile(open.FileName);

                var name = tbName.Text;
                var jpgFurniture = Home.ConnectDB.connectDB.Furniture.FirstOrDefault(x => x.Name == tbName.Text);

                jpgFurniture.Picture = ImageToByteArray(image);
                Home.ConnectDB.connectDB.SaveChanges();
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IdFur = Convert.ToInt32(tbId.Text);

            if (cbType.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Выберите тип");
            }
            else
            {
                StringBuilder errors = new StringBuilder();

                int type = 0;
                var typefurn = Home.ConnectDB.connectDB.FurnitureType.Where(x => x.Name == cbType.Text).Select(p => p.IdType).ToList();
                for (int i = 0; i < typefurn.Count(); i++) { type += typefurn[i]; }

                if (Properties.Settings.Default.IdFur == 0)
                {

                    if (tbName.Text != "Введите наименование")
                    {
                        Furniture furniture = new Furniture()
                        {
                            Name = tbName.Text,
                            IdType = type,
                            Price = Convert.ToDecimal(tbPrice.Text),
                        };
                        Home.ConnectDB.connectDB.Furniture.Add(furniture);
                        Home.ConnectDB.connectDB.SaveChanges();
                        btnAddFile.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    btnAddFile.Visibility = Visibility.Visible;

                    if (tbName.Text != "Введите наименование")
                    {
                        var theme = Home.ConnectDB.connectDB.Furniture.FirstOrDefault(x => x.IdFurniture == Properties.Settings.Default.IdFur);
                        theme.Name = tbName.Text;
                        theme.IdType = type;
                        theme.Price = Convert.ToDecimal(tbPrice.Text);
                        Home.ConnectDB.connectDB.SaveChanges();
                        Home.FormNavigate.mainFrame.Navigate(new WorkingPage(null));
                    }

                }
            }
        }

        private void tbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char inp = e.Text[0];
            if (inp < 'а' || inp > 'я')
                e.Handled = true;
        }

        private void tbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new WorkingPage(null));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

            int idFurniture = Convert.ToInt32(tbId.Text);

            var image = Home.ConnectDB.connectDB.Furniture.FirstOrDefault(x => x.IdFurniture == idFurniture);

            ConnectDB.connectDB.Furniture.Remove(image);
            ConnectDB.connectDB.SaveChanges();
            Home.FormNavigate.mainFrame.Navigate(new WorkingPage(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (tbId.Text == "0")
            {
                
            }
            else
            {
                btnAddFile.Visibility = Visibility.Visible;
                btnExit.Visibility = Visibility.Visible;
            }
        }
    }
}
