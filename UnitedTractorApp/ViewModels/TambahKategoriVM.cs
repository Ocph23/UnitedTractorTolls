using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib;

namespace UnitedTractorApp.ViewModels
{
    public class TambahKategoriVM:ViewModelBase
    {
        
        public TambahKategoriVM()
        {
            // TODO: Complete member initialization
            var window = App.Current.Windows[0] as MainApp;
            this.user = window.user;
            this.Load();
        }

        public TambahKategoriVM(UnitedTractorLib.Models.Kategori SelectedItem)
        {
            this.Load();
            // TODO: Complete member initialization
            this.SelectedItem = SelectedItem;
            this.Id = SelectedItem.Id;
            this.Nama = SelectedItem.Nama;
            this.Keterangan = SelectedItem.Keterangan;
            var window = App.Current.Windows[0] as MainApp;
            this.user = window.user;
            

        }

        public void Load()
        {
            CmdAdd = new CommandHandler { CanExecuteAction = x => CmdAddValidate(), ExecuteAction = x => CmdAddAction() };
            CmdClose = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => CmdCloseAction() };
            this.CategoryContext = new UnitedTractorLib.ContextFactory().Tolls;
        }

        private bool CmdAddValidate()
        {
            if (user.Accesslevel == AccessLevel.Administrator)
                return true;
            else
                return false;
        }


        //Command 

        public CommandHandler CmdAdd { get; set; }
        public CommandHandler CmdClose { get; set; }
        public Action CloseWindow { get; set; }


        // CommandAction

        public void CmdAddAction() {

            var model = this.CollectModel();

            this.Id = CategoryContext.KategoryContext.InsertAndGetLastID(model);
        
        
        }


        public UnitedTractorLib.Models.Kategori CollectModel()
        {
           return new UnitedTractorLib.Models.Kategori{ Id=this.Id, Keterangan = this.Keterangan, Nama = this.Nama };
        }

        public void CmdCloseAction() {

            this.CloseWindow();
        }

        // Properties

        private int _id;
        private string _nama;
        private string _ket;
        private UnitedTractorLib.Models.User user;
        private UnitedTractorLib.Contexts.Pengadaan.RepositoryTolls CategoryContext;
        private UnitedTractorLib.Models.Kategori SelectedItem;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Nama
        {
            get { return _nama; }
            set
            {
                _nama = value;
                OnPropertyChanged("Nama");
            }
        }

        public string Keterangan
        {
            get { return _ket; }
            set
            {
                _ket = value;
                OnPropertyChanged("Keterangan");
            }
        }


        public bool IsUpdated { get; set; }
    }
}
