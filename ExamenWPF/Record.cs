using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace ExamenWPF
{
    class Record : INotifyPropertyChanged
    {
        public Record()
        {
           
        }

        public Record(string _mark, string _model, int _price)
        {
            Mark = _mark;
            Model = _model;
            Price = _price;
        }

        private string mark;
        public string Mark
        {
            get
            { return mark; }
            set
            {
                mark = value;
                OnPropertyChanged();
            }
        }

        private string model;
        public string Model
        {
            get
            { return model; }
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }

        private int price;
        public int Price
        {
            get
            { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
