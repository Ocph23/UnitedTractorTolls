using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.DTO;

namespace UnitedTractorLib.Contexts.User
{
    public class RepositoryUser:Repository.IRepositoryContext<Models.User>
    {
        private List<Models.User> _users;
        public RepositoryUser()
        {
        }
        public bool Login(string username, string password)
        {
            using(var db = new OcphDbContext())
            {
                var res = from a in db.Users.Where(O => O.Username == username && O.Passwordhash == password)
                          select new Models.User { Accesslevel = a.Accesslevel, Activate = a.Activate, Passwordhash = a.Passwordhash, Password = password, Id = a.Id, Username = a.Username };
                this.UserIsLogin = res.FirstOrDefault();
                if (this.UserIsLogin != null)
                    return true;
                else
                    return false;
            }
        }

        public Models.User UserIsLogin { get; set; }

        public List<Models.User> Users
        {
            get
            {
                if (_users == null)
                {
                    using (var db = new OcphDbContext())
                    {
                        var result = from a in db.Users.Select()
                                     select new Models.User
                                     {
                                         Passwordhash = a.Passwordhash,
                                         Username = a.Username,
                                         Accesslevel = a.Accesslevel,
                                         Activate = a.Activate,
                                         Id = a.Id
                                     };
                        return result.ToList();

                    }
                }

                return _users;
            }
        }

        public bool ChangeActived(UsersDTO selectedItem)
        {
            using (var db = new OcphDbContext())
            {
                var isUpdated = db.Users.Update(O => new { O.Activate }, new UsersDTO { Id = selectedItem.Id, Activate = selectedItem.Activate }, O => O.Id == selectedItem.Id);
                return isUpdated;
            }
        }

        public bool Delete(int t)
        {
           using(var db = new OcphDbContext())
           {
               var isDeleted = db.Users.Delete(O => O.Id == t);
               if (isDeleted)
               {
                   var item = this.Users.Where(O => O.Id == t).FirstOrDefault();
                   if (item != null)
                       this._users.Remove(item);

                   return true;
               }
               else
                   return false;
           }
        }

        public bool Update(Models.User t)
        {
            using(var db = new OcphDbContext())
            {
                var isUpdated = db.Users.Update(O => new { O.Accesslevel, O.Activate, O.Passwordhash, O.Username }, t,
                    O => O.Id == t.Id);
                if (isUpdated)
                {
                    var item = this._users.Where(O => O.Id == t.Id).FirstOrDefault();
                    if (item != null)
                    {
                        item.Activate = t.Activate;
                        item.Accesslevel = t.Accesslevel;
                        item.Passwordhash = t.Passwordhash;
                        item.Username = t.Username;
                    }
                    return true;

                }
                else
                    return false;
            }
        }

        public bool Insert(Models.User t)
        {
            using(var db = new OcphDbContext())
            {
                var id = db.Users.InsertAndGetLastID(t);
                if (id > 0)
                {
                    t.Id = id;
                    this.Users.Add(t);
                    return true;
                }
                else
                    return false;
            }
        }

        public int InsertAndGetLastID(Models.User t)
        {
           using(var db =new OcphDbContext())
            {
                return db.Users.InsertAndGetLastID(new UsersDTO
                {
                    Accesslevel = t.Accesslevel,
                    Activate = t.Activate,
                    Id = t.Id,
                    Passwordhash = t.Passwordhash,
                    Photo = t.Photo,
                    Username = t.Username
                });
            }
        }

        public Models.User SelectById(int Id)
        {
            using (var db = new OcphDbContext())
            {

                var result =  from a in db.Users.Where(O => O.Id == Id)
                              select new Models.User
                              {
                                  Id = a.Id,
                                  Accesslevel = a.Accesslevel,
                                  Activate = a.Activate
                              ,
                                  Passwordhash = a.Passwordhash,
                                  Password = a.Passwordhash,
                                  Photo = a.Photo,
                                  Username = a.Username
                              };


                return result.FirstOrDefault();
            }
        }

        public IQueryable<Models.User> Select()
        {
            using(var db = new OcphDbContext())
            {
                return  from a in db.Users.Select()
                             select new Models.User { Id = a.Id, Accesslevel = a.Accesslevel, Activate = a.Activate
                             , Passwordhash = a.Passwordhash, Password = a.Passwordhash, Photo = a.Photo, Username = a.Username };

            }
        }
    }
}
