using ARM_App.Helper;
using ARM_App.Model;
using ARM_App.WindowNew;
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
    internal class RawMaterialsViewModel : INotifyPropertyChanged
    {
        public ArmbaseContext db = new ArmbaseContext();
        public ObservableCollection<RawMaterial> RawMaterialss { get; set; }

        public RawMaterialsViewModel()
        {
            var rawMaterials = db.RawMaterials.ToList();
            RawMaterialss = new ObservableCollection<RawMaterial>(rawMaterials);
            {
            };
        }

        public int MaxIdRawMaterials()
        {
            int max = 0;
            foreach (var r in this.RawMaterialss)
            {
                if (max < r.rawMaterialId)
                {
                    max = r.rawMaterialId;
                };
            }
            return max;
        }

        private RawMaterial _selectedRawMaterial;
        public RawMaterial SelectedRawMaterial
        {
            get { return _selectedRawMaterial; }
            set
            {
                _selectedRawMaterial = value;
                OnPropertyChanged("SelectedRawMaterial");
            }
        }

        private RelayCommand addRawMaterial;
        public RelayCommand AddRawMaterial
        {
            get
            {
                return addRawMaterial ??
                 (addRawMaterial = new RelayCommand(obj =>
                 {
                     WindowNewRawMaterial wnRawMaterial = new WindowNewRawMaterial
                     {
                         Title = "Новое сырье",
                     };

                     RawMaterial rawMaterial = new RawMaterial();

                     wnRawMaterial.DataContext = rawMaterial;
                     if (wnRawMaterial.ShowDialog() == true)
                     {
                         RawMaterialss.Add(rawMaterial);
                         db.RawMaterials.Add(rawMaterial);
                         db.SaveChanges();
                         RawMaterialss = new ObservableCollection<RawMaterial>(db.RawMaterials);
                     }
                     SelectedRawMaterial = rawMaterial;

                 }));
            }
        }

        private RelayCommand deleteRawMaterial;
        public RelayCommand DeleteRawMaterial
        {
            get
            {
                return deleteRawMaterial ??
                (deleteRawMaterial = new RelayCommand(obj =>
                {
                    RawMaterial rawMaterial = SelectedRawMaterial;
                    MessageBoxResult result = MessageBox.Show("Удалить данные по сырью: " + rawMaterial.rawMaterialId, "Предупреждение",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        RawMaterialss.Remove(rawMaterial);
                        db.RawMaterials.Remove(rawMaterial);
                        RawMaterialss = new ObservableCollection<RawMaterial>(db.RawMaterials);
                        db.SaveChanges();
                    }
                }, (obj) => SelectedRawMaterial != null && RawMaterialss.Count > 0));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
