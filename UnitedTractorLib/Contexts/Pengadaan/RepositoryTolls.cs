using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.DTO;
using UnitedTractorLib.Models;

namespace UnitedTractorLib.Contexts.Pengadaan
{
    public class RepositoryTolls
    {

        public RepositoryKategori KategoryContext;
        public RepositoryTransaksiStock TransaksiStockContext;
        private List<Models.Tolls> _tolles;
        public List<Models.Tolls> DaftarTolls
        {
            get
            {
                if(_tolles == null)
                {
                    _tolles = this.Select().ToList();
                }
                return _tolles;
            }
        }

        public RepositoryTolls()
        {
            KategoryContext = new RepositoryKategori();
            TransaksiStockContext = new RepositoryTransaksiStock();
        }

        public bool Delete(int Id)
        {
            using (var db = new OcphDbContext())
            {
                var tr = db.Connection.BeginTransaction();
                try
                {
                    db.Stocks.Delete(O => O.Tollsid == Id);
                    db.TransaksiStocks.Delete(O => O.Tollsid == Id);
                    db.Tolles.Delete(O => O.Id == Id);
                    var item = DaftarTolls.Where(O=>O.Id==Id).FirstOrDefault();
                    this.DaftarTolls.Remove(item);
                    tr.Commit();
                    return true;
                }
                catch (Exception)
                {
                    tr.Rollback();
                    return false;
                }
            }
        }
        public bool Insert(UnitedTractorLib.Models.Tolls t)
        {
            var isValidated = this.TollsValidateInsert(t);
            if (isValidated)
            {
                using (var db = new OcphDbContext())
                {
                    var trans = db.Connection.BeginTransaction();
                    try
                    {
                        t.Kode = Common.GenerateCodeTolls(t.Kategoriid);
                        t.Id = db.Tolles.InsertAndGetLastID(t);
                        Models.Stock stock = new Models.Stock { Id = 0, Tollsid = t.Id, Jumlah = 0 };
                        stock.Id = db.Stocks.InsertAndGetLastID(stock);
                        t.Stock = stock;
                        t.Kategori = KategoryContext.SelectById(t.Kategoriid);
                        this.DaftarTolls.Add(t);

                        trans.Commit();
                        return true;


                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;

                    }
                }
            }
            else
                return false;
        }


        public int InsertAndGetLastID(Tolls t)
        {
            throw new System.NotImplementedException();
        }
        public IQueryable<Tolls> Select()
        {
           using(var db = new OcphDbContext())
            {
                return from a in db.Tolles.Select()
                       join k in db.Kategories.Select() on a.Kategoriid equals k.Id
                       join s in db.Stocks.Select() on a.Id equals s.Tollsid
                       select new Tolls
                       {
                           Gambar = a.Gambar,
                           Id = a.Id,
                           Kategoriid = a.Kategoriid,
                           Keterangan = a.Keterangan,
                           Nama = a.Nama, Kode = a.Kode,
                           Kategori = new Kategori { Id = k.Id, Keterangan = k.Keterangan, Nama = k.Nama, Kode = k.Kode },
                           Stock = new Stock
                           {
                               Id = s.Id,
                               Jumlah = s.Jumlah,
                               Tollsid = s.Tollsid
                           }
                       
                       };
            }
        }

        public int SetNewHargaSewa(HargaSewaDTO newitem, HargaSewaDTO hargaSewa)
        {
            var result = 0;
            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    if (hargaSewa != null)
                    {
                        bool active = false;
                        db.HargaSewas.Update(O => new { O.IsActived }, new HargaSewaDTO { IsActived = active }, O => O.Id == hargaSewa.Id);
                    }
                    result = db.HargaSewas.InsertAndGetLastID(newitem);
                    trans.Commit();
                }
                catch (Exception ext)
                {

                    result = 0;
                    trans.Rollback();
                }
            }

            return result;
        }

        public Tolls SelectById(int Id)
        {
            return this.DaftarTolls.Where(O => O.Id == Id).FirstOrDefault();
        }

        public Tolls SelectByKode(string kode)
        {
            return this.DaftarTolls.Where(O => O.Kode== kode).FirstOrDefault();
        }

        public bool Update(Tolls t)
        {
            var result = false;
            var isValidated = this.TollsValidateUpdate(t);
            if (isValidated)
            {
                using (var db = new OcphDbContext())
                {
                    try
                    {
                        result = db.Tolles.Update(O => new { O.Nama, O.Kode, O.Keterangan, O.Kategoriid, O.Gambar },
                            t, O => O.Id == t.Id);
                        if(result)
                        {
                            var item = DaftarTolls.Where(O => O.Id == t.Id).FirstOrDefault();
                            item.Kategori = t.Kategori;
                            item.Keterangan = t.Keterangan;
                            item.Kode = t.Kode;
                            item.Nama = t.Nama;
                        }
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }
        private bool TollsValidateInsert(TollsDTO model)
        {
            var isvalidated = true;
            if (string.IsNullOrEmpty(model.Keterangan) || string.IsNullOrEmpty(model.Nama) || model.Kategoriid <= 0)
                isvalidated = false;

            return isvalidated;
        }
        private bool TollsValidateUpdate(TollsDTO model)
        {
            var isvalidated = true;
            if (model.Id <= 0)
                isvalidated = false;
            if (string.IsNullOrEmpty(model.Keterangan) || string.IsNullOrEmpty(model.Nama) || model.Kategoriid <= 0)
                isvalidated = false;

            return isvalidated;
        }

    }
}
