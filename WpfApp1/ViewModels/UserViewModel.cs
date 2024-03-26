using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Data;
using WpfApp1.Models;
using WpfApp1.Utilities;

namespace WpfApp1.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly DataContext _DbContext;
        private ObservableCollection<User> _Users;
        private ObservableCollection<UserType> _UserTypes;
        private User _SelectedUser;

        public UserViewModel()
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
            UserTypes = new ObservableCollection<UserType>(_DbContext.UserTypes);
            Users = new ObservableCollection<User>(_DbContext.Users);
            SelectedUser = new User();
        }

        private void Refresh(object obj)
        {
            RefreshData();
        }

        private void Save(object obj)
        {
            if (SelectedUser.ID == 0)
            {
                if (AreValidEntries())
                {
                    _DbContext.Users.Add(SelectedUser);
                    _DbContext.SaveChanges();

                    RefreshData();

                    MessageBox.Show("User successfully created!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please fill-out all the details!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Update(object obj)
        {
            if (SelectedUser.ID != 0)
            {
                if (AreValidEntries())
                {
                    _DbContext.SaveChanges();

                    RefreshData();

                    MessageBox.Show("User updated!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please fill-out all the details!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Delete(object obj)
        {
            if (SelectedUser.ID != 0)
            {
                _DbContext.Users.Remove(SelectedUser);
                _DbContext.SaveChanges();

                RefreshData();

                MessageBox.Show("User deleted!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool AreValidEntries()
        {
            return !string.IsNullOrEmpty(SelectedUser.Username) 
                && !string.IsNullOrEmpty(SelectedUser.Password)
                && !string.IsNullOrEmpty(SelectedUser.FirstName)
                && !string.IsNullOrEmpty(SelectedUser.LastName)
                && !string.IsNullOrEmpty(SelectedUser.EmailAddress)
                && SelectedUser.UserTypeID != 0 ? true : false;
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

        public ObservableCollection<UserType> UserTypes
        {
            get => _UserTypes;
            set
            {
                _UserTypes = value;
                OnPropertyChanged(nameof(UserTypes));
            }
        }

        public User SelectedUser
        {
            get => _SelectedUser;
            set
            {
                _SelectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public ICommand RefreshCommand { get; }

        public ICommand SaveCommand { get; }

        public ICommand UpdateCommand { get; }

        public ICommand DeleteCommand { get; }
    }
}
