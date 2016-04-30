using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Repository
{
    public interface IRepositoryContext<T> where T :class
    {
        bool Delete(int t);

        bool Update(T t);

        bool Insert(T t);

        int InsertAndGetLastID(T t);

        T SelectById(int Id);

        IQueryable<T> Select();
    }
}
