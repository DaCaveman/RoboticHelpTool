using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace RoboticHelpTool
{
    /// <summary>
    /// Interaktionslogik für KukaBasePage.xaml
    /// </summary>
    public partial class KukaBasePage : Page
    {
        public static KukaLocation Root = new KukaLocation();
        public static KukaLocation PositiveX = new KukaLocation();
        public static KukaLocation PositiveY = new KukaLocation();

        public KukaBasePage()
        {
            InitializeComponent();
        }
        private void Button_Einlesen(object sender, RoutedEventArgs e)
        {
            try
            {
                //Erstellen eines Base Objektes
                Root = new KukaLocation("E6POS", "Base_Root",
                    Convert.ToDouble(X_Value_Root.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_Root.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_Root.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    0,
                    0,
                    0);
            }
            catch
            { }

            try
            {
                //Erstellen eines Base Objektes
                PositiveX = new KukaLocation("E6POS", "Base_positiveX",
                    Convert.ToDouble(X_Value_positiveX.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_positiveX.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_positiveX.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    0,
                    0,
                    0);

            }
            catch
            { }

            try
            {
                //Erstellen eines Base Objektes
                PositiveY = new KukaLocation("E6POS", "Base_positiveY",
                    Convert.ToDouble(X_Value_positiveY.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_positiveY.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_positiveY.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    0,
                    0,
                    0);

            }
            catch
            { }

            //Initialisieren des Hand2nd Fensters
            KukaBaseShowPage BaseShow = new KukaBaseShowPage();
            this.NavigationService.Navigate(BaseShow);
            this.NavigationService.RemoveBackEntry();

        }
    }
}
