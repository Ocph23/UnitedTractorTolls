using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.DTO;
using UnitedTractorLib.Models;
using UnitedTractorLib.Repository;

namespace UnitedTractorLib.Contexts.Pengadaan
{
    public class RepositoryTransaksiStock
    {
        public bool Delete(int t)
        {
            using(var db = new OcphDbContext())
            {
                return db.TransaksiStocks.Delete(O => O.Id == t);
            }
        }

        public bool Insert(TransaksiStock t)
        {
            if (this.TransaksiStockValidateCreate(t))
            {
                using (var db = new OcphDbContext())
                {
                    var trans = db.Connection.BeginTransaction();
                    var cmd = db.Connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    try
                    {
                        db.TransaksiStocks.Insert(t);
                        cmd.CommandText = string.Format("update stock set jumlah=jumlah+{0} where Id={1};", t.Jumlah, t.Tollsid);
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }else
            {
                return false;
            }

        }

        public int InsertAndGetLastID(TransaksiStock t)
        {
            if (this.TransaksiStockValidateCreate(t))
            {
                using (var db = new OcphDbContext())
                {
                    var transaction = db.Connection.BeginTransaction();
                 
                    try
                    {
                        var tr= db.TransaksiStocks.InsertAndGetLastID(t);
                        var cat = new ContextFactory().Tolls.DaftarTolls.Where(O=>O.Id==t.Tollsid).FirstOrDefault();
                        var lastitem = db.TollsDetails.Where(O=>O.TollsId==t.Tollsid).OrderByDescending(O=>O.Id).FirstOrDefault();
                        int lastid = 0;
                        if(lastitem!=null)
                        {
                            lastid = Convert.ToInt32(lastitem.NomorSeri.Substring(9));
                        }
                     
                        for(int start=1;start<t.Jumlah+1; start++)
                        {
                            var seri = Common.GenerateNomorSeri(cat.Kode, lastid+start);
                            db.TollsDetails.Insert(new TollsDetailsDTO {  StatusInStock= StatusStock.Ada, Status= StatusTolls.Baik, NomorSeri = seri, HargaBeli = t.HargaBeli, Kondisi = 100, TollsId = t.Tollsid, TransaksiId = tr });
                         
                        }
                        var cmd = db.Connection.CreateCommand();
                        cmd.CommandText = string.Format("update stock set jumlah=jumlah+{0} where TollsId={1};", t.Jumlah, t.Tollsid);
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return tr;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        public IQueryable<TransaksiStock> Select()
        {
            using(var db = new OcphDbContext())
            {
                return from a in db.TransaksiStocks.Select()
                       join b in db.Tolles.Select() on a.Tollsid equals b.Id
                       select new TransaksiStock
                       {
                           Id = a.Id,
                           Jumlah = a.Jumlah,
                           Tanggal = a.Tanggal,
                           Tollsid = a.Tollsid, HargaBeli=a.HargaBeli, KategoriId=b.Kategoriid
                       };
            }
        }

        public TransaksiStock SelectById(int Id)
        {
            using (var db = new OcphDbContext())
            {
              var result = from a in db.TransaksiStocks.Where(O=>O.Id==Id)
                       select new TransaksiStock
                       {
                           Id = a.Id,
                           Jumlah = a.Jumlah,
                           Tanggal = a.Tanggal,
                           Tollsid = a.Tollsid
                       };
                return result.FirstOrDefault();
            }
        }


        public bool TransaksiStockCreate(TransaksiStockDTO model)
        {
            var result = false;
            bool Isvalidate = this.TransaksiStockValidateCreate(model);
            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    var trIsSave = db.TransaksiStocks.Insert(model);
                    if (trIsSave)
                    {
                        var stockIsUpdate = db.Stocks.Update(O => new { O.Jumlah }, new StockDTO { Jumlah = model.Jumlah }, O => O.Id == model.Tollsid);
                        if (stockIsUpdate)
                        {
                            trans.Commit();
                            result = true;
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }

                }
                catch (Exception)
                {
                    trans.Rollback();
                    result = false;
                }
            }
            return result;
        }

        public bool Update(TransaksiStock t)
        {
            using (var db = new OcphDbContext())
            {
                return db.TransaksiStocks.Update(O => new { O.Jumlah, O.Tanggal, O.Tollsid }, t, O => O.Id == t.Id);
            }
        }

        //Validate MOdel

        //Validate Model Transaksi Stock

        private bool TransaksiStockValidateCreate(TransaksiStockDTO model)
        {
            var result = true;
            if (model.Jumlah <= 0 || model.Tollsid <= 0 || model.Id > 0 ||
                model.Tanggal.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                result = false;
            }
            return result;
        }

    }
}
