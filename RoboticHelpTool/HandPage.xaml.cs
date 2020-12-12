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
    /// Interaktionslogik für HandButtons.xaml
    /// </summary>
    public partial class HandPage : Page
    {

        public decimal XValue;
        public decimal YValue;
        public decimal ZValue;
        public decimal RXValue;
        public decimal RYValue;
        public decimal RZValue;
        private bool KukaIsEmpty;
        private bool ABBIsEmpty;
        private bool MatrixIsEmpty;
        KukaLocation kukaLocation;
        MatrixLocation matrixLocation;
        ABBLocation abbLocation;


        public HandPage()
        {
            InitializeComponent();
            XYZShift.XYZOK = false;
            XYZShift.XYZOpen = false;
            KukaIsEmpty = false;
            ABBIsEmpty = false;
            MatrixIsEmpty = false;
            Hand2nd.MultiOpen = false;
            Hand2nd.MulitOK = false;

            X_Value_KUKA.Text = X_Value_KUKA.Tag.ToString();
            Y_Value_KUKA.Text = Y_Value_KUKA.Tag.ToString();
            Z_Value_KUKA.Text = Z_Value_KUKA.Tag.ToString();
            rX_Value_KUKA.Text = rX_Value_KUKA.Tag.ToString();
            rY_Value_KUKA.Text = rY_Value_KUKA.Tag.ToString();
            rZ_Value_KUKA.Text = rZ_Value_KUKA.Tag.ToString();

            F11_Value_Matrix.Text = F11_Value_Matrix.Tag.ToString();
            F12_Value_Matrix.Text = F12_Value_Matrix.Tag.ToString();
            F13_Value_Matrix.Text = F13_Value_Matrix.Tag.ToString();
            F14_Value_Matrix.Text = F14_Value_Matrix.Tag.ToString();
            F21_Value_Matrix.Text = F21_Value_Matrix.Tag.ToString();
            F22_Value_Matrix.Text = F22_Value_Matrix.Tag.ToString();
            F23_Value_Matrix.Text = F23_Value_Matrix.Tag.ToString();
            F24_Value_Matrix.Text = F24_Value_Matrix.Tag.ToString();
            F31_Value_Matrix.Text = F31_Value_Matrix.Tag.ToString();
            F32_Value_Matrix.Text = F32_Value_Matrix.Tag.ToString();
            F33_Value_Matrix.Text = F33_Value_Matrix.Tag.ToString();
            F34_Value_Matrix.Text = F34_Value_Matrix.Tag.ToString();
            F41_Value_Matrix.Text = F41_Value_Matrix.Tag.ToString();
            F42_Value_Matrix.Text = F42_Value_Matrix.Tag.ToString();
            F43_Value_Matrix.Text = F43_Value_Matrix.Tag.ToString();
            F44_Value_Matrix.Text = F44_Value_Matrix.Tag.ToString();

            X_Value_ABB.Text = X_Value_ABB.Tag.ToString();
            Y_Value_ABB.Text = Y_Value_ABB.Tag.ToString();
            Z_Value_ABB.Text = Z_Value_ABB.Tag.ToString();
            Q1_Value_ABB.Text = Q1_Value_ABB.Tag.ToString();
            Q2_Value_ABB.Text = Q2_Value_ABB.Tag.ToString();
            Q3_Value_ABB.Text = Q3_Value_ABB.Tag.ToString();
            Q4_Value_ABB.Text = Q4_Value_ABB.Tag.ToString();

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
                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(kukaLocation);
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

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(matrixLocation);

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

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(abbLocation);

            }
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

        //Methode zum Füllen des Fensters mit der aktuellen Location
        public void LocationAnzeigen(object sender)
        {
            // Für den Typ ABBLocation
            if (sender is ABBLocation)
            {
                // Der Double-Wert wird bereinigt und nach String konvertiert. 
                // Dezimal-Trennzeichen wird auf '.' festgelegt
                // Die Nachkommastellen werden auf 0.######### festgelegt
                kukaLocation = new KukaLocation(sender as ABBLocation);
                X_Value_KUKA.Text = Convert.ToDouble(kukaLocation.XCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Y_Value_KUKA.Text = Convert.ToDouble(kukaLocation.YCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Z_Value_KUKA.Text = Convert.ToDouble(kukaLocation.ZCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rX_Value_KUKA.Text = Convert.ToDouble(kukaLocation.CAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rY_Value_KUKA.Text = Convert.ToDouble(kukaLocation.BAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rZ_Value_KUKA.Text = Convert.ToDouble(kukaLocation.AAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');

                X_Value_ABB.Text = Convert.ToDouble(abbLocation.XCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Y_Value_ABB.Text = Convert.ToDouble(abbLocation.YCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Z_Value_ABB.Text = Convert.ToDouble(abbLocation.ZCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q1_Value_ABB.Text = Convert.ToDouble(abbLocation.Q1Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q2_Value_ABB.Text = Convert.ToDouble(abbLocation.Q2Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q3_Value_ABB.Text = Convert.ToDouble(abbLocation.Q3Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q4_Value_ABB.Text = Convert.ToDouble(abbLocation.Q4Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');

                matrixLocation = new MatrixLocation(sender as ABBLocation);
                F11_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld11, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F12_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld12, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F13_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld13, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F14_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld14, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F21_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld21, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F22_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld22, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F23_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld23, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F24_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld24, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F31_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld31, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F32_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld32, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F33_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld33, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F34_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld34, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F41_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld41, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F42_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld42, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F43_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld43, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F44_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld44, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');

            }

            // Für den Typ MatrixLocation
            if (sender is MatrixLocation)
            {
                // Der Double-Wert wird bereinigt und nach String konvertiert. 
                // Dezimal-Trennzeichen wird auf '.' festgelegt
                // Die Nachkommastellen werden auf 0.######### festgelegt
                kukaLocation = new KukaLocation(sender as MatrixLocation);
                X_Value_KUKA.Text = Convert.ToDouble(kukaLocation.XCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Y_Value_KUKA.Text = Convert.ToDouble(kukaLocation.YCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Z_Value_KUKA.Text = Convert.ToDouble(kukaLocation.ZCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rX_Value_KUKA.Text = Convert.ToDouble(kukaLocation.CAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rY_Value_KUKA.Text = Convert.ToDouble(kukaLocation.BAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rZ_Value_KUKA.Text = Convert.ToDouble(kukaLocation.AAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');

                abbLocation = new ABBLocation(sender as MatrixLocation);
                X_Value_ABB.Text = Convert.ToDouble(abbLocation.XCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Y_Value_ABB.Text = Convert.ToDouble(abbLocation.YCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Z_Value_ABB.Text = Convert.ToDouble(abbLocation.ZCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q1_Value_ABB.Text = Convert.ToDouble(abbLocation.Q1Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q2_Value_ABB.Text = Convert.ToDouble(abbLocation.Q2Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q3_Value_ABB.Text = Convert.ToDouble(abbLocation.Q3Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q4_Value_ABB.Text = Convert.ToDouble(abbLocation.Q4Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');

                F11_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld11, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F12_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld12, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F13_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld13, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F14_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld14, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F21_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld21, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F22_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld22, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F23_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld23, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F24_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld24, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F31_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld31, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F32_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld32, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F33_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld33, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F34_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld34, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F41_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld41, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F42_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld42, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F43_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld43, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F44_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld44, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');

            }

            // Für den Typ KukaLocation
            if (sender is KukaLocation)
            {
                // Der Double-Wert wird bereinigt und nach String konvertiert. 
                // Dezimal-Trennzeichen wird auf '.' festgelegt
                // Die Nachkommastellen werden auf 0.######### festgelegt
                X_Value_KUKA.Text = Convert.ToDouble(kukaLocation.XCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Y_Value_KUKA.Text = Convert.ToDouble(kukaLocation.YCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Z_Value_KUKA.Text = Convert.ToDouble(kukaLocation.ZCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rX_Value_KUKA.Text = Convert.ToDouble(kukaLocation.CAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rY_Value_KUKA.Text = Convert.ToDouble(kukaLocation.BAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rZ_Value_KUKA.Text = Convert.ToDouble(kukaLocation.AAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');

                abbLocation = new ABBLocation(sender as KukaLocation);
                X_Value_ABB.Text = Convert.ToDouble(abbLocation.XCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Y_Value_ABB.Text = Convert.ToDouble(abbLocation.YCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Z_Value_ABB.Text = Convert.ToDouble(abbLocation.ZCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q1_Value_ABB.Text = Convert.ToDouble(abbLocation.Q1Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q2_Value_ABB.Text = Convert.ToDouble(abbLocation.Q2Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q3_Value_ABB.Text = Convert.ToDouble(abbLocation.Q3Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Q4_Value_ABB.Text = Convert.ToDouble(abbLocation.Q4Value, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');

                matrixLocation = new MatrixLocation(sender as KukaLocation);
                F11_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld11, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F12_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld12, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F13_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld13, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F14_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld14, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F21_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld21, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F22_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld22, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F23_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld23, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F24_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld24, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F31_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld31, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F32_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld32, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F33_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld33, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F34_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld34, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F41_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld41, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F42_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld42, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F43_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld43, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                F44_Value_Matrix.Text = Convert.ToDouble(matrixLocation.Feld44, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');

            }
        }

        // Methode zum Initialisieren des Fensters
        // und anzeigen der Hilfetexte
        public void Reset_Click(object sender, RoutedEventArgs e)
        {
            XYZShift.XYZOK = false;
            XYZShift.XYZOpen = false;
            KukaIsEmpty = false;
            ABBIsEmpty = false;
            MatrixIsEmpty = false;
            Hand2nd.MultiOpen = false;
            Hand2nd.MulitOK = false;

            X_Value_KUKA.Text = X_Value_KUKA.Tag.ToString();
            Y_Value_KUKA.Text = Y_Value_KUKA.Tag.ToString();
            Z_Value_KUKA.Text = Z_Value_KUKA.Tag.ToString();
            rX_Value_KUKA.Text = rX_Value_KUKA.Tag.ToString();
            rY_Value_KUKA.Text = rY_Value_KUKA.Tag.ToString();
            rZ_Value_KUKA.Text = rZ_Value_KUKA.Tag.ToString();

            F11_Value_Matrix.Text = F11_Value_Matrix.Tag.ToString();
            F12_Value_Matrix.Text = F12_Value_Matrix.Tag.ToString();
            F13_Value_Matrix.Text = F13_Value_Matrix.Tag.ToString();
            F14_Value_Matrix.Text = F14_Value_Matrix.Tag.ToString();
            F21_Value_Matrix.Text = F21_Value_Matrix.Tag.ToString();
            F22_Value_Matrix.Text = F22_Value_Matrix.Tag.ToString();
            F23_Value_Matrix.Text = F23_Value_Matrix.Tag.ToString();
            F24_Value_Matrix.Text = F24_Value_Matrix.Tag.ToString();
            F31_Value_Matrix.Text = F31_Value_Matrix.Tag.ToString();
            F32_Value_Matrix.Text = F32_Value_Matrix.Tag.ToString();
            F33_Value_Matrix.Text = F33_Value_Matrix.Tag.ToString();
            F34_Value_Matrix.Text = F34_Value_Matrix.Tag.ToString();
            F41_Value_Matrix.Text = F41_Value_Matrix.Tag.ToString();
            F42_Value_Matrix.Text = F42_Value_Matrix.Tag.ToString();
            F43_Value_Matrix.Text = F43_Value_Matrix.Tag.ToString();
            F44_Value_Matrix.Text = F44_Value_Matrix.Tag.ToString();

            X_Value_ABB.Text = X_Value_ABB.Tag.ToString();
            Y_Value_ABB.Text = Y_Value_ABB.Tag.ToString();
            Z_Value_ABB.Text = Z_Value_ABB.Tag.ToString();
            Q1_Value_ABB.Text = Q1_Value_ABB.Tag.ToString();
            Q2_Value_ABB.Text = Q2_Value_ABB.Tag.ToString();
            Q3_Value_ABB.Text = Q3_Value_ABB.Tag.ToString();
            Q4_Value_ABB.Text = Q4_Value_ABB.Tag.ToString();

        }

        // Methode die vom Event OK-Button im Fenster XYZShift gestartet wird
        public void XYZShiftButton(object sender, EventArgs e)
        {
            //Überprüfung welcher Location Typ komplett gefüllt ist
            CheckWhat();

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == false && ABBIsEmpty == true && MatrixIsEmpty == true)
            {
                // Merker das der OK-Button gedrückt wurde
                XYZShift.XYZOK = false;

                //Füllen eines KukaLocation Objectes
                kukaLocation = new KukaLocation("E6POS", "HandEingabe",
                    Convert.ToDouble(X_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rZ_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rY_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rX_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                //verschieben des oben erstellte KukaLocation Objektes,
                //um die im Fenster angegebenen Werte
                Operation.XYZShiftKukaLocation(kukaLocation, XYZShift.XValue, XYZShift.YValue, XYZShift.ZValue);

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(kukaLocation);
            }

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == true && ABBIsEmpty == false && MatrixIsEmpty == true)
            {
                // Merker das der OK-Button gedrückt wurde
                XYZShift.XYZOK = false;

                //Füllen eines ABBLocation Objectes
                abbLocation = new ABBLocation("robtarget", "Handeingabe",
                    Convert.ToDouble(X_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q1_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q2_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q3_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q4_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                //verschieben des oben erstellte AbbLocation Objektes,
                //um die im Fenster angegebenen Werte
                Operation.XYZShiftABBLocation(abbLocation, XYZShift.XValue, XYZShift.YValue, XYZShift.ZValue);

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(abbLocation);
            }

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == true && ABBIsEmpty == true && MatrixIsEmpty == false)
            {
                // zurücksetzen des OK-Button Merkers
                XYZShift.XYZOK = false;

                //Füllen eines MatrixLocation Objectes
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

                //verschieben des oben erstellte MatrixLocation Objektes,
                //um die im Fenster angegebenen Werte
                Operation.XYZShiftMatrixLocation(matrixLocation, XYZShift.XValue, XYZShift.YValue, XYZShift.ZValue);

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(matrixLocation);
            }

        }

        //Methode zum Verschieben um X/Y/Z eines Location Objektes
        public void XYZShift_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des XYZShift Fensters
            XYZShift xyzShift = new XYZShift();
            // Verbinden des Eventes aus der XYZShift mit der Methode XYZShiftButton
            xyzShift.XYZShiftButtonClicked += XYZShiftButton;

            //Überprüfen, ob schon ein XYZShift Fenster geöffnet ist
            if (XYZShift.XYZOpen == false && XYZShift.XYZOK == false)
            {
                // öffnet ein XYZShift Fenster
                // setzt Merker, das XYZ Fenster geöffnet wurde
                XYZShift.XYZOpen = true;
                xyzShift.Owner = Application.Current.MainWindow;
                xyzShift.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                xyzShift.Show();

            }
            // überprüfen, ob der OK-Butten in einem XYZShift Fenster 
            // gedrückt wurde
            if (XYZShift.XYZOK == true)
            {
                //Überprüfung welcher Location Typ komplett gefüllt ist
                CheckWhat();

                //Auswertung welcher Location Typ komplett gefüllt ist
                if (KukaIsEmpty == false && ABBIsEmpty == true && MatrixIsEmpty == true)
                {
                    //zurücksetzten des OK-Button Merkers
                    XYZShift.XYZOK = false;

                    //Füllen eines KukaLocation Objectes
                    kukaLocation = new KukaLocation("E6POS", "HandEingabe",
                        Convert.ToDouble(X_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Y_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Z_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(rZ_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(rY_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(rX_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                    //verschieben des oben erstellte KukaLocation Objektes,
                    //um die im Fenster angegebenen Werte
                    Operation.XYZShiftKukaLocation(kukaLocation, XYZShift.XValue, XYZShift.YValue, XYZShift.ZValue);

                    // Füllen des Fensters mit den Aktuellen Werten der Location
                    // für alle Typen
                    LocationAnzeigen(kukaLocation);
                }

                //Auswertung welcher Location Typ komplett gefüllt ist
                if (KukaIsEmpty == true && ABBIsEmpty == false && MatrixIsEmpty == true)
                {
                    //zurücksetzten des OK-Button Merkers
                    XYZShift.XYZOK = false;

                    //Füllen eines ABBLocation Objectes
                    abbLocation = new ABBLocation("robtarget", "Handeingabe",
                        Convert.ToDouble(X_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Y_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Z_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q1_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q2_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q3_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q4_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                    //verschieben des oben erstellte ABBLocation Objektes,
                    //um die im Fenster angegebenen Werte
                    Operation.XYZShiftABBLocation(abbLocation, XYZShift.XValue, XYZShift.YValue, XYZShift.ZValue);

                    // Füllen des Fensters mit den Aktuellen Werten der Location
                    // für alle Typen
                    LocationAnzeigen(abbLocation);
                }

                //Auswertung welcher Location Typ komplett gefüllt ist
                if (KukaIsEmpty == true && ABBIsEmpty == true && MatrixIsEmpty == false)
                {
                    //zurücksetzten des OK-Button Merkers
                    XYZShift.XYZOK = false;

                    //Füllen eines MatrixLocation Objectes
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

                    //verschieben des oben erstellte MatrixLocation Objektes,
                    //um die im Fenster angegebenen Werte
                    Operation.XYZShiftMatrixLocation(matrixLocation, XYZShift.XValue, XYZShift.YValue, XYZShift.ZValue);

                    // Füllen des Fensters mit den Aktuellen Werten der Location
                    // für alle Typen
                    LocationAnzeigen(matrixLocation);
                }

            }
        }

        //Methode zum Verschieben um X/Y/Z eines Location Objektes
        //Auskommentierte Befehle sind als Vorlage gedacht
        public void Mirror_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des XYZShift Fensters
            //XYZShift xyzShift = new XYZShift();
            // Verbinden des Eventes aus der XYZShift mit der Methode XYZShiftButton
            //xyzShift.XYZShiftButtonClicked += XYZShiftButton;

            //Überprüfen, ob schon ein XYZShift Fenster geöffnet ist
            //if (XYZShift.XYZOpen == false && XYZShift.XYZOK == false)
            //{
            // öffnet ein XYZShift Fenster
            // setzt Merker, das XYZ Fenster geöffnet wurde
            //XYZShift.XYZOpen = true;
            //xyzShift.Show();

            //}
            // überprüfen, ob der OK-Butten in einem XYZShift Fenster 
            // gedrückt wurde
            //if (XYZShift.XYZOK == true)
            //{
            //Überprüfung welcher Location Typ komplett gefüllt ist
            CheckWhat();

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == false && ABBIsEmpty == true && MatrixIsEmpty == true)
            {
                //zurücksetzten des OK-Button Merkers
                //XYZShift.XYZOK = false;

                //Füllen eines KukaLocation Objectes
                kukaLocation = new KukaLocation("E6POS", "HandEingabe",
                    Convert.ToDouble(X_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rZ_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rY_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rX_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                //verschieben des oben erstellte KukaLocation Objektes,
                //um die im Fenster angegebenen Werte
                kukaLocation = (Operation.MirrorLocation(KukaLocation.MirrorOverX, kukaLocation));
                //kukaLocation = new KukaLocation(Operation.MultiLocation(MatrixLocation.MirrorOverZ, kukaLocation));

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(kukaLocation);
            }

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == true && ABBIsEmpty == false && MatrixIsEmpty == true)
            {
                //zurücksetzten des OK-Button Merkers
                //XYZShift.XYZOK = false;

                //Füllen eines ABBLocation Objectes
                abbLocation = new ABBLocation("robtarget", "Handeingabe",
                    Convert.ToDouble(X_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q1_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q2_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q3_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q4_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                //verschieben des oben erstellte KukaLocation Objektes,
                //um die im Fenster angegebenen Werte
                abbLocation = new ABBLocation(Operation.MirrorLocation(KukaLocation.MirrorOverX, abbLocation));
                //kukaLocation = new KukaLocation(Operation.MultiLocation(MatrixLocation.MirrorOverZ, kukaLocation));

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(abbLocation);
            }

            //}
        }

        // Methode die vom Event OK-Button im Fenster XYZShift gestartet wird
        public void MultiButton(object sender, EventArgs e)
        {
            //Überprüfung welcher Location Typ komplett gefüllt ist
            CheckWhat();

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == false && ABBIsEmpty == true && MatrixIsEmpty == true)
            {
                // Merker das der OK-Button gedrückt wurde
                Hand2nd.MulitOK = false;

                //Füllen eines KukaLocation Objectes
                kukaLocation = new KukaLocation("E6POS", "HandEingabe",
                    Convert.ToDouble(X_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rZ_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rY_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rX_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                //verschieben des oben erstellte KukaLocation Objektes,
                //um die im Fenster angegebenen Werte
                matrixLocation = (Operation.MultiLocation(Hand2nd.kukaLocation, kukaLocation));

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(matrixLocation);
            }

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == true && ABBIsEmpty == false && MatrixIsEmpty == true)
            {
                // Merker das der OK-Button gedrückt wurde
                Hand2nd.MulitOK = false;

                //Füllen eines ABBLocation Objectes
                abbLocation = new ABBLocation("robtarget", "Handeingabe",
                    Convert.ToDouble(X_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q1_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q2_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q3_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q4_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                //verschieben des oben erstellte AbbLocation Objektes,
                //um die im Fenster angegebenen Werte
                matrixLocation = (Operation.MultiLocation(Hand2nd.abbLocation, abbLocation));

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(matrixLocation);
            }

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == true && ABBIsEmpty == true && MatrixIsEmpty == false)
            {
                // zurücksetzen des OK-Button Merkers
                Hand2nd.MulitOK = false;

                //Füllen eines MatrixLocation Objectes
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

                //verschieben des oben erstellte MatrixLocation Objektes,
                //um die im Fenster angegebenen Werte
                matrixLocation = (Operation.MultiLocation(Hand2nd.matrixLocation, matrixLocation));

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(matrixLocation);
            }

        }

        //Methode zum Verschieben um X/Y/Z eines Location Objektes
        //Auskommentierte Befehle sind als Vorlage gedacht
        public void Multi_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des Hand2nd Fensters
            Hand2nd hand2nd = new Hand2nd();
            // Verbinden des Eventes aus der XYZShift mit der Methode XYZShiftButton
            hand2nd.MultiLocationEinlesen += MultiButton;

            //Überprüfen, ob schon ein Hand2nd Fenster geöffnet ist
            if (Hand2nd.MultiOpen == false && Hand2nd.MulitOK == false)
            {
                // öffnet ein Hand2nd Fenster
                // setzt Merker, das XYZ Fenster geöffnet wurde
                Hand2nd.MultiOpen = true;
                hand2nd.Owner = Application.Current.MainWindow;
                hand2nd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                hand2nd.Show();

            }
            // überprüfen, ob der OK-Butten in einem XYZShift Fenster 
            // gedrückt wurde
            if (Hand2nd.MulitOK == true)
            {
                //Überprüfung welcher Location Typ komplett gefüllt ist
                CheckWhat();

                //Auswertung welcher Location Typ komplett gefüllt ist
                if (KukaIsEmpty == false && ABBIsEmpty == true && MatrixIsEmpty == true)
                {
                    //zurücksetzten des OK-Button Merkers
                    Hand2nd.MulitOK = false;

                    //Füllen eines KukaLocation Objectes
                    kukaLocation = new KukaLocation("E6POS", "HandEingabe",
                        Convert.ToDouble(X_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Y_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Z_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(rZ_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(rY_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(rX_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                    //verschieben des oben erstellte KukaLocation Objektes,
                    //um die im Fenster angegebenen Werte
                    matrixLocation = (Operation.MultiLocation(Hand2nd.kukaLocation, kukaLocation));

                    // Füllen des Fensters mit den Aktuellen Werten der Location
                    // für alle Typen
                    LocationAnzeigen(kukaLocation);
                }

                //Auswertung welcher Location Typ komplett gefüllt ist
                if (KukaIsEmpty == true && ABBIsEmpty == true && MatrixIsEmpty == false)
                {
                    //zurücksetzten des OK-Button Merkers
                    Hand2nd.MulitOK = false;

                    //Füllen eines MatrixLocation Objectes
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

                    //verschieben des oben erstellte MatrixLocation Objektes,
                    //um die im Fenster angegebenen Werte
                    matrixLocation = (Operation.MultiLocation(Hand2nd.matrixLocation, matrixLocation));

                    // Füllen des Fensters mit den Aktuellen Werten der Location
                    // für alle Typen
                    LocationAnzeigen(matrixLocation);
                }

                //Auswertung welcher Location Typ komplett gefüllt ist
                if (KukaIsEmpty == true && ABBIsEmpty == false && MatrixIsEmpty == true)
                {
                    //zurücksetzten des OK-Button Merkers
                    Hand2nd.MulitOK = false;

                    //Füllen eines ABBLocation Objectes
                    abbLocation = new ABBLocation("robtarget", "Handeingabe",
                        Convert.ToDouble(X_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Y_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Z_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q1_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q2_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q3_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q4_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                    //verschieben des oben erstellte AbbLocation Objektes,
                    //um die im Fenster angegebenen Werte
                    matrixLocation = (Operation.MultiLocation(Hand2nd.abbLocation, abbLocation));

                    // Füllen des Fensters mit den Aktuellen Werten der Location
                    // für alle Typen
                    LocationAnzeigen(abbLocation);
                }
            }
        }

        // Methode die vom Event OK-Button im Fenster XYZShift gestartet wird
        public void RelToolButton(object sender, EventArgs e)
        {
            KukaLocation kukaLocation;

            //Überprüfung welcher Location Typ komplett gefüllt ist
            CheckWhat();

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == false && ABBIsEmpty == true && MatrixIsEmpty == true)
            {
                // Merker das der OK-Button gedrückt wurde
                XYZShift.XYZOK = false;

                //Füllen eines KukaLocation Objectes
                kukaLocation = new KukaLocation("E6POS", "HandEingabe",
                    Convert.ToDouble(X_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rZ_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rY_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(rX_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                //verschieben des oben erstellte KukaLocation Objektes,
                //um die im Fenster angegebenen Werte
                matrixLocation = (Operation.RelToolLocation(XYZShift.matrixLocationRelValue, kukaLocation));

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(matrixLocation);
            }

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == true && ABBIsEmpty == false && MatrixIsEmpty == true)
            {
                // Merker das der OK-Button gedrückt wurde
                XYZShift.XYZOK = false;

                //Füllen eines ABBLocation Objectes
                abbLocation = new ABBLocation("robtarget", "Handeingabe",
                    Convert.ToDouble(X_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Y_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Z_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q1_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q2_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q3_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                    Convert.ToDouble(Q4_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                //verschieben des oben erstellte AbbLocation Objektes,
                //um die im Fenster angegebenen Werte
                matrixLocation = (Operation.RelToolLocation(XYZShift.matrixLocationRelValue, abbLocation));

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(matrixLocation);
            }

            //Auswertung welcher Location Typ komplett gefüllt ist
            if (KukaIsEmpty == true && ABBIsEmpty == true && MatrixIsEmpty == false)
            {
                // zurücksetzen des OK-Button Merkers
                XYZShift.XYZOK = false;

                //Füllen eines MatrixLocation Objectes
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

                //verschieben des oben erstellte MatrixLocation Objektes,
                //um die im Fenster angegebenen Werte
                matrixLocation = (Operation.RelToolLocation(XYZShift.matrixLocationRelValue, matrixLocation));

                // Füllen des Fensters mit den Aktuellen Werten der Location
                // für alle Typen
                LocationAnzeigen(matrixLocation);
            }

        }

        //Methode zum Verschieben um X/Y/Z eines Location Objektes
        //Auskommentierte Befehle sind als Vorlage gedacht
        public void RelTool_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des XYZShift Fensters
            KukaLocation kukaLocation;
            XYZShift xyzShift = new XYZShift();
            xyzShift.XYZShiftButtonClicked += RelToolButton;

            //Überprüfen, ob schon ein XYZShift Fenster geöffnet ist
            if (XYZShift.XYZOpen == false && XYZShift.XYZOK == false)
            {
                // öffnet ein XYZShift Fenster
                // setzt Merker, das XYZ Fenster geöffnet wurde
                XYZShift.XYZOpen = true;
                xyzShift.Owner = Application.Current.MainWindow;
                xyzShift.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                xyzShift.ShowDialog();

            }

            // überprüfen, ob der OK-Butten in einem XYZShift Fenster 
            // gedrückt wurde
            if (XYZShift.XYZOK == true)
            {
                //Überprüfung welcher Location Typ komplett gefüllt ist
                CheckWhat();

                //Auswertung welcher Location Typ komplett gefüllt ist
                if (KukaIsEmpty == false && ABBIsEmpty == true && MatrixIsEmpty == true)
                {
                    //zurücksetzten des OK-Button Merkers
                    XYZShift.XYZOK = false;

                    //Füllen eines KukaLocation Objectes
                    kukaLocation = new KukaLocation("E6POS", "HandEingabe",
                        Convert.ToDouble(X_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Y_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Z_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(rZ_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(rY_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(rX_Value_KUKA.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                    //verschieben des oben erstellte KukaLocation Objektes,
                    //um die im Fenster angegebenen Werte
                    matrixLocation = (Operation.RelToolLocation(XYZShift.matrixLocationRelValue, kukaLocation));

                    // Füllen des Fensters mit den Aktuellen Werten der Location
                    // für alle Typen
                    LocationAnzeigen(kukaLocation);
                }

                //Auswertung welcher Location Typ komplett gefüllt ist
                if (KukaIsEmpty == true && ABBIsEmpty == true && MatrixIsEmpty == false)
                {
                    //zurücksetzten des OK-Button Merkers
                    XYZShift.XYZOK = false;

                    //Füllen eines MatrixLocation Objectes
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

                    //verschieben des oben erstellte MatrixLocation Objektes,
                    //um die im Fenster angegebenen Werte
                    matrixLocation = (Operation.RelToolLocation(XYZShift.matrixLocationRelValue, matrixLocation));

                    // Füllen des Fensters mit den Aktuellen Werten der Location
                    // für alle Typen
                    LocationAnzeigen(matrixLocation);
                }

                //Auswertung welcher Location Typ komplett gefüllt ist
                if (KukaIsEmpty == true && ABBIsEmpty == false && MatrixIsEmpty == true)
                {
                    //zurücksetzten des OK-Button Merkers
                    XYZShift.XYZOK = false;

                    //Füllen eines ABBLocation Objectes
                    abbLocation = new ABBLocation("robtarget", "Handeingabe",
                        Convert.ToDouble(X_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Y_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Z_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q1_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q2_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q3_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Convert.ToDouble(Q4_Value_ABB.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                    //verschieben des oben erstellte AbbLocation Objektes,
                    //um die im Fenster angegebenen Werte
                    matrixLocation = (Operation.RelToolLocation(XYZShift.matrixLocationRelValue, abbLocation));


                    // Füllen des Fensters mit den Aktuellen Werten der Location
                    // für alle Typen
                    LocationAnzeigen(abbLocation);
                }
            }
        }

        public void OnePosTCP_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des Hand2nd Fensters
            RobDecision Robdecision = new RobDecision();

            Robdecision.Owner = Application.Current.MainWindow;
            Robdecision.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Robdecision.Kuka_OnePosTCP.Visibility = Visibility.Visible;
            Robdecision.ABB_OnePosTCP.Visibility = Visibility.Visible;
            Robdecision.Kuka_Base.Visibility = Visibility.Hidden;
            Robdecision.Show();

        }

        public void Base_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des Hand2nd Fensters
            RobDecision Robdecision = new RobDecision();

            Robdecision.Owner = Application.Current.MainWindow;
            Robdecision.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Robdecision.Kuka_OnePosTCP.Visibility = Visibility.Hidden;
            Robdecision.ABB_OnePosTCP.Visibility = Visibility.Hidden;
            Robdecision.Kuka_Base.Visibility = Visibility.Visible;
            Robdecision.Show();

        }
    }
}
