using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.Contexts.Peminjaman;

namespace UnitedTractorLib.Contexts.Gudang
{
    public class RepositoryPengembalian
    {

        RepositoryPeminjaman ContextPeminjaman = new ContextFactory().Peminjaman;
        
        public Models.Peminjaman GetPeminjamanByKode(string kode)
        {
            return ContextPeminjaman.Peminjamans.Where(O => O.Kode == kode).FirstOrDefault();
        }


        public List<Models.Pengembalian> GetPengembalian(int id)
        {
            var result = this.Select(id);
            return result;

        }

        private List<Models.Pengembalian> Select(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = (from a in db.Pengembalians.Where(O => O.Peminjamanid == id)
                              select new Models.Pengembalian
                              {
                                  Id = a.Id,
                                  Peminjamanid = a.Peminjamanid,
                                  Petugasid = a.Petugasid,
                                  Tglkembali = a.Tglkembali
                              }).ToList();
                return result;
            }
        }

    


        public bool Delete(int t)
        {
            using (var db = new OcphDbContext())
            {
                var tr = db.Connection.BeginTransaction();
                try
                {
                    db.Pengembalians.Delete(O => O.Id == t);
                    db.PermintaanDetails.Delete(O => O.Permintaanid == t);
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

        public bool Update(Models.Pengembalian t)
        {
            using(var db = new OcphDbContext())
            {
                var tr = db.Connection.BeginTransaction();
                try
                {
                    db.Pengembalians.Update(O => new { O.Tglkembali}, t, O => O.Id == t.Id);
                    foreach(var item in t.Details)
                    {
                        db.PengembalianDetails.Update(O => new { O.Tollsid}, item, O => O.Id == item.Id);
                    }
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

       
        public bool Insert(ref Models.Pengembalian kk, bool Completed)
        {
            Models.Pengembalian k=kk;
            using(var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    var id = db.Pengembalians.InsertAndGetLastID(k);
                    if(id>0)
                    {
                     
                        foreach(var item in k.Details)
                        {
                            item.Pengembalianid = id;
                            item.Keterangan = "";
                            db.PengembalianDetails.Insert(item);
                            db.PeminjamanDetails.Update(O => new { O.IsReturnBack },
                                new DTO.PeminjamanDetailDTO { IsReturnBack = true }, O => O.Peminjamanid == k.Peminjamanid && O.Tollsid == item.Tollsid);

                            var tollsitemid = db.PeminjamanDetails.Where(O => O.Peminjamanid == k.Peminjamanid && O.Tollsid == item.Tollsid).FirstOrDefault().TollsItemId;
                            StatusStock ss;
                            if(item.Keadaantolls== StatusTolls.Baik)
                            {
                                ss= StatusStock.Ada;
                            }else
                            {
                                ss= StatusStock.Kosong;
                            }


                           var aa= db.TollsDetails.Update(O => new { O.Status,O.StatusInStock }, new DTO.TollsDetailsDTO { Status = item.Keadaantolls, StatusInStock = ss }, O => O.Id == tollsitemid);


                            if(Completed)
                            {
                                db.Peminjamans.Update(O => new { O.Completed }, new DTO.PeminjamanDTO { Completed=Completed }, O => O.Id == k.Peminjamanid);
                            }

                            var cmd = db.Connection.CreateCommand();
                            cmd.CommandText = string.Format("Update Stock set Jumlah=Jumlah+1 where TollsId={0}", item.Tollsid);
                            var r = cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    k.Id = id;
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}
