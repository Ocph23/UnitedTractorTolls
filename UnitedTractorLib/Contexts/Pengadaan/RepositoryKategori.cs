using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.DTO;
using UnitedTractorLib.Models;
using UnitedTractorLib.Repository;

namespace UnitedTractorLib.Contexts.Pengadaan
{
    public class RepositoryKategori
    {
        public bool Delete(int Id)
        {
            bool result = false;
            bool isValidate = this.ValidatedDelete(Id);
            if (isValidate)
            {
                using (var db = new OcphDbContext())
                {
                    try
                    {
                        result = db.Kategories.Delete(O => O.Id == Id);
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public bool Update(Kategori model)
        {
            var result = false;
            var isValidated = this.KategoriValidateUpdate(model);
            if (isValidated)
            {
                using (var db = new OcphDbContext())
                {
                    try
                    {
                        result = db.Kategories.Update(O => new { O.Nama, O.Keterangan }, model, O => O.Id == model.Id);
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public bool Insert(Kategori model)
        {
            var result = false;
            var isValidated = this.KategoriValidateInsert(model);
            if (isValidated)
            {
                using (var db = new OcphDbContext())
                {
                    try
                    {
                        result = db.Kategories.Insert(model);
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public int InsertAndGetLastID(Kategori model)
        {
            var result = 0;
            var isValidated = this.KategoriValidateInsert(model);
            if (isValidated)
            {
                using (var db = new OcphDbContext())
                {
                    try
                    {
                        result = db.Kategories.InsertAndGetLastID(model);
                    }
                    catch (Exception)
                    {
                        result = 0;
                    }
                }
            }

            return result;
        }

        public IQueryable<Kategori> Select()
        {
           using (var db = new OcphDbContext())
            {
                return from a in db.Kategories.Select() select new Kategori {
                    Id = a.Id, Keterangan = a.Keterangan, Nama = a.Nama, Kode=a.Kode
                };
            }
        }

        private bool ValidatedDelete(int id)
        {
            if (id > 0)
                return true;
            else
                return false;
        }
        //Validate Model Kategori
        private bool KategoriValidateInsert(KategoriDTO kategori)
        {
            var isvalidated = true;
            if (string.IsNullOrEmpty(kategori.Keterangan) || string.IsNullOrEmpty(kategori.Nama))
                isvalidated = false;
            return isvalidated;
        }

        private bool KategoriValidateUpdate(KategoriDTO kategori)
        {
            var isvalidated = true;
            if (string.IsNullOrEmpty(kategori.Keterangan) || string.IsNullOrEmpty(kategori.Nama))
                isvalidated = false;
            if (kategori.Id <= 0)
                isvalidated = false;
            return isvalidated;
        }

        public Kategori SelectById(int Id)
        {
            using(var db = new OcphDbContext())
            {
                var result = from a in db.Kategories.Where(O => O.Id == Id)
                             select new Kategori { Id = a.Id, Keterangan = a.Keterangan, Nama = a.Nama };
                return result.FirstOrDefault();
            }
        }
    }
}
