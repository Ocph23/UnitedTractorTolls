using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib
{
    public interface IViewModelBase:INotifyPropertyChanged
    {
        void OnPropertyChanged(string propertyName);
    }
}
