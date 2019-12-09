using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Diagnostics;

namespace RoboticHelpTool
{

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EmptyData Background = new EmptyData();
            MainData.Navigate(Background);

        }

        //Öffnet das Hand Eingabefenster
        private void Button_Hand(object sender, RoutedEventArgs e)
        {
            HandPage hand = new HandPage();
            MainData.Navigate(hand);

            MainData.NavigationService.RemoveBackEntry();

        }
        //Öffnet das KUKA Datei Eingabefenster
        private void Button_KUKA(object sender, RoutedEventArgs e)
        {

            KukaFilePage kuka = new KukaFilePage();
            MainData.Navigate(kuka);

            MainData.NavigationService.RemoveBackEntry();

        }
        //Öffnet das ABB Datei Eingabefenster
        private void Button_ABB(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Info(object sender, RoutedEventArgs e)
        {
            InfoBox info = new InfoBox();
            info.Owner = Application.Current.MainWindow;
            info.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            info.InfoBox_Text.Content = "Programmierer: Dennis Kellermann \n" +
                                     "Bei Fragen oder Fehlern bitte Rückmeldung \n" +
                                     "an kellermann@tsr-automation.de";
            info.OK_Button.Visibility = Visibility.Visible;
            info.Abbruch_Button.Visibility = Visibility.Hidden;
            info.Manual_Button.Visibility = Visibility.Visible;
            info.Show();

        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Button_Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
