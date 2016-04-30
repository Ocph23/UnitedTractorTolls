using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.Models
{
    public class User:DTO.UsersDTO
    {
        private string _password;
        public User()
        {

        }

        public string Password {

            get { return _password; }
            set
            {
                _password = value;
                this.Passwordhash = value;///Harus di Enscription
            }
        
        
        
        }

        public string ConfirmPassword { get; set; }

        

    }
}
