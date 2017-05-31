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
using System.IO;

namespace DataInFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Data myData;
        public MainWindow()
        {
            InitializeComponent();
            myData = new Data();
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            myData.Add(textBoxName.Text);
            textBoxName.Text = "";
        }

        private void textBoxIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
            { e.Handled = true; }
        }

        private void textBoxIndex_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int index = Convert.ToInt32(textBoxIndex.Text);
                textBoxSubstring.Text = myData[index];
            }
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            myData.ClearFile();
        }

        private void ClearListBox()
        {
            listPosition.Items.Clear();
            listId.Items.Clear();
            listName.Items.Clear();
        }

        private void InicializListBox(List<long> list)
        {
            ClearListBox();
            StreamReader file = myData.getStreamReaderHederFile();
            foreach (long it in list)
            {
                string[] substring = myData.getAllSubstringLine(file, it);
                listPosition.Items.Add(it);
                listId.Items.Add(substring[0]);
                listName.Items.Add(substring[1]);
            }
            file.Dispose();
        }

        private void button_Show_Click(object sender, RoutedEventArgs e)
        {
            List<long> list = myData.getListPosition(Substring.ID);
            InicializListBox(list);
        }

        private void button_SortName_Click(object sender, RoutedEventArgs e)
        {
            myData.Sort(Substring.Name);
            List<long> list = myData.getListPosition(Substring.Name);
            InicializListBox(list);
        }

        private void button_SortID_Click(object sender, RoutedEventArgs e)
        {
            myData.Sort(Substring.ID);
            List<long> list = myData.getListPosition(Substring.ID);
            InicializListBox(list);
        }
    }
}
