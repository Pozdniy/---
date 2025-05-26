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
using Расчёт_Себестоимости.Properties;
using Расчёт_Себестоимости.Home;

namespace Расчёт_Себестоимости.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
            Home.ConnectDB.connectDB = new CalculationEntities();
            var enter = ConnectDB.connectDB.Person.FirstOrDefault(x => x.Password == tbPass.Text && x.Login == tbLogin.Text);
            StringBuilder errors = new StringBuilder();
        }

        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "" && tbPass.Text == "")
            {
                System.Windows.MessageBox.Show("Поля не заполнены!");

            }
            else if (tbPass.Text == "")
            {
                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrWhiteSpace(tbPass.Text))
                    errors.AppendLine("Введите пароль!");

                if (errors.Length > 0)
                {
                    System.Windows.MessageBox.Show(errors.ToString());
                    return;
                }
            }
            else if (tbLogin.Text == "")
            {
                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrWhiteSpace(tbLogin.Text))
                    errors.AppendLine("Введите логин!");

                if (errors.Length > 0)
                {
                    System.Windows.MessageBox.Show(errors.ToString());
                    return;
                }
            }
            else
            {
                var enter = ConnectDB.connectDB.Person.FirstOrDefault(x => x.Password == tbPass.Text && x.Login == tbLogin.Text);
                if (enter == null)
                {
                    System.Windows.MessageBox.Show("Данного пользователя нет!");

                }
                else
                {
                    Home.FormNavigate.mainFrame.Navigate(new WorkingPage(null));
                }
            }
        }

    }
}
