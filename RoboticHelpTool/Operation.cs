using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RoboticHelpTool
{
    public class Operation
    {
        //--------------Klassenmethoden---------------

        //Methode um Grad in Rad umzuwandeln
        public static double DegToRad(double deg)
        {
            return deg * (Math.PI / 180);
        }

		//Methode um Rad in Grad umzuwandeln
        public static double RadToDeg(double rad)
        {
            return rad * (180 / Math.PI);
        }

		//Methode um ein KukaLocation Objekt um die X/Y/Z Werte zu verschieben
        public static KukaLocation XYZShiftKukaLocation(KukaLocation kukaLocation, double x, double y, double z)
        {
            kukaLocation.XCoordinate = kukaLocation.XCoordinate + x;
            kukaLocation.YCoordinate = kukaLocation.YCoordinate + y;
            kukaLocation.ZCoordinate = kukaLocation.ZCoordinate + z;

            return kukaLocation;
        }

		//Methode um ein ABBLocation Objekt um die X/Y/Z Werte zu verschieben
        public static ABBLocation XYZShiftABBLocation(ABBLocation abbLocation, double x, double y, double z)
        {
            abbLocation.XCoordinate = abbLocation.XCoordinate + x;
            abbLocation.YCoordinate = abbLocation.YCoordinate + y;
            abbLocation.ZCoordinate = abbLocation.ZCoordinate + z;

            return abbLocation;
        }

		//Methode um ein MatrixLocation Objekt um die X/Y/Z Werte zu verschieben
        public static MatrixLocation XYZShiftMatrixLocation(MatrixLocation matrixLocation, double x, double y, double z)
        {
            matrixLocation.Feld14 = matrixLocation.Feld14 + x;
            matrixLocation.Feld24 = matrixLocation.Feld24 + y;
            matrixLocation.Feld34 = matrixLocation.Feld34 + z;

            return matrixLocation;
        }

        //Methode um Locations zu Spiegeln
        public static MatrixLocation MirrorLocation(object sender)
        {
            KukaLocation tmpKukaLocation = new KukaLocation();
            ABBLocation tmpABBLocation = new ABBLocation();
            MatrixLocation tmpMatrixLocation = new MatrixLocation();

            if (sender is KukaLocation)
            {
                tmpMatrixLocation = new MatrixLocation(sender as KukaLocation);

                tmpMatrixLocation.Feld11 = tmpMatrixLocation.Feld11 * -1;
                tmpMatrixLocation.Feld24 = tmpMatrixLocation.Feld24 * -1;
            }
            return tmpMatrixLocation;
        }

        //Methode zum Multiplizieren von Locations
        public static MatrixLocation RelToolLocation(object B, object A)
        {
            MatrixLocation tmpMatrixLocationA = new MatrixLocation();
            MatrixLocation tmpMatrixLocationB = new MatrixLocation();
            MatrixLocation tmpMatrixLocationC = new MatrixLocation();

            if (A is KukaLocation)
            {
                if (B is KukaLocation)
                    tmpMatrixLocationB = new MatrixLocation(B as KukaLocation);

                else if (B is ABBLocation)
                    tmpMatrixLocationB = new MatrixLocation(B as ABBLocation);

                else if (B is MatrixLocation)
                    tmpMatrixLocationB = (B as MatrixLocation);

                tmpMatrixLocationA = new MatrixLocation(A as KukaLocation);

                //Verschiebung translatorisch relativ zum Tool
                tmpMatrixLocationC.Type = tmpMatrixLocationA.Type;
                tmpMatrixLocationC.Name = tmpMatrixLocationA.Name;
                tmpMatrixLocationC.Feld11 = tmpMatrixLocationA.Feld11 * 1
                                          + tmpMatrixLocationA.Feld12 * 0
                                          + tmpMatrixLocationA.Feld13 * 0
                                          + tmpMatrixLocationA.Feld14 * 0;
                tmpMatrixLocationC.Feld21 = tmpMatrixLocationA.Feld21 * 1
                                          + tmpMatrixLocationA.Feld22 * 0
                                          + tmpMatrixLocationA.Feld23 * 0
                                          + tmpMatrixLocationA.Feld24 * 0;
                tmpMatrixLocationC.Feld31 = tmpMatrixLocationA.Feld31 * 1
                                          + tmpMatrixLocationA.Feld32 * 0
                                          + tmpMatrixLocationA.Feld33 * 0
                                          + tmpMatrixLocationA.Feld34 * 0;
                tmpMatrixLocationC.Feld41 = tmpMatrixLocationA.Feld41 * 1
                                          + tmpMatrixLocationA.Feld42 * 0
                                          + tmpMatrixLocationA.Feld43 * 0
                                          + tmpMatrixLocationA.Feld44 * 0;
                tmpMatrixLocationC.Feld12 = tmpMatrixLocationA.Feld11 * 0
                                          + tmpMatrixLocationA.Feld12 * 1
                                          + tmpMatrixLocationA.Feld13 * 0
                                          + tmpMatrixLocationA.Feld14 * 0;
                tmpMatrixLocationC.Feld22 = tmpMatrixLocationA.Feld21 * 0
                                          + tmpMatrixLocationA.Feld22 * 1
                                          + tmpMatrixLocationA.Feld23 * 0
                                          + tmpMatrixLocationA.Feld24 * 0;
                tmpMatrixLocationC.Feld32 = tmpMatrixLocationA.Feld31 * 0
                                          + tmpMatrixLocationA.Feld32 * 1
                                          + tmpMatrixLocationA.Feld33 * 0
                                          + tmpMatrixLocationA.Feld34 * 0;
                tmpMatrixLocationC.Feld42 = tmpMatrixLocationA.Feld41 * 0
                                          + tmpMatrixLocationA.Feld42 * 1
                                          + tmpMatrixLocationA.Feld43 * 0
                                          + tmpMatrixLocationA.Feld44 * 0;
                tmpMatrixLocationC.Feld13 = tmpMatrixLocationA.Feld11 * 0
                                          + tmpMatrixLocationA.Feld12 * 0
                                          + tmpMatrixLocationA.Feld13 * 1
                                          + tmpMatrixLocationA.Feld14 * 0;
                tmpMatrixLocationC.Feld23 = tmpMatrixLocationA.Feld21 * 0
                                          + tmpMatrixLocationA.Feld22 * 0
                                          + tmpMatrixLocationA.Feld23 * 1
                                          + tmpMatrixLocationA.Feld24 * 0;
                tmpMatrixLocationC.Feld33 = tmpMatrixLocationA.Feld31 * 0
                                          + tmpMatrixLocationA.Feld32 * 0
                                          + tmpMatrixLocationA.Feld33 * 1
                                          + tmpMatrixLocationA.Feld34 * 0;
                tmpMatrixLocationC.Feld43 = tmpMatrixLocationA.Feld41 * 0
                                          + tmpMatrixLocationA.Feld42 * 0
                                          + tmpMatrixLocationA.Feld43 * 1
                                          + tmpMatrixLocationA.Feld44 * 0;
                tmpMatrixLocationC.Feld14 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld24 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld34 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld44 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld44;

                //Verschiebung rotatorisch relativ zum Tool
                //rotatorische Verschiebung muss anders berechnet werden

                //tmpMatrixLocationC.Feld11 = tmpMatrixLocationB.Feld11 * tmpMatrixLocationA.Feld11
                //                          + tmpMatrixLocationB.Feld12 * tmpMatrixLocationA.Feld21
                //                          + tmpMatrixLocationB.Feld13 * tmpMatrixLocationA.Feld31;
                //tmpMatrixLocationC.Feld21 = tmpMatrixLocationB.Feld21 * tmpMatrixLocationA.Feld11
                //                          + tmpMatrixLocationB.Feld22 * tmpMatrixLocationA.Feld21
                //                          + tmpMatrixLocationB.Feld23 * tmpMatrixLocationA.Feld31;
                //tmpMatrixLocationC.Feld31 = tmpMatrixLocationB.Feld31 * tmpMatrixLocationA.Feld11
                //                          + tmpMatrixLocationB.Feld32 * tmpMatrixLocationA.Feld21
                //                          + tmpMatrixLocationB.Feld33 * tmpMatrixLocationA.Feld31;
                //tmpMatrixLocationC.Feld12 = tmpMatrixLocationB.Feld11 * tmpMatrixLocationA.Feld12
                //                          + tmpMatrixLocationB.Feld12 * tmpMatrixLocationA.Feld22
                //                          + tmpMatrixLocationB.Feld13 * tmpMatrixLocationA.Feld32;
                //tmpMatrixLocationC.Feld22 = tmpMatrixLocationB.Feld21 * tmpMatrixLocationA.Feld12
                //                          + tmpMatrixLocationB.Feld22 * tmpMatrixLocationA.Feld22
                //                          + tmpMatrixLocationB.Feld23 * tmpMatrixLocationA.Feld32;
                //tmpMatrixLocationC.Feld32 = tmpMatrixLocationB.Feld31 * tmpMatrixLocationA.Feld12
                //                          + tmpMatrixLocationB.Feld32 * tmpMatrixLocationA.Feld22
                //                          + tmpMatrixLocationB.Feld33 * tmpMatrixLocationA.Feld32;
                //tmpMatrixLocationC.Feld13 = tmpMatrixLocationB.Feld11 * tmpMatrixLocationA.Feld13
                //                          + tmpMatrixLocationB.Feld12 * tmpMatrixLocationA.Feld23
                //                          + tmpMatrixLocationB.Feld13 * tmpMatrixLocationA.Feld33;
                //tmpMatrixLocationC.Feld23 = tmpMatrixLocationB.Feld21 * tmpMatrixLocationA.Feld13
                //                          + tmpMatrixLocationB.Feld22 * tmpMatrixLocationA.Feld23
                //                          + tmpMatrixLocationB.Feld23 * tmpMatrixLocationA.Feld33;
                //tmpMatrixLocationC.Feld33 = tmpMatrixLocationB.Feld31 * tmpMatrixLocationA.Feld13
                //                          + tmpMatrixLocationB.Feld32 * tmpMatrixLocationA.Feld23
                //                          + tmpMatrixLocationB.Feld33 * tmpMatrixLocationA.Feld33;

                tmpMatrixLocationC.Status   = tmpMatrixLocationA.Status;
                tmpMatrixLocationC.Turn     = tmpMatrixLocationA.Turn;
                tmpMatrixLocationC.E1Value  = tmpMatrixLocationA.E1Value;
                tmpMatrixLocationC.E2Value  = tmpMatrixLocationA.E2Value;
                tmpMatrixLocationC.E3Value  = tmpMatrixLocationA.E3Value;
                tmpMatrixLocationC.E4Value  = tmpMatrixLocationA.E4Value;
                tmpMatrixLocationC.E5Value  = tmpMatrixLocationA.E5Value;
                tmpMatrixLocationC.E6Value  = tmpMatrixLocationA.E6Value;

            }
            if (A is ABBLocation)
            {
                if (B is KukaLocation)
                    tmpMatrixLocationB = new MatrixLocation(B as KukaLocation);

                else if (B is ABBLocation)
                    tmpMatrixLocationB = new MatrixLocation(B as ABBLocation);

                else if (B is MatrixLocation)
                    tmpMatrixLocationB = (B as MatrixLocation);

                tmpMatrixLocationA = new MatrixLocation(A as ABBLocation);

                //Verschiebung relativ zum Tool
                tmpMatrixLocationC.Type = tmpMatrixLocationA.Type;
                tmpMatrixLocationC.Name = tmpMatrixLocationA.Name;
                tmpMatrixLocationC.Feld11 = tmpMatrixLocationA.Feld11 * 1
                                          + tmpMatrixLocationA.Feld12 * 0
                                          + tmpMatrixLocationA.Feld13 * 0
                                          + tmpMatrixLocationA.Feld14 * 0;
                tmpMatrixLocationC.Feld21 = tmpMatrixLocationA.Feld21 * 1
                                          + tmpMatrixLocationA.Feld22 * 0
                                          + tmpMatrixLocationA.Feld23 * 0
                                          + tmpMatrixLocationA.Feld24 * 0;
                tmpMatrixLocationC.Feld31 = tmpMatrixLocationA.Feld31 * 1
                                          + tmpMatrixLocationA.Feld32 * 0
                                          + tmpMatrixLocationA.Feld33 * 0
                                          + tmpMatrixLocationA.Feld34 * 0;
                tmpMatrixLocationC.Feld41 = tmpMatrixLocationA.Feld41 * 1
                                          + tmpMatrixLocationA.Feld42 * 0
                                          + tmpMatrixLocationA.Feld43 * 0
                                          + tmpMatrixLocationA.Feld44 * 0;
                tmpMatrixLocationC.Feld12 = tmpMatrixLocationA.Feld11 * 0
                                          + tmpMatrixLocationA.Feld12 * 1
                                          + tmpMatrixLocationA.Feld13 * 0
                                          + tmpMatrixLocationA.Feld14 * 0;
                tmpMatrixLocationC.Feld22 = tmpMatrixLocationA.Feld21 * 0
                                          + tmpMatrixLocationA.Feld22 * 1
                                          + tmpMatrixLocationA.Feld23 * 0
                                          + tmpMatrixLocationA.Feld24 * 0;
                tmpMatrixLocationC.Feld32 = tmpMatrixLocationA.Feld31 * 0
                                          + tmpMatrixLocationA.Feld32 * 1
                                          + tmpMatrixLocationA.Feld33 * 0
                                          + tmpMatrixLocationA.Feld34 * 0;
                tmpMatrixLocationC.Feld42 = tmpMatrixLocationA.Feld41 * 0
                                          + tmpMatrixLocationA.Feld42 * 1
                                          + tmpMatrixLocationA.Feld43 * 0
                                          + tmpMatrixLocationA.Feld44 * 0;
                tmpMatrixLocationC.Feld13 = tmpMatrixLocationA.Feld11 * 0
                                          + tmpMatrixLocationA.Feld12 * 0
                                          + tmpMatrixLocationA.Feld13 * 1
                                          + tmpMatrixLocationA.Feld14 * 0;
                tmpMatrixLocationC.Feld23 = tmpMatrixLocationA.Feld21 * 0
                                          + tmpMatrixLocationA.Feld22 * 0
                                          + tmpMatrixLocationA.Feld23 * 1
                                          + tmpMatrixLocationA.Feld24 * 0;
                tmpMatrixLocationC.Feld33 = tmpMatrixLocationA.Feld31 * 0
                                          + tmpMatrixLocationA.Feld32 * 0
                                          + tmpMatrixLocationA.Feld33 * 1
                                          + tmpMatrixLocationA.Feld34 * 0;
                tmpMatrixLocationC.Feld43 = tmpMatrixLocationA.Feld41 * 0
                                          + tmpMatrixLocationA.Feld42 * 0
                                          + tmpMatrixLocationA.Feld43 * 1
                                          + tmpMatrixLocationA.Feld44 * 0;
                tmpMatrixLocationC.Feld14 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld24 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld34 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld44 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.E1Value = tmpMatrixLocationB.E1Value;
                tmpMatrixLocationC.E2Value = tmpMatrixLocationB.E2Value;
                tmpMatrixLocationC.E3Value = tmpMatrixLocationB.E3Value;
                tmpMatrixLocationC.E4Value = tmpMatrixLocationB.E4Value;
                tmpMatrixLocationC.E5Value = tmpMatrixLocationB.E5Value;
                tmpMatrixLocationC.E6Value = tmpMatrixLocationB.E6Value;


            }
            return tmpMatrixLocationC;
        }
        //Methode zum Spiegeln von Locations
        public static KukaLocation MirrorLocation(object A, object B)
        {
                KukaLocation tmpKukaLocationA = new KukaLocation();
                KukaLocation tmpKukaLocationB = new KukaLocation();
                KukaLocation tmpKukaLocationC = new KukaLocation();

            if (B is KukaLocation)
            {
                if (A is MatrixLocation)
                    tmpKukaLocationA = new KukaLocation(A as MatrixLocation);

                else if (A is ABBLocation)
                    tmpKukaLocationA = new KukaLocation(A as ABBLocation);

                else if (A is KukaLocation)
                    tmpKukaLocationA = (A as KukaLocation);

                tmpKukaLocationB = (B as KukaLocation);


                tmpKukaLocationC.Type = tmpKukaLocationB.Type;
                tmpKukaLocationC.Name = tmpKukaLocationB.Name;
                tmpKukaLocationC.XCoordinate = tmpKukaLocationA.XCoordinate * tmpKukaLocationB.XCoordinate;
                tmpKukaLocationC.YCoordinate = tmpKukaLocationA.YCoordinate * tmpKukaLocationB.YCoordinate;
                tmpKukaLocationC.ZCoordinate = tmpKukaLocationA.ZCoordinate * tmpKukaLocationB.ZCoordinate;
                tmpKukaLocationC.AAngle = tmpKukaLocationA.AAngle * tmpKukaLocationB.AAngle;
                tmpKukaLocationC.BAngle = tmpKukaLocationA.BAngle * tmpKukaLocationB.BAngle;
                tmpKukaLocationC.CAngle = tmpKukaLocationA.CAngle * tmpKukaLocationB.CAngle;
                tmpKukaLocationC.StatusCf1 = tmpKukaLocationB.StatusCf1;
                tmpKukaLocationC.TurnCf4 = tmpKukaLocationB.TurnCf4;
                tmpKukaLocationC.E1Value = tmpKukaLocationB.E1Value;
                tmpKukaLocationC.E2Value = tmpKukaLocationB.E2Value;
                tmpKukaLocationC.E3Value = tmpKukaLocationB.E3Value;
                tmpKukaLocationC.E4Value = tmpKukaLocationB.E4Value;
                tmpKukaLocationC.E5Value = tmpKukaLocationB.E5Value;
                tmpKukaLocationC.E6Value = tmpKukaLocationB.E6Value;

            }

            if (B is ABBLocation)
            {
                if (A is MatrixLocation)
                    tmpKukaLocationA = new KukaLocation(A as MatrixLocation);

                else if (A is ABBLocation)
                    tmpKukaLocationA = new KukaLocation(A as ABBLocation);

                else if (A is KukaLocation)
                    tmpKukaLocationA = (A as KukaLocation);

                tmpKukaLocationB = new KukaLocation(B as ABBLocation);


                tmpKukaLocationC.Type = tmpKukaLocationB.Type;
                tmpKukaLocationC.Name = tmpKukaLocationB.Name;
                tmpKukaLocationC.XCoordinate = tmpKukaLocationA.XCoordinate * tmpKukaLocationB.XCoordinate;
                tmpKukaLocationC.YCoordinate = tmpKukaLocationA.YCoordinate * tmpKukaLocationB.YCoordinate;
                tmpKukaLocationC.ZCoordinate = tmpKukaLocationA.ZCoordinate * tmpKukaLocationB.ZCoordinate;
                tmpKukaLocationC.AAngle = tmpKukaLocationA.AAngle * tmpKukaLocationB.AAngle;
                tmpKukaLocationC.BAngle = tmpKukaLocationA.BAngle * tmpKukaLocationB.BAngle;
                tmpKukaLocationC.CAngle = tmpKukaLocationA.CAngle * tmpKukaLocationB.CAngle;
                tmpKukaLocationC.StatusCf1 = tmpKukaLocationB.StatusCf1;
                tmpKukaLocationC.TurnCf4 = tmpKukaLocationB.TurnCf4;
                tmpKukaLocationC.E1Value = tmpKukaLocationB.E1Value;
                tmpKukaLocationC.E2Value = tmpKukaLocationB.E2Value;
                tmpKukaLocationC.E3Value = tmpKukaLocationB.E3Value;
                tmpKukaLocationC.E4Value = tmpKukaLocationB.E4Value;
                tmpKukaLocationC.E5Value = tmpKukaLocationB.E5Value;
                tmpKukaLocationC.E6Value = tmpKukaLocationB.E6Value;

            }

            return tmpKukaLocationC;
            
        }


        //Methode zum Multiplizieren von Locations
        public static MatrixLocation MultiLocation(object B, object A)
        {
            MatrixLocation tmpMatrixLocationA = new MatrixLocation();
            MatrixLocation tmpMatrixLocationB = new MatrixLocation();
            MatrixLocation tmpMatrixLocationC = new MatrixLocation();

            if (A is KukaLocation)
            {
                if (B is KukaLocation)
                    tmpMatrixLocationB = new MatrixLocation(B as KukaLocation);

                else if (B is ABBLocation)
                    tmpMatrixLocationB = new MatrixLocation(B as ABBLocation);

                else if (B is MatrixLocation)
                    tmpMatrixLocationB = (B as MatrixLocation);

                tmpMatrixLocationA = new MatrixLocation(A as KukaLocation);

                tmpMatrixLocationC.Type = tmpMatrixLocationB.Type;

                //Changed for transformation from Location in files over a base 20200721
                //wrong order of matrix multiplication
                //tmpMatrixLocationC.Name = tmpMatrixLocationA.Name;
                tmpMatrixLocationC.Name = tmpMatrixLocationB.Name;

                tmpMatrixLocationC.Feld11 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld11
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld21
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld31
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld41;
                tmpMatrixLocationC.Feld21 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld11
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld21
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld31
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld41;
                tmpMatrixLocationC.Feld31 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld11
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld21
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld31
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld41;
                tmpMatrixLocationC.Feld41 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld11
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld21
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld31
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld41;
                tmpMatrixLocationC.Feld12 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld12
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld22
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld32
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld42;
                tmpMatrixLocationC.Feld22 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld12
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld22
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld32
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld42;
                tmpMatrixLocationC.Feld32 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld12
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld22
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld32
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld42;
                tmpMatrixLocationC.Feld42 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld12
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld22
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld32
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld42;
                tmpMatrixLocationC.Feld13 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld13
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld23
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld33
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld43;
                tmpMatrixLocationC.Feld23 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld13
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld23
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld33
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld43;
                tmpMatrixLocationC.Feld33 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld13
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld23
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld33
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld43;
                tmpMatrixLocationC.Feld43 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld13
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld23
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld33
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld43;
                tmpMatrixLocationC.Feld14 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld24 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld34 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld44 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Status = tmpMatrixLocationA.Status;
                tmpMatrixLocationC.Turn = tmpMatrixLocationA.Turn;
                tmpMatrixLocationC.E1Value = tmpMatrixLocationA.E1Value;
                tmpMatrixLocationC.E2Value = tmpMatrixLocationA.E2Value;
                tmpMatrixLocationC.E3Value = tmpMatrixLocationA.E3Value;
                tmpMatrixLocationC.E4Value = tmpMatrixLocationA.E4Value;
                tmpMatrixLocationC.E5Value = tmpMatrixLocationA.E5Value;
                tmpMatrixLocationC.E6Value = tmpMatrixLocationA.E6Value;

            }
            if (A is ABBLocation)
            {
                if (B is KukaLocation)
                    tmpMatrixLocationB = new MatrixLocation(B as KukaLocation);

                else if (B is ABBLocation)
                    tmpMatrixLocationB = new MatrixLocation(B as ABBLocation);

                else if (B is MatrixLocation)
                    tmpMatrixLocationB = (B as MatrixLocation);

                tmpMatrixLocationA = new MatrixLocation(A as ABBLocation);

                tmpMatrixLocationC.Type = tmpMatrixLocationB.Type;
                tmpMatrixLocationC.Name = tmpMatrixLocationA.Name;
                tmpMatrixLocationC.Feld11 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld11
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld21
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld31
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld41;
                tmpMatrixLocationC.Feld21 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld11
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld21
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld31
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld41;
                tmpMatrixLocationC.Feld31 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld11
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld21
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld31
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld41;
                tmpMatrixLocationC.Feld41 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld11
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld21
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld31
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld41;
                tmpMatrixLocationC.Feld12 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld12
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld22
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld32
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld42;
                tmpMatrixLocationC.Feld22 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld12
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld22
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld32
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld42;
                tmpMatrixLocationC.Feld32 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld12
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld22
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld32
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld42;
                tmpMatrixLocationC.Feld42 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld12
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld22
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld32
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld42;
                tmpMatrixLocationC.Feld13 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld13
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld23
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld33
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld43;
                tmpMatrixLocationC.Feld23 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld13
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld23
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld33
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld43;
                tmpMatrixLocationC.Feld33 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld13
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld23
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld33
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld43;
                tmpMatrixLocationC.Feld43 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld13
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld23
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld33
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld43;
                tmpMatrixLocationC.Feld14 = tmpMatrixLocationA.Feld11 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld12 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld13 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld14 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld24 = tmpMatrixLocationA.Feld21 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld22 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld23 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld24 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld34 = tmpMatrixLocationA.Feld31 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld32 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld33 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld34 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.Feld44 = tmpMatrixLocationA.Feld41 * tmpMatrixLocationB.Feld14
                                          + tmpMatrixLocationA.Feld42 * tmpMatrixLocationB.Feld24
                                          + tmpMatrixLocationA.Feld43 * tmpMatrixLocationB.Feld34
                                          + tmpMatrixLocationA.Feld44 * tmpMatrixLocationB.Feld44;
                tmpMatrixLocationC.E1Value = tmpMatrixLocationB.E1Value;
                tmpMatrixLocationC.E2Value = tmpMatrixLocationB.E2Value;
                tmpMatrixLocationC.E3Value = tmpMatrixLocationB.E3Value;
                tmpMatrixLocationC.E4Value = tmpMatrixLocationB.E4Value;
                tmpMatrixLocationC.E5Value = tmpMatrixLocationB.E5Value;
                tmpMatrixLocationC.E6Value = tmpMatrixLocationB.E6Value;


            }
            return tmpMatrixLocationC;
        }

        public static MatrixLocation BaseCalc(object root, object positiveX, object positiveY)
        {
            MatrixLocation tmpMatrixLocation = new MatrixLocation();

            Double[] tmpX = new Double[3];
            Double[] tmpY = new Double[3];
            Double[] tmpZ = new Double[3];
            Double[] tmpXY = new Double[3];
            Double sK_PROD = new Double();
            Double laenge = new Double();
            Int16 i = new Int16();
            Double[,] tmpT = new double[3, 3];

            if (root is KukaLocation && positiveX is KukaLocation && positiveY is KukaLocation)
            {
                tmpX[0] = (positiveX as KukaLocation).XCoordinate - (root as KukaLocation).XCoordinate;
                tmpX[1] = (positiveX as KukaLocation).YCoordinate - (root as KukaLocation).YCoordinate;
                tmpX[2] = (positiveX as KukaLocation).ZCoordinate - (root as KukaLocation).ZCoordinate;

                sK_PROD = 0;
                laenge = 0;
                for (i = 0; i <= 2; i++)
                {
                    sK_PROD = sK_PROD + tmpX[i] * tmpX[i];
                }
                laenge = Math.Sqrt(sK_PROD);
                for (i = 0; i <= 2; i++)
                {
                    tmpX[i] = tmpX[i] / laenge;
                }


                tmpXY[0] = (positiveY as KukaLocation).XCoordinate - (root as KukaLocation).XCoordinate;
                tmpXY[1] = (positiveY as KukaLocation).YCoordinate - (root as KukaLocation).YCoordinate;
                tmpXY[2] = (positiveY as KukaLocation).ZCoordinate - (root as KukaLocation).ZCoordinate;

                sK_PROD = 0;
                laenge = 0;
                for (i = 0; i <= 2; i++)
                {
                    sK_PROD = sK_PROD + tmpXY[i] * tmpXY[i];
                }
                laenge = Math.Sqrt(sK_PROD);
                for (i = 0; i <= 2; i++)
                {
                    tmpXY[i] = tmpXY[i] / laenge;
                }

                tmpZ[0] = (tmpX[1] * tmpXY[2]) - (tmpX[2] * tmpXY[1]);
                tmpZ[1] = (tmpX[2] * tmpXY[0]) - (tmpX[0] * tmpXY[2]);
                tmpZ[2] = (tmpX[0] * tmpXY[1]) - (tmpX[1] * tmpXY[0]);

                sK_PROD = 0;
                laenge = 0;
                for (i = 0; i <= 2; i++)
                {
                    sK_PROD = sK_PROD + tmpZ[i] * tmpZ[i];
                }
                laenge = Math.Sqrt(sK_PROD);
                for (i = 0; i <= 2; i++)
                {
                    tmpZ[i] = tmpZ[i] / laenge;
                }

                tmpY[0] = (tmpZ[1] * tmpX[2]) - (tmpZ[2] * tmpX[1]);
                tmpY[1] = (tmpZ[2] * tmpX[0]) - (tmpZ[0] * tmpX[2]);
                tmpY[2] = (tmpZ[0] * tmpX[1]) - (tmpZ[1] * tmpX[0]);

                for (i = 0; i <= 2; i++)
                {
                    tmpT[i, 0] = tmpX[i];
                    tmpT[i, 1] = tmpY[i];
                    tmpT[i, 2] = tmpZ[i];
                }

                tmpMatrixLocation = (new MatrixLocation("E6POS", "Base", tmpT[0, 0], tmpT[0, 1], tmpT[0, 2], KukaBasePage.Root.XCoordinate, tmpT[1, 0], tmpT[1, 1], tmpT[1, 2], KukaBasePage.Root.YCoordinate
                                                         , tmpT[2, 0], tmpT[2, 1], tmpT[2, 2], KukaBasePage.Root.ZCoordinate, 0, 0, 0, 1));

            }
            return tmpMatrixLocation;
        }

        // Calculates the average of the values from LocationList XCoordinate
        public static Double[] averageXYZ(List<KukaLocation> locationList)
        {
            double[] result = new double[3];
            double sumX = 0;
            double sumY = 0;
            double sumZ = 0;

            for (int i = 0; i < locationList.Count; i++)
            {
                sumX = sumX + locationList[i].XCoordinate;
            }

            for (int i = 0; i < locationList.Count; i++)
            {
                sumY = sumY + locationList[i].YCoordinate;
            }

            for (int i = 0; i < locationList.Count; i++)
            {
                sumZ = sumZ + locationList[i].ZCoordinate;
            }

            result[0] = sumX / locationList.Count;
            result[1] = sumY / locationList.Count;
            result[2] = sumZ / locationList.Count;

            return result;
        }

        // Calculates the summary for each index of the A Matrix
        public static Double[,] sumForA(List<KukaLocation> locationList)
        {
            double[,] result;
            double XvX = 0;
            double XvY = 0;
            double XvZ = 0;
            double YvX = 0;
            double YvY = 0;
            double YvZ = 0;
            double ZvX = 0;
            double ZvY = 0;
            double ZvZ = 0;

            for (int i = 0; i < locationList.Count; i++)
            {
                XvX = XvX + (locationList[i].XCoordinate * (locationList[i].XCoordinate - averageXYZ(locationList)[0]) 
                            / locationList.Count);
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                XvY = XvY + (locationList[i].XCoordinate * (locationList[i].YCoordinate - averageXYZ(locationList)[1])
                            / locationList.Count);
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                XvZ = XvZ + (locationList[i].XCoordinate * (locationList[i].ZCoordinate - averageXYZ(locationList)[2])
                            / locationList.Count);
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                YvX = YvX + (locationList[i].YCoordinate * (locationList[i].XCoordinate - averageXYZ(locationList)[0])
                            / locationList.Count);
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                YvY = YvY + (locationList[i].YCoordinate * (locationList[i].YCoordinate - averageXYZ(locationList)[1])
                            / locationList.Count);
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                YvZ = YvZ + (locationList[i].YCoordinate * (locationList[i].ZCoordinate - averageXYZ(locationList)[2])
                            / locationList.Count);
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                ZvX = ZvX + (locationList[i].ZCoordinate * (locationList[i].XCoordinate - averageXYZ(locationList)[0])
                            / locationList.Count);
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                ZvY = ZvY + (locationList[i].ZCoordinate * (locationList[i].YCoordinate - averageXYZ(locationList)[1])
                            / locationList.Count);
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                ZvZ = ZvZ + (locationList[i].ZCoordinate * (locationList[i].ZCoordinate - averageXYZ(locationList)[2])
                            / locationList.Count);
            }

            result = new double[,]{ { XvX, XvY, XvZ},{ YvX, YvY, YvZ},{ ZvX, ZvY, ZvZ} };

            return result;
        }

        public static Double[,] sumForB(List<KukaLocation> locationList)
        {
            double[,] result = new double[3,1];
            double allX = 0;
            double allY = 0;
            double allZ = 0;
            

            for (int i = 0; i < locationList.Count;i++)
            {
                allX = allX + ((Math.Pow(locationList[i].XCoordinate, 2) + Math.Pow(locationList[i].YCoordinate, 2) + Math.Pow(locationList[i].ZCoordinate, 2)) * 
                                (locationList[i].XCoordinate - averageXYZ(locationList)[0])) / 
                                locationList.Count;
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                allY = allY + ((Math.Pow(locationList[i].XCoordinate, 2) + Math.Pow(locationList[i].YCoordinate, 2) + Math.Pow(locationList[i].ZCoordinate, 2)) *
                                (locationList[i].YCoordinate - averageXYZ(locationList)[1])) /
                                locationList.Count;
            }

            for (int i = 0; i < locationList.Count; i++)
            {
                allZ = allZ + ((Math.Pow(locationList[i].XCoordinate, 2) + Math.Pow(locationList[i].YCoordinate, 2) + Math.Pow(locationList[i].ZCoordinate, 2)) *
                                (locationList[i].ZCoordinate - averageXYZ(locationList)[2])) /
                                locationList.Count;
            }

            result[0,0] = allX;
            result[1,0] = allY;
            result[2,0] = allZ;

            return result;
        }

        public static Double[,] bestFit(List<KukaLocation> locationList)
        {
            double[,] result = new double[9,3];
            double[,] bestFitBase;
            double[,] A;
            double[,] B;
            double[,] ATrans;
            double[,] invATransA;
            List<double> failureValues = new List<double>();
            double minFailure = 0;
            double maxFailure = 0;
            double avgFailure = 0;
            int minFailureIndex = 0;
            KukaLocation Base;

            A = new double[,] { { 2 * sumForA(locationList)[0,0], 2 * sumForA(locationList)[0, 1], 2 * sumForA(locationList)[0, 2] },
                                { 2 * sumForA(locationList)[1,0], 2 * sumForA(locationList)[1, 1], 2 * sumForA(locationList)[1, 2] },
                                { 2 * sumForA(locationList)[2,0], 2 * sumForA(locationList)[2, 1], 2 * sumForA(locationList)[2, 2] }};

            B = new double[,] { { sumForB(locationList)[0,0]},
                                { sumForB(locationList)[1,0]},
                                { sumForB(locationList)[2,0]}};

            ATrans = Transpose(A);
            invATransA = MatrixInver(MatrixMulti(ATrans, A));
            bestFitBase = MatrixMulti(MatrixMulti(invATransA, ATrans), B);


            result[0, 0] = bestFitBase[0, 0];
            result[1, 0] = bestFitBase[1, 0];
            result[2, 0] = bestFitBase[2, 0];
            result[3, 0] = Radius(locationList, result);
            result[4, 0] = FitQuality(locationList, result);

            for (int i = 0; i < locationList.Count; i++)
            {
                failureValues.Add(FunctionZ(locationList[i], result) - locationList[i].ZCoordinate);
            }
            minFailure = failureValues.Select(x => Math.Abs(x)).Min();
            maxFailure = failureValues.Select(x => Math.Abs(x)).Max();
            avgFailure = failureValues.Select(x => Math.Abs(x)).Average();
            minFailureIndex = failureValues.IndexOf(minFailure);
            if (minFailureIndex < 0)
                minFailureIndex = failureValues.IndexOf(-minFailure);


            result[5, 0] = minFailure;
            result[6, 0] = maxFailure;
            result[7, 0] = avgFailure;

            KukaOnePosTcpPage.FlanschInv = new KukaLocation(Operation.MatrixInv(locationList[minFailureIndex]));
            Base = new KukaLocation("BASE", "Base", result[0, 0], result[1, 0], result[2, 0], 0, 0, 0);
            KukaOnePosTcpPage.TCP = new KukaLocation(Operation.MultiLocation(Base, KukaOnePosTcpPage.FlanschInv));

            result[8, 0] = KukaOnePosTcpPage.TCP.XCoordinate;
            result[8, 1] = KukaOnePosTcpPage.TCP.YCoordinate;
            result[8, 2] = KukaOnePosTcpPage.TCP.ZCoordinate;

            return result;
        }

        public static double FunctionZ(KukaLocation location, double[,] bestFit)
        {
            double result = 0;

            if (location.ZCoordinate < bestFit[2, 0])
            {
                result = -Math.Sqrt(Math.Pow(bestFit[3, 0], 2) -
                                    Math.Pow(location.XCoordinate - bestFit[0, 0], 2) -
                                    Math.Pow(location.YCoordinate - bestFit[1, 0], 2)) + bestFit[2, 0];
            }
            else if (location.ZCoordinate >= bestFit[2, 0])
            {
                result = Math.Sqrt(Math.Pow(bestFit[3, 0], 2) -
                                    Math.Pow(location.XCoordinate - bestFit[0, 0], 2) -
                                    Math.Pow(location.YCoordinate - bestFit[1, 0], 2)) + bestFit[2, 0];
            }

            return result;
        }

        public static double FitQuality(List<KukaLocation> locationList, double[,] bestFit)
        {
            double result = 0;
            double fitQualityUpper = 0;
            double fitQualityLower = 0;
            double sumZ = 0;

            for (int i = 0; i < locationList.Count; i++)
            {
                sumZ = sumZ + locationList[i].ZCoordinate;
            }
            for ( int i = 0; i < locationList.Count; i++)
            {
                fitQualityUpper = fitQualityUpper + Math.Pow(locationList[i].ZCoordinate - FunctionZ(locationList[i], bestFit), 2);
            }
            for (int i = 0; i < locationList.Count; i++)
            {
                fitQualityLower = fitQualityLower + Math.Pow(locationList[i].ZCoordinate - (sumZ / locationList.Count), 2);
            }

            result = 1 - (fitQualityUpper / fitQualityLower);

            return result;
        }
        public static double Radius(List<KukaLocation> locationList, double[,] bestFitBase)
        {
            double result = 0;
            double sumRadius = 0;

            for (int i = 0; i < locationList.Count; i++)
            {
                sumRadius = sumRadius + (Math.Pow(locationList[i].XCoordinate - bestFitBase[0, 0], 2) +
                                         Math.Pow(locationList[i].YCoordinate - bestFitBase[1, 0], 2) +
                                         Math.Pow(locationList[i].ZCoordinate - bestFitBase[2, 0], 2));
            }

            result = Math.Sqrt(sumRadius / locationList.Count);

            return result;
        }
        public static double[,] MatrixMulti(double[,] A, double[,] B)
        {
            int lengthA;
            int rankA;
            int lenghtB;
            int rankB;

            lengthA = A.GetLength(0);
            rankA = A.GetLength(1);
            lenghtB = B.GetLength(0);
            rankB = B.GetLength(1);
            double[,] result = new double[lenghtB,rankB];

            for (int i = 0; i < lengthA; i++)
            {
                for (int j = 0; j < rankB; j++)
                {
                    result[i,j] = 0;
                    for (int k = 0; k < lenghtB; k++)
                        result[i,j] = result[i,j] + (A[i,k] * B[k,j]);
                }
            }

            return result;
        }

        public static double[,] Transpose(double[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            double[,] result = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }
        public static Double[,] MatrixInver(double[,] matrix)
        {
            int lengthMatrix = matrix.GetLength(0);
            int rankMatrix = matrix.GetLength(1);

            double[,] result = new double[lengthMatrix,rankMatrix];
            double[][] m = MatrixCreate(lengthMatrix,rankMatrix);
            double[][] inv;

            for (int i = 0; i < rankMatrix; i++)
            {
                for (int j = 0; j < lengthMatrix; j++)
                {
                    m[i][j] = matrix[i, j];
                }
            }

            inv = MatrixInverse(m);

            for (int i = 0; i < rankMatrix; i++)
            {
                for (int j = 0; j < lengthMatrix; j++)
                {
                    result[i,j] = inv[i][j];
                }
            }

            return result;
        }

        //*********************************************************************************************************************************************
        //Sonstige Hilfsmethoden, kopiert vom Internet https://stackoverflow.com/questions/46836908/double-inversion-c-sharp

        // Temporär für ablauf zum erstellen eine Matrix zum Invertieren
        // Nur zum entwickeln das umsetzten mit meinen Matrizen
        public static MatrixLocation MatrixInv(object L)
        {
            MatrixLocation tmpMatrixLocationA = new MatrixLocation();
            MatrixLocation tmpMatrixLocationB = new MatrixLocation();
            double [][] m;
            double [][] inv;

            if (L is KukaLocation)
            {
                tmpMatrixLocationA = new MatrixLocation(L as KukaLocation);

                m = new double[][] { new double[] { tmpMatrixLocationA.Feld11, tmpMatrixLocationA.Feld12, tmpMatrixLocationA.Feld13, tmpMatrixLocationA.Feld14 },
                                     new double[] { tmpMatrixLocationA.Feld21, tmpMatrixLocationA.Feld22, tmpMatrixLocationA.Feld23, tmpMatrixLocationA.Feld24 },
                                     new double[] { tmpMatrixLocationA.Feld31, tmpMatrixLocationA.Feld32, tmpMatrixLocationA.Feld33, tmpMatrixLocationA.Feld34 },
                                     new double[] { tmpMatrixLocationA.Feld41, tmpMatrixLocationA.Feld42, tmpMatrixLocationA.Feld43, tmpMatrixLocationA.Feld44 }};


                inv = MatrixInverse(m);


                tmpMatrixLocationB = new MatrixLocation("InverseFrame", "FlanschInverse",
                                                        inv[0][0], inv[0][1], inv[0][2], inv[0][3],
                                                        inv[1][0], inv[1][1], inv[1][2], inv[1][3],
                                                        inv[2][0], inv[2][1], inv[2][2], inv[2][3],
                                                        inv[3][0], inv[3][1], inv[3][2], inv[3][3]);
            }

            return tmpMatrixLocationB;
        }
        static double[][] MatrixCreate(int rows, int cols)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }

        static double[][] MatrixIdentity(int n)
        {
            // return an n x n Identity matrix
            double[][] result = MatrixCreate(n, n);
            for (int i = 0; i < n; ++i)
                result[i][i] = 1.0;

            return result;
        }

        static double[][] MatrixInverse(double[][] matrix)
        {
            int n = matrix.Length;
            double[][] result = MatrixDuplicate(matrix);

            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm,
              out toggle);
            if (lum == null)
                throw new Exception("Unable to compute inverse");

            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }

                double[] x = HelperSolve(lum, b);

                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return result;
        }

        static double[][] MatrixDuplicate(double[][] matrix)
        {
            // allocates/creates a duplicate of a matrix.
            double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i) // copy the values
                for (int j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];
            return result;
        }

        static double[] HelperSolve(double[][] luMatrix, double[] b)
        {
            // before calling this helper, permute b using the perm array
            // from MatrixDecompose that generated luMatrix
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // rerturns: result is L (with 1s on diagonal) and U;
            // perm holds row permutations; toggle is +1 or -1 (even or odd)
            int rows = matrix.Length;
            int cols = matrix[0].Length; // assume square
            if (rows != cols)
                throw new Exception("Attempt to decompose a non-square m");

            int n = rows; // convenience

            double[][] result = MatrixDuplicate(matrix);

            perm = new int[n]; // set up row permutation result
            for (int i = 0; i < n; ++i) { perm[i] = i; }

            toggle = 1; // toggle tracks row swaps.
                        // +1 -greater-than even, -1 -greater-than odd. used by MatrixDeterminant

            for (int j = 0; j < n - 1; ++j) // each column
            {
                double colMax = Math.Abs(result[j][j]); // find largest val in col
                int pRow = j;
                //for (int i = j + 1; i less-than n; ++i)
                //{
                //  if (result[i][j] greater-than colMax)
                //  {
                //    colMax = result[i][j];
                //    pRow = i;
                //  }
                //}

                // reader Matt V needed this:
                for (int i = j + 1; i < n; ++i)
                {
                    if (Math.Abs(result[i][j]) > colMax)
                    {
                        colMax = Math.Abs(result[i][j]);
                        pRow = i;
                    }
                }
                // Not sure if this approach is needed always, or not.

                if (pRow != j) // if largest value not on pivot, swap rows
                {
                    double[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[pRow]; // and swap perm info
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                // --------------------------------------------------
                // This part added later (not in original)
                // and replaces the 'return null' below.
                // if there is a 0 on the diagonal, find a good row
                // from i = j+1 down that doesn't have
                // a 0 in column j, and swap that good row with row j
                // --------------------------------------------------

                if (result[j][j] == 0.0)
                {
                    // find a good row to swap
                    int goodRow = -1;
                    for (int row = j + 1; row < n; ++row)
                    {
                        if (result[row][j] != 0.0)
                            goodRow = row;
                    }

                    if (goodRow == -1)
                        throw new Exception("Cannot use Doolittle's method");

                    // swap rows so 0.0 no longer on diagonal
                    double[] rowPtr = result[goodRow];
                    result[goodRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[goodRow]; // and swap perm info
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }
                // --------------------------------------------------
                // if diagonal after swap is zero . .
                //if (Math.Abs(result[j][j]) less-than 1.0E-20) 
                //  return null; // consider a throw

                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }


            } // main j column loop

            return result;
        }

    }
}
