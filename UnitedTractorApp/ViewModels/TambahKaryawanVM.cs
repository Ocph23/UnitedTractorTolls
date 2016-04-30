using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using UnitedTractorLib;
using UnitedTractorLib.Models;

namespace UnitedTractorApp.ViewModels
{
    public class TambahKaryawanVM:ViewModelBase
    {
        private KaryawansVM karyawansVM;
        private int _id;
        private string _nik;
        private string _nama;
        private string _jabatan;
        private string _alamat;
        private string _email;
        private string _hp;
        private string _message;
        private Customer selectedItem;
        private BitmapImage _gambar;
        private byte[] _photo;

        public TambahKaryawanVM(KaryawansVM karyawansVM)
        {
            // TODO: Complete member initialization
            this.karyawansVM = karyawansVM;
            this.Load();
          
        }

        public TambahKaryawanVM(KaryawansVM karyawansVM, Customer selectedItem)
        {
            this.karyawansVM = karyawansVM;
            this.selectedItem = selectedItem;
            this.Load();

            this.Id = selectedItem.Id;
            this.Alamat = selectedItem.Alamat;
            this.Email = selectedItem.Email;
            this.Hp = selectedItem.Hp;
            this.Id = selectedItem.Id;
            this.Jabatan = selectedItem.Jabatan;
            this.Nama = selectedItem.Nama;
            this.Nik = selectedItem.Nik;

        }


        private void Load()
        {
            SaveCommand = new CommandHandler { CanExecuteAction = o => SaveCommandIsValid(), ExecuteAction = o => SaveCommandaction() };
            CloseCommand = new CommandHandler { CanExecuteAction = O => true, ExecuteAction = x => Close() };
            ChangePicture = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => ChangePictureAction() };

        }

      

        public CommandHandler SaveCommand { get; set; }
        public CommandHandler CloseCommand { get; set; }
        public Action CloseWindow { get; set; }

        public CommandHandler ChangePicture { get; set; }
        
        public void Close()
        {
            this.CloseWindow();
        }

        private void ChangePictureAction()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            MemoryStream stream = new MemoryStream();
            if (f.FileName !=string.Empty)
            {
                f.OpenFile().CopyTo(stream);
             
                Gambar = Common.ImageHelpers.ConvertStreamToBitmatImage(stream);
            }
        }

        public BitmapImage Gambar
        {
            get { return _gambar; }
            set
            {
                _gambar = value;
                OnPropertyChanged("Gambar");
            }
        }
        public void SaveCommandaction()
        {
            if(this.Id<=0)
            {
                this.selectedItem = this.CollectModel();
                if (this.karyawansVM.Context.Insert(selectedItem))
                {
                    this.karyawansVM.Source.Refresh();
                    this.Close();
                }
            }else
            {
               this.selectedItem= this.CollectModel();
                if (this.karyawansVM.Context.Update(selectedItem))
                {
                    this.karyawansVM.Source.Refresh();
                    this.Close();
                }
            }
        }

        private UnitedTractorLib.Models.Customer CollectModel()
        {
            return new UnitedTractorLib.Models.Customer
            {
                Nik = this.Nik,
                Nama = this.Nama,
                Jabatan = this.Jabatan,
                Hp = this.Hp,
                Email = this.Email,
                Alamat = this.Alamat,
                Id = this.Id, Photo=this.Photo
            };
        }


        public void CloseCommandAction()
        {
            this.CloseWindow();
        }


        //validate

        public bool SaveCommandIsValid()
        {
            if (string.IsNullOrEmpty(this.Nik))
            {
                ChangeMessage("NIK Tidak Boleh Kosong");
                return false;
            }
            if(string.IsNullOrEmpty(Nama))
            {
                ChangeMessage("Nama Tidak Boleh Kosong");
                return false;
            }

            if(string.IsNullOrEmpty(Jabatan))
            {
                ChangeMessage(" Jabatan Tidak Boleh Kosong ");
                return false;
            }

        
            if (string.IsNullOrEmpty(Email))
            {
                ChangeMessage("Email Tidak Boleh Kosong ");
                return false;
            }
            if (!Email.Contains('@') || !Email.Contains('.'))
            {
                ChangeMessage("Email Yang Anda Masukkan Salah");
                return false;
            }
            if (string.IsNullOrEmpty(Hp))
            {
                ChangeMessage(" Nomor Hp/Tlp Tidak Boleh Kosong ");
                return false;
            }
            if (string.IsNullOrEmpty(Alamat))
            {
                ChangeMessage(" Alamat Tidak Boleh Kosong ");
                return false;
            }

            ChangeMessage("");
            return true;
        }
        //

        public string ErrorMessage
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("ErrorMessage");
            }
        }


        public void ChangeMessage(string message)
        {
            this.ErrorMessage = string.Empty;
            this.ErrorMessage = message;
        }

        public int Id{
            get {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");

            }
        }

        public string Nik
        {
            get
            {
                return _nik;
            }
            set
            {
                _nik = value;
                OnPropertyChanged("Nik");

            }
        }

        public string Nama
        {
            get
            {
                return _nama;
            }
            set
            {
                _nama = value;
                OnPropertyChanged("Nama");
            }
        }

        public string Jabatan
        {
            get
            {
                return _jabatan;
            }
            set
            {
                _jabatan = value;
                OnPropertyChanged("Jabatan");

            }
        }

        public string Alamat
        {
            get
            {
                return _alamat;
            }
            set
            {
                _alamat = value;
                OnPropertyChanged("Alamat");
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Hp
        {
            get { return _hp; }
            set
            {
                _hp = value;
                OnPropertyChanged("Hp");
            }
        }

        public byte[] Photo
        {

            get
            {
                if(_photo==null)
                {
                    MemoryStream ms = Gambar.StreamSource as MemoryStream;
                    _photo = Common.ImageHelpers.CreateThumbnail( ms.ToArray(),200);
                }
                return _photo;
            }
            set
            {
                _photo = value;
                if (value != null && value.Length > 0)
                    Gambar = Common.ImageHelpers.ConvertByteArrayToBitmatImage(value);
                OnPropertyChanged("Photo");
            }
        }

    }
}
