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
using System.IO;

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
            String Manual = AppDomain.CurrentDomain.BaseDirectory + "RoboticHelpToolManual.pdf";
            if (File.Exists(Manual))
            {
                Process.Start(Manual);
            }
            else
            {
                try
                {
                    File.WriteAllBytes(Manual, Properties.Resources.RoboticHelpToolManual);
                }
                catch 
                {
                    //ex As Exception
                    //MsgBox("Helpfile konnte nicht erzeugt werden. Melde dich bitte bei mir" & vbNewLine & "Vielleicht liegt dieses Programm auch in einem Ordner, für den du keine Schreibrechte hast.")
                }
            Process.Start(Manual);
            }
            Process.Start("RoboticHelpToolManual.pdf");

        }
    }
}
