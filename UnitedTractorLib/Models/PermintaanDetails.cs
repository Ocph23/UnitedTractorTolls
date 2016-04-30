using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Models
{
    public class PermintaanDetails : DTO.PermintaanDetailDTO
    {
        public Models.Permintaan Permintaan
        {
            get
            {
                if (this.Permintaanid > 0)
                {
                    using (var db = new OcphDbContext())
                    {
                        return (from a in db.Permintaans.Where(o => o.Id == this.Permintaanid)
                                select new Models.Permintaan { Id = a.Id, Karyawanid = a.Karyawanid, Kode = a.Kode, Tglpengajuan = a.Tglpengajuan }).FirstOrDefault();
                    }
                }
                else
                    return null;

            }
        }

        public Models.Tolls Toll
        {
            get
            {
                if (this.Permintaanid > 0)
                {
                    using (var db = new OcphDbContext())
                    {
                        return (from a in db.Tolles.Where(o => o.Id == this.Tollsid)
                                select new Models.Tolls { Id = a.Id, Kategoriid=a.Kategoriid, Keterangan=a.Keterangan, Kode=a.Kode, Nama=a.Nama, Gambar=a.Gambar }).FirstOrDefault();
                    }
                }
                else
                    return null;

            }
        }

    }
}