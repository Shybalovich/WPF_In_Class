﻿using System;
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
            record.ID = Convert.ToInt32(ID.Text);
            ID.Text = "";
            record.LastName = LastName.Text;
            LastName.Text = "";
            record.FirstName = FirstName.Text;
            FirstName.Text = "";
            data.Add(record);
        }


        private void ID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!Char.IsNumber(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void experiment_Click(object sender, RoutedEventArgs e)
        {
            //experimentFile exp = new experimentFile();
            textBoxExp.Text = experimentFile.getLengsInfFile(data.pathToLineIndexes) + " " + experimentFile.getLengsInfFile(data.pathToDatabase);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            data.deleteAllFile();
        }


    }
}
