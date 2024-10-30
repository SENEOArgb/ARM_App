using ARM_App.ViewModel;
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

namespace ARM_App.WindowNew
{
    /// <summary>
    /// Логика взаимодействия для WindowNewProduct.xaml
    /// </summary>
    public partial class WindowNewProduct : Window
    {
        public WindowNewProduct()
        {
            InitializeComponent();

            DataContext = new ProductsViewModel();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ExpDate_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ExpDate.Visibility == Visibility.Hidden)
            {
                DpExpDate.Visibility = Visibility.Visible;
            }
            else
            {
                DpExpDate.Visibility = Visibility.Hidden;
            }
        }

    }
}
