using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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
    /// Interaktionslogik für AuswahlListe.xaml
    /// </summary>
    public partial class AuswahlListe : Window
    {

        public AuswahlListe()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox y in this.WorkList.Items)
            {
                y.IsChecked = false;
            }
            this.Close();
        }
        private void Button_Checkbox(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox y in this.WorkList.Items)
            {
                y.IsChecked = true;
            }
        }

        private void Button_Ausgabe(object sender, RoutedEventArgs e)
        {
            //Auswahl Test Ende
            this.Close();
        }

    }
}
