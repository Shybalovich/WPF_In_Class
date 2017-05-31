using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        class Model
        {
            public ObservableCollection<Record> records = new ObservableCollection<Record>();
        }
        Model m = new Model();

        public MainWindow()
        {
            InitializeComponent();
            m.records.Add(new Record("aaa", "bbb"));
            m.records.Add(new Record("asd", "bbb"));
            m.records.Add(new Record("fdf", "435"));
            m.records.Add(new Record("aaa", "aba"));
            list.ItemsSource = m.records;

            Type mytype = typeof(Record);
            //mytype.GetProperties
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zzzz.IsChecked = false;
            //MessageBox.Show(m.records[0].Firstname);
            m.records[0].Firstname = "oooooooo";
            m.records.Add(new Record("newnewnewnew", "a"));

            /*
             * this.m.records.BinarySearch(null);
            m.records.BS();
            Helper.BS(m.records);
             */
        }

        bool flag = false; 
        private void ooooo(object sender, RoutedEventArgs e)
        {
            RadioButton s = (RadioButton)sender;
            if ((s.IsChecked == true) && (flag == false))
            {
                flag = true;
            } else 
            if ((s.IsChecked == true) && (flag == true))
            {
                s.IsChecked = false;
                flag = false;
            }


        }
    }

    #region .
    public static  class Helper{
        public static int BS<T>(this List<T> obj) {
            return 1;
        }
    }
#endregion
}
