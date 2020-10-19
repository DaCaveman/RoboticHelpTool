using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (type == "robtarget")
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
            double l1;
            double m1;
            double n1;
            double l;
            double m;
            double n;


            Name = matrixLocation.Name;
            Type = matrixLocation.Type;
            XCoordinate = matrixLocation.Feld14;
            YCoordinate = matrixLocation.Feld24;
            ZCoordinate = matrixLocation.Feld34;

            double cosQ = (0.5) * (matrixLocation.Feld11 + matrixLocation.Feld22 + matrixLocation.Feld33 - 1);
            double tanQ = (Math.Sqrt(((matrixLocation.Feld32 - matrixLocation.Feld23) * (matrixLocation.Feld32 - matrixLocation.Feld23)) + ((matrixLocation.Feld13 - matrixLocation.Feld31) * (matrixLocation.Feld13 - matrixLocation.Feld31))
                    + ((matrixLocation.Feld21 - matrixLocation.Feld12) * (matrixLocation.Feld21 - matrixLocation.Feld12)))) / (matrixLocation.Feld11 + matrixLocation.Feld22 + matrixLocation.Feld33 - 1);
            double qRad = Math.Atan2(0.5 * Math.Sqrt((((matrixLocation.Feld32 - matrixLocation.Feld23) * (matrixLocation.Feld32 - matrixLocation.Feld23)) + ((matrixLocation.Feld13 - matrixLocation.Feld31) * (matrixLocation.Feld13 - matrixLocation.Feld31))
                    + ((matrixLocation.Feld21 - matrixLocation.Feld12) * (matrixLocation.Feld21 - matrixLocation.Feld12)))), (cosQ));
            double qDeg = RadToDeg(qRad);

            if ((matrixLocation.Feld32 - matrixLocation.Feld23) > 0)
                l1 = Math.Sqrt((matrixLocation.Feld11 - cosQ) / (1 - cosQ));
            else
            {
                if (cosQ == 1)
                    l1 = 0;
                else
                    l1 = -1 * Math.Sqrt((matrixLocation.Feld11 - cosQ) / (1 - cosQ));
            }
            if ((matrixLocation.Feld13 - matrixLocation.Feld31) > 0)
                m1 = Math.Sqrt((matrixLocation.Feld22 - cosQ) / (1 - cosQ));
            else
            {
                if (cosQ == 1)
                    m1 = 0;
                else
                    m1 = -1 * Math.Sqrt((matrixLocation.Feld22 - cosQ) / (1 - cosQ));
            }
            if ((matrixLocation.Feld21 - matrixLocation.Feld12) > 0)
                n1 = Math.Sqrt((matrixLocation.Feld33 - cosQ) / (1 - cosQ));
            else
            {
                if (cosQ == 1)
                    n1 = 0;
                else
                    n1 = -1 * Math.Sqrt((matrixLocation.Feld33 - cosQ) / (1 - cosQ));
            }
            if (Math.Abs(l1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                l = l1;
            else
            {
                if (Math.Abs(m1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                    l = (matrixLocation.Feld21 + matrixLocation.Feld12) / (2 * m1 * (1 - cosQ));
                else
                    l = (matrixLocation.Feld31 + matrixLocation.Feld13) / (2 * n1 * (1 - cosQ));
            }
            if (Math.Abs(m1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                m = m1;
            else
            {
                if (Math.Abs(l1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                    m = (matrixLocation.Feld21 + matrixLocation.Feld12) / (2 * l1 * (1 - cosQ));
                else
                    m = (matrixLocation.Feld32 + matrixLocation.Feld23) / (2 * n1 * (1 - cosQ));
            }
            if (Math.Abs(n1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                n = n1;
            else
            {
                if (Math.Abs(l1) == Math.Max(Math.Max(Math.Abs(l1), Math.Abs(m1)), Math.Abs(n1)))
                    n = (matrixLocation.Feld31 + matrixLocation.Feld13) / (2 * l1 * (1 - cosQ));
                else
                    n = (matrixLocation.Feld32 + matrixLocation.Feld23) / (2 * m1 * (1 - cosQ));
            }
            Q1Value = Math.Cos(qRad / 2);
            Q2Value = Math.Sin(qRad / 2) * l;
            Q3Value = Math.Sin(qRad / 2) * m;
            Q4Value = Math.Sin(qRad / 2) * n;
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


    }
}
