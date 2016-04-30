using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib;

namespace UnitedTractorApp.ViewModels
{
    public class Request:ViewModelBase
    {
       
        private int _tollsid;
        private string _kode;
        private string _name;
        private string _ket;
        private UnitedTractorLib.StatusStock _ketersediaan;
        public int TollsId {
            get { return _tollsid; }
            set { _tollsid = value;
            OnPropertyChanged("TollsId");

            }
        }
        public string Kode
        {
            get { return _kode; }
            set
            {
                
                _kode = value;
                OnPropertyChanged("Kode");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Keterangan
        {
            get { return _ket; }
            set { _ket = value;
            OnPropertyChanged("Keterangan");
            }
        }

        public UnitedTractorLib.StatusStock Ketersediaan
        {
            get { return _ketersediaan; }
            set
            {
                _ketersediaan = value;
                OnPropertyChanged("Ketersediaan");
            }
        }

    }
}
