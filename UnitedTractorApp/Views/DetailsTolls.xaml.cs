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

namespace UnitedTractorApp.Views
{
    /// <summary>
    /// Interaction logic for DetailsTolls.xaml
    /// </summary>
    public partial class DetailsTolls : Window
    {
        private ViewModels.DaftarTollsVM daftarTollsVM;
        private UnitedTractorLib.Models.Tolls tolls;

        public DetailsTolls()
        {
            InitializeComponent();
        }

        public DetailsTolls(ViewModels.DaftarTollsVM daftarTollsVM, UnitedTractorLib.Models.Tolls tolls)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.daftarTollsVM = daftarTollsVM;
            this.tolls = tolls;
        }
    }
}
