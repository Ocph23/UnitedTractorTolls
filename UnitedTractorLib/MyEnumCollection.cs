using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib
{
    public enum JenisPelanggaran
    {
        Menghilangkan, Merusakkan
    }

    public enum StatusTolls
    {
      None, Baik, Hilang, Rusak
    }

    public enum StatusStock
    {
      Kosong, Ada, Terpakai
    }

    public enum AccessLevel
    {
        Administrator, Staf,
        Gudang
    }

}
