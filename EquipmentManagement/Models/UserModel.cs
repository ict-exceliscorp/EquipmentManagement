using EquipmentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Models
{
    public class UserModel : ViewModelBase
    {
		private int _UserID;
        private int _UserType;
        private string _FirstName;
        private string _LastName;
        private string _EmailAddress;
        private string _Username;
        private string _Password;
        private ObservableCollection<UserModel> _Users;

        public int UserID
		{
			get { return _UserID; }
			set
			{
				_UserID = value;
				OnPropertyChanged(nameof(UserID));
			}
		}

		public int UserType
        {
			get { return _UserType; }
			set
			{
				_UserType = value;
                OnPropertyChanged(nameof(UserType));
            }
		}

		public string FirstName
        {
			get { return _FirstName; }
			set
			{
				_FirstName = value;
				OnPropertyChanged(nameof(FirstName));
			}
		}

		public string LastName
        {
			get { return _LastName; }
			set
			{
				_LastName = value;
				OnPropertyChanged(nameof(LastName));
			}
		}

		public string EmailAddress
        {
			get { return _EmailAddress; }
			set
			{
				_EmailAddress = value;
				OnPropertyChanged(nameof(EmailAddress));
			}
		}

		public string Username
        {
			get { return _Username; }
			set
			{
				_Username = value;
				OnPropertyChanged(nameof(Username));
			}
		}

		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				_Password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		public ObservableCollection<UserModel> Users
        {
			get { return _Users; }
			set
			{
				_Users = value;
				OnPropertyChanged(nameof(Users));
			}
		}

        public void UserModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
            OnPropertyChanged(nameof(Users));
        }
    }
}
