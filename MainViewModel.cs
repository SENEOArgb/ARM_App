using ARM_App.Helper;
using ARM_App.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ARM_App.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ICommand OpenProductsCommand { get; }
        public ICommand OpenRawMaterialsCommand { get; }
        public ICommand OpenProductionCommand { get; }

        public MainViewModel()
        {
            OpenProductsCommand = new RelayCommand(param => OpenPage("Products"));
            OpenRawMaterialsCommand = new RelayCommand(param => OpenPage("RawMaterials"));
            OpenProductionCommand = new RelayCommand(param => OpenPage("Production"));
        }


        private void OpenPage(object pageType)
        {
            if (pageType is string pageKey)
            {
                Page page = null;
                switch (pageKey)
                {
                    case "Products":
                        page = new ProductsPage();
                        break;
                    case "RawMaterials":
                        page = new RawMaterialsPage();
                        break;
                }

                if (page != null)
                {
                    var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;
                    mainWindow.MainFrame.Navigate(page);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
