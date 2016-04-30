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
    /// Interaction logic for ItemPengembalian.xaml
    /// </summary>
    public partial class ItemPengembalian : Window
    {
        private UnitedTractorLib.Models.PeminjamanDetails value;

        public List<UnitedTractorLib.StatusTolls> StatusTolls { get; set; }

       

        public ItemPengembalian(UnitedTractorLib.Models.PeminjamanDetails value)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.value = value;
            var s = Enum.GetNames(typeof(UnitedTractorLib.StatusTolls));
            StatusTolls = new List<UnitedTractorLib.StatusTolls>();
            foreach(var item in s)
            {
                UnitedTractorLib.StatusTolls i = (UnitedTractorLib.StatusTolls)Enum.Parse(typeof(UnitedTractorLib.StatusTolls), item);
                StatusTolls.Add(i);
            }

            this.DataContext = this;
        }

        public UnitedTractorLib.StatusTolls SelectedItem { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Item = new UnitedTractorLib.Models.PengembalianDetails { Keadaantolls = SelectedItem, TollsItemId = value.TollsItemId, Tollsid = value.Tollsid, Keterangan = txtKeterangan.Text , TollItem=value.TOllDetails, TollKode=value.TollKode, TollName=value.TollName};
            this.Close();
        }





        public UnitedTractorLib.Models.PengembalianDetails Item { get; set; }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Item = null;
            this.Close();
        }
    }
}
