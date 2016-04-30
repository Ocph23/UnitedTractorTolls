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
    /// Interaction logic for CreatePengembalian.xaml
    /// </summary>
    public partial class CreatePengembalian : Window
    {

        public CreatePengembalian(UnitedTractorLib.Models.Peminjaman peminjaman, List<UnitedTractorLib.Models.Pengembalian> pengembalians)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.DataContext = new ViewModels.CreatePengembalianVM(peminjaman,pengembalians );
        }
    }
}
