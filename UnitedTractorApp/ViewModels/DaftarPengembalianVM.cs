using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UnitedTractorApp.ViewModels
{
    public class DaftarPengembalianVM:UnitedTractorLib.ViewModelBase
    {

        private UnitedTractorLib.Contexts.Gudang.RepositoryPengembalian ContextPengembalian;
        private string _kode;
        public UnitedTractorLib.Models.Peminjaman Peminjaman { get; set; }

        public CollectionView DataSourceView { get; set; }
        public CollectionView DetailsView { get; set; }
        public ObservableCollection<UnitedTractorLib.Models.Pengembalian> DataSource { get; set; }
        private List<UnitedTractorLib.Models.PengembalianDetails> Details;
        private UnitedTractorLib.Models.User user;
        private UnitedTractorLib.Models.Pengembalian _selected;


        public DaftarPengembalianVM()
        {
            this.user = (App.Current.Windows[0] as MainApp).user;
            this.ContextPengembalian = new UnitedTractorLib.ContextFactory().Pengembalian;
            DataSource = new ObservableCollection<UnitedTractorLib.Models.Pengembalian>();
            DataSourceView = (CollectionView)CollectionViewSource.GetDefaultView(DataSource);

            Details = new List<UnitedTractorLib.Models.PengembalianDetails>();
            DetailsView = (CollectionView)CollectionViewSource.GetDefaultView(Details);
            Search = new CommandHandler { CanExecuteAction = x => SearchValidate(), ExecuteAction = x => SearchAction() };
            NewPengembalian = new CommandHandler { CanExecuteAction = x => NewPengembalianValidation(), ExecuteAction = x => NewPengembalianAction() };
            PrintBuktiPengembalian = new CommandHandler { CanExecuteAction = x => PrintBuktiPengembalianValidate(), ExecuteAction = x => PrintBuktiPengembalianAction() };
        }

        private void PrintBuktiPengembalianAction()
        {
            var form = new Reports.Views.BuktiPengembalian(this.SelectedItem, this.Peminjaman);
            form.ShowDialog();
        }

        private bool PrintBuktiPengembalianValidate()
        {
            return true;
        }

        private void NewPengembalianAction()
        {
            var form = new Views.CreatePengembalian(this.Peminjaman, this.Pengembalians);
            form.ShowDialog();
        }

        private bool NewPengembalianValidation()
        {
            if (this.Peminjaman != null)
            {
                if (!Peminjaman.Completed)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        //View Properti
     

        public string Kode
        {
            get { return _kode; }
            set
            {
                _kode = value;
                OnPropertyChanged("Kode");

            }
        }



        public UnitedTractorLib.Models.Pengembalian SelectedItem
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (value != null)
                {
                    Details.Clear();
                    foreach (var item in value.Details)
                    {
                        Details.Add(item);
                    }
                    DetailsView.Refresh();
                }
                OnPropertyChanged("SelectedItem");
            }
        }


        //Command

        public CommandHandler Search { get; set; }
        public CommandHandler NewPengembalian { get; set; }
        public CommandHandler PrintBuktiPengembalian { get; set; }


        //Command Validated

        public bool SearchValidate()
        {
            if(String.IsNullOrEmpty(this.Kode))
            {
                return false;
            }else
                return true;

        }

       
        //CommandAction
        public void SearchAction()
        {
            this.Peminjaman = this.ContextPengembalian.GetPeminjamanByKode(this.Kode.ToUpper());
            
            if (this.Peminjaman != null)
            {
               
                this.Pengembalians = this.ContextPengembalian.GetPengembalian(Peminjaman.Id);
                if (Pengembalians.Count > 0)
                {
                    DataSource.Clear();
                    foreach(var item in Pengembalians)
                    {
                        DataSource.Add(item);
                    }
                }
            }
        }




        public List<UnitedTractorLib.Models.Pengembalian> Pengembalians { get; set; }
    }
}
