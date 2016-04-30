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
using UnitedTractorApp.ViewModels;

namespace UnitedTractorApp.Views
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        private UsersVM viewmodel;

        public Users()
        {
            InitializeComponent();
            this.viewmodel = new ViewModels.UsersVM();
            this.DataContext = viewmodel;
        }
    }
}
