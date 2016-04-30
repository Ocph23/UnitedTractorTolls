using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Models
{
    public class Pelanggaran : DTO.PelanggaranDTO
    {
        private List<DTO.PelanggaranDetailDTO> _details;

        public List<DTO.PelanggaranDetailDTO> Details
        {
            get
            {
                if (_details == null)
                {
                    using (var db = new OcphDbContext())
                    {
                        int id = this.Id;
                        _details = db.PelanggaranDetails.Where(O => O.Id == id).ToList();
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
