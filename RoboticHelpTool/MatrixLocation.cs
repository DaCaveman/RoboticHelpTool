using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticHelpTool
{
    public class MatrixLocation : Operation
    {
        //--------------Eigenschaftsmethoden---------------

        //Deklaration der benötigten Listen
        public static List<KukaLocation> KukaLocationsAktuell = new List<KukaLocation>();
        public static List<MatrixLocation> MatrixLocationsAktuell = new List<MatrixLocation>();
        public static List<String> LocationsAktuellString = new List<String>();
        public static MatrixLocation MirrorOverX = new MatrixLocation("MatrixLocation", "MirrorOverX"
                                                , 1.0, 0.0, 0.0,  0.0
                                                , 0.0, -1.0, 0.0,  0.0
                                                , 0.0, 0.0, 1.0,  0.0
                                                , 0.0, 0.0, 0.0,  1.0
                                                , 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

        public static MatrixLocation MirrorOverZ = new MatrixLocation("MatrixLocation", "MirrorOverZ"
                                                , Math.Cos(45), -Math.Sin(45), 0.0, 0.0
                                                , Math.Sin(45), Math.Cos(45), 0.0, 0.0
                                                , 0.0, 0.0, 1.0, 0.0
                                                , 0.0, 0.0, 0.0, 1.0
                                                , 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

        protected string _Type;
        protected string _Name;
        protected double _Feld11;
        protected double _Feld12;
        protected double _Feld13;
        protected double _Feld14;
        protected double _Feld21;
        protected double _Feld22;
        protected double _Feld23;
        protected double _Feld24;
        protected double _Feld31;
        protected double _Feld32;
        protected double _Feld33;
        protected double _Feld34;
        protected double _Feld41;
        protected double _Feld42;
        protected double _Feld43;
        protected double _Feld44;
        protected int _Status;
        protected int _Turn;
        protected int _Cf1;
        protected int _Cf4;
        protected int _Cf6;
        protected int _CfX;
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
        public virtual double Feld11
        {
            get { return _Feld11; }
            set { _Feld11 = value; }
        }
        public virtual double Feld12
        {
            get { return _Feld12; }
            set { _Feld12 = value; }
        }
        public virtual double Feld13
        {
            get { return _Feld13; }
            set { _Feld13 = value; }
        }
        public virtual double Feld14
        {
            get { return _Feld14; }
            set { _Feld14 = value; }
        }
        public virtual double Feld21
        {
            get { return _Feld21; }
            set { _Feld21 = value; }
        }
        public virtual double Feld22
        {
            get { return _Feld22; }
            set { _Feld22 = value; }
        }
        public virtual double Feld23
        {
            get { return _Feld23; }
            set { _Feld23 = value; }
        }
        public virtual double Feld24
        {
            get { return _Feld24; }
            set { _Feld24 = value; }
        }
        public virtual double Feld31
        {
            get { return _Feld31; }
            set { _Feld31 = value; }
        }
        public virtual double Feld32
        {
            get { return _Feld32; }
            set { _Feld32 = value; }
        }
        public virtual double Feld33
        {
            get { return _Feld33; }
            set { _Feld33 = value; }
        }
        public virtual double Feld34
        {
            get { return _Feld34; }
            set { _Feld34 = value; }
        }
        public virtual double Feld41
        {
            get { return _Feld41; }
            set { _Feld41 = value; }
        }
        public virtual double Feld42
        {
            get { return _Feld42; }
            set { _Feld42 = value; }
        }
        public virtual double Feld43
        {
            get { return _Feld43; }
            set { _Feld43 = value; }
        }
        public virtual double Feld44
        {
            get { return _Feld44; }
            set { _Feld44 = value; }
        }
        public virtual int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public virtual int Turn
        {
            get { return _Turn; }
            set { _Turn = value; }
        }
        public virtual int Cf1
        {
            get { return _Cf1; }
            set { _Cf1 = value; }
        }
        public virtual int Cf4
        {
            get { return _Cf4; }
            set { _Cf4 = value; }
        }
        public virtual int Cf6
        {
            get { return _Cf6; }
            set { _Cf6 = value; }
        }
        public virtual int CfX
        {
            get { return _CfX; }
            set { _CfX = value; }
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

        public MatrixLocation() : this("", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        {
        }

        public MatrixLocation(string type, string name
                            , double f11, double f12, double f13, double f14
                            , double f21, double f22, double f23, double f24
                            , double f31, double f32, double f33, double f34
                            , double f41, double f42, double f43, double f44)
            : this(type, name
                 , f11, f12, f13, f14
                 , f21, f22, f23, f24
                 , f31, f32, f33, f34
                 , f41, f42, f43, f44
                 , 0, 0, 0, 0, 0, 0)
        {
        }

        public MatrixLocation(string type, string name
                            , double f11, double f12, double f13, double f14
                            , double f21, double f22, double f23, double f24
                            , double f31, double f32, double f33, double f34
                            , double f41, double f42, double f43, double f44
                            , double e1Value, double e2Value, double e3Value
                            , double e4Value, double e5Value, double e6Value)
        {
            Type = Type;
            Name = name;
            Feld11 = f11;
            Feld12 = f12;
            Feld13 = f13;
            Feld14 = f14;
            Feld21 = f21;
            Feld22 = f22;
            Feld23 = f23;
            Feld24 = f24;
            Feld31 = f31;
            Feld32 = f32;
            Feld33 = f33;
            Feld34 = f34;
            Feld41 = f41;
            Feld42 = f42;
            Feld43 = f43;
            Feld44 = f44;
            E1Value = e1Value;
            E2Value = e2Value;
            E3Value = e3Value;
            E4Value = e4Value;
            E5Value = e5Value;
            E6Value = e6Value;
        }

        public MatrixLocation(KukaLocation kukaLocation)
        {
            Type = kukaLocation.Type;
            Name = kukaLocation.Name;
            Feld11 = Math.Cos(DegToRad(kukaLocation.AAngle)) * Math.Cos(DegToRad(kukaLocation.BAngle));
            Feld12 = Math.Cos(DegToRad(kukaLocation.AAngle)) * Math.Sin(DegToRad(kukaLocation.BAngle))
                     * Math.Sin(DegToRad(kukaLocation.CAngle))
                     - Math.Sin(DegToRad(kukaLocation.AAngle)) * Math.Cos(DegToRad(kukaLocation.CAngle));
            Feld13 = Math.Cos(DegToRad(kukaLocation.CAngle)) * Math.Sin(DegToRad(kukaLocation.BAngle))
                     * Math.Cos(DegToRad(kukaLocation.AAngle))
                     + Math.Sin(DegToRad(kukaLocation.CAngle)) * Math.Sin(DegToRad(kukaLocation.AAngle));
            Feld14 = kukaLocation.XCoordinate;
            Feld21 = Math.Sin(DegToRad(kukaLocation.AAngle)) * Math.Cos(DegToRad(kukaLocation.BAngle));
            Feld22 = Math.Sin(DegToRad(kukaLocation.AAngle)) * Math.Sin(DegToRad(kukaLocation.BAngle))
                     * Math.Sin(DegToRad(kukaLocation.CAngle))
                     + Math.Cos(DegToRad(kukaLocation.CAngle)) * Math.Cos(DegToRad(kukaLocation.AAngle));
            Feld23 = Math.Sin(DegToRad(kukaLocation.AAngle)) * Math.Sin(DegToRad(kukaLocation.BAngle))
                     * Math.Cos(DegToRad(kukaLocation.CAngle))
                     - Math.Cos(DegToRad(kukaLocation.AAngle)) * Math.Sin(DegToRad(kukaLocation.CAngle));
            Feld24 = kukaLocation.YCoordinate;
            Feld31 = -Math.Sin(DegToRad(kukaLocation.BAngle));
            Feld32 = Math.Cos(DegToRad(kukaLocation.BAngle)) * Math.Sin(DegToRad(kukaLocation.CAngle));
            Feld33 = Math.Cos(DegToRad(kukaLocation.BAngle)) * Math.Cos(DegToRad(kukaLocation.CAngle));
            Feld34 = kukaLocation.ZCoordinate;
            Feld41 = 0;
            Feld42 = 0;
            Feld43 = 0;
            Feld44 = 1;
            Status = kukaLocation.StatusCf1;
            Turn = kukaLocation.TurnCf4;
            E1Value = kukaLocation.E1Value;
            E2Value = kukaLocation.E2Value;
            E3Value = kukaLocation.E3Value;
            E4Value = kukaLocation.E4Value;
            E5Value = kukaLocation.E5Value;
            E6Value = kukaLocation.E6Value;
        }

        public MatrixLocation(ABBLocation abbLocation)                           
        {
            Type = abbLocation.Type;
            Name = abbLocation.Name;

            Feld11 = 1 - 2 * (abbLocation.Q3Value * abbLocation.Q3Value + abbLocation.Q4Value * abbLocation.Q4Value);
            Feld12 = 2 * (abbLocation.Q2Value * abbLocation.Q3Value - abbLocation.Q1Value * abbLocation.Q4Value);
            Feld13 = 2 * (abbLocation.Q2Value * abbLocation.Q4Value + abbLocation.Q1Value * abbLocation.Q3Value);
            Feld14 = abbLocation.XCoordinate;
            Feld21 = 2 * (abbLocation.Q2Value * abbLocation.Q3Value + abbLocation.Q1Value * abbLocation.Q4Value);
            Feld22 = 1 - 2 * (abbLocation.Q2Value * abbLocation.Q2Value + abbLocation.Q4Value * abbLocation.Q4Value);
            Feld23 = 2 * (abbLocation.Q3Value * abbLocation.Q4Value - abbLocation.Q1Value * abbLocation.Q2Value);
            Feld24 = abbLocation.YCoordinate;
            Feld31 = 2 * (abbLocation.Q2Value * abbLocation.Q4Value - abbLocation.Q1Value * abbLocation.Q3Value);
            Feld32 = 2 * (abbLocation.Q3Value * abbLocation.Q4Value + abbLocation.Q1Value * abbLocation.Q2Value);
            Feld33 = 1 - 2 * (abbLocation.Q2Value * abbLocation.Q2Value + abbLocation.Q3Value * abbLocation.Q3Value);
            Feld34 = abbLocation.ZCoordinate;
            Feld41 = 0;
            Feld42 = 0;
            Feld43 = 0;
            Feld44 = 1;
            Cf1 = abbLocation.Cf1Value;
            Cf4 = abbLocation.Cf4Value;
            Cf6 = abbLocation.Cf6Value;
            CfX = abbLocation.CfXValue;
            E1Value = abbLocation.E1Value;
            E2Value = abbLocation.E2Value;
            E3Value = abbLocation.E3Value;
            E4Value = abbLocation.E4Value;
            E5Value = abbLocation.E5Value;
            E6Value = abbLocation.E6Value;
        }

        //Methode zum umwandeln von Location Objecten zu fertigen E6POS "Strings"
        //List<location> wird zu List<string>
        public static void MatrixListeToFile()
        {
            LocationsAktuellString.Clear();
            foreach (var n in MatrixLocationsAktuell)
            {
                LocationsAktuellString.Add(String.Format(new NumberFormatInfo() { NumberDecimalSeparator = "." }
                , "{0} {1}" + Environment.NewLine +
                    "{2}|{3}|{4}|{5}" + Environment.NewLine +
                    "{6}|{7}|{8}|{9}" + Environment.NewLine +
                    "{10}|{11}|{12}|{13}" + Environment.NewLine +
                    "{14}|{15}|{16}|{17}" + Environment.NewLine
                        , n.Type, n.Name
                        , n.Feld11, n.Feld12, n.Feld13, n.Feld14
                        , n.Feld21, n.Feld22, n.Feld23, n.Feld24
                        , n.Feld31, n.Feld32, n.Feld33, n.Feld34
                        , n.Feld41, n.Feld42, n.Feld43, n.Feld44));
            }

        }

    }
}
