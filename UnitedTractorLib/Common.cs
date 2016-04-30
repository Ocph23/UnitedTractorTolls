using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib
{
    public static class Common
    {
        public static string GenerateCodePeminjaman
        {
            get
            {
                using (var db = new OcphDbContext())
                {
                    var item = db.Peminjamans.GetLastItem();
                    var id = 0;
                    if (item != null)
                    {
                        id = Convert.ToInt32(item.Kode.Substring(4));
                    }
                    return string.Format("PNJ-{0:D5}", id + 1);
                }
            }
           
        }

        public static string GenerateCodePermintaan {

            get
            {
                using (var db = new OcphDbContext())
                {
                    var item = db.Permintaans.GetLastItem();
                    var id = 0;
                    if (item != null)
                    {
                        id = Convert.ToInt32(item.Kode.Substring(4));
                    }
                    return string.Format("MNT-{0:D5}", id + 1);
                }
            }
        }

        internal static string GenerateCodeTolls(int p)
        {
            using (var db = new OcphDbContext())
            {
                var kategori = db.Kategories.Where(O => O.Id == p).FirstOrDefault();
                var item = db.Tolles.Where(O => O.Kode.Substring(1,3) == kategori.Kode).OrderByDescending(O=>O.Id).FirstOrDefault();
                if (item != null)
                {
                    var id = Convert.ToInt32(item.Kode.Substring(4));
                    return string.Format("{0}-{1:D4}", kategori.Kode, id + 1);
                }
                return string.Format("{0}-{1:D4}",kategori.Kode, 1);
            }
        }



        internal static string GenerateNomorSeri(string p1, int p2)
        {
            return string.Format("{0}{1:D4}", p1, p2);
        }
    }
}
