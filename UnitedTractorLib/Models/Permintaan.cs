using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Models
{
    public class Permintaan:DTO.PermintaanDTO
    {
        private List<Models.PermintaanDetails> _details;
       
        public List<Models.PermintaanDetails> Details
        {
            get
            {
                if(_details==null)
                {
                    if(this.Id>0)
                    {
                        using(var db = new OcphDbContext())
                        {
                            var _id = this.Id;
                            _details = (from a in db.PermintaanDetails.Where(O => O.Permintaanid == _id)
                                        select new Models.PermintaanDetails { Id = a.Id, Permintaanid = a.Permintaanid, Statustolls = a.Statustolls, Tollsid = a.Tollsid }).ToList();

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


     



    }
}
