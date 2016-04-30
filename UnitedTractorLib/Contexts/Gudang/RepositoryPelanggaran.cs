using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Contexts.Gudang
{
    internal class RepositoryPelanggaran:Repository.IRepositoryContext<Models.Pelanggaran>
    {

        public bool Delete(int t)
        {
            using(var db = new OcphDbContext())
            {
                var tr = db.Connection.BeginTransaction();
                try
                {
                    db.Pelanggarans.Delete(O => O.Id == t);
                    db.PelanggaranDetails.Delete(O => O.Pelanggaranid== t);
                    tr.Commit();
                    return true;
                }
                catch (Exception)
                {
                    tr.Rollback();
                    return false;
                }
            }
        }

        public bool Update(Models.Pelanggaran t)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Models.Pelanggaran t)
        {
            throw new NotImplementedException();
        }

        public int InsertAndGetLastID(Models.Pelanggaran t)
        {
            throw new NotImplementedException();
        }

        public Models.Pelanggaran SelectById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Models.Pelanggaran> Select()
        {
            throw new NotImplementedException();
        }
    }
}
