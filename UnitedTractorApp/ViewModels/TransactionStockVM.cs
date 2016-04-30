using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UnitedTractorApp.ViewModels
{
    public class TransactionStockVM:UnitedTractorLib.ViewModelBase
    {
        private UnitedTractorLib.Models.Kategori _kat;
        private UnitedTractorLib.Models.Tolls _toll;
        private List<UnitedTractorLib.Models.Tolls> _listTolls;
        public ObservableCollection<UnitedTractorLib.Models.TransaksiStock> Source { get; set; }
        public CollectionView SourceView { get; set; }
        public UnitedTractorLib.Models.TransaksiStock SelectedItem { get; set; }

        public List<UnitedTractorLib.Models.Kategori> Kategories { get; set; }

        public UnitedTractorLib.Models.Kategori CategorySelectedItem
        {
            get { return _kat; }
            set
            {
                _kat = value;
                TollsSelectedItem = null;
                if(_kat!=null)
                {
                    Tolles = new List<UnitedTractorLib.Models.Tolls>();

                   Tolles = Context.DaftarTolls.Where(O => O.Kategori.Id == _kat.Id).ToList();
                   

                    SourceView.Refresh();
                }
                OnPropertyChanged("CategorySelectedItem");
            }

        }



        public List<UnitedTractorLib.Models.Tolls> Tolles
        {
            get
            {
                return _listTolls;
            }
            set
            {
                _listTolls = value;
                OnPropertyChanged("Tolles");
            }
        }
        public UnitedTractorLib.Models.Tolls TollsSelectedItem
        {
            get { return _toll; }
            set
            {
                _toll = value;
                OnPropertyChanged("TollsSelectedItem");
                this.SourceView.Refresh();
               
            }
        }


        public UnitedTractorLib.Contexts.Pengadaan.RepositoryTolls Context { get; set; }
        public TransactionStockVM()
        {
            var window = (App.Current.Windows[0] as MainApp);
            this.UserLogin = window.user;
            this.Context = new UnitedTractorLib.ContextFactory().Tolls;

            
            Kategories = Context.KategoryContext.Select().ToList();
            Tolles = new List<UnitedTractorLib.Models.Tolls>();


            Source = new ObservableCollection<UnitedTractorLib.Models.TransaksiStock>(Context.TransaksiStockContext.Select());
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(Source);
            SourceView.Filter = this.FilterOutA;



            AddTransaction = new CommandHandler { CanExecuteAction = x => AddTransactionValidate(), ExecuteAction = x => AddCommandAction() };
            DeleteTransaction = new CommandHandler { CanExecuteAction = x => DeleteTransactionValidate(), ExecuteAction = x => DeleteCommandActin() };

        }

        public bool FilterOutA(object item)
        {
            if (CategorySelectedItem != null)
            {
                if (this.TollsSelectedItem != null)
                {
                    var transaksi = (UnitedTractorLib.Models.TransaksiStock)item;
                    return (transaksi.Tollsid.Equals(TollsSelectedItem.Id) && transaksi.KategoriId.Equals(CategorySelectedItem.Id));
                }
                else
                {
                    var transaksi = (UnitedTractorLib.Models.TransaksiStock)item;
                    return (transaksi.KategoriId.Equals(CategorySelectedItem.Id));
                }
            }
            else
                return false;
        }


        //Command
        public CommandHandler AddTransaction { get; set; }
        public CommandHandler DeleteTransaction { get; set; }
      
        
        //Command Validated

        public bool AddTransactionValidate()
        {
            if (this.UserLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator && TollsSelectedItem !=null)
                return true;
            else
                return false;
        }

        public bool DeleteTransactionValidate()
        {
            if (this.UserLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator && this.SelectedItem!=null)
                return true;
            else
                return false;
        }


        //CommandAction

        public void AddCommandAction()
        {
            var form = new Views.TambahTransaksiStock(this.CategorySelectedItem,this.TollsSelectedItem);
            form.ShowDialog();
        }

        public void DeleteCommandActin()
        {

        }


        public UnitedTractorLib.Models.User UserLogin { get; set; }
    }
}
