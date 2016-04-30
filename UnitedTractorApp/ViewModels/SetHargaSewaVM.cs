using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.Models;

namespace UnitedTractorApp.ViewModels
{
    public class SetHargaSewaVM : UnitedTractorLib.ViewModelBase
    {
        private Tolls selectedItem;

        private string kode;
        public string Kode
        {
            get
            {
                return kode;
            }

            set
            {
                kode = value;
                OnPropertyChanged("Kode");
            }
        }

        public string Nama
        {
            get
            {
                return nama;
            }

            set
            {
                nama = value;
                OnPropertyChanged("Nama");
            }
        }

        public double OldHarga
        {
            get
            {
                return oldHarga;
            }

            set
            {
                oldHarga = value;
                OnPropertyChanged("OldHarga");
            }
        }

        public double OldDenda
        {
            get
            {
                return oldDenda;
            }

            set
            {
                oldDenda = value;
                OnPropertyChanged("OldDenda");
            }
        }

        public double NewHarga
        {
            get
            {
                return newHarga;
            }

            set
            {
                newHarga = value;
                OnPropertyChanged("NewHarga");
            }
        }

        public double NewDenda
        {
            get
            {
                return newDenda;
            }

            set
            {
                newDenda = value;
                OnPropertyChanged("NewDenda");
            }
        }

        private double newDenda;
        private double newHarga;


        private double oldDenda;
        private double oldHarga;

        private string nama;


        public CommandHandler CmdSave { get; set; }

        public SetHargaSewaVM(Tolls selectedItem)
        {
            this.selectedItem = selectedItem;
            this.Kode = selectedItem.Kode;
            this.Nama = selectedItem.Nama;
            if (selectedItem.HargaSewa != null)
            {
                this.OldHarga = selectedItem.HargaSewa.Harga;
                this.oldDenda = selectedItem.HargaSewa.Denda;
            }


            CmdSave = new CommandHandler { CanExecuteAction = x => CanAddNewHarga(), ExecuteAction = x => AddNeHargaAction() };
        }

        private bool CanAddNewHarga()
        {
            if (this.window.user.Accesslevel == UnitedTractorLib.AccessLevel.Administrator)
                return true;
            else
                return false;
        }
        private MainApp window = App.Current.Windows[0] as MainApp;

        private void AddNeHargaAction()
        {
            var context = new UnitedTractorLib.ContextFactory().Tolls;
            var newitem = new UnitedTractorLib.DTO.HargaSewaDTO { Denda = this.NewDenda, Harga = this.NewHarga, Id = 0, IsActived = true, TollsId = selectedItem.Id };
           int newId= context.SetNewHargaSewa(newitem, selectedItem.HargaSewa);
            if(newId>0)
            {
                newitem.Id = newId;
                selectedItem.HargaSewa = newitem;
            }
        }
    }
}
