using FirstFloor.ModernUI.Windows.Controls;
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
using UnitedTractorApp.ViewModels;
using UnitedTractorLib.Models;

namespace UnitedTractorApp.Views
{
    /// <summary>
    /// Interaction logic for TambahKaryawan.xaml
    /// </summary>
    public partial class TambahKaryawan :MetroWindow
    {
        private ViewModels.KaryawansVM karyawansVM;
        private Customer selectedItem;

        public TambahKaryawan(ViewModels.KaryawansVM karyawansVM)
        {
            InitializeComponent();
            this.karyawansVM = karyawansVM;
            this.DataContext = new ViewModels.TambahKaryawanVM(karyawansVM) {CloseWindow= Close };
        }

        public TambahKaryawan(KaryawansVM karyawansVM, Customer selectedItem)
        {
            InitializeComponent();
            this.karyawansVM = karyawansVM;
            this.DataContext = new ViewModels.TambahKaryawanVM(karyawansVM, selectedItem) { CloseWindow = Close };
            this.selectedItem = selectedItem;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
