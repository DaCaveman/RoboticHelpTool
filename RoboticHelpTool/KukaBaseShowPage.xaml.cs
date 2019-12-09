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
    /// Interaktionslogik für KukaBaseShowPage.xaml
    /// </summary>
    public partial class KukaBaseShowPage : Page
    {
        public static KukaLocation Base = new KukaLocation();

        public KukaBaseShowPage()
        {

            InitializeComponent();

            Base = new KukaLocation(Operation.BaseCalc(KukaBasePage.Root, KukaBasePage.PositiveX, KukaBasePage.PositiveY));

            try
            {
                X_Value_Base.Text = Convert.ToDouble(Base.XCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Y_Value_Base.Text = Convert.ToDouble(Base.YCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                Z_Value_Base.Text = Convert.ToDouble(Base.ZCoordinate, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rX_Value_Base.Text = Convert.ToDouble(Base.CAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rY_Value_Base.Text = Convert.ToDouble(Base.BAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
                rZ_Value_Base.Text = Convert.ToDouble(Base.AAngle, new NumberFormatInfo() { NumberDecimalSeparator = "." }).ToString("0.#########").Replace(',', '.');
            }
            catch
            {}
        }
    }
}
