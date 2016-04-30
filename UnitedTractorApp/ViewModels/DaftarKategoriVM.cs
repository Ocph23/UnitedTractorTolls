using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UnitedTractorApp.ViewModels
{
    public class DaftarKategoriVM:UnitedTractorLib.ViewModelBase
    {
        private UnitedTractorLib.Models.User UserLogin;
        public ObservableCollection<UnitedTractorLib.Models.Kategori> Source { get; set; }
        public CollectionView SourceView { get; set; }
        public UnitedTractorLib.Models.Kategori SelectedItem { get; set; }

        public DaftarKategoriVM()
        {
            var window = App.Current.Windows[0] as MainApp;
            this.UserLogin = window.user;
            this.Context = new UnitedTractorLib.ContextFactory().Tolls.KategoryContext;
            Source = new ObservableCollection<UnitedTractorLib.Models.Kategori>(Context.Select());
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(Source);


            AddItem = new CommandHandler { CanExecuteAction = x => AddItemValidate(), ExecuteAction = x => AddItemAction() };
            EditItem = new CommandHandler { CanExecuteAction = x => EditItemValidate(), ExecuteAction = x => EditItemAction() };
            DeleteItem = new CommandHandler { CanExecuteAction = x => DeleteItemValidate(), ExecuteAction =x=> DeleteItemAction() };
        }


        //Command

        public CommandHandler AddItem { get; set; }
        public CommandHandler EditItem { get; set; }
        public CommandHandler DeleteItem { get; set; }
        


        //Validate 

        public bool AddItemValidate()
        {
            if (UserLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator)
                return true;
            else
                return false;
        }

        public bool EditItemValidate()
        {
            if (UserLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator)
                return true;
            else
                return false;
        }

        public bool DeleteItemValidate()
        {
            if (UserLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator)
                return true;
            else
                return false;
        }


        //validate

        public void AddItemAction()
        {
            var form = new Views.TambahKategori();
            form.ShowDialog();
            var vm = form.DataContext as ViewModels.TambahKategoriVM;
            if(vm.Id>0)
            {
                var item = vm.CollectModel();
                Source.Add(item);
                SourceView.Refresh();
            }
        }



        public void EditItemAction()
        {
            var form = new Views.TambahKategori(SelectedItem);
            form.ShowDialog();
            var vm = form.DataContext as ViewModels.TambahKategoriVM;
            if(vm.IsUpdated)
            {
                var item = vm.CollectModel();
                var olditem = Source.Where(O => O.Id == item.Id).FirstOrDefault();
                if(olditem!=null)
                {
                    olditem.Nama = item.Nama;
                    olditem.Keterangan = item.Keterangan;
                    SourceView.Refresh();
                }

            }


        }

        public void DeleteItemAction()
        {
            var isDeleted = Context.Delete(SelectedItem.Id);
            if(isDeleted)
            {
                Source.Remove(SelectedItem);
                SourceView.Refresh();
            }
        }

        public UnitedTractorLib.Contexts.Pengadaan.RepositoryKategori Context { get; set; }
    }
}
