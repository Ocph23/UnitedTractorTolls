using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorApp.Reports.Models
{
    public class Peminjaman
    {
        public int Nomor { get; set; }
        public string Kode { get; set; }
        public string Pelanggan { get; set; }
        public DateTime TglPinjam { get; set; }
        public DateTime TglKembali { get; set; }
        public bool TelahLengkap { get; set; }
        public string Petugas { get; set; }
    }
}
