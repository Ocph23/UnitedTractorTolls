using MahApps.Metro.Controls;
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
    /// Interaction logic for TambahTolls.xaml
    /// </summary>
    public partial class TambahTolls : MetroWindow
    {
        public TambahTolls(ViewModels.DaftarTollsVM daftarTollsVM)
        {
            InitializeComponent();
            this.DataContext = new ViewModels.TambahTollsVM(daftarTollsVM) {CloseWindow=this.Close };
        }

        public TambahTolls(ViewModels.DaftarTollsVM daftarTollsVM, UnitedTractorLib.Models.Tolls tolls)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.DataContext = new ViewModels.TambahTollsVM(daftarTollsVM, tolls) { CloseWindow = this.Close };
        }

       
    }
}
