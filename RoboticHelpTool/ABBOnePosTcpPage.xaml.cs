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
    public partial class ABBOnePosTcpPage : Page
    {
        public static KukaLocation Base = new KukaLocation();
        public static KukaLocation Flansch = new KukaLocation();
        public static KukaLocation FlanschInv = new KukaLocation();
        public static KukaLocation TCP = new KukaLocation();
        public static ABBLocation TCP_ABB = new ABBLocation();

        public ABBOnePosTcpPage()
        {
            InitializeComponent();
        }
        private void Button_Einlesen(object sender, RoutedEventArgs e)
        {
            try
                {
                //Erstellen eines Base Objektes
                Base = new KukaLocation(new ABBLocation("robtarget", "OnePosTCP_Base",
                    Convert.ToDouble(X_Value_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q1_Value_ABB_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q2_Value_ABB_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q3_Value_ABB_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q4_Value_ABB_Base.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." })));
            }
            catch
            { }

            try
            {
                //Erstellen eines Base Objektes
                Flansch = new KukaLocation(new ABBLocation("robtarget", "OnePosTCP_Flansch",
                    Convert.ToDouble(X_Value_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q1_Value_ABB_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q2_Value_ABB_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q3_Value_ABB_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q4_Value_ABB_Flansch.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." })));

                FlanschInv = new KukaLocation(Operation.MatrixInv(Flansch));

                TCP = new KukaLocation(Operation.MultiLocation(Base, FlanschInv));
                TCP_ABB = new ABBLocation(TCP);
            }
            catch
            { }

            try
            {
                X_Value_TCP.Text = Convert.ToDouble(TCP_ABB.XCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Y_Value_TCP.Text = Convert.ToDouble(TCP_ABB.YCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Z_Value_TCP.Text = Convert.ToDouble(TCP_ABB.ZCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q1_Value_ABB_TCP.Text = Convert.ToDouble(TCP_ABB.Q1Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q2_Value_ABB_TCP.Text = Convert.ToDouble(TCP_ABB.Q2Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q3_Value_ABB_TCP.Text = Convert.ToDouble(TCP_ABB.Q3Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q4_Value_ABB_TCP.Text = Convert.ToDouble(TCP_ABB.Q4Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
            }
            catch
            { }

        }
    }
}
