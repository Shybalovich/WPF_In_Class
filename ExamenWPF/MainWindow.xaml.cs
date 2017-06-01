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

namespace ExamenWPF
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

        Model model = new Model();

        public MainWindow()
        {
            InitializeComponent();
            model.records.Add(new Record("Opel", "Astra", 2300));
            model.records.Add(new Record("BMV", "E65", 9550));
            model.records.Add(new Record("Ford", "Focus", 3700));
            list.ItemsSource = model.records;
        }

        private void PriceTextBlox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                e.Handled = true;
        }

        private void PriceTextBlox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string marka = MarkaTextBlox.Text;
            string model1 = ModelTextBlox.Text;
            int price = Convert.ToInt32(PriceTextBlox.Text);
            bool good = true;
            foreach (Record it in model)
            {
                if (it.Mark == marka && model1 == it.Model)
                {
                    good = false;

                }
            }

            if (good)
            {
                model.records.Add(new Record(marka, model1, price));
            }
            MarkaTextBlox.Text = "";
            ModelTextBlox.Text = "";
            PriceTextBlox.Text = "";
        }
    }
}
