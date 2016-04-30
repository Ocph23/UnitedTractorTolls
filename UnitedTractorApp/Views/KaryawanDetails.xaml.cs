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
using UnitedTractorLib.Models;

namespace UnitedTractorApp.Views
{
    /// <summary>
    /// Interaction logic for KaryawanDetails.xaml
    /// </summary>
    public partial class KaryawanDetails : Window
    {
        private Customer selectedItem;

       
        public KaryawanDetails(Customer selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            this.DataContext = selectedItem;
        }
    }
}
