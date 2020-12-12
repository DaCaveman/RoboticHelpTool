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
using System.Windows.Shapes;

namespace RoboticHelpTool
{
    /// <summary>
    /// Interaktionslogik für RobDecision.xaml
    /// </summary>
    public partial class RobDecision : Window
    {
        public RobDecision()
        {
            InitializeComponent();
            EmptyData Background = new EmptyData();
            MainData.Navigate(Background);
        }


        public void KUKA_TCP_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des Hand2nd Fensters
            KukaOnePosTcpPage kuka = new KukaOnePosTcpPage();
            MainData.Navigate(kuka);

            MainData.NavigationService.RemoveBackEntry();

        }

        public void KUKA_Base_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des Hand2nd Fensters
            KukaBasePage kuka = new KukaBasePage();
            MainData.Navigate(kuka);

            MainData.NavigationService.RemoveBackEntry();

        }

        public void ABB_TCP_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des Hand2nd Fensters
            ABBOnePosTcpPage abb = new ABBOnePosTcpPage();
            MainData.Navigate(abb);

            MainData.NavigationService.RemoveBackEntry();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
