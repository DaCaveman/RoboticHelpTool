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

            ABBFilePage abb = new ABBFilePage();
            MainData.Navigate(abb);

            MainData.NavigationService.RemoveBackEntry();

        }

        private void Button_Info(object sender, RoutedEventArgs e)
        {
            InfoBox info = new InfoBox();
            info.Owner = Application.Current.MainWindow;
            info.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            info.InfoBox_Text.Content = "Programmierer: D.K \n" +
                                     "Bei Fragen oder Fehlern bitte Rückmeldung \n" +
                                     "an https://github.com/DaCaveman";
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
    public class FontSizeConverterTextBox : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double actualHeight = System.Convert.ToDouble(value) / 9;
            int fontSize = (int)(actualHeight * .5);
            return fontSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class FontSizeConverterLabel : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double actualHeight = System.Convert.ToDouble(value) / 13;
            int fontSize = (int)(actualHeight * .5);
            return fontSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
