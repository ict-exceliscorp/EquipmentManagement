using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Data;
using WpfApp1.Models;
using WpfApp1.Utilities;

namespace WpfApp1.ViewModels
{
    public class RegisteredEquipmentViewModel : ViewModelBase
    {
        private readonly DataContext _DbContext;
        private ObservableCollection<RegisteredEquipment> _RegisteredEquipment;
        private ObservableCollection<Equipment> _Equipments;
        private ObservableCollection<Site> _Sites;
        private RegisteredEquipment _SelectedEquipment;

        public RegisteredEquipmentViewModel()
        {
            _DbContext = new DataContext();

            RefreshData();

            RefreshCommand = new ViewModelCommand(Refresh);
            SaveCommand = new ViewModelCommand(Save);
            DeleteCommand = new ViewModelCommand(Delete);
        }

        private void RefreshData()
        {
            RegisteredEquipments = new ObservableCollection<RegisteredEquipment>(_DbContext.RegisteredEquipments);
            Equipments = new ObservableCollection<Equipment>(_DbContext.Equipments);
            Sites = new ObservableCollection<Site>(_DbContext.Sites);
            SelectedEquipment = new RegisteredEquipment();
        }

        private void Refresh(object obj)
        {
            RefreshData(); 
        }

        private void Save(object obj)
        {
            if (SelectedEquipment.ID == 0)
            {
                if (AreValidEntries())
                {
                    _DbContext.RegisteredEquipments.Add(SelectedEquipment);
                    _DbContext.SaveChanges();

                    RefreshData();

                    MessageBox.Show("Equipment registered successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please fill-out all the details!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Delete(object obj)
        {
            if (SelectedEquipment.ID != 0)
            {
                _DbContext.RegisteredEquipments.Remove(SelectedEquipment);
                _DbContext.SaveChanges();

                RefreshData();

                MessageBox.Show("Equipment deleted!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool AreValidEntries()
        {
            return SelectedEquipment.SiteID != 0
                && SelectedEquipment.EquipmentID != 0 ? true : false;
        }

        public ObservableCollection<RegisteredEquipment> RegisteredEquipments
        {
            get => _RegisteredEquipment;
            set
            {
                _RegisteredEquipment = value;
                OnPropertyChanged(nameof(RegisteredEquipments));
            }
        }

        public ObservableCollection<Equipment> Equipments
        {
            get => _Equipments;
            set
            {
                _Equipments = value;
                OnPropertyChanged(nameof(Equipments));
            }
        }

        public ObservableCollection<Site> Sites
        {
            get => _Sites;
            set
            {
                _Sites = value;
                OnPropertyChanged(nameof(Sites));
            }
        }

        public RegisteredEquipment SelectedEquipment
        {
            get => _SelectedEquipment;
            set
            {
                _SelectedEquipment = value;
                OnPropertyChanged(nameof(SelectedEquipment));
            }
        }

        public ICommand RefreshCommand { get; }

        public ICommand SaveCommand { get; }

        public ICommand DeleteCommand { get; }
    }
}
