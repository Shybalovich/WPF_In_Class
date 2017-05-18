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

namespace TaskWithButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LinearGradientBrush lgb;
        public MainWindow()
        {
            InitializeComponent();
            inicialLineGradientBrush();
        }

        private void inicialLineGradientBrush()
        {
            lgb =
    new LinearGradientBrush();
            lgb.StartPoint = new Point(0, 0.5);
            lgb.EndPoint = new Point(1, 0.5);
            lgb.GradientStops.Add(
                new GradientStop(Colors.Yellow, 0.0));
            lgb.GradientStops.Add(
                new GradientStop(Colors.Red, 0.25));
            lgb.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.75));
            lgb.GradientStops.Add(
                new GradientStop(Colors.LimeGreen, 1.0));
        }
    }
}
