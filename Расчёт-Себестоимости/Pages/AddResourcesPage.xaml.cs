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
    /// Логика взаимодействия для AddResourcesPage.xaml
    /// </summary>
    public partial class AddResourcesPage : Page
    {
        private Resources _currentResources = new Resources();
        public AddResourcesPage(Resources selectedResources)
        {
            InitializeComponent();
            if (selectedResources != null)
                _currentResources = selectedResources;

            cbType.ItemsSource = Home.ConnectDB.connectDB.ResourcesType.ToList();

            DataContext = _currentResources;
            Home.ConnectDB.connectDB = new CalculationEntities();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (cbType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип");
            }
            else
            {
                StringBuilder errors = new StringBuilder();

                int type = 0;
                var typefurn = Home.ConnectDB.connectDB.ResourcesType.Where(x => x.Name == cbType.Text).Select(p => p.IdType).ToList();
                for (int i = 0; i < typefurn.Count(); i++) { type += typefurn[i]; }

                if (Properties.Settings.Default.IdResources == 0)
                {
                    if (tbName.Text != "Введите наименование")
                    {
                        Resources resources = new Resources()
                        {
                            Name = tbName.Text,
                            IdType = type,
                            Price = Convert.ToDecimal(tbPrice.Text),
                        };
                        Home.ConnectDB.connectDB.Resources.Add(resources);
                        Home.ConnectDB.connectDB.SaveChanges();
                        Home.FormNavigate.mainFrame.Navigate(new EditingPage());
                    }
                }
                else
                {

                    if (tbName.Text != "Введите наименование")
                    {

                        var theme = Home.ConnectDB.connectDB.Resources.FirstOrDefault(x => x.IdResources == Properties.Settings.Default.IdResources);
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
