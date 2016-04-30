using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UnitedTractorLib.Contexts.User;

namespace UnitedTractorApp.ViewModels
{
    public class UsersVM:UnitedTractorLib.ViewModelBase
    {
        private RepositoryUser Context;

        public ObservableCollection<UnitedTractorLib.DTO.UsersDTO> UsersSource { get; set; }
        public CollectionView UsersView { get; set; }

        public UnitedTractorLib.DTO.UsersDTO SelectedItem { get; set; }

        //Command
        public Action WindowClose { get; set; }
        public CommandHandler CommandWindowClose { get; set; }
        public CommandHandler CommandAddUser { get; set; }
        public CommandHandler CommandChangeUserActived { get; set; }


        public UsersVM()
        {
            this.Context = new UnitedTractorLib.ContextFactory().Users;
            UsersSource = new ObservableCollection<UnitedTractorLib.DTO.UsersDTO>(Context.Select());
            UsersView = (CollectionView)CollectionViewSource.GetDefaultView(UsersSource);

            CommandWindowClose = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => CommandWindowCloseAction() };
            CommandAddUser = new CommandHandler { CanExecuteAction = x => CommandAddUserValidate(), ExecuteAction = x => CommandAddUserAction() };
            CommandChangeUserActived = new CommandHandler { CanExecuteAction = x => CommandChangeUserActivedValidate(), ExecuteAction = x => CommandChangeUserActivedAction() };

        }

        private void CommandChangeUserActivedAction()
        {
            Context.ChangeActived(this.SelectedItem);
        }


        private void CommandAddUserAction()
        {
            var form = new Views.AddUser();
            form.ShowDialog();

        }


        private void CommandWindowCloseAction()
        {
            WindowClose();
        }

        //Validate


        private bool CommandChangeUserActivedValidate()
        {
            throw new NotImplementedException();
        }
        private bool CommandAddUserValidate()
        {
            var window = (App.Current.Windows[0] as MainApp);
            if (this.SelectedItem != null && window.user.Accesslevel == UnitedTractorLib.AccessLevel.Administrator)
            {
                return true;
            }
            else
                return false;
        }







    }
}
