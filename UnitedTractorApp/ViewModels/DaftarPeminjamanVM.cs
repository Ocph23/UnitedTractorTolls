using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UnitedTractorLib.Models;

namespace UnitedTractorApp.ViewModels
{
    public class DaftarPeminjamanVM : UnitedTractorLib.ViewModelBase
    {
        public UnitedTractorLib.Contexts.Peminjaman.RepositoryPeminjaman ContextPeminjaman;
        private Peminjaman _selectedItem;
        private Customer _customer;


        public ObservableCollection<UnitedTractorLib.Models.Peminjaman> DataSource { get; set; }
        public CollectionView SourceView { get; set; }

        public ObservableCollection<UnitedTractorLib.Models.PeminjamanDetails> Details { get; set; }
        public CollectionView DetailsView { get; set; }
        public ObservableCollection<UnitedTractorLib.Models.PermintaanDetails> Requests { get; set; }
        public CollectionView RequestsView { get; set; }
  
        public Peminjaman SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                this.Details.Clear();
                foreach(var item in value.Details)
                {
                    this.Details.Add(item);
                }
                this.DetailsView.Refresh();


                this.Requests.Clear();

                foreach(var item in value.Permintaan.Details)
                {
                    Requests.Add(item);
                }


                this.Customer = _selectedItem.Customer;
            }
        }

        public DaftarPeminjamanVM()
        {
            this.UserLogin = (App.Current.Windows[0] as MainApp).user;
            this.ContextPeminjaman = new UnitedTractorLib.ContextFactory().Peminjaman;
            var data = ContextPeminjaman.DaftarPeminjaman.OrderByDescending(O => O.Id);
            this.DataSource = new ObservableCollection<Peminjaman>(data);
            this.SourceView = (CollectionView)CollectionViewSource.GetDefaultView(DataSource);
            this.Details = new ObservableCollection<PeminjamanDetails>();
            this.DetailsView = (CollectionView)CollectionViewSource.GetDefaultView(Details);
            this.Requests = new ObservableCollection<UnitedTractorLib.Models.PermintaanDetails>();
            this.RequestsView = (CollectionView)CollectionViewSource.GetDefaultView(Requests);
            AddItemPeminjaman = new CommandHandler { CanExecuteAction = x => this.AddItemPeminjamanValidate(), ExecuteAction = x => this.AddItemPeminjamanAction() };
            DeleteItemPeminjaman = new CommandHandler { CanExecuteAction = x => this.DeleteItemPeminjamanValidate(), ExecuteAction = x => DeleteItemPeminjamanAction() };
            PrintBuktiPembayaran = new CommandHandler { CanExecuteAction = x => PrintBuktiPembayaranValidate(), ExecuteAction = x => PrintBuktiPembayaranAction() };
        }

        private bool PrintBuktiPembayaranValidate()
        {
            if (this.UserLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator && this.SelectedItem != null)
            {
                return true;
            }
            else
                return false;
          
        }

        private void PrintBuktiPembayaranAction()
        {
            var form = new Reports.Views.BuktiPembayaran(this.SelectedItem);
            form.ShowDialog();
        }

        //Command validate
        private bool AddItemPeminjamanValidate()
        {
            if (this.UserLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator)
            {
                return true;
            }
            else
                return false;
        }

        private bool DeleteItemPeminjamanValidate()
        {
            if (this.UserLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator && this.SelectedItem != null)
            {
                return true;
            }
            else
                return false;
        }

        //command Action
        private void AddItemPeminjamanAction()
        {
            var form = new Views.Peminjaman();
            form.ShowDialog();
            ViewModels.PeminjamanVM vm = (ViewModels.PeminjamanVM)form.DataContext;
            if(vm.Model!=null)
            {
                this.DataSource.Add(vm.Model);
                this.SourceView.Refresh();
                this.SelectedItem = vm.Model;
            }
        }
        private void DeleteItemPeminjamanAction()
        {
            throw new NotImplementedException();
        }

        //command
        public CommandHandler AddItemPeminjaman { get; set; }
        public CommandHandler DeleteItemPeminjaman { get; set; }
        public CommandHandler PrintBuktiPembayaran { get; set; }


        public User UserLogin { get; set; }






        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged("Customer");
            }
        }
    }

}
