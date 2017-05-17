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

namespace second
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
            (new List<string>() {
            "aaa","bb","cc","dd","eee"
            }).
            ForEach(new Action<string>(x => listBox.Items.Add(x)));


            // LINQ
            /*
            var res =
                from i in
                    new List<string>() { "aaa", "bb", "cc", "dd", "eee" }
                select listBox.Items.Add(i);
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            box.Fill = new SolidColorBrush(Colors.Yellow);
            return;
            foreach (var x in grid.Children)
            {
                if (x is Rectangle)
                {
                    Rectangle r = (Rectangle)x;
                    r.Fill = new SolidColorBrush(Colors.Pink);
                }
            }

        }
    }
}
