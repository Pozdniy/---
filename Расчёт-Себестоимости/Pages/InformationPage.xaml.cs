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
using Расчёт_Себестоимости.Home;

namespace Расчёт_Себестоимости.Pages
{
    /// <summary>
    /// Логика взаимодействия для InformationPage.xaml
    /// </summary>
    public partial class InformationPage : Page
    {
        private Material _currentMaterial = new Material();

        private Resources _currentRes = new Resources();
        public InformationPage(Material selectedMaterial)
        {
            InitializeComponent();

            ConnectDB.connectDB = new CalculationEntities();

            var idfurniture = ConnectDB.connectDB.Furniture.FirstOrDefault(x => x.IdFurniture == Properties.Settings.Default.IdFurniture);

            tbNameFur.Text = idfurniture.Name;
            tbPriceFur.Text = idfurniture.Price.ToString();

            var material = ConnectDB.connectDB.Material.Where(x => x.IdType == 1).ToList();
            var material1 = ConnectDB.connectDB.Material.Where(x => x.IdType == 2).ToList();
            var material2 = ConnectDB.connectDB.Material.Where(x => x.IdType == 1003).ToList();
            var material3 = ConnectDB.connectDB.Material.Where(x => x.IdType == 1004).ToList();
            var material4 = ConnectDB.connectDB.Material.Where(x => x.IdType >= 1).ToList();

            var resources = ConnectDB.connectDB.Resources.Where(x => x.IdType == 1).ToList();
            var resources1 = ConnectDB.connectDB.Resources.Where(x => x.IdType == 2).ToList();

            material.Insert(0, new Material
            {
                Name = " "
            });
            material1.Insert(0, new Material
            {
                Name = " "
            });
            material2.Insert(0, new Material
            {
                Name = " "
            });
            material3.Insert(0, new Material
            {
                Name = " "
            });
            material4.Insert(0, new Material
            {
                Name = " "
            });
            resources.Insert(0, new Resources
            {
                Name = " "
            });
            resources1.Insert(0, new Resources
            {
                Name = " "
            });

            if (selectedMaterial != null)
                _currentMaterial = selectedMaterial;

            cbMaterial.ItemsSource = material;

            cbMaterial.SelectedIndex = 0;

            cbMaterialTwo.ItemsSource = material1;

            cbMaterialTwo.SelectedIndex = 0;

            cbMaterialThree.ItemsSource = material2;

            cbMaterialThree.SelectedIndex = 0;

            cbMaterialFor.ItemsSource = material3;

            cbMaterialFor.SelectedIndex = 0;

            cbMaterialFive.ItemsSource = material4;

            cbMaterialFive.SelectedIndex = 0;

            cbResources.ItemsSource = resources;

            cbResources.SelectedIndex = 0;

            cbResourcesTwo.ItemsSource = resources;

            cbResourcesTwo.SelectedIndex = 0;

            cbWork.ItemsSource = resources1;

            cbWork.SelectedIndex = 0;

            cbWorkTwo.ItemsSource = resources1;

            cbWorkTwo.SelectedIndex = 0;

            cbWorkThree.ItemsSource = resources1;

            cbWorkThree.SelectedIndex = 0;
        }

        private void cbMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = ConnectDB.connectDB.Material.Where(x => x.IdType == 1).ToList();
            if (cbMaterial.SelectedIndex > 0)
            {
                var sa = material.FirstOrDefault(x => x.Equals(cbMaterial.SelectedItem as Material));
                tbPriceMaterial.Text = sa.Price.ToString();
            }
        }

