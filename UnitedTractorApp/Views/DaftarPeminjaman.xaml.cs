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

namespace UnitedTractorApp.Views
{
    /// <summary>
    /// Interaction logic for DaftarPeminjaman.xaml
    /// </summary>
    public partial class DaftarPeminjaman : Page
    {
        public DaftarPeminjaman()
        {
            InitializeComponent();
            this.DataContext =new  ViewModels.DaftarPeminjamanVM();
        }
    }
}
