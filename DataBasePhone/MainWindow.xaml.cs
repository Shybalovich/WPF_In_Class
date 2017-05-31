using System;
using System.Collections.Generic;
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

namespace DataBasePhone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database data;
        Database.Record record;
        public MainWindow()
        {
            InitializeComponent();
            data = Database.Instance;
            record = new Database.Record();
        }

        private void Seva_Click(object sender, RoutedEventArgs e)
        {
            record.ID = ID.Text != "" ? Convert.ToInt32(ID.Text) : 0;
            ID.Text = "";
            record.LastName = LastName.Text;
            LastName.Text = "";
            record.FirstName = FirstName.Text;
            FirstName.Text = "";
            data.Add(record);
        }

        private void experiment_Click(object sender, RoutedEventArgs e)
        {
            //string s = experimentFile.getLengsInfFile(data.pathToLineIndexes);
            //s += " ";
            //s += experimentFile.getLengsInfFile(data.pathToDatabase);
            textBoxExp.Text = experimentFile.getLengsInfFile(data.pathToLineIndexes) + " " + experimentFile.getLengsInfFile(data.pathToDatabase);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            data.deleteAllFile();
        }

        private void ID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Space)
                e.Handled = true;
        }


    }
}
