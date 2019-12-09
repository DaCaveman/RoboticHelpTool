using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace RoboticHelpTool
{
    /// <summary>
    /// Interaktionslogik für Hand2nd.xaml
    /// </summary>
    public partial class Hand2nd : Window
    {
        //--------------Klasseneigenschaften-----------------
        public decimal XValue;
        public decimal YValue;
        public decimal ZValue;
        public decimal RXValue;
        public decimal RYValue;
        public decimal RZValue;
        private bool KukaIsEmpty;
        private bool ABBIsEmpty;
        private bool MatrixIsEmpty;
        public static KukaLocation kukaLocation = new KukaLocation();
        public static MatrixLocation matrixLocation;
        public static ABBLocation abbLocation;
        public static bool MulitOK;
        public static bool MultiOpen;

        // deklarieren eines Events
        public event EventHandler MultiLocationEinlesen;


        public Hand2nd()
        {
            InitializeComponent();
        }
        private void Button_Einlesen(object sender, RoutedEventArgs e)
        {

            // Überprüfung, welcher Location Typ eingegeben wurde
            CheckWhat();

            // Auswertung, welcher Location Typ eingeben wurde
            if (KukaIsEmpty == false && ABBIsEmpty == true && MatrixIsEmpty == true)
            {
                //Erstellen eines KukaLocation Objektes
                kukaLocation = new KukaLocation("E6POS", "HandEingabe",
                    Convert.ToDouble(X_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rZ_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rY_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rX_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

            }

            // Auswertung, welcher Location Typ eingeben wurde
            if (KukaIsEmpty == true && ABBIsEmpty == true && MatrixIsEmpty == false)
            {
                //Erstellen eines MatrixLocation Objektes
                matrixLocation = new MatrixLocation("Matrix", "HandEingabe",
                    Convert.ToDouble(F11_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F12_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F13_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F14_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F21_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F22_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F23_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F24_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F31_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F32_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F33_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F34_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F41_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F42_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F43_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(F44_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

            }

            // Auswertung, welcher Location Typ eingeben wurde
            if (KukaIsEmpty == true && ABBIsEmpty == false && MatrixIsEmpty == true)
            {
                //Erstellen eines ABBLocation Objektes
                abbLocation = new ABBLocation("robtarget", "Handeingabe",
                    Convert.ToDouble(X_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q1_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q2_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q3_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q4_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

            }
            // Merker für den OK-Button wird gesetzt
            MulitOK = true;

            // XYZShift Fenster wird geschlossen
            this.Close();

            // aktivieren des Events
            // ZielMethode ist in der class Hand
            MultiLocationEinlesen?.Invoke(sender, e);

        }


        // Methode zum Auswerten, welcher Location Typ komplett mit Double-Werten gefüllt ist
        public void CheckWhat()
        {
            KukaIsEmpty = true;
            ABBIsEmpty = true;
            MatrixIsEmpty = true;
            bool isDouble;
            double doubleValue;

            // ',' werden mit '.' ersetzt. Festlegen, dass das Dezimal-Trennzeichen ein '.' ist
            if ((isDouble = Double.TryParse(Convert.ToString(X_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Y_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Z_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(rZ_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(rY_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(rX_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue)))
            {
                //Der Typ Kuka ist komplett gefüllt
                KukaIsEmpty = false;
            }

            // ',' werden mit '.' ersetzt. Festlegen, dass das Dezimal-Trennzeichen ein '.' ist
            if ((isDouble = Double.TryParse(Convert.ToString(X_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Y_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Z_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Q1_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Q2_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Q3_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Q4_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue)))
            {
                //Der Typ ABB ist komplett gefüllt
                ABBIsEmpty = false;
            }

            // ',' werden mit '.' ersetzt. Festlegen, dass das Dezimal-Trennzeichen ein '.' ist
            if ((isDouble = Double.TryParse(Convert.ToString(F11_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F12_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F13_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F14_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F21_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F22_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F23_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F24_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F31_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F32_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F33_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F34_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F41_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F42_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F43_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(F44_Value_Matrix.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue)))
            {
                //Der Typ Matrix ist komplett gefüllt
                MatrixIsEmpty = false;
            }

        }
        // Methode, wenn das Fenster geschlossen wird
        void MultiClosing(object sender, CancelEventArgs e)
        {
            // Merker, dass das XYZShift Fenster geschlossen wurde
            MultiOpen = false;

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
