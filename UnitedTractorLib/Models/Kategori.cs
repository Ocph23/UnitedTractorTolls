using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.DTO;

namespace UnitedTractorLib.Models
{
    public class Kategori:DTO.KategoriDTO
    {
        private List<Tolls> _details;

       

        public List<Tolls> Tolls
        {
            get {
                if(_details==null && this.Id>0)
                {
                    using(var db = new OcphDbContext())
                    {
                        var result = from a in db.Tolles.Where(O => O.Kategoriid == Id)
                                     select new Tolls { Id = a.Id, Gambar = a.Gambar, Kategoriid = a.Kategoriid, Keterangan = a.Keterangan, Kode = a.Kode, Nama = a.Nama };
                        _details = result.ToList();
                    }
                }
                return _details; }
            set { _details = value; }
        }

    }
}
