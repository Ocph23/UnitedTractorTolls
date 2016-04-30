using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.DTO;

namespace UnitedTractorLib.Models
{
    public class Tolls:DTO.TollsDTO
    {
        private List<TollsDetailsDTO> _details;
        private Models.Kategori _kategori;
        private HargaSewaDTO _sewa;

        public Models.Kategori Kategori
        {
            get
            {
                if(_kategori==null && Kategoriid>0)
                {
                    using (var db = new OcphDbContext())
                    {
                        var result = (from a in db.Kategories.Where(O => O.Id == Kategoriid)
                                      select new Kategori { Id = a.Id, Keterangan = a.Keterangan, Nama = a.Nama, Kode = a.Kode }).FirstOrDefault();
                        _kategori = result;

                    }
                }
                return _kategori;
            }
            set
            {
                _kategori = value;
            }
        }


        public Models.Stock Stock { get; set; }


        public List<TollsDetailsDTO> Details
        {
            get
            {
                if (_details == null)
                {
                    if (this.Id > 0)
                    {
                        using (var db = new OcphDbContext())
                        {
                            var _id = this.Id;
                            _details = db.TollsDetails.Where(O => O.TollsId == _id).ToList();
                        }
                    }
                }
                return _details;
            }
            set
            {
                _details = value;
            }
        }

        public HargaSewaDTO HargaSewa
        {
            get
            {
                if (_sewa == null)
                {
                    if (this.Id > 0)
                    {
                        using (var db = new OcphDbContext())
                        {
                            var _id = this.Id;
                            _sewa = db.HargaSewas.Where(O => O.TollsId == this.Id).FirstOrDefault();
                        }
                    }
                }
                return _sewa;
            }
            set { _sewa = value; }
        }

        public TollsDetailsDTO GetDetailByNomorSeri(string nomorSeri)
        {
            return _details.Where(O => O.NomorSeri.ToUpper() == nomorSeri.ToUpper()).FirstOrDefault();
        }

    }
}
