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
    /// Interaction logic for Karyawans.xaml
    /// </summary>
    public partial class Karyawans : Page
    {

        public Karyawans()
        {
            InitializeComponent();

            this.DataContext = new ViewModels.KaryawansVM() {  };
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
