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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ARM_App.View
{
    /// <summary>
    /// Логика взаимодействия для RawMaterialsPage.xaml
    /// </summary>
    public partial class RawMaterialsPage : Page
    {
        public RawMaterialsPage()
        {
            InitializeComponent();

            DataContext = new RawMaterialsViewModel();
        }
    }
}
