using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PropertyChanged;

namespace Quantums_adventure.Infrastructure
{
    //[ImplementPropertyChanged]  
    public abstract class PropertyChangedBase : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;


            
        protected virtual void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}
