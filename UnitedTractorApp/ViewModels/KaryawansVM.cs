using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using UnitedTractorLib.Contexts.Customer;
using UnitedTractorLib;


namespace UnitedTractorApp.ViewModels
{
    public class KaryawansVM : ViewModelBase
    {
        private UnitedTractorLib.Models.User UserLogin;
        private UnitedTractorLib.Models.Customer _selected;
        public RepositoryCustomer Context { get; set; }
        public ObservableCollection<UnitedTractorLib.Models.Customer> DataSource { get; set; }
        public CollectionView Source { get; set; }
        public UnitedTractorLib.Models.Customer SelectedItem
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public KaryawansVM()
        {
            this.Context = new ContextFactory().Karyawan;
             this.DataSource = new ObservableCollection<UnitedTractorLib.Models.Customer>(Context.Customers);
            Source = (CollectionView)CollectionViewSource.GetDefaultView(DataSource);
            this.UserLogin = (App.Current.Windows[0] as MainApp).user;
            CmdTambah = new CommandHandler { ExecuteAction = O => CmdTambahAction(), CanExecuteAction = O => CmdValidate() };
            CmdHapus = new CommandHandler { ExecuteAction = x => CmdHapusAction(), CanExecuteAction = x => CmdValidate() };
            CmdEdit = new CommandHandler { CanExecuteAction = x => CmdValidate(), ExecuteAction = x => CmdEditAction() };
            CmdDetails = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => CmdDetailsAction() };
            //Parent Window Show
        }

    

        public CommandHandler CmdTambah { get; set; }
        public CommandHandler CmdEdit { get; set; }
        public CommandHandler CmdHapus { get; set; }
        public CommandHandler CmdDetails { get; set; }
        public CommandHandler CmdKeluar { get; set; }
       

        //action


        public void CmdTambahAction()
        {
            var form = new Views.TambahKaryawan(this);
            form.ShowDialog();
        }
       
        private void CmdDetailsAction()
        {
            var form = new Views.KaryawanDetails(SelectedItem);
            form.ShowDialog();
        }
        private void CmdEditAction()
        {
            var form = new Views.TambahKaryawan(this, SelectedItem);
            form.ShowDialog();
            var vm = (ViewModels.TambahKaryawanVM)form.DataContext;
            var item = DataSource.Where(O => O.Id == vm.Id).FirstOrDefault();
            if(item!=null)
            {
                item.Alamat = vm.Alamat;
                item.Email = vm.Email;
                item.Hp = vm.Hp;
                item.Jabatan = vm.Jabatan;
                item.Nama = vm.Nama;
                item.Nik = vm.Nik;
                item.Photo = vm.Photo;
                
            }

            Source.Refresh();
            
        }
        private void CmdHapusAction()
        {
            if (SelectedItem != null)
            {
                Context.Delete(SelectedItem.Id);
                Source.Refresh();
            }

        }
        //validate
        private bool CmdValidate()
        {
            if (this.UserLogin.Accesslevel == AccessLevel.Administrator)
            { return true; }
            else
                return false;
        }
    }
}