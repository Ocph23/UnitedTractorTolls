using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorApp.Reports.Models
{
    public class Perkakas
    {
        public int Nomor { get; set; }
        public string Kode { get; set; }
        public string Nama { get; set; }
        public string Kategori { get; set; }
        public int Baik { get; set; }
        public int RusakOrHilang { get; set; }

    }


}