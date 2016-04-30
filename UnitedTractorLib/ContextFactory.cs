using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.Contexts;

namespace UnitedTractorLib
{
    public class ContextFactory
    {
        public Contexts.Customer.RepositoryCustomer Karyawan
        {
            get
            {
                return new Contexts.Customer.RepositoryCustomer();
            }
        }

        public Contexts.Gudang.RepositoryPengembalian Pengembalian { get { return new Contexts.Gudang.RepositoryPengembalian(); } }

        public Contexts.User.RepositoryUser Users
        {
            get
            {
                return new Contexts.User.RepositoryUser();
            }
        }

        public Contexts.Pengadaan.RepositoryTolls Tolls{ get { return new Contexts.Pengadaan.RepositoryTolls(); } }

        public Contexts.Peminjaman.RepositoryPeminjaman Peminjaman { get { return new Contexts.Peminjaman.RepositoryPeminjaman(); } }

    }
}