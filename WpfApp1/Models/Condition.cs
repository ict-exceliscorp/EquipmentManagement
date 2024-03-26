using System.Collections.ObjectModel;

namespace WpfApp1.Models
{
    public class Condition
    {
        public Condition()
        {
            Equipments = new ObservableCollection<Equipment>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public virtual ObservableCollection<Equipment> Equipments { get; set; }
    }
}
