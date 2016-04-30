using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using UnitedTractorLib;
using UnitedTractorLib.Models;

namespace UnitedTractorApp.ViewModels
{
    public class DaftarTollsVM:UnitedTractorLib.ViewModelBase
    {

        private MainApp window = App.Current.Windows[0] as MainApp;
        public UnitedTractorLib.Models.User userIsLogin;
        private UnitedTractorLib.Models.Tolls _selected;
        public ObservableCollection<Tolls> Source { get; set; }

        public CollectionView DataSource { get; set; }
        public UnitedTractorLib.Models.Tolls SelectedItem
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                
                OnPropertyChanged("SelectedItem");
            }
        }
        


        public DaftarTollsVM()
        {
            // TODO: Complete member initialization
            userIsLogin = window.user;
            var Context = new ContextFactory().Tolls;
            this.Source = new ObservableCollection<Tolls>(Context.DaftarTolls);
            this.DataSource = (CollectionView)CollectionViewSource.GetDefaultView(Source);

            //instant Command
            CmdAdd = new CommandHandler { CanExecuteAction = x => IsAdministrator(), ExecuteAction = x => CmdaddAction() };
            cmdDetails = new CommandHandler { ExecuteAction = x => CmdDetailsAction(), CanExecuteAction = x => IsAdministrator() };
            CmdEdit = new CommandHandler { CanExecuteAction = x => IsAdministrator(), ExecuteAction = x => CmdEditAction() };
            CmdClose = new CommandHandler { ExecuteAction = x => CmdCloseAction(), CanExecuteAction = x => true };
            CmdDelete = new CommandHandler { ExecuteAction = x => CmdDeleteAction(), CanExecuteAction = x => IsAdministrator() };
            CmdHargaSewa = new CommandHandler { CanExecuteAction = x => CanSetHargaSewa(), ExecuteAction = x => SetHargasewaAction() };
        }

        private void SetHargasewaAction()
        {
            var form = new Views.SetHargaSewa(this.SelectedItem);
            form.ShowDialog();
            var a =Source.Where(O => O.Id == SelectedItem.Id).FirstOrDefault();
            a.HargaSewa = SelectedItem.HargaSewa;
            DataSource.Refresh();

        }

        private bool CanSetHargaSewa()
        {
            return IsAdministrator();
        }


        // Command

        public Action CloseWindow {get;set;}
        public Action HideWindow {get;set;}
        public Action ShowWindow { get; set; }


        public CommandHandler CmdAdd { get; set; }
        public CommandHandler CmdEdit { get; set; }
        public CommandHandler CmdDelete { get; set; }
        public CommandHandler cmdDetails { get; set; }
        public CommandHandler CmdClose { get; set; }
        public CommandHandler CmdHargaSewa { get; set; }



        //action

        public void CmdaddAction()
        {
            var form = new Views.TambahTolls(this);
            form.ShowDialog();
            var vm = (ViewModels.TambahTollsVM)form.DataContext;
            if(vm.Model!=null)
            {
                Source.Add(vm.Model);
                DataSource.Refresh();
            };
         
        }

        public void CmdEditAction()
        {
            var form =new Views.TambahTolls(this,this.SelectedItem);
            form.ShowDialog();
        }

        public void CmdDeleteAction()
        {

            var ctx = new UnitedTractorLib.ContextFactory().Tolls;
            ctx.Delete(SelectedItem.Id);
            Source.Remove(Source.Where(O => O.Id == SelectedItem.Id).FirstOrDefault());
            DataSource.Refresh();
        }

        public void CmdDetailsAction() {

            var form = new Views.DetailsTolls(this, this.SelectedItem);
        
        }
        public void CmdCloseAction() { }



        public bool IsAdministrator()
        {
            if (this.userIsLogin.Accesslevel == UnitedTractorLib.AccessLevel.Administrator)
                return true;
            else
                return false;
        }



        internal void SourceRefresh()
        {
            Source.Clear();
           var list = new System.Collections.ObjectModel.ObservableCollection<Tolls>(new UnitedTractorLib.ContextFactory().Tolls.DaftarTolls);
            foreach(var item in list)
            {
                Source.Add(item);
            }

            DataSource.Refresh();
        }
    }
}
