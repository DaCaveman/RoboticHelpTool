using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace RoboticHelpTool
{
    /// <summary>
    /// Interaktionslogik für InfoBox.xaml
    /// </summary>
    public partial class InfoBox : Window
    {
        public bool OK;
        public bool Abbruch;

        public InfoBox()
        {
            InitializeComponent();
            OK = false;
            Abbruch = false;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_OK(object sender, RoutedEventArgs e)
        {
            OK = true;
            Abbruch = false;
            this.Close();
        }
        private void Button_Abbruch(object sender, RoutedEventArgs e)
        {
            OK = false;
            Abbruch = true;
            this.Close();
        }
        private void Button_Manual(object sender, RoutedEventArgs e)
        {
            //Öffnen der Datei mit dem festgelegten "StandartProgramm" des Betriebssystemes
            Process.Start("RoboticHelpToolManual.pdf");

        }
    }
}
