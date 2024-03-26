using System.Collections.ObjectModel;

namespace WpfApp1.Models
{
    public class UserType
    {
        public UserType()
        {
            Users = new ObservableCollection<User>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public virtual ObservableCollection<User> Users { get; set; }
    }
}
