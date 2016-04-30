using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Models
{
    public class Customer:DTO.CustomerDTO
    {
        private List<Peminjaman> _peminjamans;
        public List<Models.Peminjaman> Peminjamans
        {
            get
            {
                if(_peminjamans==null && this.Id>0)
                {
                    using (var db = new OcphDbContext())
                    {
                        var result = from a in db.Permintaans.Where(O => O.Karyawanid == Id)
                                     join b in db.Peminjamans.Select() on a.Id equals b.Permintaanid
                                     select new Models.Peminjaman{ Id=b.Id, Kode=b.Kode, Permintaanid=b.Permintaanid, Tglkembali=b.Tglkembali, Tglmulai=b.Tglmulai };
                        _peminjamans = result.ToList();
                    }
                }
                return _peminjamans;
            }
        }

    }
}
