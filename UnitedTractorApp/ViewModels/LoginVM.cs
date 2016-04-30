using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UnitedTractorLib;

namespace UnitedTractorApp.ViewModels
{
    public class LoginVM:ViewModelBase
    {
        private string _username;
        private string _password;
        private string _message;
        public LoginVM()
        {
            LoginCommand = new CommandHandler { CanExecuteAction = O => LoginValidate(), ExecuteAction = O => LoginAction() };
            CloseCommand = new CommandHandler { CanExecuteAction = O => true, ExecuteAction = O => CloseAction() };
        }

      

        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("UserName");
            }
        }



        public string Password
        {
            get { return _password; }
            set{
                _password = value;
                OnPropertyChanged("Password");
            }
        }


        public string PasswordHash
        {
            get
            {
                return _password;
            }
        }


        private void CloseAction()
        {
            this.mainWindow = App.Current.MainWindow as MainWindow;
            mainWindow.Close();
        }

        private void LoginAction()
        {
           var Context = new ContextFactory().Users;
            
           this.IsLogin = Context.Login(this.UserName, this.PasswordHash);
            if(IsLogin)
            {
                this.mainWindow = App.Current.MainWindow as MainWindow;
                var from = new MainApp(Context.UserIsLogin);
                from.Show();
                
                mainWindow.Close();
            }else
            {
                if(Context.Users.Count<=0)
                {
                   if(Context.Insert(new UnitedTractorLib.Models.User { Username = "admin", Password = "admin", Accesslevel = AccessLevel.Administrator, Activate = true }))
                   {
                       ErrorMessage = "You Is Administrator, UserName = admin & password=admin  Please Change After Login";
                   }
                    
                }else
                {
                    ErrorMessage = "UserName Atau Password Anda";
                }
              
            }

        }

        private bool LoginValidate()
        {
           
            bool result = true;
            if (string.IsNullOrEmpty(this.UserName) || string.IsNullOrEmpty(this.Password))
           {
               result = false;
             
           }

            return result;
        }

        public CommandHandler LoginCommand { get; set; }

        public CommandHandler CloseCommand { get; set; }


        public string ErrorMessage {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged("ErrorMessage");
            }
        
        }

        public bool IsLogin { get; set; }

        public MainWindow mainWindow { get; set; }

        
    }
}
