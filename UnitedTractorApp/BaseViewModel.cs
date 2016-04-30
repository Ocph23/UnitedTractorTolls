using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UnitedTractorApp
{
    public class BaseViewModel:UnitedTractorLib.ViewModelBase
    {
        private Page parentMenu;
         public BaseViewModel(Page mainMenu)
         {
             // TODO: Complete member initialization
             this.parentMenu = mainMenu;
               BackCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = x => BackCommandAction() };
        
         }
        private void BackCommandAction()
        {
            if (this.parentMenu != null)
            {
                var window = App.Current.MainWindow as MainWindow;
                window.Content = this.parentMenu;
            }
        }


        public CommandHandler BackCommand { get; set; }
    }
}
