namespace WpfApp1.Models
{
    public class UserPage
    {
		private User _User;

		public User User
        {
			get { return _User; }
			set { _User = value; }
		}

		public int ID => _User.ID;
	}
}
