using EquipmentManagement.Utilities;
using EquipmentManagement.Models;
using EquipmentManagement.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EquipmentManagement.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly EquipmentManagementEntities _DbEntity;
        private ObservableCollection<User> _Users;

        public UserViewModel()
        {
            _DbEntity = new EquipmentManagementEntities();
            _Users = new ObservableCollection<User>(_DbEntity.Users);
            ShowWindowCommand = new ViewModelCommand(ShowCreateWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowCreateWindow(object obj)
        {
            CreateUser dlg = new CreateUser();
            dlg.Owner = (Window)obj;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dlg.Show();
        }

        public ObservableCollection<User> Users
        {
            get { return _Users; }
        }

        public ICommand ShowWindowCommand { get; }
    }
}
