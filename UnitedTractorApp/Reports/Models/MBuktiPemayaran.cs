using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorApp.Reports.Models
{
    public class MBuktiPemayaran
    {

        public string KodePeminjaman { get; set; }
        public string NamaPelanggan { get; set; }
        public DateTime Tanggal { get; set; }
        public string KodePerkakas { get; set; }
        public string NomorSeri { get; set; }
        public double HargaSatuan { get; set; }

    }
}
