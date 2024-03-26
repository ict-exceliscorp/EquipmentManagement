using WpfApp1.Models;
using WpfApp1.Utilities;

namespace WpfApp1.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly UserPage _UserPage;

        public HomeViewModel()
        {
            _UserPage = new UserPage();

        }
    }
}
