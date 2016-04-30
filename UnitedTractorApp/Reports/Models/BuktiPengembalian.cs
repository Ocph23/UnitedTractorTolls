using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib;

namespace UnitedTractorApp.Reports.Models
{
    public class BuktiPengembalian
    {
        public string KodePeminjaman { get; set; }
        public string NamaPeminjam { get; set; }
        public DateTime Tanggal { get; set; }
        public string KodePerkakas { get; set; }
        public StatusTolls Status { get; set; }
        public double Denda { get; set; }
    }
}
