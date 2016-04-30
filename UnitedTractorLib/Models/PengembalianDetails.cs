using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Models
{
    public class PengembalianDetails:DTO.PengembalianDetailDTO
    {
        private DTO.TollsDetailsDTO _items;
        public string TollName { get; set; }

        public string TollKode { get; set; }


        public DTO.TollsDetailsDTO TollItem
        {
            get { 
                if(_items==null)
                {
                    using (var db = new OcphDbContext())
                    {
                        _items = db.TollsDetails.Where(O => O.Id == this.TollsItemId).FirstOrDefault();
                    }
                }
                return _items;
            }
            set
            {
                _items = value;
            }
        }
    }
}
