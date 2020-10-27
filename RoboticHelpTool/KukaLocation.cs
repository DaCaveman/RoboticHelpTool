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
    public class KukaLocation : Operation
    {
        //--------------Klasseneigenschaften-----------------

        //Deklaration der benötigten Listen
        public static List<KukaLocation> KukaLocationsAktuell = new List<KukaLocation>();
        public static List<KukaLocation> KukaLocationsAktuellShift = new List<KukaLocation>();
        public static List<KukaLocation> KukaLocationsAktuellMirror = new List<KukaLocation>();
        public static List<KukaLocation> KukaLocationsAktuellMulti = new List<KukaLocation>();
        public static List<MatrixLocation> MatrixLocationsAktuell = new List<MatrixLocation>();
        public static List<String> LocationsAktuellString = new List<String>();
        public static List<String> LocationsAuswahlString = new List<String>();
        public static List<String> KUKA_Header = new List<String>();
        public static List<String> KUKA_Header_clean = new List<String>();
        public static List<String> KUKA_Sorted = new List<String>();
        public static List<String> SortLocationsMisc = new List<String>();
        public static List<String> SortLocationsFromSrc = new List<String>();
        public static List<String> SortLocationsE6POS = new List<String>();
        public static List<String> SortLocationsFRAME = new List<String>();
        public static List<String> SortLocationsVW = new List<String>();
        public static List<String> SortLocationsFDAT = new List<String>();
        public static List<String> SortLocationsPLDAT = new List<String>();
        public static List<String> SrcInLines = new List<String>();
        public static List<String> DatInNames = new List<String>();
        public static List<String> DatInLines = new List<String>();
        public static List<String> ExistingNames = new List<String>();
        public static List<String> MissingNames = new List<String>();
        public static List<KukaLocation> SrcExistingVariables = new List<KukaLocation>();
        public static KukaLocation MirrorOverX = new KukaLocation("E6POS", "MirrorOverX", 1.0, -1.0, 1.0, -1.0, 1.0, -1.0);

        //--------------Eigenschaftsmethoden---------------

        protected string _Type;
        protected string _Name;
        protected double _XCoordinate;
        protected double _YCoordinate;
        protected double _ZCoordinate;
        protected double _AAngle;
        protected double _BAngle;
        protected double _CAngle;
        protected int _StatusCf1;
        protected int _TurnCf4;
        protected int _Cf6;
        protected int _Cfx;
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
        public virtual int StatusCf1
        {
            get { return _StatusCf1; }
            set { _StatusCf1 = value; }
        }
        public virtual int TurnCf4
        {
            get { return _TurnCf4; }
            set { _TurnCf4 = value; }
        }
        public virtual int Cf6
        {
            get { return _Cf6; }
            set { _Cf6 = value; }
        }
        public virtual int Cfx
        {
            get { return _Cfx; }
            set { _Cfx = value; }
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

        public KukaLocation() : this("", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) { }

        public KukaLocation(string type, string name) : this(type, name, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) { }

        public KukaLocation(string type, string name, double xCoordinate, double yCoordinate, double zCoordinate
                , double aAngle, double bAngle, double cAngle)
            : this(type, name, xCoordinate, yCoordinate, zCoordinate, aAngle, bAngle, cAngle, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) { }

        public KukaLocation(string type, string name, double xCoordinate, double yCoordinate, double zCoordinate
                , double aAngle, double bAngle, double cAngle, double e1Value, double e2Value
                , double e3Value, double e4Value, double e5Value, double e6Value)
            : this(type, name, xCoordinate, yCoordinate, zCoordinate, aAngle, bAngle, cAngle, 0, 0, 0, 0, e1Value, e2Value, e3Value, e4Value, e5Value, e6Value) { }

        public KukaLocation(string type, string name, double xCoordinate, double yCoordinate, double zCoordinate
                , double aAngle, double bAngle, double cAngle, int statusCf1, int turnCf2
                , double e1Value, double e2Value, double e3Value, double e4Value, double e5Value, double e6Value)
            : this(type, name, xCoordinate, yCoordinate, zCoordinate, aAngle, bAngle, cAngle, statusCf1, turnCf2, 0, 0, e1Value, e2Value, e3Value, e4Value, e5Value, e6Value) { }

        public KukaLocation(string type, string name, double xCoordinate, double yCoordinate, double zCoordinate
                , double aAngle, double bAngle, double cAngle, int statusCf1, int turnCf4, int kukaCf6, int kukaCfx
                , double e1Value, double e2Value, double e3Value, double e4Value, double e5Value, double e6Value)
        {
            if (name != null || type != null || name != "" || type != "")
            {
                if (type == "E6POS" || type != "")
                {
                    Name = name;
                    Type = type;
                    XCoordinate = xCoordinate;
                    YCoordinate = yCoordinate;
                    ZCoordinate = zCoordinate;
                    AAngle = aAngle;
                    BAngle = bAngle;
                    CAngle = cAngle;
                    StatusCf1 = statusCf1;
                    TurnCf4 = turnCf4;
                    E1Value = e1Value;
                    E2Value = e2Value;
                    E3Value = e3Value;
                    E4Value = e4Value;
                    E5Value = e5Value;
                    E6Value = e6Value;
                }
                if (type == "robtarget" || type != "")
                {
                    Name = name;
                    Type = type;
                    XCoordinate = xCoordinate;
                    YCoordinate = yCoordinate;
                    ZCoordinate = zCoordinate;
                    AAngle = aAngle;
                    BAngle = bAngle;
                    CAngle = cAngle;
                    StatusCf1 = statusCf1;
                    TurnCf4 = turnCf4;
                    Cf6 = kukaCf6;
                    Cfx = kukaCfx;
                    E1Value = e1Value;
                    E2Value = e2Value;
                    E3Value = e3Value;
                    E4Value = e4Value;
                    E5Value = e5Value;
                    E6Value = e6Value;
                }
            }
        }

        public KukaLocation(ABBLocation abbLocation)
        {
            double l1;
            double m1;
            double n1;
            double l;
            double m;
            double n;

            Name = abbLocation.Name;
            Type = abbLocation.Type;
            XCoordinate = abbLocation.XCoordinate;
            YCoordinate = abbLocation.YCoordinate;
            ZCoordinate = abbLocation.ZCoordinate;

            double feld11 = 1 - 2 * (abbLocation.Q3Value * abbLocation.Q3Value + abbLocation.Q4Value * abbLocation.Q4Value);
            double feld12 = 2 * (abbLocation.Q2Value * abbLocation.Q3Value - abbLocation.Q1Value * abbLocation.Q4Value);
            double feld13 = 2 * (abbLocation.Q2Value * abbLocation.Q4Value + abbLocation.Q1Value * abbLocation.Q3Value);
            double feld21 = 2 * (abbLocation.Q2Value * abbLocation.Q3Value + abbLocation.Q1Value * abbLocation.Q4Value);
            double feld22 = 1 - 2 * (abbLocation.Q2Value * abbLocation.Q2Value + abbLocation.Q4Value * abbLocation.Q4Value);
            double feld23 = 2 * (abbLocation.Q3Value * abbLocation.Q4Value - abbLocation.Q1Value * abbLocation.Q2Value);
            double feld31 = 2 * (abbLocation.Q2Value * abbLocation.Q4Value - abbLocation.Q1Value * abbLocation.Q3Value);
            double feld32 = 2 * (abbLocation.Q3Value * abbLocation.Q4Value + abbLocation.Q1Value * abbLocation.Q2Value);
            double feld33 = 1 - 2 * (abbLocation.Q2Value * abbLocation.Q2Value + abbLocation.Q3Value * abbLocation.Q3Value);

            double cosQ = (0.5) * (feld11 + feld22 + feld33 - 1);
            double tanQ = (Math.Sqrt(((feld32 - feld23) * (feld32 - feld23)) + ((feld13 - feld31) * (feld13 - feld31))
                    + ((feld21 - feld12) * (feld21 - feld12)))) / (feld11 + feld22 + feld33 - 1);
            double qRad = Math.Atan2(0.5 * Math.Sqrt((((feld32 - feld23) * (feld32 - feld23)) + ((feld13 - feld31) * (feld13 - feld31))
                    + ((feld21 - feld12) * (feld21 - feld12)))), (cosQ));
            double qDeg = RadToDeg(qRad);

            if ((feld32 - feld23) > 0)
                l1 = Math.Sqrt((feld11 - cosQ) / (1 - cosQ));
            else
            {
                if (cosQ == 1)
                    l1 = 0;
                else
                    l1 = -1 * Math.Sqrt((feld11 - cosQ) / (1 - cosQ));
            }
            if ((feld13 - feld31) > 0)
                m1 = Math.Sqrt((feld22 - cosQ) / (1 - cosQ));
            else
            {
                if (cosQ == 1)
                    m1 = 0;
                else
                    m1 = -1 * Math.Sqrt((feld22 - cosQ) / (1 - cosQ));
            }
            if ((feld21 - feld12) > 0)
                n1 = Math.Sqrt((feld33 - cosQ) / (1 - cosQ));
            else
            {
                if (cosQ == 1)
                    n1 = 0;
                else
                    n1 = -1 * Math.Sqrt((feld33 - cosQ) / (1 - cosQ));
            }
            if (Math.Abs(l1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                l = l1;
            else
            {
                if (Math.Abs(m1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                    l = (feld21 + feld12) / (2 * m1 * (1 - cosQ));
                else
                    l = (feld31 + feld13) / (2 * n1 * (1 - cosQ));
            }
            if (Math.Abs(m1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                m = m1;
            else
            {
                if (Math.Abs(l1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                    m = (feld21 + feld12) / (2 * l1 * (1 - cosQ));
                else
                    m = (feld32 + feld23) / (2 * n1 * (1 - cosQ));
            }
            if (Math.Abs(n1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                n = n1;
            else
            {
                if (Math.Abs(l1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                    n = (feld31 + feld13) / (2 * l1 * (1 - cosQ));
                else
                    n = (feld32 + feld23) / (2 * m1 * (1 - cosQ));
            }
            AAngle = RadToDeg(Math.Atan2(feld21, feld11));
            BAngle = RadToDeg(Math.Atan2(-feld31, feld11 * Math.Cos(Math.Atan2(feld21, feld11))
                    + feld21 * Math.Sin(Math.Atan2(feld21, feld11))));
            CAngle = RadToDeg(Math.Atan2(feld13 * Math.Sin(Math.Atan2(feld21, feld11))
                    - feld23 * Math.Cos(Math.Atan2(feld21, feld11))
                    , feld22 * Math.Cos(Math.Atan2(feld21, feld11))
                    - feld12 * Math.Sin(Math.Atan2(feld21, feld11))));
            StatusCf1 = abbLocation.Cf1Value;
            TurnCf4 = abbLocation.Cf4Value;
            Cf6 = abbLocation.Cf6Value;
            Cfx = abbLocation.CfXValue;
            E1Value = abbLocation.E1Value;
            E2Value = abbLocation.E2Value;
            E3Value = abbLocation.E3Value;
            E4Value = abbLocation.E4Value;
            E5Value = abbLocation.E5Value;
            E6Value = abbLocation.E6Value;
        }

        public KukaLocation(MatrixLocation matrixLocation)
        {
            Name = matrixLocation.Name;
            Type = matrixLocation.Type;
            XCoordinate = matrixLocation.Feld14;
            YCoordinate = matrixLocation.Feld24;
            ZCoordinate = matrixLocation.Feld34;
            AAngle = MatrixLocation.RadToDeg(Math.Atan2(matrixLocation.Feld21, matrixLocation.Feld11));
            BAngle = MatrixLocation.RadToDeg
                (-Math.Atan2(matrixLocation.Feld31, (matrixLocation.Feld11 * Math.Cos(Math.Atan2(matrixLocation.Feld21, matrixLocation.Feld11))
                + matrixLocation.Feld21 * Math.Sin(Math.Atan2(matrixLocation.Feld21, matrixLocation.Feld11)))
                ));
            CAngle = MatrixLocation.RadToDeg
                (Math.Atan2(matrixLocation.Feld13 * Math.Sin(Math.Atan2(matrixLocation.Feld21, matrixLocation.Feld11))
                - matrixLocation.Feld23 * Math.Cos(Math.Atan2(matrixLocation.Feld21, matrixLocation.Feld11))
                , matrixLocation.Feld22 * Math.Cos(Math.Atan2(matrixLocation.Feld21, matrixLocation.Feld11))
                - matrixLocation.Feld12 * Math.Sin(Math.Atan2(matrixLocation.Feld21, matrixLocation.Feld11))
                ));
            StatusCf1 = matrixLocation.Status;
            TurnCf4 = matrixLocation.Turn;
            E1Value = matrixLocation.E1Value;
            E2Value = matrixLocation.E2Value;
            E3Value = matrixLocation.E3Value;
            E4Value = matrixLocation.E4Value;
            E5Value = matrixLocation.E5Value;
            E6Value = matrixLocation.E6Value;
        }

        //Methode zum sortieren der .dat Datei
        public static void DAT_Sort()
        {
            //leeren der benötigten Listen
            KUKA_Header.Clear();
            KUKA_Sorted.Clear();
            LocationsAktuellString.Clear();
            SortLocationsE6POS.Clear();
            SortLocationsMisc.Clear();
            SortLocationsVW.Clear();
            SortLocationsFDAT.Clear();
            SortLocationsPLDAT.Clear();
            try
            {
                StreamReader dateiReader;
                dateiReader = File.OpenText(KukaFilePage.DateiOrtDat);


                string zeile = "";

                //einlesen der kompletten Datei
                while (dateiReader.Peek() != -1) //Solange bis Dateiende erreicht
                {

                    zeile = dateiReader.ReadLine(); // Zeile lesen
                    LocationsAktuellString.Add(zeile);
                    //Wenn in der Zeile keine Deklaration einer Variablen stattfindet
                    if (!zeile.CaseInsensitiveContains("DECL "))
                        KUKA_Header.Add(zeile);

                    //Wenn in der Zeile eine Deklaration einer Variablen stattfindet
                    if (zeile.Contains("DECL "))
                    {
                        //sonstige Deklarationen
                        if (!zeile.CaseInsensitiveContains("E6POS") && !zeile.CaseInsensitiveContains("VW") &&
                            !zeile.CaseInsensitiveContains("FDAT") && !zeile.CaseInsensitiveContains("PDAT") &&
                            !zeile.CaseInsensitiveContains("LDAT"))
                            SortLocationsMisc.Add(zeile);

                        //E6POS Deklarationen
                        if (zeile.CaseInsensitiveContains("E6POS"))
                            SortLocationsE6POS.Add(zeile);

                        //VW Deklartionen
                        if (zeile.CaseInsensitiveContains("VW"))
                            SortLocationsVW.Add(zeile);

                        //FDAT Deklarationen
                        if (zeile.CaseInsensitiveContains("FDAT"))
                            SortLocationsFDAT.Add(zeile);

                        //PDAT oder LDAT Deklarationen
                        if (zeile.CaseInsensitiveContains("PDAT") || zeile.CaseInsensitiveContains("LDAT"))
                            SortLocationsPLDAT.Add(zeile);

                    }
                }
                //Zusammenfügen der Listen zu einer "sortierten" Liste
                if (KUKA_Header.Any())
                {
                    KUKA_Sorted.InsertRange(0, KUKA_Header);

                    //Jeder separate Liste wird vor die ENDDAT Zeile eingefügt
                    if (SortLocationsMisc.Any())
                    {
                        //SortLocationsMisc.Sort();
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------Misc------------");
                        KUKA_Sorted.InsertRange(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , SortLocationsMisc);
                    }

                    if (SortLocationsE6POS.Any())
                    {
                        //SortLocationsE6POS.Sort();
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------E6POS------------");
                        KUKA_Sorted.InsertRange(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , SortLocationsE6POS);
                    }

                    if (SortLocationsVW.Any())
                    {
                        //SortLocationsVW.Sort();
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------VW_PARAMETER------------");
                        KUKA_Sorted.InsertRange(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , SortLocationsVW);
                    }

                    if (SortLocationsFDAT.Any())
                    {
                        //SortLocationsFDAT.Sort();
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------FDAT------------");
                        KUKA_Sorted.InsertRange(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , SortLocationsFDAT);
                    }

                    if (SortLocationsPLDAT.Any())
                    {
                        //SortLocationsPLDAT.Sort();
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------P/L_DAT------------");
                        KUKA_Sorted.InsertRange(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , SortLocationsPLDAT);
                    }
                }
                dateiReader.Close();

                //Überprüfen, ob die "sortierte" Liste den selben Inhalt wie die "unsortierte" Liste hat
                bool listequals = true;
                foreach (var line in LocationsAktuellString)
                {
                    if (!KUKA_Sorted.Contains(line))
                    {
                        listequals = false;
                        throw new ArgumentException("Die sortierte Datei ist ungleich der originalen!");
                    }

                }

                //Wenn die Listen den selben Inhalt haben, wird die originale Datei mit der sortierten Überschrieben
                if (listequals == true && KUKA_Sorted.Any())
                {
                    File.WriteAllLines(KukaFilePage.DateiOrtDat, KUKA_Sorted);

                    InfoBox finish = new InfoBox();
                    finish.Owner = Application.Current.MainWindow;
                    finish.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    finish.InfoBox_Text.Content = "Datei wurde sortiert " + KukaFilePage.DateiOrtDat;
                    finish.OK_Button.Visibility = Visibility.Visible;
                    finish.Abbruch_Button.Visibility = Visibility.Hidden;
                    finish.Manual_Button.Visibility = Visibility.Hidden;
                    finish.Show();
                }
            }
            //Ansonsten wird ein Hinweis herausgeben, dass die Dateien unterschiedlich sind
            catch (ArgumentException)
            {
                InfoBox error = new InfoBox();
                error.Owner = Application.Current.MainWindow;
                error.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                error.InfoBox_Text.Content = "Die sortierte Datei ist ungleich der originalen!";
                error.OK_Button.Visibility = Visibility.Visible;
                error.Abbruch_Button.Visibility = Visibility.Hidden;
                error.Manual_Button.Visibility = Visibility.Hidden;
                error.Show();

                return;

            }
            catch (FileNotFoundException)
            {
                InfoBox error = new InfoBox();
                error.Owner = Application.Current.MainWindow;
                error.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                error.InfoBox_Text.Content = "Datei wurde nicht gefunden: " + KukaFilePage.DateiOrtSrc + "!\n" +
                                          "Die .dat konnte nicht sortiert werden!";
                error.OK_Button.Visibility = Visibility.Visible;
                error.Abbruch_Button.Visibility = Visibility.Hidden;
                error.Manual_Button.Visibility = Visibility.Hidden;
                error.Show();

                return;

            }

        }

        //Methode zum sortieren der .dat Datei
        public static void DAT_SortTo_Src()
        {
            //leeren der benötigten Listen
            KUKA_Header.Clear();
            KUKA_Sorted.Clear();
            LocationsAktuellString.Clear();
            SortLocationsE6POS.Clear();
            SortLocationsMisc.Clear();
            SortLocationsVW.Clear();
            SortLocationsFDAT.Clear();
            SortLocationsPLDAT.Clear();
            SortLocationsFromSrc.Clear();
            try
            {
                StreamReader dateiReader;
                dateiReader = File.OpenText(KukaFilePage.DateiOrtDat);


                string zeile = "";

                //einlesen der kompletten Datei
                while (dateiReader.Peek() != -1) //Solange bis Dateiende erreicht
                {

                    zeile = dateiReader.ReadLine(); // Zeile lesen
                    if (!string.IsNullOrWhiteSpace(zeile))
                    {
                        LocationsAktuellString.Add(zeile);
                        //Wenn in der Zeile keine Deklaration einer Variablen stattfindet
                        if (!zeile.CaseInsensitiveContains("DECL "))
                            KUKA_Header.Add(zeile);

                        //Wenn in der Zeile eine Deklaration einer Variablen stattfindet
                        if (zeile.Contains("DECL "))
                        {
                            //sonstige Deklarationen
                            SortLocationsMisc.Add(zeile);

                        }
                    }
                }

                KukaLocation.Bereinigen_Read();
                string DateiOrtBak = KukaFilePage.DateiOrtDat.Replace(".dat", ".bak");
                foreach (string name in KukaLocation.DatInNames)
                {
                    
                    foreach (var line in KukaLocation.SrcInLines)
                    {
                        String[] split = line.Split(' ', '=');
                        foreach (var x in split)
                        {
                            if (x.Equals(name) && !KukaLocation.ExistingNames.Contains(name))
                            {
                                KukaLocation.ExistingNames.Add(name);
                                goto nextline;
                            }
                        }
                    }
                nextline:;
                }
                foreach (var name in KukaLocation.ExistingNames)
                {
                    foreach (string line in SortLocationsMisc)
                    {
                        string[] split = line.Split(' ', '=');
                        foreach (var x in split)
                        {
                            if ((x.Equals(name) && !SortLocationsFromSrc.Contains(line)) || 
                                (x.Equals("SUCCESS") && !SortLocationsFromSrc.Contains("DECL INT SUCCESS")))
                            {
                                SortLocationsFromSrc.Add(line);

                                if (!x.Equals("SUCCESS"))
                                goto nextline;
                            }
                        }
                    }
                nextline:;
                }

                //Zusammenfügen der Listen zu einer "sortierten" Liste
                if (KUKA_Header.Any())
                {
                    KUKA_Sorted.InsertRange(0, KUKA_Header);

                    //Jeder separate Liste wird vor die ENDDAT Zeile eingefügt
                    if (SortLocationsFromSrc.Any())
                    {
                        //SortLocationsMisc.Sort();
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------Sorted from Src------------");
                        KUKA_Sorted.InsertRange(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , SortLocationsFromSrc);
                    }

                }
                SortLocationsE6POS.Clear();
                SortLocationsFRAME.Clear();
                SortLocationsMisc.Clear();
                SortLocationsVW.Clear();
                SortLocationsFDAT.Clear();
                SortLocationsPLDAT.Clear();
                //Wenn in der Zeile eine Deklaration einer Variablen stattfindet
                foreach (var zeil in SortLocationsFromSrc)
                {
                    if (zeil.Contains("DECL "))
                    {
                        //sonstige Deklarationen
                        if (!zeil.CaseInsensitiveContains("E6POS") && !zeil.CaseInsensitiveContains("VW") &&
                            !zeil.CaseInsensitiveContains("FDAT") && !zeil.CaseInsensitiveContains("PDAT") &&
                            !zeil.CaseInsensitiveContains("LDAT") && !zeil.CaseInsensitiveContains("DECL FRAME"))
                            SortLocationsMisc.Add(zeil);

                        //E6POS Deklarationen
                        if (zeil.CaseInsensitiveContains("E6POS"))
                            SortLocationsE6POS.Add(zeil);

                        //FRAME Deklarationen
                        if (zeil.CaseInsensitiveContains("DECL FRAME"))
                            SortLocationsFRAME.Add(zeil);

                        //VW Deklartionen
                        if (zeil.CaseInsensitiveContains("VW"))
                            SortLocationsVW.Add(zeil);

                        //FDAT Deklarationen
                        if (zeil.CaseInsensitiveContains("FDAT"))
                            SortLocationsFDAT.Add(zeil);

                        //PDAT oder LDAT Deklarationen
                        if (zeil.CaseInsensitiveContains("PDAT") || zeil.CaseInsensitiveContains("LDAT"))
                            SortLocationsPLDAT.Add(zeil);

                    }
                }
                KUKA_Sorted.Clear();
                KUKA_Header_clean.Clear();
                //Zusammenfügen der Listen zu einer "sortierten" Liste
                if (KUKA_Header.Any())
                {
                    foreach (string lzeile in KUKA_Header)
                    {
                        if (!lzeile.StartsWith(";s") && (!lzeile.StartsWith(";-")) && (!lzeile.StartsWith(";AE")) && (!lzeile.StartsWith(";CO"))
                            && (!lzeile.StartsWith(";PR")) && (!lzeile.StartsWith(";ES")) && (!lzeile.StartsWith(";SS")) && (!lzeile.StartsWith(";#-")))
                        {
                            KUKA_Header_clean.Add(lzeile);
                        }
                    }
                    KUKA_Sorted.InsertRange(0, KUKA_Header_clean);

                    //Jeder separate Liste wird vor die ENDDAT Zeile eingefügt
                    if (SortLocationsMisc.Any())
                    {
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------Misc------------");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        KUKA_Sorted.InsertRange(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , SortLocationsMisc);
                    }

                    if (SortLocationsE6POS.Any())
                    {
                        string name = "";
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------E6POS------------");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        foreach (string line in SortLocationsE6POS)
                        {
                            string[] split;
                            split = line.Split('_','=');
                            foreach (string x in split)
                            {
                                if ((Regex.IsMatch(x,@"s\d\dr\d\d") || (Regex.IsMatch(x, @"(?i)ak\d\d")) || (Regex.IsMatch(x, @"(?i)s\d\d"))) && !x.Equals(name) && !line.CaseInsensitiveContains("vorpos"))
                                {
                                    name = x;
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , "");
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , ";------------" + name + "------------");
                                    break;
                                }
                            }

                            KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                , line);
                        }
                    }

                    if (SortLocationsFRAME.Any())
                    {
                        string name = "";
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------FRAME------------");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        foreach (string line in SortLocationsFRAME)
                        {
                            string[] split;
                            split = line.Split('_', '=');
                            foreach (string x in split)
                            {
                                if ((Regex.IsMatch(x, @"s\d\dr\d\d") || (Regex.IsMatch(x, @"(?i)ak\d\d")) || (Regex.IsMatch(x, @"(?i)s\d\d"))) && !x.Equals(name) && !line.CaseInsensitiveContains("vorpos"))
                                {
                                    name = x;
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , "");
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , ";------------" + name + "------------");
                                    break;
                                }
                            }

                            KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                , line);
                        }
                    }

                    if (SortLocationsVW.Any())
                    {
                        string name = "";
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------VW_PARAMETER------------");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        foreach (string line in SortLocationsVW)
                        {
                            string[] split;
                            split = line.Split('_','=');
                            foreach (string x in split)
                            {
                                if ((Regex.IsMatch(x, @"s\d\dr\d\d") || (Regex.IsMatch(x, @"(?i)ak\d\d")) || (Regex.IsMatch(x, @"(?i)s\d\d"))) && !x.Equals(name) && !line.CaseInsensitiveContains("vorpos"))
                                {
                                    name = x;
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , "");
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , ";------------" + name + "------------");
                                    break;
                                }
                            }

                            KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , line);
                        }
                    }

                    if (SortLocationsFDAT.Any())
                    {
                        string name = "";
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------FDAT------------");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        foreach (string line in SortLocationsFDAT)
                        {
                            string[] split;
                            split = line.Split('_','=');
                            foreach (string x in split)
                            {
                                if ((Regex.IsMatch(x, @"s\d\dr\d\d") || (Regex.IsMatch(x, @"(?i)ak\d\d")) || (Regex.IsMatch(x, @"(?i)s\d\d"))) && !x.Equals(name) && !line.CaseInsensitiveContains("vorpos"))
                                {
                                    name = x;
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , "");
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , ";------------" + name + "------------");
                                    break;
                                }
                            }

                            KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , line);
                        }
                    }

                    if (SortLocationsPLDAT.Any())
                    {
                        string name = "";
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , ";------------P/L_DAT------------");
                        KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , "");
                        foreach (string line in SortLocationsPLDAT)
                        {
                            string[] split;
                            split = line.Split('_','=');
                            foreach (string x in split)
                            {
                                if ((Regex.IsMatch(x, @"s\d\dr\d\d") || (Regex.IsMatch(x, @"(?i)ak\d\d")) || (Regex.IsMatch(x, @"(?i)s\d\d"))) && !x.Equals(name) && !line.CaseInsensitiveContains("vorpos"))
                                {
                                    name = x;
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , "");
                                    KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                                        (y => y.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                                        , ";------------" + name + "------------");
                                    break;
                                }
                            }

                            KUKA_Sorted.Insert(KUKA_Sorted.FindIndex
                            (x => x.Equals("ENDDAT", StringComparison.CurrentCultureIgnoreCase))
                            , line);
                        }
                    }
                }
            dateiReader.Close();

                //Überprüfen, ob die "sortierte" Liste den selben Inhalt wie die "unsortierte" Liste hat
                bool listequals = true;
                foreach (var line in LocationsAktuellString)
                {
                    if (!line.CaseInsensitiveContains(";s") && (!line.CaseInsensitiveContains(";-")) && (!line.StartsWith(";AE")) && (!line.StartsWith(";CO"))
                            && (!line.StartsWith(";PR")) && (!line.StartsWith(";ES")) && (!line.StartsWith(";SS")) && (!line.StartsWith(";#-")))
                    {
                        if (!KUKA_Sorted.Contains(line))
                        {
                            listequals = false;
                            throw new ArgumentException("Die sortierte Datei ist ungleich der originalen!");
                        }
                    }
                }

                //Wenn die Listen den selben Inhalt haben, wird die originale Datei mit der sortierten Überschrieben
                if (listequals == true && KUKA_Sorted.Any())
                {
                    File.WriteAllLines(KukaFilePage.DateiOrtDat, KUKA_Sorted);

                    InfoBox finish = new InfoBox();
                    finish.Owner = Application.Current.MainWindow;
                    finish.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    finish.InfoBox_Text.Content = "Datei wurde sortiert " + KukaFilePage.DateiOrtDat;
                    finish.OK_Button.Visibility = Visibility.Visible;
                    finish.Abbruch_Button.Visibility = Visibility.Hidden;
                    finish.Manual_Button.Visibility = Visibility.Hidden;
                    if (KukaFilePage.SpezialAblauf)
                    {

                    }
                    else
                    {
                        finish.ShowDialog();
                    }
                }
            }
            //Ansonsten wird ein Hinweis herausgeben, dass die Dateien unterschiedlich sind
            catch (ArgumentException)
            {
                InfoBox error = new InfoBox();
                error.Owner = Application.Current.MainWindow;
                error.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                error.InfoBox_Text.Content = "Die sortierte Datei ist ungleich der originalen!";
                error.OK_Button.Visibility = Visibility.Hidden;
                error.Abbruch_Button.Visibility = Visibility.Visible;
                error.Manual_Button.Visibility = Visibility.Hidden;
                error.ShowDialog();

                return;

            }
            catch (FileNotFoundException)
            {
                InfoBox error = new InfoBox();
                error.Owner = Application.Current.MainWindow;
                error.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                error.InfoBox_Text.Content = "Datei wurde nicht gefunden: " + KukaFilePage.DateiOrtSrc + "!\n" +
                                          "Die .dat konnte nicht sortiert werden!";
                error.OK_Button.Visibility = Visibility.Hidden;
                error.Abbruch_Button.Visibility = Visibility.Visible;
                error.Manual_Button.Visibility = Visibility.Hidden;
                error.ShowDialog();

                return;

            }

        }

        //Methode zum aufsplitten der Deklarationen von E6POS "Strings" in abfragbare und
        // bearbeitbare Werte z.B. Dezimal usw.
        public static void LocationSplit()
        {
            StreamReader datei;
            datei = File.OpenText(KukaFilePage.DateiOrtDat);
            string zeile = "";
            string[] felder;
            string[] name;
            Double XCoordinate;
            Double YCoordinate;
            Double ZCoordinate;
            Double AAngle;
            Double BAngle;
            Double CAngle;
            int Status;
            int Turn;
            Double E1Value;
            Double E2Value;
            Double E3Value;
            Double E4Value;
            Double E5Value;
            Double E6Value;

            while (datei.Peek() != -1) //Solange bis Dateiende erreicht
            {
                zeile = datei.ReadLine(); // Zeile lesen

                //finden von Deklarationen von E6POS
                if (zeile.CaseInsensitiveContains("DECL E6POS") || zeile.CaseInsensitiveContains("DECL FRAME"))
                {

                    felder = zeile.Split(new char[] { '{', ',', '}', '=' }); // Zeile an "Chars" aufbrechen

                    //Ausplitten für den Namen der Location
                    name = felder[0].Split(new char[] { ' ' });

                    // Aufgesplitte Zeile Zuweisen und in Dezimal umwandeln

                    string[] XCoordinateDec = Regex.Split(felder[2], @"[^-?\d*\.{0,1}\d+$]")                                    //Nur Zahlen
                        .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                    XCoordinate = Convert.ToDouble(XCoordinateDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });//Sting in Double konvertieren
                    string[] YCoordinateDec = Regex.Split(felder[3], @"[^-?\d*\.{0,1}\d+$]")                                    //Nur Zahlen
                        .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                    YCoordinate = Convert.ToDouble(YCoordinateDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });//Sting in Double konvertieren
                    string[] ZCoordinateDec = Regex.Split(felder[4], @"[^-?\d*\.{0,1}\d+$]")                                    //Nur Zahlen
                        .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                    ZCoordinate = Convert.ToDouble(ZCoordinateDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });//Sting in Double konvertieren
                    string[] AAngleDec = Regex.Split(felder[5], @"[^-?\d*\.{0,1}\d+$]")                                         //Nur Zahlen
                        .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                    AAngle = Convert.ToDouble(AAngleDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });          //Sting in Double konvertieren
                    string[] BAngleDec = Regex.Split(felder[6], @"[^-?\d*\.{0,1}\d+$]")                                         //Nur Zahlen
                        .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                    BAngle = Convert.ToDouble(BAngleDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });          //Sting in Double konvertieren
                    string[] CAngleDec = Regex.Split(felder[7], @"[^-?\d*\.{0,1}\d+$]")                                         //Nur Zahlen
                        .Where(c => c != "." && c.Trim() != "").ToArray();                                                      //Leerzeichen entfernen
                    CAngle = Convert.ToDouble(CAngleDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });          //Sting in Double konvertieren

                    // IF Anweisung, wenn in felder[8] nicht der Status definiert ist.
                    if (felder[8].CaseInsensitiveContains("s") && !zeile.CaseInsensitiveContains("DECL FRAME"))
                    {
                        try
                        {
                            string[] StatusDec = Regex.Split(felder[8], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                         //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            Status = Convert.ToInt16(StatusDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });            //Sting in Double konvertieren
                        }
                        catch
                        {
                            Status = 0;
                        }
                        try
                        {
                            string[] TurnDec = Regex.Split(felder[9], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                           //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            Turn = Convert.ToInt16(TurnDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });                //Sting in Double konvertieren
                        }
                        catch
                        {
                            Turn = 0;
                        }
                        try
                        {
                            string[] E1ValueDec = Regex.Split(felder[10], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                 //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E1Value = Convert.ToDouble(E1ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E1Value = 0;
                        }
                        try
                        {
                            string[] E2ValueDec = Regex.Split(felder[11], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E2Value = Convert.ToDouble(E2ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E2Value = 0;
                        }
                        try
                        {
                            string[] E3ValueDec = Regex.Split(felder[12], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E3Value = Convert.ToDouble(E3ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E3Value = 0;
                        }
                        try
                        {
                            string[] E4ValueDec = Regex.Split(felder[13], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E4Value = Convert.ToDouble(E4ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E4Value = 0;
                        }
                        try
                        {
                            string[] E5ValueDec = Regex.Split(felder[14], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E5Value = Convert.ToDouble(E5ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E5Value = 0;
                        }
                        try
                        {
                            string[] E6ValueDec = Regex.Split(felder[15], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E6Value = Convert.ToDouble(E6ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E6Value = 0;
                        }
                    }
                    else
                    {
                        Status = 99;
                        Turn = 99;
                        try
                        {
                            string[] E1ValueDec = Regex.Split(felder[8], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                 //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E1Value = Convert.ToDouble(E1ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E1Value = 0;
                        }
                        try
                        {
                            string[] E2ValueDec = Regex.Split(felder[9], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E2Value = Convert.ToDouble(E2ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E2Value = 0;
                        }
                        try
                        {
                            string[] E3ValueDec = Regex.Split(felder[10], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E3Value = Convert.ToDouble(E3ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E3Value = 0;
                        }
                        try
                        {
                            string[] E4ValueDec = Regex.Split(felder[11], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E4Value = Convert.ToDouble(E4ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E4Value = 0;
                        }
                        try
                        {
                            string[] E5ValueDec = Regex.Split(felder[12], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E5Value = Convert.ToDouble(E5ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E5Value = 0;
                        }
                        try
                        {
                            string[] E6ValueDec = Regex.Split(felder[13], @"[^-?\d*\.{0,1}\d+$(?:E)]")                                  //Nur Zahlen
                                .Where(c => c != "." && c != "E1" && c != "E2" && c != "E3" && c != "E4" && c != "E5"                  //Leerzeichen entfernen
                                && c != "E6" && c.Trim() != "").ToArray();                                                             //Leerzeichen entfernen
                            E6Value = Convert.ToDouble(E6ValueDec[0], new NumberFormatInfo() { NumberDecimalSeparator = "." });        //Sting in Double konvertieren
                        }
                        catch
                        {
                            E6Value = 0;
                        }
                    }

                    if (Misc.CaseInsensitiveContains(zeile, "global"))
                        KukaLocationsAktuell.Add(new KukaLocation(name[2], name[3], XCoordinate, YCoordinate, ZCoordinate
                                , AAngle, BAngle, CAngle, Status, Turn, E1Value, E2Value, E3Value, E4Value, E5Value, E6Value));
                    else
                        //E6POS Deklarationen in Location Objecte umwandeln unt in einer Liste speichern
                        KukaLocationsAktuell.Add(new KukaLocation(name[1], name[2], XCoordinate, YCoordinate, ZCoordinate
                                    , AAngle, BAngle, CAngle, Status, Turn, E1Value, E2Value, E3Value, E4Value, E5Value, E6Value));
                }
            }

            Console.WriteLine("Datei wurde eingelesen von: {0}", KukaFilePage.DateiOrtDat);
            datei.Close();
        }

        //Methode zum aufsplitten der Deklarationen von E6POS "Strings" in abfragbare und
        // bearbeitbare Werte z.B. Dezimal usw.
        public static void Bereinigen_Read()
        {

            try
            {
                SrcInLines.Clear();
                DatInNames.Clear();
                DatInLines.Clear();
                StreamReader src;
                StreamReader dat;
                src = File.OpenText(KukaFilePage.DateiOrtSrc);
                dat = File.OpenText(KukaFilePage.DateiOrtDat);
                SrcInLines.Clear();
                string zeile = "";
                string[] felder;
                string[] name;

                while (src.Peek() != -1) //Solange bis Dateiende erreicht
                {
                    zeile = src.ReadLine(); // Zeile lesen

                    //E6POS Deklarationen in Location Objecte umwandeln unt in einer Liste speichern
                    SrcInLines.Add(zeile);
                }

                while (dat.Peek() != -1) //Solange bis Dateiende erreicht
                {
                    zeile = dat.ReadLine(); // Zeile lesen

                    DatInLines.Add(zeile);

                    //finden von Deklarationen von E6POS
                    if (zeile.CaseInsensitiveContains("DECL "))
                    {

                        felder = zeile.Split(new char[] { '{', ',', '}', '=' }); // Zeile an "Chars" aufbrechen

                        //Ausplitten für den Namen der Location
                        name = felder[0].Split(new char[] { ' ' });

                        if (Misc.CaseInsensitiveContains(zeile, "global"))
                            DatInNames.Add(name[3]);
                        else
                            //E6POS Deklarationen in Location Objecte umwandeln und in einer Liste speichern
                            DatInNames.Add(name[2]);
                    }
                }

                src.Close();
                dat.Close();
            }
            catch(FileNotFoundException)
            {
                InfoBox error = new InfoBox();
                error.Owner = Application.Current.MainWindow;
                error.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                error.InfoBox_Text.Content = "Datei wurde nicht gefunden: " + KukaFilePage.DateiOrtSrc + "!\n" +
                                          "Die .dat konnte nicht bereinigt werden!";
                error.OK_Button.Visibility = Visibility.Visible;
                error.Abbruch_Button.Visibility = Visibility.Hidden;
                error.Manual_Button.Visibility = Visibility.Hidden;
                error.Show();

                return;

            }
            catch (ArgumentNullException)
            {
                InfoBox error = new InfoBox();
                error.Owner = Application.Current.MainWindow;
                error.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                error.InfoBox_Text.Content = "Datei wurde nicht gefunden: " + KukaFilePage.DateiOrtSrc + "!\n" +
                                          "Die .dat konnte nicht bereinigt werden!";
                error.OK_Button.Visibility = Visibility.Visible;
                error.Abbruch_Button.Visibility = Visibility.Hidden;
                error.Manual_Button.Visibility = Visibility.Hidden;
                error.Show();

                return;

            }
        }

        //Methode zum umwandeln von Location Objecten zu fertigen E6POS "Strings"
        //List<location> wird zu List<string>
        public static void KukaListeToFile(List<KukaLocation> kukaLocation)
        {
            LocationsAktuellString.Clear();
            foreach (var n in kukaLocation)
            {
                LocationsAktuellString.Add(String.Format(new NumberFormatInfo() { NumberDecimalSeparator = "." }
                , "DECL {0} {1}={{X {2},Y {3},Z {4},A {5},B {6},C {7},S {8},T {9},E1 {10},E2 {11},E3 {12},E4 {13},E5 {14},E6 {15}}}"
                        , n.Type, n.Name
                        , n.XCoordinate.ToString("0.#########").Replace(',', '.'), n.YCoordinate.ToString("0.#########").Replace(',', '.')
                        , n.ZCoordinate.ToString("0.#########").Replace(',', '.')
                        , n.AAngle.ToString("0.#########").Replace(',', '.'), n.BAngle.ToString("0.#########").Replace(',', '.')
                        , n.CAngle.ToString("0.#########").Replace(',', '.')
                        , n.StatusCf1, n.TurnCf4
                        , n.E1Value.ToString("0.#########").Replace(',', '.'), n.E2Value.ToString("0.#########").Replace(',', '.')
                        , n.E3Value.ToString("0.#########").Replace(',', '.')
                        , n.E4Value.ToString("0.#########").Replace(',', '.'), n.E5Value.ToString("0.#########").Replace(',', '.')
                        , n.E6Value.ToString("0.#########").Replace(',', '.')));
            }
        }

        public static void SortQuestion()
        {
            // Konfiguration der DialogBox
            InfoBox sortieren = new InfoBox();
            sortieren.Owner = Application.Current.MainWindow;
            sortieren.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sortieren.InfoBox_Text.Content = "Soll die Datei vorher nach Variablenart sortiert werden?\n" +
                                             "Die Original-Datei wird auf gleichheit geprüft \n" +
                                             "und danach überschrieben!\n" +
                                             "Diese Funktion bitte mit Vorsicht benutzen!";
            sortieren.OK_Button.Visibility = Visibility.Visible;
            sortieren.Abbruch_Button.Visibility = Visibility.Visible;
            sortieren.Manual_Button.Visibility = Visibility.Hidden;
            if (KukaFilePage.SpezialAblauf)
            {

            }
            else
            {
                sortieren.ShowDialog();
            }

            // Verarbeiten des Dialoges

            if (sortieren.OK || KukaFilePage.SpezialAblauf)
            { 
                //DAT_Sort();
                DAT_SortTo_Src();
            }

            if (sortieren.Abbruch)
            {
                InfoBox finish = new InfoBox();
                finish.Owner = Application.Current.MainWindow;
                finish.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                finish.InfoBox_Text.Content = "Sortierung wurde abgebrochen";
                finish.OK_Button.Visibility = Visibility.Visible;
                finish.Abbruch_Button.Visibility = Visibility.Hidden;
                finish.Manual_Button.Visibility = Visibility.Hidden;
                finish.ShowDialog();
            }

        }

    }
}
