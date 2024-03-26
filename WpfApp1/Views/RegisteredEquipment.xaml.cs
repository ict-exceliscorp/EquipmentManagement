using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for SiteEquipment.xaml
    /// </summary>
    public partial class RegisteredEquipment : Window
    {
        private readonly Models.Site _Site;

        public RegisteredEquipment(Models.Site Site)
        {
            InitializeComponent();

            _Site = Site;
            txtSiteID.Text = _Site.ID.ToString();
            txtSite.Text = _Site.Description;
        }
    }
}
