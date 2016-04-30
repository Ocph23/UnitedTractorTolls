using FirstFloor.ModernUI.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using UnitedTractorLib.Models;

namespace UnitedTractorApp.Views
{
    /// <summary>
    /// Interaction logic for DaftarTolls.xaml
    /// </summary>
    public partial class DaftarTolls : Page, IContent
    {
        private User userIsLogin;

        public DaftarTolls()
        {
            InitializeComponent();

            this.DataContext = new ViewModels.DaftarTollsVM();

            var ctx = App.Current.Windows[0];
        }

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
           
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            if (DataContext != null)
            {
                var a = (ViewModels.DaftarTollsVM)this.DataContext;
                a.SourceRefresh();

            }
        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
