using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    class Record:INotifyPropertyChanged
    {
        private static int lastid = 0;
        public Record()
        {
            Firstname = "";
            Lastname = Guid.NewGuid().ToString();
            Id = lastid++;
            IsGood = true;
        }
        public Record(string _firstname, string _lastname)
        {
            Firstname = _firstname;
            Lastname = Guid.NewGuid().ToString();
            Id = lastid++;
        }
        public int Id { get; private set; }
        private string firstname;
        public string Firstname
        {
            get
            { return firstname; }
            set {
                firstname = value;
                OnPropertyChanged("Firstname");
            }
        }
        private string lastname;

        public string Lastname
        {
            get
            { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged();
            }
        }       
        
        private bool isGood;

        public bool IsGood
        {
            get
            { return isGood; }
            set
            {
                isGood = value;
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
