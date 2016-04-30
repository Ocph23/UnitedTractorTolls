using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Models
{
    public class Pengembalian: DTO.PengembalianDTO
    {
        private List<Models.PengembalianDetails> _details;
        private Models.User _petugas;
        public List<Models.PengembalianDetails> Details
        {
            get
            {
                if (_details == null && this.Id > 0)
                {
                    using(var db = new OcphDbContext())
                    {
                        int id = this.Id;
                        _details = (from a in db.PengembalianDetails.Where(O => O.Pengembalianid == id)
                                    join b in db.Tolles.Select() on a.Tollsid equals b.Id
                                    join i in db.TollsDetails.Select() on a.TollsItemId  equals i.Id
                                    select new Models.PengembalianDetails
                                    {
                                        Id = a.Id,
                                        Keadaantolls = a.Keadaantolls,
                                        Keterangan = a.Keterangan,
                                        Tollsid = a.Tollsid,
                                        Pengembalianid = a.Pengembalianid,
                                        TollKode = b.Kode,
                                        TollName = b.Nama, TollsItemId=i.Id, TollItem = i
                                    }
                                        ).ToList();
                    }
                }
                return _details;
            }
            set
            {
                _details = value;
            }
        }

        public User Petugas
        {
            get
            {
                if (_petugas==null && this.Petugasid > 0)
                {
                    using (var db = new OcphDbContext())
                    {
                        _petugas = (from a in db.Users.Where(O => O.Id == this.Petugasid)
                                    select new User
                                    {
                                        Accesslevel = a.Accesslevel,
                                        Activate = a.Activate,
                                        Id = a.Id,
                                        Username = a.Username
                                    }).FirstOrDefault();
                    }
                }

                return _petugas;
            }
        }



    }
}
