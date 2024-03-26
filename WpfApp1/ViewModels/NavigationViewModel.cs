using System.Windows.Input;
using WpfApp1.Utilities;

namespace WpfApp1.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
		private object _CurrentView;

        public NavigationViewModel()
        {
            HomeCommand = new ViewModelCommand(Home);
			UserCommand = new ViewModelCommand(User);
            SiteCommand = new ViewModelCommand(Site);
            EquipmentCommand = new ViewModelCommand(Equipment);

			CurrentView = new HomeViewModel();
        }

        public object CurrentView
        {
            get { return _CurrentView; }
            set
            {
                _CurrentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        private void Home(object obj) => CurrentView = new HomeViewModel();

        private void User(object obj) => CurrentView = new UserViewModel();

        private void Site(object obj) => CurrentView = new SiteViewModel();

		private void Equipment(object obj) => CurrentView = new EquipmentViewModel();

		public ICommand HomeCommand { get; set; }

		public ICommand UserCommand { get; set; }

        public ICommand SiteCommand { get; set; }

		public ICommand EquipmentCommand { get; set; }
	}
}
