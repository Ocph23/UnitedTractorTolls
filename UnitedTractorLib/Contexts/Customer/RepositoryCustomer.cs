using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.Models;

namespace UnitedTractorLib.Contexts.Customer
{
    public class RepositoryCustomer
    {
        private List<Models.Customer> _customers;

        public List<Models.Customer> Customers
        {
            get {

                if (_customers == null)
                {
                    _customers = this.Select().ToList();
                }
                    
                return _customers; }
            set
            {
                _customers = value;
            }
        }

        public bool Delete(int t)
        {
            using (var db = new OcphDbContext())
            {
               var isDeleted= db.Customers.Delete(O => O.Id == t);
               if (isDeleted)
               {
                   var item = this.SelectById(t);
                   _customers.Remove(item);
                   return true;
               }
               else
                   return false;
            }
        }

        public bool Insert(Models.Customer t)
        {
            using (var db = new OcphDbContext())
            {
               var result = db.Customers.InsertAndGetLastID(t);
               if (result > 0)
               {
                   t.Id = result;
                   _customers.Add(t);
                   return true;
               }
               else
                   return false;
            }
        }

        private IQueryable<Models.Customer> Select()
        {
            using (var db = new OcphDbContext())
            {
                IQueryable<Models.Customer> result = from a in db.Customers.Select()
                       select new Models.Customer
                       {
                           Alamat = a.Alamat,
                           Email = a.Email,
                           Hp = a.Hp,
                           Id = a.Id,
                           Jabatan = a.Jabatan,
                           Nama = a.Nama,
                           Nik = a.Nik, Photo=a.Photo
                       };
                if (result == null)
                    result = new List<Models.Customer>() as IQueryable<Models.Customer>;

                return result;

            }
        }

        private Models.Customer SelectById(int Id)
        {
            if (_customers != null)
            {
               return _customers.Where(O => O.Id == Id).FirstOrDefault();
            }
            else
                return null;
        }

        public bool Update(Models.Customer t)
        {
            using (var db = new OcphDbContext())
            {
               var isUpdated= db.Customers.Update(O => new { O.Alamat, O.Email, O.Hp, O.Jabatan, O.Nama, O.Nik,O.Photo }, t, O => O.Id == t.Id);
               if (isUpdated)
               {
                   var O = this.SelectById(t.Id);
                   O.Alamat = t.Alamat;
                   O.Email = t.Email;
                   O.Hp = t.Hp;
                   O.Jabatan = t.Jabatan;
                   O.Nama = t.Nama;
                   O.Nik = t.Nik;
                   return true;
               }
               else
                   return false;
            }
        }

    }
}
