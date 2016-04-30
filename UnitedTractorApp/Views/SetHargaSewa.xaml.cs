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
using UnitedTractorLib.DTO;
using UnitedTractorLib.Models;

namespace UnitedTractorApp.Views
{
    /// <summary>
    /// Interaction logic for SetHargaSewa.xaml
    /// </summary>
    public partial class SetHargaSewa : Window
    {
      
        public SetHargaSewa()
        {
            InitializeComponent();
        }

        public SetHargaSewa(Tolls selectedItem)
        {
            InitializeComponent();
            this.DataContext = new ViewModels.SetHargaSewaVM(selectedItem);
        }


        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
