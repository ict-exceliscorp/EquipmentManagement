using System.Collections.ObjectModel;
using WpfApp1.Utilities;

namespace WpfApp1.Models
{
    public class Equipment : ViewModelBase
    {
        private int _UserID;
        private string _SerialNumber;
        private string _Description;
        private int _ConditionID;

        public Equipment()
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

        public string SerialNumber
        {
            get => _SerialNumber;
            set
            {
                _SerialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
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

        public int ConditionID
        {
            get => _ConditionID;
            set
            {
                _ConditionID = value;
                OnPropertyChanged(nameof(ConditionID));
            }
        }

        public User User { get; set; }

        public Condition Condition { get; set; }

        public ObservableCollection<RegisteredEquipment> RegisteredEquipments { get; set; }
    }
}