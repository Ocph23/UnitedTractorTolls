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
    /// Interaction logic for TambahKategori.xaml
    /// </summary>
    public partial class TambahKategori : MetroWindow
    {
        private UnitedTractorLib.Models.Kategori SelectedItem;


        public TambahKategori()
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.DataContext = new ViewModels.TambahKategoriVM() { CloseWindow = this.Close };
        }

        public TambahKategori(UnitedTractorLib.Models.Kategori SelectedItem)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.SelectedItem = SelectedItem;
            this.DataContext = new ViewModels.TambahKategoriVM(SelectedItem) { CloseWindow = this.Close };
        }
    }
}
