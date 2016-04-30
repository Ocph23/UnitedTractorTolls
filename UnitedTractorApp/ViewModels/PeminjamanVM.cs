using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UnitedTractorLib;
using UnitedTractorLib.Contexts.Peminjaman;

namespace UnitedTractorApp.ViewModels
{
    public class PeminjamanVM:ViewModelBase
    {
        public UnitedTractorLib.Models.Permintaan permintaan { get; set; }
        public RepositoryPeminjaman PeminjamanContext = new ContextFactory().Peminjaman;
        public UnitedTractorLib.Contexts.Pengadaan.RepositoryTolls PengadaanContext = new ContextFactory().Tolls;
        public CollectionView KaryawanCollection { get; set; }
        public ObservableCollection<ViewModels.Request> DataSource { get; set; }
        public CollectionView collection { get; set; }


        public CommandHandler AddNewTolls { get; set; }
        public CommandHandler CekKetersediaan { get; set; }
        public CommandHandler Cancel { get; set; }

        public Action WindowClose { get; set; }
        public ViewModels.Request SelectedItem
        {
            get { return _req; }
            set
            {
                
             
                _req = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        private UnitedTractorLib.Models.User user;
        private string _kode;
        private int _karyawanId;
        private DateTime _tanggal;
        private string _content;
        private Request _req;
        public PeminjamanVM(UnitedTractorLib.Models.User user)
        {
            // TODO: Complete member initialization
            this.CmdProccessContent = "Cek";
            this.user = user;

            DataSource = new ObservableCollection<Request>(new List<ViewModels.Request>());
            collection = (CollectionView)CollectionViewSource.GetDefaultView(DataSource);
            var sr = new ContextFactory().Karyawan.Customers;
            KaryawanCollection =(CollectionView)CollectionViewSource.GetDefaultView(sr);
            CekKetersediaan = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => CekKetersediaanAction() };
            AddNewTolls = new CommandHandler { ExecuteAction = x => AddNewTollsAction(), CanExecuteAction = x => true };
            Cancel = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => this.Close() };
            this.Tanggal = DateTime.Now;
        }

        private void Close()
        {
            this.Model = null;
            this.WindowClose();
        }

        public void CekKetersediaanAction()
        {
            
            if(this.CanContinue==false)
            {
                this.permintaan = this.ConvertRequestToPermintaan();
                var result = PeminjamanContext.CekKetersediaanTolls(permintaan);
                this.UpdateStatusKeberadaan(result);
                if (result!=null && result.Details.Where(O => O.Statustolls == StatusStock.Ada).Count() > 0)
                {
                    this.Kode = result.Kode;
                    this.CanContinue = true;
                    this.CmdProccessContent = "Lanjutkan";
                    permintaan = result;
                  
                }
              
            }else
            {
                this.Model= this.PeminjamanContext.RequestNewPermintaan(permintaan);
                this.WindowClose();
            }
        }

        private void UpdateStatusKeberadaan(UnitedTractorLib.Models.Permintaan result)
        {
           foreach(var item in result.Details)
           {
               var res = this.DataSource.Where(O => O.TollsId == item.Tollsid).FirstOrDefault();
               res.Ketersediaan = item.Statustolls;
           }
           this.collection.Refresh();
        }

        private UnitedTractorLib.Models.Permintaan ConvertRequestToPermintaan()
        {
            return new UnitedTractorLib.Models.Permintaan
            {
                Id = 0,
                Karyawanid = this.KaryawanID,
                Tglpengajuan = this.Tanggal,
                Kode = this.Kode,
                Details = ConvertRequestItemsToPermintaanItems()
            };
        }

        private List<UnitedTractorLib.Models.PermintaanDetails> ConvertRequestItemsToPermintaanItems()
        {
            List<UnitedTractorLib.Models.PermintaanDetails> list =  new List<UnitedTractorLib.Models.PermintaanDetails>();
            foreach(var item in DataSource)
            {
                var obj = new UnitedTractorLib.Models.PermintaanDetails { Tollsid = item.TollsId };
                list.Add(obj);
            }
            return list;
        }

     
        public void AddNewTollsAction()
        {
            var form = new Views.BrowseTolls(PengadaanContext, DataSource, collection);
            form.ShowDialog();
        }

      

        public string Kode
        {
            get { return _kode; }
            set
            {
                _kode = value;
                base.OnPropertyChanged("Kode");
            }
        }

        public int KaryawanID
        {
            get { return _karyawanId; }
            set
            {
                _karyawanId = value;
                OnPropertyChanged("KaryawanID");
            }
        }

        public DateTime Tanggal
        {
            get { return _tanggal; }
            set
            {
                _tanggal = value;
                OnPropertyChanged("Tanggal");
            }
        }


        public bool CanContinue { get; set; }

        public string CmdProccessContent
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("CmdProccessContent");
            }
        }



        public UnitedTractorLib.Models.Peminjaman Model { get; set; }
    }
}
