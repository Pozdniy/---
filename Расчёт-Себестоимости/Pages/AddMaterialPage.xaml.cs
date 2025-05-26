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

namespace Расчёт_Себестоимости.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddMaterialPage.xaml
    /// </summary>
    public partial class AddMaterialPage : Page
    {
        private Material _currentMaterial = new Material();
        public AddMaterialPage(Material selectedMaterial) 
        {
            InitializeComponent();
            if (selectedMaterial != null)
                _currentMaterial = selectedMaterial;

            cbType.ItemsSource = Home.ConnectDB.connectDB.MaterialType.ToList();

            DataContext = _currentMaterial;
            Home.ConnectDB.connectDB = new CalculationEntities();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IdMaterials = Convert.ToInt32(tbId.Text);

            if (cbType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип");
            }
            else
            {
                StringBuilder errors = new StringBuilder();

                int type = 0;
                var typefurn = Home.ConnectDB.connectDB.MaterialType.Where(x => x.Name == cbType.Text).Select(p => p.IdType).ToList();
                for (int i = 0; i < typefurn.Count(); i++) { type += typefurn[i]; }

                if (Properties.Settings.Default.IdMaterials == 0)
                {
                    if (tbName.Text != "Введите наименование")
                    {
                        Material material = new Material()
                        {
                            Name = tbName.Text,
                            IdType = type,
                            Price = Convert.ToDecimal(tbPrice.Text),
                        };
                        Home.ConnectDB.connectDB.Material.Add(material);
                        Home.ConnectDB.connectDB.SaveChanges();
                        Home.FormNavigate.mainFrame.Navigate(new EditingPage());
                    }
                }
                else
                {

                    if (tbName.Text != "Введите наименование")
                    {

                        var theme = Home.ConnectDB.connectDB.Material.FirstOrDefault(x => x.IdMaterial == Properties.Settings.Default.IdMaterials);
                        theme.Name = tbName.Text;
                        theme.IdType = type;
                        theme.Price = Convert.ToDecimal(tbPrice.Text);
                        Home.ConnectDB.connectDB.SaveChanges();
                        Home.FormNavigate.mainFrame.Navigate(new EditingPage());
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new EditingPage());
        }
    }
}