        private void cbMaterialTwo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = ConnectDB.connectDB.Material.Where(x => x.IdType == 2).ToList();
            if (cbMaterialTwo.SelectedIndex > 0)
            {
                var sa = material.FirstOrDefault(x => x.Equals(cbMaterialTwo.SelectedItem as Material));
                tbPriceMaterialTwo.Text = sa.Price.ToString();
            }
        }

        private void cbMaterialThree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = ConnectDB.connectDB.Material.Where(x => x.IdType == 1003).ToList();
            if (cbMaterialThree.SelectedIndex > 0)
            {
                var sa = material.FirstOrDefault(x => x.Equals(cbMaterialThree.SelectedItem as Material));
                tbPriceMaterialThree.Text = sa.Price.ToString();
            }
        }

        private void cbMaterialFor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = ConnectDB.connectDB.Material.Where(x => x.IdType == 1004).ToList();
            if (cbMaterialFor.SelectedIndex > 0)
            {
                var sa = material.FirstOrDefault(x => x.Equals(cbMaterialFor.SelectedItem as Material));
                tbPriceMaterialFor.Text = sa.Price.ToString();
            }
        }

        private void cbMaterialFive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = ConnectDB.connectDB.Material.Where(x => x.IdType >= 1).ToList();
            if (cbMaterialFive.SelectedIndex > 0)
            {
                var sa = material.FirstOrDefault(x => x.Equals(cbMaterialFive.SelectedItem as Material));
                tbPriceMaterialFive.Text = sa.Price.ToString();
            }
        }

        void OnComboboxTextChanged(object sender, RoutedEventArgs e)
        {
            cbMaterial.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(cbMaterial.ItemsSource);
            cv.Filter = s =>
                ((string)s).IndexOf(cbMaterial.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        void OnComboboxTextChanged1(object sender, RoutedEventArgs e)
        {
            cbMaterialTwo.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(cbMaterialTwo.ItemsSource);
            cv.Filter = s =>
                ((string)s).IndexOf(cbMaterialTwo.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        void OnComboboxTextChanged2(object sender, RoutedEventArgs e)
        {
            cbMaterialThree.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(cbMaterialThree.ItemsSource);
            cv.Filter = s =>
                ((string)s).IndexOf(cbMaterialThree.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        void OnComboboxTextChanged3(object sender, RoutedEventArgs e)
        {
            cbMaterialFor.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(cbMaterialFor.ItemsSource);
            cv.Filter = s =>
                ((string)s).IndexOf(cbMaterialFor.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        void OnComboboxTextChanged4(object sender, RoutedEventArgs e)
        {
            cbMaterialFive.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(cbMaterialFive.ItemsSource);
            cv.Filter = s =>
                ((string)s).IndexOf(cbMaterialFive.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void cbResources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var resources = ConnectDB.connectDB.Resources.Where(x => x.IdType == 1).ToList();
            if (cbResources.SelectedIndex > 0)
            {
                var sa = resources.FirstOrDefault(x => x.Equals(cbResources.SelectedItem as Resources));
                tbResourcesPrice.Text = sa.Price.ToString();
            }
        }

        private void cbResourcesTwo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var resources = ConnectDB.connectDB.Resources.Where(x => x.IdType == 1).ToList();
            if (cbResourcesTwo.SelectedIndex > 0)
            {
                var sa = resources.FirstOrDefault(x => x.Equals(cbResourcesTwo.SelectedItem as Resources));
                tbResourcesPriceTwo.Text = sa.Price.ToString();
            }
        }

        private void cbWork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var resources = ConnectDB.connectDB.Resources.Where(x => x.IdType == 2).ToList();
            if (cbWork.SelectedIndex > 0)
            {
                var sa = resources.FirstOrDefault(x => x.Equals(cbWork.SelectedItem as Resources));
                tbPriceWork.Text = sa.Price.ToString();
            }
        }

        private void cbWorkTwo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var resources = ConnectDB.connectDB.Resources.Where(x => x.IdType == 2).ToList();
            if (cbWorkTwo.SelectedIndex > 0)
            {
                var sa = resources.FirstOrDefault(x => x.Equals(cbWorkTwo.SelectedItem as Resources));
                tbPriceWorkTwo.Text = sa.Price.ToString();
            }
        }

        private void cbWorkThree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var resources = ConnectDB.connectDB.Resources.Where(x => x.IdType == 2).ToList();
            if (cbWorkThree.SelectedIndex > 0)
            {
                var sa = resources.FirstOrDefault(x => x.Equals(cbWorkThree.SelectedItem as Resources));
                tbPriceWorkThree.Text = sa.Price.ToString();
            }
        }

        private void btnCalculation_Click(object sender, RoutedEventArgs e)
        {
            Double db, db1, db2, db3, db4, db5, db6, db7, db8, db9, db10, db11, db12, db13, db14, db15, result;
            db = Double.Parse(tbPriceFur.Text);
            if (tbPriceMaterial.Text.Length != 0)
                db1 = Double.Parse(tbPriceMaterial.Text);
            else db1 = 0;
            if (tbPriceMaterialTwo.Text.Length != 0)
                db2 = Double.Parse(tbPriceMaterialTwo.Text);
            else db2 = 0;
            if (tbPriceMaterialThree.Text.Length != 0)
                db3 = Double.Parse(tbPriceMaterialThree.Text);
            else db3 = 0;
            if (tbPriceMaterialFor.Text.Length != 0)
                db4 = Double.Parse(tbPriceMaterialFor.Text);
            else db4 = 0;
            if (tbPriceMaterialFive.Text.Length != 0)
                db5 = Double.Parse(tbPriceMaterialFive.Text);
            else db5 = 0;
            if (tbPriceWork.Text.Length != 0)
                db6 = Double.Parse(tbPriceWork.Text);
            else db6 = 0;
            if (tbPriceWorkTwo.Text.Length != 0)
                db10 = Double.Parse(tbPriceWorkTwo.Text);
            else db10 = 0;
            if (tbPriceWorkThree.Text.Length != 0)
                db7 = Double.Parse(tbPriceWorkThree.Text);
            else db7 = 0;
            if (tbResourcesPrice.Text.Length != 0)
                db8 = Double.Parse(tbResourcesPrice.Text);
            else db8 = 0;
            if (tbResourcesPriceTwo.Text.Length != 0)
                db9 = Double.Parse(tbResourcesPriceTwo.Text);
            else db9 = 0;

            db11 = Double.Parse(tbCost.Text);
            db12 = Double.Parse(tbCost1.Text);
            db13 = Double.Parse(tbCost2.Text);
            db14 = Double.Parse(tbCost3.Text);
            db15 = Double.Parse(tbCost4.Text);

            result = (db - db1*db11 - db2*db12 - db3*db13 - db4*db14 - db5*db15 - db6 - db10 - db7 - db8 -db9)*1000;
            tbCalculation.Text = result.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Home.FormNavigate.mainFrame.Navigate(new WorkingPage(null));
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tbCost.Text = "1";
            tbCost1.Text = "1";
            tbCost2.Text = "1";
            tbCost3.Text = "1";
            tbCost4.Text = "1";
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost.Text);
            if (i < 4)
            {
                i++;
                tbCost.Text = i.ToString();
            }
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost.Text);
            if (i>1)
            {
               i--;
               tbCost.Text = i.ToString();
            }
        }

        private void btnUp1_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost1.Text);
            if (i < 4)
            {
                i++;
                tbCost1.Text = i.ToString();
            }
        }

        private void btnDown1_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost1.Text);
            if (i > 1)
            {
                i--;
                tbCost1.Text = i.ToString();
            }
        }

        private void btnUp2_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost2.Text);
            if (i < 4)
            {
                i++;
                tbCost2.Text = i.ToString();
            }
        }

        private void btnDown2_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost2.Text);
            if (i > 1)
            {
                i--;
                tbCost2.Text = i.ToString();
            }
        }

        private void btnUp3_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost3.Text);
            if (i < 4)
            {
                i++;
                tbCost3.Text = i.ToString();
            }
        }

        private void btnDown3_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost3.Text);
            if (i > 1)
            {
                i--;
                tbCost3.Text = i.ToString();
            }
        }

        private void btnUp4_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost4.Text);
            if (i < 4)
            {
                i++;
                tbCost4.Text = i.ToString();
            }
        }

        private void btnDown4_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(tbCost4.Text);
            if (i > 1)
            {
                i--;
                tbCost4.Text = i.ToString();
            }
        }
    }
}
