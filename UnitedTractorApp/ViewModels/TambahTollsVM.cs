using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using UnitedTractorLib;
using System.Windows.Data;

namespace UnitedTractorApp.ViewModels
{
    public class TambahTollsVM:ViewModelBase
    {
        private DaftarTollsVM daftarTollsVM;
        public TambahTollsVM(DaftarTollsVM daftarTollsVM)
        {
            // TODO: Complete member initialization
            this.daftarTollsVM = daftarTollsVM;
            this.Load();
        }

        public TambahTollsVM(DaftarTollsVM daftarTollsVM, UnitedTractorLib.Models.Tolls tolls)
        {
            // TODO: Complete member initialization
            this.daftarTollsVM = daftarTollsVM;
            this.Load();
            this.tolls = tolls;
            this.Gambar = tolls.Gambar;
            this.Id = tolls.Id;
            this.Kategoriid = tolls.Kategoriid;
            this.KategoriSelected = this.Kategories.Where(O => O.Id == tolls.Kategoriid).FirstOrDefault();

            this.Keterangan = tolls.Keterangan;
            this.Kode = tolls.Kode;
            this.Nama = tolls.Nama;

            
        }


        private void Load()
        {
            
            CmdPicture = new CommandHandler { ExecuteAction = x => CmdPictureAction(), CanExecuteAction = x => true };
            CmdAdd = new CommandHandler { CanExecuteAction = x => Isadministrator(), ExecuteAction = x => CmdAddAction() };
            CmdClose = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => CmdCloseAction() };
            Kategories = new UnitedTractorLib.ContextFactory().Tolls.KategoryContext.Select().ToList();
            KategoriesView = (CollectionView)CollectionViewSource.GetDefaultView(Kategories);
        }

        //Command

        public Action CloseWindow { get; set; }
        public CommandHandler CmdAdd { get; set; }
        public CommandHandler CmdClose { get; set; }
        public CommandHandler CmdPicture { get; set; }

        public void CmdPictureAction ()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            if (f.FileName != string.Empty)
            {
                MemoryStream stream = new MemoryStream();
                f.OpenFile().CopyTo(stream);
                Picture = Common.ImageHelpers.ConvertStreamToBitmatImage(stream);
            }
        }


        //action

        public void CmdAddAction()
        {
            var Context = new UnitedTractorLib.ContextFactory().Tolls;
            this.Model = this.CollectModel();
            if(this.Id<=0)
            {
               
                if(Context.Insert(Model))
                {
                    daftarTollsVM.DataSource.Refresh();
                }
            }else
            if(Context.Update(Model))
            {
                daftarTollsVM.DataSource.Refresh();
            }

            this.CloseWindow();
        }

        private UnitedTractorLib.Models.Tolls CollectModel()
        {
            return new UnitedTractorLib.Models.Tolls { Id = this.Id, Gambar = this.Gambar, Keterangan = this.Keterangan, 
                Nama = this.Nama, Kategoriid=KategoriSelected.Id };
        }


        public void CmdCloseAction() {

            this.Model = null;
            this.CloseWindow();

        }



        //validate

        public bool Isadministrator()
        {
            if (daftarTollsVM.userIsLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator)
            {
                return true;
            }
            else
                return false;
        }




        //Properties
        private int _id;
        private int _kategoriid;
        private string _nama;
        private BitmapImage _picture;
        private byte[] _gambar;
        private string _ket;
        private UnitedTractorLib.Models.Tolls tolls;
        private string _kode;
     
        public int Id
        {
            get { return _id; }
            set { 
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Kode
        {
            get { return _kode; }
            set { _kode = value;
            OnPropertyChanged("Kode");
            }
        }
        public int Kategoriid
        {
            get { return _kategoriid; }
            set
            {
                _kategoriid = value;
                OnPropertyChanged("kategoriid");
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

        public byte[] Gambar
        {

            get {

                if (Picture != null && Picture.StreamSource != null)
                {
                    MemoryStream stream = new MemoryStream();
                    Picture.StreamSource.CopyTo(stream);
                    _gambar = stream.ToArray();
                }
                return _gambar;
            }
            set
            {
                _gambar = value;
                if(value!=null && value.Length>0)
                Picture = Common.ImageHelpers.ConvertByteArrayToBitmatImage(value);
                OnPropertyChanged("Gambar");
            }
        }
       

        public BitmapImage Picture
        {
            get { return _picture; }
            set
            {
                _picture = value;
                OnPropertyChanged("Picture");
            }
        }



        public List<UnitedTractorLib.Models.Kategori> Kategories { get; set; }
        public UnitedTractorLib.Models.Kategori KategoriSelected { get; set; }

        public UnitedTractorLib.Models.Tolls Model { get; set; }
        public CollectionView KategoriesView { get; private set; }
    }
}
