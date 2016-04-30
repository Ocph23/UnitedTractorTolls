using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.DTO;

namespace UnitedTractorLib.Models
{
    public class PeminjamanDetails:DTO.PeminjamanDetailDTO,IViewModelBase
    {
        private StatusTolls _keadaan;
        public string TollName { get; set; }

        public string TollKode { get; set; }

        public bool CanNotChange
        {
            get { return _cannotChange; }
            set
            {
                _cannotChange = value;
                OnPropertyChanged("CanNotChange");
            }
        }

        public StatusTolls Keadaan
        {
            get { return _keadaan; }
            set
            {
                _keadaan = value;
                OnPropertyChanged("Keadaan");
                
            }
        }


        public void OnPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private bool _cannotChange;
        private DTO.TollsDetailsDTO _items;
        private HargaSewaDTO _sewa;

        public DTO.TollsDetailsDTO TOllDetails
        {
            get { 
                if(_items==null && this.Id>0)
                {
                    using (var db = new OcphDbContext())
                    {
                        _items = db.TollsDetails.Where(O => O.Id == this.TollsItemId).FirstOrDefault();
                    }
                }

                return _items; }
        }


        public DTO.HargaSewaDTO HargaSewa
        {
            get
            {
                
                if (_sewa == null && this.SewaId > 0)
                {
                    using (var db = new OcphDbContext())
                    {
                        _sewa = db.HargaSewas.Where(O => O.Id == this.SewaId).FirstOrDefault();
                    }
                }

                return _sewa;
            }
        }
       
    }
}
