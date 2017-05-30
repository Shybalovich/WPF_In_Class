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

namespace UserCOntrols
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static DependencyProperty ColorProperty;
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;

        public static RoutedEvent ColorChangedEvent;
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        static ColorPicker() {
            ColorProperty = DependencyProperty.Register(
                "Color",            // номер счёта 300000305085402
                typeof(Color),      // в рблях
                typeof(ColorPicker), // для меня
                new FrameworkPropertyMetadata(Colors.Black,
                    new PropertyChangedCallback(OnColorChanged))
                );
            RedProperty = DependencyProperty.Register(
                "Red",
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorComponentChanged))

                );
            GreenProperty = DependencyProperty.Register(
                "Green",
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorComponentChanged))

                );
            BlueProperty = DependencyProperty.Register(
                "Blue",
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorComponentChanged))

                );

            ColorChangedEvent = EventManager.RegisterRoutedEvent(
                "ColorChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>),
                typeof(ColorPicker)
                );
        }

        private static void OnColorComponentChanged(
            DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
            {
                color.R = (byte)e.NewValue;
            }
            if (e.Property == GreenProperty)
            {
                color.G = (byte)e.NewValue;
            }
            if (e.Property == BlueProperty)
            {
                color.B = (byte)e.NewValue;
            }
            colorPicker.Color = color;
        }

        private static void OnColorChanged(
            DependencyObject sender, 
            DependencyPropertyChangedEventArgs e
        )
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color newColor = (Color)e.NewValue;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;

            var Eventargs = 
                new RoutedPropertyChangedEventArgs<Color>(
                    (Color)e.OldValue, 
                    (Color)e.NewValue,
                    ColorChangedEvent
                );
            var element = ((UIElement)sender);
            element.RaiseEvent(Eventargs);
        }

    }
}
