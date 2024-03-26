using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Data;
using WpfApp1.Models;
using WpfApp1.Utilities;

namespace WpfApp1.ViewModels
{
    public class EquipmentViewModel : ViewModelBase
    {
        private readonly DataContext _DbContext;
        private ObservableCollection<Equipment> _Equipments;
        private ObservableCollection<User> _Users;
        private ObservableCollection<Models.Condition> _Conditions;
        private Equipment _SelectedEquipment;

        public EquipmentViewModel() 
        {
            _DbContext = new DataContext();

            RefreshData();

            RefreshCommand = new ViewModelCommand(Refresh);
            SaveCommand = new ViewModelCommand(Save);
            UpdateCommand = new ViewModelCommand(Update);
            DeleteCommand = new ViewModelCommand(Delete);
        }

        private void RefreshData()
        {
            Users = new ObservableCollection<User>(_DbContext.Users);
            Equipments = new ObservableCollection<Equipment>(_DbContext.Equipments);
            Conditions = new ObservableCollection<Models.Condition>(_DbContext.Conditions);
            SelectedEquipment = new Equipment();
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
                    _DbContext.Equipments.Add(SelectedEquipment);
                    _DbContext.SaveChanges();

                    RefreshData();

                    MessageBox.Show("Equipment successfully created!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please fill-out all the details!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Update(object obj)
        {
            if (SelectedEquipment.ID != 0)
            {
                if (AreValidEntries())
                {
                    _DbContext.SaveChanges();

                    RefreshData();

                    MessageBox.Show("Equipment updated!", "", MessageBoxButton.OK, MessageBoxImage.Information);
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
                _DbContext.Equipments.Remove(SelectedEquipment);
                _DbContext.SaveChanges();

                RefreshData();

                MessageBox.Show("Equipment deleted!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool AreValidEntries()
        {
            return !string.IsNullOrEmpty(SelectedEquipment.SerialNumber)
                && !string.IsNullOrEmpty(SelectedEquipment.Description)
                && SelectedEquipment.ConditionID != 0
                && SelectedEquipment.UserID != 0 ? true : false;
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

        public ObservableCollection<User> Users
        {
            get => _Users;
            set
            {
                _Users = value;
                OnPropertyChanged(nameof(Users));
            }
        }


        public ObservableCollection<Models.Condition> Conditions
        {
            get => _Conditions;
            set
            {
                _Conditions = value;
                OnPropertyChanged(nameof(Conditions));
            }
        }

        public Equipment SelectedEquipment
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

        public ICommand UpdateCommand { get; }

        public ICommand DeleteCommand { get; }
    }
}
