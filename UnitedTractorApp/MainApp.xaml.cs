using FirstFloor.ModernUI.Windows.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnitedTractorApp
{
    /// <summary>
    /// Interaction logic for MainApp.xaml
    /// </summary>
    public partial class MainApp : ModernWindow
    {
        public UnitedTractorLib.Models.User user;


        public MainApp(UnitedTractorLib.Models.User user)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.user = user;
        }
    }
}
