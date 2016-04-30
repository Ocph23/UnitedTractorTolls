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
    /// Interaction logic for BrowseTolls.xaml
    /// </summary>
    public partial class BrowseTolls : Window
    {
        private UnitedTractorLib.Contexts.Pengadaan.RepositoryTolls PengadaanContext;
        private System.Collections.ObjectModel.ObservableCollection<ViewModels.Request> DataSource;
        private CollectionView collection;
        private Image _gambar;
        private UnitedTractorLib.Models.Tolls _selected;
        private string _search;

        //properti

        public Image Gambar
        {
            get { return _gambar; }
            set
            {
                _gambar = value;
            }
        }

        public string Keterangan { get; set; }

        public CollectionView DataSourceView { get; set; }

        public CommandHandler CmdAdd { get; set; }
        public CommandHandler CmdClose { get; set; }

        public UnitedTractorLib.Models.Tolls SelectedItem
        {
            get { return _selected; }
            set
            {
                this.Keterangan = value.Keterangan;
                _selected = value;
            }
        }


        public BrowseTolls(UnitedTractorLib.Contexts.Pengadaan.RepositoryTolls PengadaanContext, System.Collections.ObjectModel.ObservableCollection<ViewModels.Request> DataSource, CollectionView collection)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.PengadaanContext = PengadaanContext;
            this.DataSource = DataSource;
            this.collection = collection;
            DataSourceView = (CollectionView)CollectionViewSource.GetDefaultView(PengadaanContext.DaftarTolls);
            CmdAdd = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => CmdAddAction() };
            CmdClose = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => CmdCloseAction() };
            this.DataContext = this;



            this.DataContext = this;
        }

        private void CmdCloseAction()
        {
            this.Close();
        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        public void CmdAddAction()
        {
            if(this.SelectedItem!=null)
            {
                DataSource.Add(new ViewModels.Request
                {
                    Keterangan = SelectedItem.Keterangan,
                    Kode = this.SelectedItem.Kode,
                    Name = this.SelectedItem.Nama,
                    TollsId = this.SelectedItem.Id
                });

                collection.Refresh();
            }
        }

    }
}
