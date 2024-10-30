using ARM_App.Helper;
using ARM_App.Model;
using ARM_App.WindowNew;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ARM_App.ViewModel
{
    internal class ProductsViewModel : INotifyPropertyChanged
    {
        public ArmbaseContext db = new ArmbaseContext();
        public ObservableCollection<Product> Productss { get; set; }

        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }

        public ProductsViewModel()
        {
            var products = db.Products.ToList();
            Productss = new ObservableCollection<Product>(products);
        }

        public int MaxIdProducts()
        {
            int max = 0;
            foreach (var p in this.Productss)
            {
                if (max < p.productId)
                {
                    max = p.productId;
                };
            }
            return max;
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private RelayCommand addProduct;
        public RelayCommand AddProduct
        {
            get
            {
                return addProduct ??
                 (addProduct = new RelayCommand(obj =>
                 {
                     WindowNewProduct wnProduct = new WindowNewProduct
                     {
                         Title = "Новый продукт",
                     };

                     Product product = new Product();

                     wnProduct.DataContext = product;
                     if (wnProduct.ShowDialog() == true)
                     {
                         Productss.Add(product);
                         db.Products.Add(product);
                         db.SaveChanges();
                         Productss = new ObservableCollection<Product>(db.Products);
                     }
                     SelectedProduct = product;

                 }));
            }
        }

        private RelayCommand deleteProduct;
        public RelayCommand DeleteProduct
        {
            get
            {
                return deleteProduct ??
                (deleteProduct = new RelayCommand(obj =>
                {
                    Product products = SelectedProduct;
                    MessageBoxResult result = MessageBox.Show("Удалить данные по продукту: " + products.productId, "Предупреждение",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        Productss.Remove(products);
                        db.Products.Remove(products);
                        Productss = new ObservableCollection<Product>(db.Products);
                        db.SaveChanges();
                    }
                }, (obj) => SelectedProduct != null && Productss.Count > 0));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
