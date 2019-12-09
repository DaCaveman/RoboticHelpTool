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
    /// Interaktionslogik für KukaOnePosTcpPage.xaml
    /// </summary>
    public partial class KukaOnePosTcpPage : Page
    {
        public static KukaLocation Base = new KukaLocation();
        public static KukaLocation Flansch = new KukaLocation();
        public static KukaLocation FlanschInv = new KukaLocation();
        public static KukaLocation TCP = new KukaLocation();

        public KukaOnePosTcpPage()
        {
            InitializeComponent();
        }
        private void Button_Einlesen(object sender, RoutedEventArgs e)
        {
            try
                {
                //Erstellen eines Base Objektes
                Base = new KukaLocation("E6POS", "OnePosTCP_Base",
                    Convert.ToDouble(X_Value_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rZ_Value_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rY_Value_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rX_Value_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));
            }
            catch
            { }

            try
            {
                //Erstellen eines Base Objektes
                Flansch = new KukaLocation("E6POS", "OnePosTCP_Flansch",
                    Convert.ToDouble(X_Value_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rZ_Value_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rY_Value_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rX_Value_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                FlanschInv = new KukaLocation(Operation.MatrixInv(Flansch));

                TCP = new KukaLocation(Operation.MultiLocation(Base, FlanschInv));
            }
            catch
            { }

            try
            {
                X_Value_TCP.Text = Convert.ToDouble(TCP.XCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Y_Value_TCP.Text = Convert.ToDouble(TCP.YCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Z_Value_TCP.Text = Convert.ToDouble(TCP.ZCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rX_Value_TCP.Text = Convert.ToDouble(TCP.CAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rY_Value_TCP.Text = Convert.ToDouble(TCP.BAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rZ_Value_TCP.Text = Convert.ToDouble(TCP.AAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
            }
            catch
            { }

        }
    }
}
