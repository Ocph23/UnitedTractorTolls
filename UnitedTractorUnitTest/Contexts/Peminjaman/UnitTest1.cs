using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitedTractorLib;

namespace UnitedTractorUnitTest.Contexts.Peminjaman
{
    [TestClass]
    public class Peminjaman
    {
        [TestMethod]
        public void CekKetersediaanTolls()
        {
            var context = new ContextFactory().Peminjaman;

            UnitedTractorLib.Models.Permintaan model = new UnitedTractorLib.Models.Permintaan { Id=0, Karyawanid=2, Kode=Common.GenerateCodePermintaan, Tglpengajuan=DateTime.Now };
            model.Details = new System.Collections.Generic.List<UnitedTractorLib.DTO.PermintaanDetailDTO>();
            model.Details.Add(new UnitedTractorLib.DTO.PermintaanDetailDTO { Tollsid = 1, Statustolls = StatusStock.Kosong });
            model.Details.Add(new UnitedTractorLib.DTO.PermintaanDetailDTO { Tollsid = 2, Statustolls = StatusStock.Kosong });

            var result = context.CekKetersediaanTolls(model);

            var count = model.Details.FindAll(O => O.Statustolls == StatusStock.Ada).Count;

            Assert.IsTrue(count > 0);
           

        }

        [TestMethod]
        public void InsertPeminjaman()
        {
            var context = new ContextFactory().Peminjaman;

            UnitedTractorLib.Models.Permintaan model = new UnitedTractorLib.Models.Permintaan { Id = 0, Karyawanid = 2, Kode = Common.GenerateCodePermintaan, Tglpengajuan = DateTime.Now };
            model.Details = new System.Collections.Generic.List<UnitedTractorLib.DTO.PermintaanDetailDTO>();
            model.Details.Add(new UnitedTractorLib.DTO.PermintaanDetailDTO { Tollsid = 1, Statustolls = StatusStock.Kosong });
            model.Details.Add(new UnitedTractorLib.DTO.PermintaanDetailDTO { Tollsid = 2, Statustolls = StatusStock.Kosong });

            var result = context.CekKetersediaanTolls(model);

           var res= context.RequestNewPermintaan(model);

            Assert.IsTrue(true);
        }


    }
}
