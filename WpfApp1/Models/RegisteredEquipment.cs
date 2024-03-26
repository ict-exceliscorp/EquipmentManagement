using WpfApp1.Utilities;

namespace WpfApp1.Models
{
    public class RegisteredEquipment : ViewModelBase
    {
        private int _EquipmentID;
        private int _SiteID;

        public int ID { get; set; }

        public int EquipmentID
        {
            get => _EquipmentID;
            set
            {
                _EquipmentID = value;
                OnPropertyChanged(nameof(EquipmentID));
            }
        }

        public int SiteID
        {
            get => _SiteID;
            set
            {
                _SiteID = value;
                OnPropertyChanged(nameof(SiteID));
            }
        }

        public Equipment Equipment { get; set; }

        public Site Site { get; set; }
    }
}
