using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Models
{
    public class Peminjaman:DTO.PeminjamanDTO
    {
        private List<Models.PeminjamanDetails> _details;
        private Models.Permintaan _permintaan;
        private Customer _customer;
        private int _progress;

        public List<Models.PeminjamanDetails> Details 
        {
            get {
                if (_details == null && this.Id > 0)
                 {

                    using (var db = new OcphDbContext())
                    {
                        _details = (from a in db.PeminjamanDetails.Where(O => O.Peminjamanid == Id)
                                    join b in db.Tolles.Select() on a.Tollsid equals b.Id
                                    select new Models.PeminjamanDetails
                                    {
                                        Id = a.Id,
                                        IsReturnBack = a.IsReturnBack,
                                        Peminjamanid = a.Peminjamanid,
                                        TollsItemId = a.TollsItemId,
                                        TollKode = b.Kode,
                                        TollName = b.Nama,
                                        Tollsid = a.Tollsid, SewaId= a.SewaId
                                    }).ToList();
                    }
                }
                return _details;
            }
            set {
                _details = value;
            }
        }

        public Permintaan Permintaan
        {
            get
            {
                if (_permintaan == null && this.Permintaanid>0)
                {
                    using (var db = new OcphDbContext())
                    {
                        var result= db.Permintaans.Where(O => O.Id == Permintaanid).FirstOrDefault();
                        _permintaan = new Permintaan { Id = result.Id, Karyawanid = result.Karyawanid, Kode = result.Kode, Tglpengajuan = result.Tglpengajuan };
                    }
                }
                return _permintaan;
            }
            set
            {
                _permintaan = value;
            }
        }


        public Customer Customer
        {
            get
            {
                if(_customer==null)
                {
                    using(var db = new OcphDbContext())
                    {
                        var id = Permintaan.Karyawanid;
                        var r = db.Customers.Where(O => O.Id == id).FirstOrDefault();
                        _customer = new Customer { Alamat = r.Alamat, Email = r.Email, Hp = r.Hp, Id = r.Id, Jabatan = r.Jabatan, Nama = r.Nama, Nik = r.Nik, Photo=r.Photo };
                    }
                }
                return _customer;
            }
        }


        public int Progress
        {
            get { 
                if(_progress==0 &&  Id>0)
                {
                    using (var db = new OcphDbContext())
                    {
                        int count = 0;
                        var pengembalians = from a in db.Pengembalians.Where(O => O.Peminjamanid == Id)
                                            select new Models.Pengembalian { Id = a.Id, Peminjamanid=a.Peminjamanid, Petugasid=a.Petugasid, Tglkembali=a.Tglkembali };
                        foreach(var item in pengembalians)
                        {
                            count += item.Details.Count;
                        }
                        var n = 100 / Details.Count;

                        _progress = count * n;
                       
                    }
                }
                return _progress; 
            }

            set
            {
                _progress = value;
            }
        }



        public void SetProgreess()
        {
            if(_progress==null &&  Id>0)
                {
                    using (var db = new OcphDbContext())
                    {
                        int count = 0;
                        var pengembalians = from a in db.Pengembalians.Where(O => O.Peminjamanid == Id)
                                            select new Models.Pengembalian { Id = a.Id, Peminjamanid=a.Peminjamanid, Petugasid=a.Petugasid, Tglkembali=a.Tglkembali };
                        foreach(var item in pengembalians)
                        {
                            count += item.Details.Count;
                        }
                        var n = 100 / Details.Count;

                        _progress = count * n;
                       
                    }
                }
        }

    }
}
