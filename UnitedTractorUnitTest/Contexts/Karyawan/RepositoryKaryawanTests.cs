using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitedTractorLib.Contexts.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Contexts.Customer.Tests
{
    [TestClass()]
    public class RepositoryKaryawanTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            var model = new Models.Customer
            {
                Alamat = "ini alamat",
                Email = "Ocph@gmail.com",
                Hp = "0812334",
                Id = 0,
                Jabatan = "Direktur",
                Nama = "Yoseph Kungkung",
                Nik = "03404303430430"
            };
            var context = new Contexts.Customer.RepositoryCustomer();
            Assert.IsTrue(context.Insert(model), "Error Is Not Validate");
        }

        
    }
}