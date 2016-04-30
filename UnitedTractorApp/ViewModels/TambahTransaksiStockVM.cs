using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorApp.ViewModels
{
    public class TambahTransaksiStockVM:UnitedTractorLib.ViewModelBase
    {
        private UnitedTractorLib.Models.Kategori kategori;
        private UnitedTractorLib.Models.Tolls tolls;
        private UnitedTractorLib.Contexts.Pengadaan.RepositoryTransaksiStock Context;
        private string _cat;
        private string _tolls;
        private int _jumlah;
        private double _harga;

        public TambahTransaksiStockVM(UnitedTractorLib.Models.Kategori kategori, UnitedTractorLib.Models.Tolls tolls)
        {
            // TODO: Complete member initialization
            this.kategori = kategori;
            this.tolls = tolls;
            this.Context = new UnitedTractorLib.ContextFactory().Tolls.TransaksiStockContext;
            AddItem = new CommandHandler { CanExecuteAction = x => AddItemValidate(), ExecuteAction = x => AddItemAction() };
            Close = new CommandHandler { CanExecuteAction = x => DeleteItemValidate(), ExecuteAction = x => DeleteItemAction() };
        }


        //Command
        public Action CloseWindow { get; set; }


        public CommandHandler AddItem { get; set; }
        public CommandHandler Close { get; set; }

        //Validate

        public bool AddItemValidate()
        {
            return true;
        }


        public bool DeleteItemValidate()
        {
            return true;
        }
        //Action


        public void AddItemAction()
        {
            var item = new UnitedTractorLib.Models.TransaksiStock{Tollsid=tolls.Id, KategoriId=kategori.Id, Jumlah=this.Jumlah, HargaBeli=this.HargaBeli, Tanggal=DateTime.Now};
            var result = Context.InsertAndGetLastID(item);
        }

        public void DeleteItemAction()
        {
            CloseWindow();
        }


        //Properies

        public string CategoryName
        {
            get { return _cat; }
            set
            {
                _cat = value;
                _cat = value;
                OnPropertyChanged("CategoryName");
            }
        }
        public string TollsName
        {
            get { return _tolls; }
            set
            {
                _tolls = value;
                OnPropertyChanged("TollsName");
            }
        }

        public int Jumlah
        {
            get { return _jumlah; }
            set
            {
                _jumlah = value;
                OnPropertyChanged("Jumlah");
            }
        }

        public double HargaBeli
        {
            get { return _harga; }
            set
            {
                _harga = value;
                OnPropertyChanged("HargaBeli");
            }
        }
    }
}
