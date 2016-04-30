using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UnitedTractorApp.ViewModels
{
    public class CreatePengembalianVM:UnitedTractorLib.ViewModelBase
    {
        private UnitedTractorLib.Contexts.Gudang.RepositoryPengembalian ContextPengembalian;
        public UnitedTractorLib.Models.Peminjaman Peminjaman { get; set; }
        public CollectionView DataSourceView { get; set; }
        public ObservableCollection<UnitedTractorLib.Models.PengembalianDetails> DataSource { get; set; }
        public List<UnitedTractorLib.Models.PeminjamanDetails> ComboItems { get; set; }
        private List<UnitedTractorLib.Models.Pengembalian> Pengembalians;
        private UnitedTractorLib.Models.User user;
        private UnitedTractorLib.Models.PeminjamanDetails _comboselected;

        public CollectionView ComboItemsView { get; set; }
     

        public CreatePengembalianVM(UnitedTractorLib.Models.Peminjaman peminjaman, List<UnitedTractorLib.Models.Pengembalian> pengembalians)
        {
            // TODO: Complete member initialization
            this.Peminjaman = peminjaman;
            this.Pengembalians = pengembalians;
            this.user = (App.Current.Windows[0] as MainApp).user;
            this.ContextPengembalian = new UnitedTractorLib.ContextFactory().Pengembalian;
            DataSource = new ObservableCollection<UnitedTractorLib.Models.PengembalianDetails>();
            DataSourceView = (CollectionView)CollectionViewSource.GetDefaultView(DataSource);
            SaveCommand = new CommandHandler { CanExecuteAction = x => SaveCommandValidate(), ExecuteAction = x => SaveCommandAction() };
            this.ComboItems = this.Peminjaman.Details.Where(O => O.IsReturnBack == false).ToList();
            ComboItemsView = (CollectionView)CollectionViewSource.GetDefaultView(ComboItems);
        }



        public UnitedTractorLib.Models.PeminjamanDetails SelectedItem
        {
            get { return _comboselected;}
            set
            {
                _comboselected = value;
                OnPropertyChanged("SelectedItem");
                if (value != null)
                {
                    var form = new Views.ItemPengembalian(value);
                    form.ShowDialog();
                    if (form.Item != null)
                    {
                        DataSource.Add(form.Item);
                        var i = ComboItems.Where(O => O.TollsItemId == form.Item.TollsItemId).FirstOrDefault();
                        ComboItems.Remove(i);
                    }
                    DataSourceView.Refresh();
                    ComboItemsView.Refresh();
                }
               
            }
        }


        //Command

        public CommandHandler SaveCommand { get; set; }


        //Command Validated

      
        public bool SaveCommandValidate()
        {
            if (Peminjaman!=null && Peminjaman.Details.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        //CommandAction
     

        public void SaveCommandAction()
        {
            if (this.DataSource.Count > 0)
            {
                UnitedTractorLib.Models.Pengembalian k = new UnitedTractorLib.Models.Pengembalian { Details = this.DataSource.ToList(), Id = 0, Peminjamanid = this.Peminjaman.Id, Tglkembali = DateTime.Now, Petugasid = user.Id };

                var isCompleted = this.CheckIfcompleted();
                ContextPengembalian.Insert(ref k, isCompleted);
            }
           
            
            
           
        }

        private bool CheckIfcompleted()
        {
            int isbackCount = 0;
            var pengembalians = ContextPengembalian.GetPengembalian(this.Peminjaman.Id);
            if (pengembalians.Count > 0)
            {

                foreach (var item in pengembalians)
                {
                    foreach (var itemdetails in item.Details)
                    {
                        isbackCount++;
                    }
                }
            }

            if ((isbackCount + DataSource.Count) == this.Peminjaman.Details.Count)
            {
                return true;
            }
            else
                return false;
        }

    }
}
