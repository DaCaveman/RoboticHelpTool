using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace RoboticHelpTool
{
    public class ABBLocation : Operation
    {
        //--------------Klasseneigenschaften-----------------

        //Deklaration der benötigten Listen
        public static List<ABBLocation> ABBLocationsAktuell = new List<ABBLocation>();
        public static List<ABBLocation> ABBLocationsAktuellShift = new List<ABBLocation>();
        public static List<MatrixLocation> MatrixLocationsAktuell = new List<MatrixLocation>();
        public static List<String> LocationsAktuellString = new List<String>();
        public static List<String> ABB_Header = new List<String>();
        public static List<String> ABB_Sorted = new List<String>();

        //--------------Eigenschaftsmethoden---------------

        protected string _Type;
        protected string _Name;
        protected double _XCoordinate;
        protected double _YCoordinate;
        protected double _ZCoordinate;
        protected double _Q1Value;
        protected double _Q2Value;
        protected double _Q3Value;
        protected double _Q4Value;
        protected double _AAngle;
        protected double _BAngle;
        protected double _CAngle;
        protected int _Cf1Value;
        protected int _Cf4Value;
        protected int _Cf6Value;
        protected int _CfXValue;
        protected double _E1Value;
        protected double _E2Value;
        protected double _E3Value;
        protected double _E4Value;
        protected double _E5Value;
        protected double _E6Value;

        public virtual string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public virtual string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public virtual double XCoordinate
        {
            get { return _XCoordinate; }
            set { _XCoordinate = value; }
        }
        public virtual double YCoordinate
        {
            get { return _YCoordinate; }
            set { _YCoordinate = value; }
        }
        public virtual double ZCoordinate
        {
            get { return _ZCoordinate; }
            set { _ZCoordinate = value; }
        }
        public virtual double Q1Value
        {
            get { return _Q1Value; }
            set { _Q1Value = value; }
        }
        public virtual double Q2Value
        {
            get { return _Q2Value; }
            set { _Q2Value = value; }
        }
        public virtual double Q3Value
        {
            get { return _Q3Value; }
            set { _Q3Value = value; }
        }
        public virtual double Q4Value
        {
            get { return _Q4Value; }
            set { _Q4Value = value; }
        }
        public virtual double AAngle
        {
            get { return _AAngle; }
            set { _AAngle = value; }
        }
        public virtual double BAngle
        {
            get { return _BAngle; }
            set { _BAngle = value; }
        }
        public virtual double CAngle
        {
            get { return _CAngle; }
            set { _CAngle = value; }
        }
        public virtual int Cf1Value
        {
            get { return _Cf1Value; }
            set { _Cf1Value = value; }
        }
        public virtual int Cf4Value
        {
            get { return _Cf4Value; }
            set { _Cf4Value = value; }
        }
        public virtual int Cf6Value
        {
            get { return _Cf6Value; }
            set { _Cf6Value = value; }
        }
        public virtual int CfXValue
        {
            get { return _CfXValue; }
            set { _CfXValue = value; }
        }
        public virtual double E1Value
        {
            get { return _E1Value; }
            set { _E1Value = value; }
        }
        public virtual double E2Value
        {
            get { return _E2Value; }
            set { _E2Value = value; }
        }

        public virtual double E3Value
        {
            get { return _E3Value; }
            set { _E3Value = value; }
        }

        public virtual double E4Value
        {
            get { return _E4Value; }
            set { _E4Value = value; }
        }

        public virtual double E5Value
        {
            get { return _E5Value; }
            set { _E5Value = value; }
        }

        public virtual double E6Value
        {
            get { return _E6Value; }
            set { _E6Value = value; }
        }

        //--------------Konstruktoren------------------------

        public ABBLocation() : this("", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) { }

        public ABBLocation(string type, string name) : this(type, name, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) { }

        public ABBLocation(string type, string name, double xCoordinate, double yCoordinate, double zCoordinate
                , double q1Value, double q2Value, double q3Value, double q4Value)
            : this(type, name, xCoordinate, yCoordinate, zCoordinate, q1Value, q2Value, q3Value, q4Value, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) { }

        public ABBLocation(string type, string name, double xCoordinate, double yCoordinate, double zCoordinate
                , double q1Value, double q2Value, double q3Value, double q4Value
                , double e1Value, double e2Value, double e3Value, double e4Value, double e5Value, double e6Value)
            : this(type, name, xCoordinate, yCoordinate, zCoordinate, q1Value, q2Value, q3Value, q4Value, 0, 0, 0, 0
                  , e1Value, e2Value, e3Value, e4Value, e5Value, e6Value) { }

        public ABBLocation(string type, string name, double xCoordinate, double yCoordinate, double zCoordinate
                , double q1Value, double q2Value, double q3Value, double q4Value
                , int cf1Value, int cf4Value, int cf6Value, int cfXValue
                , double e1Value, double e2Value, double e3Value, double e4Value, double e5Value, double e6Value)
        {
            if (name != null || type != null || name != "" || type != "")
            {
                if (type.CaseInsensitiveContains("robtarget"))
                {
                    Name = name;
                    Type = type;
                    XCoordinate = xCoordinate;
                    YCoordinate = yCoordinate;
                    ZCoordinate = zCoordinate;
                    Q1Value = q1Value;
                    Q2Value = q2Value;
                    Q3Value = q3Value;
                    Q4Value = q4Value;
                    Cf1Value = cf1Value;
                    Cf4Value = cf4Value;
                    Cf6Value = cf6Value;
                    CfXValue = cfXValue;
                    E1Value = e1Value;
                    E2Value = e2Value;
                    E3Value = e3Value;
                    E4Value = e4Value;
                    E5Value = e5Value;
                    E6Value = e6Value;
                }
            }
        }

        public ABBLocation(MatrixLocation matrixLocation)
        {
            double S;
            double tr;

            Name = matrixLocation.Name;
            Type = matrixLocation.Type;
            XCoordinate = matrixLocation.Feld14;
            YCoordinate = matrixLocation.Feld24;
            ZCoordinate = matrixLocation.Feld34;

            tr = matrixLocation.Feld11 + matrixLocation.Feld22 + matrixLocation.Feld33;
            if (tr > 0)
            {
                S = Math.Sqrt(tr + 1.0) * 2;
                Q1Value = 0.25 * S;
                Q2Value = (matrixLocation.Feld32 - matrixLocation.Feld23) / S;
                Q3Value = (matrixLocation.Feld13 - matrixLocation.Feld31) / S;
                Q4Value = (matrixLocation.Feld21 - matrixLocation.Feld12) / S;
            }
            else if ((matrixLocation.Feld11 > matrixLocation.Feld22) & (matrixLocation.Feld11 > matrixLocation.Feld33))
            {
                S = Math.Sqrt(1.0 + matrixLocation.Feld11 - matrixLocation.Feld22 - matrixLocation.Feld33) * 2; // S=4*qx 
                Q1Value = (matrixLocation.Feld32 - matrixLocation.Feld23) / S;
                Q2Value = 0.25 * S;
                Q3Value = (matrixLocation.Feld12 + matrixLocation.Feld21) / S;
                Q4Value = (matrixLocation.Feld13 + matrixLocation.Feld31) / S;
            }
            else if (matrixLocation.Feld22 > matrixLocation.Feld33)
            {
                S = Math.Sqrt(1.0 + matrixLocation.Feld22 - matrixLocation.Feld11 - matrixLocation.Feld33) * 2; // S=4*qy
                Q1Value = (matrixLocation.Feld13 - matrixLocation.Feld31) / S;
                Q2Value = (matrixLocation.Feld12 + matrixLocation.Feld12) / S;
                Q3Value = 0.25 * S;
                Q4Value = (matrixLocation.Feld23 + matrixLocation.Feld32) / S;
            }
            else
            {
                S = Math.Sqrt(1.0 + matrixLocation.Feld33 - matrixLocation.Feld11 - matrixLocation.Feld22) * 2; // S=4*qz
                Q1Value = (matrixLocation.Feld21 - matrixLocation.Feld21) / S;
                Q2Value = (matrixLocation.Feld13 + matrixLocation.Feld31) / S;
                Q3Value = (matrixLocation.Feld23 + matrixLocation.Feld32) / S;
                Q4Value = 0.25 * S;
            }
            Cf1Value = matrixLocation.Cf1;
            Cf4Value = matrixLocation.Cf4;
            Cf6Value = matrixLocation.Cf6;
            CfXValue = matrixLocation.CfX;
            E1Value = matrixLocation.E1Value;
            E2Value = matrixLocation.E2Value;
            E3Value = matrixLocation.E3Value;
            E4Value = matrixLocation.E4Value;
            E5Value = matrixLocation.E5Value;
            E6Value = matrixLocation.E6Value;
        }

        public ABBLocation(KukaLocation kukaLocation)
        {
            double S;
            double tr;

            Name = kukaLocation.Name;
            Type = kukaLocation.Type;
            XCoordinate = kukaLocation.XCoordinate;
            YCoordinate = kukaLocation.YCoordinate;
            ZCoordinate = kukaLocation.ZCoordinate;

            double feld11 = Math.Cos(DegToRad(kukaLocation.AAngle)) * Math.Cos(DegToRad(kukaLocation.BAngle));
            double feld12 = Math.Cos(DegToRad(kukaLocation.AAngle)) * Math.Sin(DegToRad(kukaLocation.BAngle))
                     * Math.Sin(DegToRad(kukaLocation.CAngle))
                     - Math.Sin(DegToRad(kukaLocation.AAngle)) * Math.Cos(DegToRad(kukaLocation.CAngle));
            double feld13 = Math.Cos(DegToRad(kukaLocation.CAngle)) * Math.Sin(DegToRad(kukaLocation.BAngle))
                     * Math.Cos(DegToRad(kukaLocation.AAngle))
                     + Math.Sin(DegToRad(kukaLocation.CAngle)) * Math.Sin(DegToRad(kukaLocation.AAngle));
            double feld21 = Math.Sin(DegToRad(kukaLocation.AAngle)) * Math.Cos(DegToRad(kukaLocation.BAngle));
            double feld22 = Math.Sin(DegToRad(kukaLocation.AAngle)) * Math.Sin(DegToRad(kukaLocation.BAngle))
                     * Math.Sin(DegToRad(kukaLocation.CAngle))
                     + Math.Cos(DegToRad(kukaLocation.CAngle)) * Math.Cos(DegToRad(kukaLocation.AAngle));
            double feld23 = Math.Sin(DegToRad(kukaLocation.AAngle)) * Math.Sin(DegToRad(kukaLocation.BAngle))
                     * Math.Cos(DegToRad(kukaLocation.CAngle))
                     - Math.Cos(DegToRad(kukaLocation.AAngle)) * Math.Sin(DegToRad(kukaLocation.CAngle));
            double feld31 = -Math.Sin(DegToRad(kukaLocation.BAngle));
            double feld32 = Math.Cos(DegToRad(kukaLocation.BAngle)) * Math.Sin(DegToRad(kukaLocation.CAngle));
            double feld33 = Math.Cos(DegToRad(kukaLocation.BAngle)) * Math.Cos(DegToRad(kukaLocation.CAngle));

            tr = feld11 + feld22 + feld33;
            if (tr > 0)
            {
                S = Math.Sqrt(tr + 1.0) * 2;
                Q1Value = 0.25 * S;
                Q2Value = (feld32 - feld23) / S;
                Q3Value = (feld13 - feld31) / S;
                Q4Value = (feld21 - feld12) / S;
            }
            else if ((feld11 > feld22) & (feld11 > feld33))
            {
                S = Math.Sqrt(1.0 + feld11 - feld22 - feld33) * 2; // S=4*qx 
                Q1Value = (feld32 - feld23) / S;
                Q2Value = 0.25 * S;
                Q3Value = (feld12 + feld21) / S;
                Q4Value = (feld13 + feld31) / S;
            }
            else if (feld22 > feld33)
            {
                S = Math.Sqrt(1.0 + feld22 - feld11 - feld33) * 2; // S=4*qy
                Q1Value = (feld13 - feld31) / S;
                Q2Value = (feld12 + feld12) / S;
                Q3Value = 0.25 * S;
                Q4Value = (feld23 + feld32) / S;
            }
            else
            {
                S = Math.Sqrt(1.0 + feld33 - feld11 - feld22) * 2; // S=4*qz
                Q1Value = (feld21 - feld21) / S;
                Q2Value = (feld13 + feld31) / S;
                Q3Value = (feld23 + feld32) / S;
                Q4Value = 0.25 * S;
            }
            E1Value = kukaLocation.E1Value;
            E2Value = kukaLocation.E2Value;
            E3Value = kukaLocation.E3Value;
            E4Value = kukaLocation.E4Value;
            E5Value = kukaLocation.E5Value;
            E6Value = kukaLocation.E6Value;
        }

        //Methode zum aufsplitten der Deklarationen von E6POS "Strings" in abfragbare und
        // bearbeitbare Werte z.B. Dezimal usw.
        public static void LocationSplit()
        {
            StreamReader datei;
            datei = File.OpenText(ABBFilePage.DateiOrtDat);
            string zeile = "";
            string[] felder;
            string[] name;
            Double XCoordinate;
            Double YCoordinate;
            Double ZCoordinate;
            Double Q1;
            Double Q2;
            Double Q3;
            Double Q4;
            int cf1;
            int cf2;
            int cf3;
            int cf4;
            Double E1Value;
            Double E2Value;
            Double E3Value;
            Double E4Value;
            Double E5Value;
            Double E6Value;
            ABBLocation abbTemp;

            while (datei.Peek() != -1) //Solange bis Dateiende erreicht
            {
                zeile = datei.ReadLine(); // Zeile lesen

                //finden von Deklarationen von E6POS
                if (zeile.CaseInsensitiveContains("CONST robtarget") || zeile.CaseInsensitiveContains("VAR robtarget"))
                {

                    felder = zeile.Split(new char[] { '[', ',', ']', '=', ':' }); // Zeile an "Chars" aufbrechen

                    //Ausplitten für den Namen der Location
                    name = felder[0].Split(new char[] { ' ' });

                    // Aufgesplitte Zeile Zuweisen und in Dezimal umwandeln
                    if (felder.Length > 10)
                    {
                        string[] XCoordinateDec = Regex.Split(felder[4], @"[^-?\d*\.{0,1}\d+$]")                                    //Nur Zahlen
                            .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                        XCoordinate = Convert.ToDouble(XCoordinateDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });//Sting in Double konvertieren
                        string[] YCoordinateDec = Regex.Split(felder[5], @"[^-?\d*\.{0,1}\d+$]")                                    //Nur Zahlen
                            .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                        YCoordinate = Convert.ToDouble(YCoordinateDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });//Sting in Double konvertieren
                        string[] ZCoordinateDec = Regex.Split(felder[6], @"[^-?\d*\.{0,1}\d+$]")                                    //Nur Zahlen
                            .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                        ZCoordinate = Convert.ToDouble(ZCoordinateDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });//Sting in Double konvertieren
                        string[] Q1Dec = Regex.Split(felder[9], @"[^-?\d*\.{0,1}\d+$]")                                         //Nur Zahlen
                            .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                        Q1 = Convert.ToDouble(Q1Dec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });          //Sting in Double konvertieren
                        string[] Q2Dec = Regex.Split(felder[10], @"[^-?\d*\.{0,1}\d+$]")                                         //Nur Zahlen
                            .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                        Q2 = Convert.ToDouble(Q2Dec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });          //Sting in Double konvertieren
                        string[] Q3Dec = Regex.Split(felder[11], @"[^-?\d*\.{0,1}\d+$]")                                         //Nur Zahlen
                            .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                        Q3 = Convert.ToDouble(Q3Dec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });          //Sting in Double konvertieren
                        string[] Q4Dec = Regex.Split(felder[12], @"[^-?\d*\.{0,1}\d+$]")                                         //Nur Zahlen
                            .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                        Q4 = Convert.ToDouble(Q4Dec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });          //Sting in Double konvertieren

                        try
                        {
                            string[] cf1Dec = Regex.Split(felder[15], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                         //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            cf1 = Convert.ToInt16(cf1Dec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });            //Sting in Double konvertieren
                        }
                        catch
                        {
                            cf1 = 0;
                        }
                        try
                        {
                            string[] cf2Dec = Regex.Split(felder[16], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                           //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            cf2 = Convert.ToInt16(cf2Dec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });                //Sting in Double konvertieren
                        }
                        catch
                        {
                            cf2 = 0;
                        }
                        try
                        {
                            string[] cf3Dec = Regex.Split(felder[17], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                         //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            cf3 = Convert.ToInt16(cf3Dec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });            //Sting in Double konvertieren
                        }
                        catch
                        {
                            cf3 = 0;
                        }
                        try
                        {
                            string[] cf4Dec = Regex.Split(felder[18], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                           //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            cf4 = Convert.ToInt16(cf4Dec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });                //Sting in Double konvertieren
                        }
                        catch
                        {
                            cf4 = 0;
                        }
                        try
                        {
                            string[] E1ValueDec = Regex.Split(felder[21], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                 //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            //if (E1ValueDec[0].CaseInsensitiveContains("9E+09"))
                            //    E1ValueDec[0] = "0.0";
                            E1Value = Convert.ToDouble(E1ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E1Value = 0;
                        }
                        try
                        {
                            string[] E2ValueDec = Regex.Split(felder[22], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            //if (E2ValueDec[0].Equals("9E+09"))
                            //    E2ValueDec[0] = "0.0";
                            E2Value = Convert.ToDouble(E2ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E2Value = 0;
                        }
                        try
                        {
                            string[] E3ValueDec = Regex.Split(felder[23], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            //if (E3ValueDec[0].Equals("9E+09"))
                            //    E3ValueDec[0] = "0.0";
                            E3Value = Convert.ToDouble(E3ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E3Value = 0;
                        }
                        try
                        {
                            string[] E4ValueDec = Regex.Split(felder[24], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            //if (E4ValueDec[0].Equals("9E+09"))
                            //    E4ValueDec[0] = "0.0";
                            E4Value = Convert.ToDouble(E4ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E4Value = 0;
                        }
                        try
                        {
                            string[] E5ValueDec = Regex.Split(felder[25], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            //if (E5ValueDec[0].Equals("9E+09"))
                            //    E5ValueDec[0] = "0.0";
                            E5Value = Convert.ToDouble(E5ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E5Value = 0;
                        }
                        try
                        {
                            string[] E6ValueDec = Regex.Split(felder[26], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            //if (E6ValueDec[0].Equals("9E+09"))
                            //    E6ValueDec[0] = "0.0";
                            E6Value = Convert.ToDouble(E6ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E6Value = 0;
                        }
                        abbTemp = new ABBLocation(name[4] + " " + name[5] + " " + name[6], name[7], XCoordinate, YCoordinate, ZCoordinate
                                , Q1, Q2, Q3, Q4, cf1, cf2, cf3, cf4, E1Value, E2Value, E3Value, E4Value, E5Value, E6Value);
                        KukaLocation.KukaLocationsAktuell.Add(new KukaLocation(abbTemp));
                    }
                }
            }

            Console.WriteLine("Datei wurde eingelesen von: {0}", KukaFilePage.DateiOrtDat);
            datei.Close();
        }

        //Methode zum umwandeln von Location Objecten zu fertigen E6POS "Strings"
        //List<location> wird zu List<string>
        public static void ABBListeToFile(List<KukaLocation> kukaLocation)
        {
            LocationsAktuellString.Clear();
            foreach (var n in kukaLocation)
            {
                LocationsAktuellString.Add(String.Format(new NumberFormatInfo() { NumberDecimalSeparator = "." }
                , "{0} {1}:=[[{2},{3},{4}],[{5},{6},{7}],[{8},{9},{10},{11}],[{12},{13},{14},{15},{16},{17}]];"
                        , n.Type, n.Name
                        , n.XCoordinate.ToString("0.#########").Replace(',', '.'), n.YCoordinate.ToString("0.#########").Replace(',', '.')
                        , n.ZCoordinate.ToString("0.#########").Replace(',', '.')
                        , n.AAngle.ToString("0.#########").Replace(',', '.'), n.BAngle.ToString("0.#########").Replace(',', '.')
                        , n.CAngle.ToString("0.#########").Replace(',', '.')
                        , n.StatusCf1, n.TurnCf4, n.Cf6, n.Cfx
                        , n.E1Value.ToString("0.#########").Replace(',', '.'), n.E2Value.ToString("0.#########").Replace(',', '.')
                        , n.E3Value.ToString("0.#########").Replace(',', '.')
                        , n.E4Value.ToString("0.#########").Replace(',', '.'), n.E5Value.ToString("0.#########").Replace(',', '.')
                        , n.E6Value.ToString("0.#########").Replace(',', '.')).Replace("9000000000", "9E+09"));
            }
        }



    }
}
