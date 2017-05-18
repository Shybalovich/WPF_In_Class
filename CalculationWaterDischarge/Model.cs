using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalculationWaterDischarge
{
    public class Model : INotifyPropertyChanged
    {
        private double volumePerPersone;               // обем расхода воды на одного человека
        private double priceLower;                     // тариф при непревышении стоимости
        private double priceHigher;                    // тариф при превышении стоимости
        private double coldValume;                     // объем холодной воды
        private double hotVolume;                      // объем горячей воды
        private double total;                          // итого

        public double VolumePerPersone               // обем расхода воды на одного человека
        { 
            get
            {
                return volumePerPersone;
            }
            set
            {
                if(value > 0)
                {
                    volumePerPersone = value;
                    OnPropertyChanged();
                }
            }
        }

        private double priceLower;                     // тариф при непревышении стоимости
        private double priceHigher;                    // тариф при превышении стоимости
        private double coldValume;                     // объем холодной воды
        private double hotVolume;                      // объем горячей воды
        private double total;                          // итого

        public Model()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
