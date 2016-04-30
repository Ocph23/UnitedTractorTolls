using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Contexts.Peminjaman
{
    public class RepositoryPeminjaman
    {
        public RepositoryPeminjaman()
        {

        }
        public List<Models.Peminjaman> DaftarPeminjaman
        {
            get
            {
                if(_daftarPeminjaman==null)
                {
                    using(var db = new OcphDbContext())
                    {
                        var r = from a in db.Peminjamans.Select()
                                join b in db.Permintaans.Select() on a.Permintaanid equals b.Id
                                select new Models.Peminjaman
                                {
                                    Id = a.Id,
                                    Permintaanid = b.Id,
                                    Kode = a.Kode,
                                    Tglmulai = a.Tglmulai,
                                    Completed = a.Completed,
                                    Tglkembali = a.Tglkembali

                                };
                        _daftarPeminjaman = r.ToList();
                    }
                }
                return _daftarPeminjaman;
            }
            set
            {
                _daftarPeminjaman = value;
            }
        }

        private List<Models.Peminjaman> _peminjamans;
        private List<Models.Peminjaman> _daftarPeminjaman;

        public List<Models.Peminjaman> Peminjamans 
        {
            get {
                if (_peminjamans == null)
                    _peminjamans = this.Select();
                return _peminjamans;
            } 
            set{
                _peminjamans=value;
            }
        }

        private List<Models.Peminjaman> Select()
        {
            using(var db = new OcphDbContext())
            {
                var r = (from p in db.Peminjamans.Select()
                         select new Models.Peminjaman
                         {
                             Id = p.Id,
                             Permintaanid = p.Permintaanid,
                             Kode = p.Kode,
                             Completed = p.Completed,
                             Tglkembali = p.Tglkembali,
                             Tglmulai = p.Tglmulai
                         }).ToList();

                return r;

            }
        }

        public Models.Peminjaman  RequestNewPermintaan(Models.Permintaan permintaan)
        {
            DTO.SettingDTO setting = null;
            Models.Peminjaman model = null;
            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                try
                {
                    //get Setting 
                    setting = db.Settings.Where(O => O.Actived == true).FirstOrDefault();

                    //inser Permintaan

                    permintaan.Id = db.Permintaans.InsertAndGetLastID(permintaan);

                    foreach (var item in permintaan.Details)
                    {
                        item.Permintaanid = permintaan.Id;
                        item.Id = db.PermintaanDetails.InsertAndGetLastID(item);
                    }

                    model = new Models.Peminjaman { Id = 0, Kode = Common.GenerateCodePeminjaman, Permintaanid = permintaan.Id, Completed = false, Tglmulai = DateTime.Now };

                    model.Tglkembali = model.Tglmulai.AddDays(setting.Maxpinjam);

                    model.Id = db.Peminjamans.InsertAndGetLastID(model);
                    model.Details = new List<Models.PeminjamanDetails>();
                    if (model.Id > 0)
                    {
                        foreach (var item2 in permintaan.Details.Where(O => O.Statustolls == StatusStock.Ada))
                        {
                            item2.Permintaanid = model.Id;
                            var baik = StatusTolls.Baik;
                            var ada = StatusStock.Ada;
                            var i = db.TollsDetails.Where(O => O.TollsId == item2.Tollsid && O.Status == baik && O.StatusInStock== ada ).OrderByDescending(O => O.Kondisi).FirstOrDefault();
                            var newmodel =  new Models.PeminjamanDetails{ IsReturnBack = false, Tollsid = item2.Tollsid, TollsItemId=i.Id,  Peminjamanid = item2.Permintaanid, Id = 0 };
                          
                            var sewa = db.HargaSewas.Where(O => O.TollsId == item2.Tollsid && O.IsActived == true).FirstOrDefault();

                            if (sewa != null)
                            {
                                newmodel.SewaId = sewa.Id;
                                newmodel.Id = db.PeminjamanDetails.InsertAndGetLastID(newmodel);
                                var p = StatusStock.Terpakai;
                                var res = db.TollsDetails.Update(O => new { O.StatusInStock }, new DTO.TollsDetailsDTO { StatusInStock = p }, O => O.Id == i.Id);
                                model.Details.Add(newmodel);
                                cmd.CommandText = string.Format("Update stock set jumlah=jumlah-1 where TollsId={0};", item2.Tollsid);
                                var r = cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    trans.Commit();
                    this.Peminjamans.Add(model);
                    return model;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return null;
                }
            }
        }

        public Models.Permintaan CekKetersediaanTolls(Models.Permintaan permintaan)
        {
            foreach(var item in permintaan.Details)
            {
                item.Statustolls = this.CekKetersediaan(item);
            }
            permintaan.Kode = Common.GenerateCodePermintaan;
            return permintaan;
        }

        private StatusStock CekKetersediaan(DTO.PermintaanDetailDTO item)
        {
            using(var db = new OcphDbContext())
           {
               var stock = db.Stocks.Where(O => O.Tollsid == item.Tollsid).FirstOrDefault();
               var terpinjams= db.PeminjamanDetails.Where(O=>O.Tollsid==item.Tollsid && O.IsReturnBack==false).ToList();
               if (stock!=null && stock.Jumlah > 0)
                   return StatusStock.Ada;
               else
               {
                   if (terpinjams.Count > 0)
                   {
                       return StatusStock.Terpakai;
                   }
                   else
                       return StatusStock.Kosong;
               }
           }
        }

    }
}
