using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1.Utilities;

namespace WpfApp1.Models
{
    public class Site : ViewModelBase
    {
        private int _UserID;
        private string _Description;
        private bool _IsActive;

        public Site()
        {
            RegisteredEquipments = new ObservableCollection<RegisteredEquipment>();
        }

        public int ID { get; set; }

        public int UserID
        {
            get => _UserID;
            set
            {
                _UserID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        public string Description
        {
            get => _Description;
            set
            {
                _Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool IsActive
        {
            get => _IsActive;
            set
            {
                _IsActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        public User User { get; set; }

        public ObservableCollection<RegisteredEquipment> RegisteredEquipments { get; set; }
    }
}