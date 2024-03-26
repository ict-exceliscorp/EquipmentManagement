using System.Collections.ObjectModel;
using WpfApp1.Utilities;

namespace WpfApp1.Models
{
    public class User : ViewModelBase
    {
        private int _UserTypeID = 2;
        private string _FirstName;
        private string _LastName;
        private string _EmailAddress;
        private string _Username;
        private string _Password;

        public User()
        {
            Equipments = new ObservableCollection<Equipment>();
            Sites = new ObservableCollection<Site>();
        }

        public int ID { get; set; }

        public int UserTypeID
        {
            get => _UserTypeID;
            set
            {
                _UserTypeID = value;
                OnPropertyChanged(nameof(UserTypeID));
            }
        }

        public string FirstName
        {
            get => _FirstName;
            set
            {
                _FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string DisplayName => $"{LastName} {FirstName}";

        public string EmailAddress
        {
            get => _EmailAddress;
            set
            {
                _EmailAddress = value;
                OnPropertyChanged(nameof(EmailAddress));
            }
        }

        public string Username
        {
            get => _Username; 
            set
            {
                _Username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _Password;
            set
            {
                _Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public UserType UserType { get; set; }

        public ObservableCollection<Equipment> Equipments { get; set; }

        public ObservableCollection<Site> Sites { get; set; }
    }
}