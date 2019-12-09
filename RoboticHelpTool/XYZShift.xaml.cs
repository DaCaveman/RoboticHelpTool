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
    /// Interaktionslogik für XYZShift.xaml
    /// </summary>
    public partial class XYZShift : Window
    {
		// deklarieren eines Events
        public event EventHandler XYZShiftButtonClicked;

        public static double XValue;
        public static double YValue;
        public static double ZValue;
        public static bool XYZOK;
        public static bool XYZOpen;
        public static MatrixLocation matrixLocationRelValue;


        public XYZShift()
        {
            InitializeComponent();
        }

		//OK-Button im XYZShift Fenster
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isDouble;

			//Überprüfen, ob die im Fenster eingebenen Werte vom Typ Double werden können
            if ((isDouble = Double.TryParse(Convert.ToString(X.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out double doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Y.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Y.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue)))
            {
				// Konvertieren von String zu Double mit Bereinigung, Trennzeichen '.'
                XValue = Convert.ToDouble(X.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." });
                YValue = Convert.ToDouble(Y.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." });
                ZValue = Convert.ToDouble(Z.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." });

            }

			//Ansonsten werden als Werte zum Verschieben mit 0.0 festgelegt
            else
            {
                XValue = 0.0;
                YValue = 0.0;
                ZValue = 0.0;
            }
            matrixLocationRelValue = new MatrixLocation("", "",1,0,0,XValue,0,1,0,YValue,0,0,1,ZValue,0,0,0,1);
            // Merker für den OK-Button wird gesetzt
            XYZOK = true;

			// XYZShift Fenster wird geschlossen
            this.Close();

			// aktivieren des Events
			// ZielMethode ist in der class Hand
            XYZShiftButtonClicked?.Invoke(sender, e);

        }
        //OK-Button im XYZShift Fenster
        private void Enter_Press(object sender, RoutedEventArgs e)
        {
            bool isDouble;

            //Überprüfen, ob die im Fenster eingebenen Werte vom Typ Double werden können
            if ((isDouble = Double.TryParse(Convert.ToString(X.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out double doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Y.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue))
                && (isDouble = Double.TryParse(Convert.ToString(Y.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." }), out doubleValue)))
            {
                // Konvertieren von String zu Double mit Bereinigung, Trennzeichen '.'
                XValue = Convert.ToDouble(X.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." });
                YValue = Convert.ToDouble(Y.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." });
                ZValue = Convert.ToDouble(Z.Text.Replace(',', '.'), new NumberFormatInfo() { NumberDecimalSeparator = "." });

            }

            //Ansonsten werden als Werte zum Verschieben mit 0.0 festgelegt
            else
            {
                XValue = 0.0;
                YValue = 0.0;
                ZValue = 0.0;
            }
            matrixLocationRelValue = new MatrixLocation("", "", 1, 0, 0, XValue, 0, 1, 0, YValue, 0, 0, 1, ZValue, 0, 0, 0, 1);
            // Merker für den OK-Button wird gesetzt
            XYZOK = true;

            // XYZShift Fenster wird geschlossen
            this.Close();

            // aktivieren des Events
            // ZielMethode ist in der class Hand
            XYZShiftButtonClicked?.Invoke(sender, e);

        }

        // Methode, wenn das Fenster geschlossen wird
        void XYZShiftClosing(object sender, CancelEventArgs e)
        {
			// Merker, dass das XYZShift Fenster geschlossen wurde
            XYZOpen = false;

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
