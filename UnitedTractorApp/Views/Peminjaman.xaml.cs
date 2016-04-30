using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UnitedTractorLib;
using UnitedTractorLib.Contexts.Peminjaman;

namespace UnitedTractorApp.Views
{
    /// <summary>
    /// Interaction logic for Peminjaman.xaml
    /// </summary>
    public partial class Peminjaman : Window
    {
       private ViewModels.PeminjamanVM viewmodel;

        public Peminjaman()
        {
            // TODO: Complete member initialization
            InitializeComponent();
            var user = App.Current.Windows[0] as MainApp;
            viewmodel = new ViewModels.PeminjamanVM(user.user) { WindowClose=this.Close };
            this.DataContext = viewmodel;
        }

      

    }
}
