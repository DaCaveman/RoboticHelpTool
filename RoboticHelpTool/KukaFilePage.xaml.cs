using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Text.RegularExpressions;


namespace RoboticHelpTool
{
    /// <summary>
    /// Interaktionslogik für KukaFilePage.xaml
    /// </summary>
    public partial class KukaFilePage : Page
    {
        //--------------Klasseneigenschaften-----------------
        public static string DateiOrtDat;
        public static string DateiOrtSrc;
        public static string[] DatenOrte;
        public static bool SpezialAblauf;

        public KukaFilePage()
        {
            SpezialAblauf = false;
            KukaLocation.KukaLocationsAktuell.Clear();
            KukaLocation.KukaLocationsAktuell.Clear();
            KukaLocation.KukaLocationsAktuellShift.Clear();
            KukaLocation.KukaLocationsAktuellMirror.Clear();
            KukaLocation.KukaLocationsAktuellMulti.Clear();
            KukaLocation.MatrixLocationsAktuell.Clear();
            KukaLocation.LocationsAktuellString.Clear();
            KukaLocation.LocationsAuswahlString.Clear();
            KukaLocation.KUKA_Header.Clear();
            KukaLocation.KUKA_Header_clean.Clear();
            KukaLocation.KUKA_Sorted.Clear();
            KukaLocation.SortLocationsMisc.Clear();
            KukaLocation.SortLocationsFromSrc.Clear();
            KukaLocation.SortLocationsE6POS.Clear();
            KukaLocation.SortLocationsVW.Clear();
            KukaLocation.SortLocationsFDAT.Clear();
            KukaLocation.SortLocationsPLDAT.Clear();
            KukaLocation.SrcInLines.Clear();
            KukaLocation.DatInNames.Clear();
            KukaLocation.DatInLines.Clear();
            KukaLocation.ExistingNames.Clear();
            KukaLocation.MissingNames.Clear();
            KukaLocation.SrcExistingVariables.Clear();

            InitializeComponent();
        }
        private void DateiZiel_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }

        private void DateiZiel_PreviewDrop(object sender, DragEventArgs e)
        {
            object text = e.Data.GetData(DataFormats.FileDrop);
            if (DateiZiel != null)
            {
                DateiZiel.Text = string.Format("{0}", ((string[])text)[0]);
            }
        }
        private void DateiZiel_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateiOrtDat = DateiZiel.Text;
            DateiOrtSrc = DateiOrtDat.Replace(".dat", ".src");
        }

        private void Button_Einlesen(object sender, RoutedEventArgs e)
        {
            DateiOrtDat = DateiZiel.Text.Replace(".src", ".dat");
            DateiOrtSrc = DateiOrtDat.Replace(".dat",".src");
            AuswahlListe LocationListe = new AuswahlListe();

            KukaLocation.KukaLocationsAktuell.Clear();
            KukaLocation.KukaLocationsAktuell.Clear();
            KukaLocation.KukaLocationsAktuellShift.Clear();
            KukaLocation.KukaLocationsAktuellMirror.Clear();
            KukaLocation.KukaLocationsAktuellMulti.Clear();
            KukaLocation.MatrixLocationsAktuell.Clear();
            KukaLocation.LocationsAktuellString.Clear();
            KukaLocation.LocationsAuswahlString.Clear();
            KukaLocation.KUKA_Header.Clear();
            KukaLocation.KUKA_Header_clean.Clear();
            KukaLocation.KUKA_Sorted.Clear();
            KukaLocation.SortLocationsMisc.Clear();
            KukaLocation.SortLocationsFromSrc.Clear();
            KukaLocation.SortLocationsE6POS.Clear();
            KukaLocation.SortLocationsVW.Clear();
            KukaLocation.SortLocationsFDAT.Clear();
            KukaLocation.SortLocationsPLDAT.Clear();
            KukaLocation.SrcInLines.Clear();
            KukaLocation.DatInNames.Clear();
            KukaLocation.DatInLines.Clear();
            KukaLocation.ExistingNames.Clear();
            KukaLocation.MissingNames.Clear();
            KukaLocation.SrcExistingVariables.Clear();

            try
            {
                KukaLocation.LocationSplit_File();

                //Auswahl Test
                KukaLocation.KukaListeToFile(KukaLocation.KukaLocationsAktuell);
                foreach (var x in KukaLocation.LocationsAktuellString)
                {
                    CheckBox newCheckbox = new CheckBox();
                    newCheckbox.Content = x;
                    LocationListe.WorkList.Items.Add(newCheckbox);
                }
                LocationListe.ShowDialog();
                KukaLocation.LocationsAuswahlString.Clear();
                foreach (CheckBox y in LocationListe.WorkList.Items)
                {
                    if (y.IsChecked == true)
                        KukaLocation.LocationsAuswahlString.Add(y.Content.ToString());
                }
                // Auswahl in aktuelle LocationList einfügen
                KukaLocation.LocationSplit_List(KukaLocation.LocationsAuswahlString);

                InfoBox finish = new InfoBox();
                finish.Owner = Application.Current.MainWindow;
                finish.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                finish.InfoBox_Text.Content = "Daten sind eingelesen \n" + DateiOrtDat;
                finish.OK_Button.Visibility = Visibility.Visible;
                finish.Abbruch_Button.Visibility = Visibility.Hidden;
                finish.Manual_Button.Visibility = Visibility.Hidden;
                finish.Show();
            }
            catch(FileNotFoundException)
            {
                InfoBox finish = new InfoBox();
                finish.Owner = Application.Current.MainWindow;
                finish.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                finish.InfoBox_Text.Content = "Keine Datei gefunden!";
                finish.OK_Button.Visibility = Visibility.Visible;
                finish.Abbruch_Button.Visibility = Visibility.Hidden;
                finish.Manual_Button.Visibility = Visibility.Hidden;
                finish.Show();
            }
        }
        //Action EmptyDelegate = delegate () { }; // Zuweisung einer anonymen Methode ohne ausführbaren Code

        private void Button_Einlesen_Bereinigen_Sortieren(object sender, RoutedEventArgs e)
        {
            SpezialAblauf = true;
            //Prb.Value = 0;
            //double Proz = 0;

            OpenFileDialog fop = new OpenFileDialog();
                fop.Multiselect = true;

                fop.InitialDirectory = "C:\\";
                fop.Filter = "KUKA|*.dat";
            if (fop.ShowDialog() == true)
            {
                //Proz = 100 / fop.FileNames.Length;

                foreach (String files in fop.FileNames)
                {

                    //Prb.Value = Prb.Value + Proz;
                    //// Aktualisierung der ProgressBar ("refresh")
                    //Prb.Dispatcher.Invoke(
                    //    EmptyDelegate,
                    //    System.Windows.Threading.DispatcherPriority.Background
                    //    );

                    KukaLocation.KukaLocationsAktuell.Clear();
                    KukaLocation.KukaLocationsAktuell.Clear();
                    KukaLocation.KukaLocationsAktuellShift.Clear();
                    KukaLocation.KukaLocationsAktuellMirror.Clear();
                    KukaLocation.KukaLocationsAktuellMulti.Clear();
                    KukaLocation.MatrixLocationsAktuell.Clear();
                    KukaLocation.LocationsAktuellString.Clear();
                    KukaLocation.LocationsAuswahlString.Clear();
                    KukaLocation.KUKA_Header.Clear();
                    KukaLocation.KUKA_Header_clean.Clear();
                    KukaLocation.KUKA_Sorted.Clear();
                    KukaLocation.SortLocationsMisc.Clear();
                    KukaLocation.SortLocationsFromSrc.Clear();
                    KukaLocation.SortLocationsE6POS.Clear();
                    KukaLocation.SortLocationsVW.Clear();
                    KukaLocation.SortLocationsFDAT.Clear();
                    KukaLocation.SortLocationsPLDAT.Clear();
                    KukaLocation.SrcInLines.Clear();
                    KukaLocation.DatInNames.Clear();
                    KukaLocation.DatInLines.Clear();
                    KukaLocation.ExistingNames.Clear();
                    KukaLocation.MissingNames.Clear();
                    KukaLocation.SrcExistingVariables.Clear();

                    DateiOrtDat = files;
                    DateiOrtSrc = DateiOrtDat.Replace(".dat", ".src");

                    KukaLocation.LocationSplit_File();
                    InfoBox finish1 = new InfoBox();
                    finish1.Owner = Application.Current.MainWindow;
                    finish1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    finish1.InfoBox_Text.Content = "Datei ist eingelesen \n" + DateiOrtDat;
                    finish1.OK_Button.Visibility = Visibility.Visible;
                    finish1.Abbruch_Button.Visibility = Visibility.Hidden;
                    finish1.Manual_Button.Visibility = Visibility.Hidden;
                    if (SpezialAblauf)
                    {

                    }
                    else
                    {
                        finish1.ShowDialog();
                    }

                    // Konfiguration der DialogBox
                    InfoBox reinigen = new InfoBox();
                    reinigen.Owner = Application.Current.MainWindow;
                    reinigen.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    reinigen.InfoBox_Text.Content = "Soll die .dat Datei Bereinigt werden?\n" +
                                                    "Es werden alle Deklaration entfernt, die nicht in \n" +
                                                    "der .src benutzt werden\n" +
                                                    "Die Original-Datei wird im Ursprungsordner mit" +
                                                    ".bak gebackupt!\n" +
                                                    "Diese Funktion bitte mit Vorsicht benutzen!";
                    reinigen.OK_Button.Visibility = Visibility.Visible;
                    reinigen.Abbruch_Button.Visibility = Visibility.Visible;
                    reinigen.Manual_Button.Visibility = Visibility.Hidden;
                    if (SpezialAblauf)
                    {

                    }
                    else
                    {
                        reinigen.ShowDialog();
                    }

                    // Verarbeiten des Dialoges
                    try
                    {

                        if (reinigen.OK || SpezialAblauf)
                        {

                            KukaLocation.Bereinigen_Read();
                            string DateiOrtBak = DateiOrtDat.Replace(".dat", ".bak");
                            KukaLocation.MissingNames = KukaLocation.DatInNames.Except(KukaLocation.ExistingNames).ToList();
                            foreach (var line in KukaLocation.SrcInLines)
                            {
                                string[] split;
                                split = line.Split(' ', ',', '=');
                                foreach (var name in KukaLocation.DatInNames)
                                {
                                    if (Regex.IsMatch(line, "\\b" + name + "\\b", RegexOptions.IgnoreCase))
                                    //if (line.CaseInsensitiveContains(name))
                                    {
                                        KukaLocation.ExistingNames.Add(name);
                                    }

                                }
                            }
                            KukaLocation.MissingNames = KukaLocation.DatInNames.Except(KukaLocation.ExistingNames).ToList();

                            File.WriteAllLines(DateiOrtBak, KukaLocation.DatInLines);

                            for (int i = KukaLocation.DatInLines.Count - 1; i >= 0; i--)
                            {
                                foreach (var nv in KukaLocation.MissingNames)
                                {
                                    if (Regex.IsMatch(KukaLocation.DatInLines[i], "\\b" + nv + "\\b", RegexOptions.IgnoreCase))
                                    //    if (KukaLocation.DatInLines[i].Contains(nv))
                                    {
                                        if (!Misc.CaseInsensitiveContains(KukaLocation.DatInLines[i], "SUCCESS"))
                                            if (!Misc.CaseInsensitiveContains(KukaLocation.DatInLines[i], "global"))
                                                KukaLocation.DatInLines.RemoveAt(i);
                                    }
                                }
                            }

                            if (KukaLocation.DatInLines.Any())
                            {
                                File.WriteAllLines(DateiOrtDat, KukaLocation.DatInLines);

                                InfoBox finish2 = new InfoBox();
                                finish2.Owner = Application.Current.MainWindow;
                                finish2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                                finish2.InfoBox_Text.Content = "Datei wurde bereinigt " + DateiOrtDat;
                                finish2.OK_Button.Visibility = Visibility.Visible;
                                finish2.Abbruch_Button.Visibility = Visibility.Hidden;
                                finish2.Manual_Button.Visibility = Visibility.Hidden;
                                if (SpezialAblauf)
                                {

                                }
                                else
                                {
                                    finish2.ShowDialog();
                                }
                            }
                        }
                        if (reinigen.Abbruch)
                        {
                            InfoBox finish3 = new InfoBox();
                            finish3.Owner = Application.Current.MainWindow;
                            finish3.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            finish3.InfoBox_Text.Content = "Bereinigung wurde abgebrochen";
                            finish3.OK_Button.Visibility = Visibility.Visible;
                            finish3.Abbruch_Button.Visibility = Visibility.Hidden;
                            finish3.Manual_Button.Visibility = Visibility.Hidden;
                            finish3.ShowDialog();
                        }

                    }
                    catch (FileNotFoundException)
                    {
                        InfoBox error = new InfoBox();
                        error.Owner = Application.Current.MainWindow;
                        error.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        error.InfoBox_Text.Content = "Datei wurde nicht gefunden: " + DateiOrtSrc + "!\n" +
                                                     "Die .dat konnte nicht bereinigt werden!";
                        error.OK_Button.Visibility = Visibility.Visible;
                        error.Abbruch_Button.Visibility = Visibility.Hidden;
                        error.Manual_Button.Visibility = Visibility.Hidden;
                        error.ShowDialog();

                    }
                    catch (NullReferenceException)
                    {
                        return;
                    }
                    DateiOrtDat = files;
                    KukaLocation.SortQuestion();
                }
                InfoBox CompleteFinish = new InfoBox();
                CompleteFinish.Owner = Application.Current.MainWindow;
                CompleteFinish.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                CompleteFinish.InfoBox_Text.Content = "Es wurden " + fop.FileNames.Length + " sortiert";
                CompleteFinish.OK_Button.Visibility = Visibility.Visible;
                CompleteFinish.Abbruch_Button.Visibility = Visibility.Hidden;
                CompleteFinish.Manual_Button.Visibility = Visibility.Hidden;
                CompleteFinish.ShowDialog();

            }
            SpezialAblauf = false;
            return;
        }

        private void Button_Ausgeben(object sender, RoutedEventArgs e)
        {

            //Umwandeln von Location Objekten zu
            //String Objekten die vom Roboter gelesen werden können
            KukaLocation.KukaListeToFile(KukaLocation.KukaLocationsAktuell);

			//Testsyntax für bestFit Test
            //Operation.bestFit(KukaLocation.KukaLocationsAktuell);

            //löschen der letzten Datei
            File.Delete("tmpOutputKuka.src");

            //Initialisieren der neuen Datei
            using (var file = new StreamWriter("tmpOutputKuka.src"))
            {
                //Schreiben in die Datei
                //je Zeile ein String Objekt der Liste
                KukaLocation.LocationsAktuellString.ForEach(v => file.WriteLine(v));
            }

            //Öffnen der Datei mit dem festgelegten "StandartProgramm" des Betriebssystemes
            Process.Start("tmpOutputKuka.src");

        }

        private void Button_Bereinigen(object sender, RoutedEventArgs e)
        {
            // Konfiguration der DialogBox
            InfoBox reinigen = new InfoBox();
            reinigen.Owner = Application.Current.MainWindow;
            reinigen.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            reinigen.InfoBox_Text.Content = "Soll die .dat Datei Bereinigt werden?\n" +
                                            "Es werden alle Deklaration entfernt, die nicht in \n" +
                                            "der .src benutzt werden\n" +
                                            "Die Original-Datei wird im Ursprungsordner mit" + 
                                            ".bak gebackupt!\n" +
                                            "Diese Funktion bitte mit Vorsicht benutzen!";
            reinigen.OK_Button.Visibility = Visibility.Visible;
            reinigen.Abbruch_Button.Visibility = Visibility.Visible;
            reinigen.Manual_Button.Visibility = Visibility.Hidden;
            reinigen.ShowDialog();

            // Verarbeiten des Dialoges
            try
            {

                if (reinigen.OK)
                {

                    KukaLocation.Bereinigen_Read();
                    string DateiOrtBak = DateiOrtDat.Replace(".dat", ".bak");
                    KukaLocation.MissingNames = KukaLocation.DatInNames.Except(KukaLocation.ExistingNames).ToList();
                    foreach (var line in KukaLocation.SrcInLines)
                    {
                        string[] split;
                        split = line.Split(' ', ',', '=');
                        foreach (var name in KukaLocation.DatInNames)
                        {
                            if (Regex.IsMatch(line, "\\b"+ name + "\\b", RegexOptions.IgnoreCase))
                            //if (line.CaseInsensitiveContains(name))
                            {
                                KukaLocation.ExistingNames.Add(name);
                            }

                        }
                    }
                    KukaLocation.MissingNames = KukaLocation.DatInNames.Except(KukaLocation.ExistingNames).ToList();

                    File.WriteAllLines(DateiOrtBak, KukaLocation.DatInLines);

                    for (int i = KukaLocation.DatInLines.Count - 1; i >= 0; i--)
                    {
                        foreach (var nv in KukaLocation.MissingNames)
                        {
                            if (Regex.IsMatch(KukaLocation.DatInLines[i], "\\b" + nv + "\\b", RegexOptions.IgnoreCase))
                            //    if (KukaLocation.DatInLines[i].Contains(nv))
                            {
                                if (!Misc.CaseInsensitiveContains(KukaLocation.DatInLines[i], "SUCCESS"))
                                    if (!Misc.CaseInsensitiveContains(KukaLocation.DatInLines[i], "global"))
                                        KukaLocation.DatInLines.RemoveAt(i);
                            }
                        }
                    }

                    if (KukaLocation.DatInLines.Any())
                    {
                        File.WriteAllLines(DateiOrtDat, KukaLocation.DatInLines);

                        InfoBox finish = new InfoBox();
                        finish.Owner = Application.Current.MainWindow;
                        finish.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        finish.InfoBox_Text.Content = "Datei wurde bereinigt " + DateiOrtDat;
                        finish.OK_Button.Visibility = Visibility.Visible;
                        finish.Abbruch_Button.Visibility = Visibility.Hidden;
                        finish.Manual_Button.Visibility = Visibility.Hidden;
                        finish.Show();
                    }
                }
                if (reinigen.Abbruch)
                {
                    InfoBox finish = new InfoBox();
                    finish.Owner = Application.Current.MainWindow;
                    finish.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    finish.InfoBox_Text.Content = "Bereinigung wurde abgebrochen";
                    finish.OK_Button.Visibility = Visibility.Visible;
                    finish.Abbruch_Button.Visibility = Visibility.Hidden;
                    finish.Manual_Button.Visibility = Visibility.Hidden;
                    finish.Show();
                }

            }
            catch (FileNotFoundException)
            {
                InfoBox error = new InfoBox();
                error.Owner = Application.Current.MainWindow;
                error.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                error.InfoBox_Text.Content = "Datei wurde nicht gefunden: " + DateiOrtSrc + "!\n" +
                                             "Die .dat konnte nicht bereinigt werden!";
                error.OK_Button.Visibility = Visibility.Visible;
                error.Abbruch_Button.Visibility = Visibility.Hidden;
                error.Manual_Button.Visibility = Visibility.Hidden;
                error.Show();

            }
            catch(NullReferenceException)
            {
                return;
            }
        }

        private void Button_Sortieren(object sender, RoutedEventArgs e)
        {
            DateiOrtDat = DateiZiel.Text;
            KukaLocation.SortQuestion();
        }

        //Event Methode für den XYZShift Button
        public void XYZShiftButton(object sender, EventArgs e)
        {

            //leeren der Zwischenspeicher KukaLocation Liste
            KukaLocation.KukaLocationsAktuellShift.Clear();

            //Merker für den OK-Button des XYZShift Fensters zurücksetzen
            XYZShift.XYZOK = false;

            //Zwischenspeichern der KukaLocation Liste
            foreach (var item in KukaLocation.KukaLocationsAktuell)
                //Verschieben jedes Listen Elementes mit den X/Y/Y Werten des XYZShift Fensters
                KukaLocation.KukaLocationsAktuellShift.Add(Operation.XYZShiftKukaLocation(item, XYZShift.XValue, XYZShift.YValue, XYZShift.ZValue));

            //Umwandeln von Location Objekten zu
            //String Objekten die vom Roboter gelesen werden können
            KukaLocation.KukaListeToFile(KukaLocation.KukaLocationsAktuellShift);

            //löschen der letzten Datei
            File.Delete("tmpOutputKukaShift.src");

            //Initialisieren der neuen Datei
            using (var file = new StreamWriter("tmpOutputKukaShift.src"))
            {
                //Schreiben in die Datei
                //je Zeile ein String Objekt der Liste
                KukaLocation.LocationsAktuellString.ForEach(v => file.WriteLine(v));
            }

            //Öffnen der Datei mit dem festgelegten "StandartProgramm" des Betriebssystemes
            Process.Start("tmpOutputKukaShift.src");

        }

        //Methode für den XYZShift Button
        public void XYZShift_Click(object sender, RoutedEventArgs e)
        {
            //Initialisieren des XYZShift Fensters
            XYZShift xyzShift = new XYZShift();
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

                //leeren der Zwischenspeicher KukaLocation Liste
                KukaLocation.KukaLocationsAktuellShift.Clear();

                //Merker für den OK-Button des XYZShift Fensters zurücksetzen
                XYZShift.XYZOK = false;

                //Zwischenspeichern der KukaLocation Liste
                foreach (var item in KukaLocation.KukaLocationsAktuell)
                    //Verschieben jedes Listen Elementes mit den X/Y/Y Werten des XYZShift Fensters
                    KukaLocation.KukaLocationsAktuellShift.Add(Operation.XYZShiftKukaLocation(item, XYZShift.XValue, XYZShift.YValue, XYZShift.ZValue));

                //Umwandeln von Location Objekten zu
                //String Objekten die vom Roboter gelesen werden können
                KukaLocation.KukaListeToFile(KukaLocation.KukaLocationsAktuellShift);

                //löschen der letzten Datei
                File.Delete("tmpOutputKukaShift.src");

                //Initialisieren der neuen Datei
                using (var file = new StreamWriter("tmpOutputKukaShift.src"))
                {
                    //Schreiben in die Datei
                    //je Zeile ein String Objekt der Liste
                    KukaLocation.LocationsAktuellString.ForEach(v => file.WriteLine(v));
                }

                //Öffnen der Datei mit dem festgelegten "StandartProgramm" des Betriebssystemes
                Process.Start("tmpOutputKukaShift.src");

            }
        }
        public static void Mirror()
        {
            KukaLocation kukaLocation;
            foreach (var l in KukaLocation.KukaLocationsAktuell)
            {
                kukaLocation = new KukaLocation(Operation.MirrorLocation(l));
                KukaLocation.KukaLocationsAktuellMirror.Add(kukaLocation);
            }

        }

        private void Mirror_Click(object sender, RoutedEventArgs e)
        {
            //Zwischenspeichern der KukaLocation Liste
            foreach (var item in KukaLocation.KukaLocationsAktuell)
                //Verschieben jedes Listen Elementes mit den X/Y/Y Werten des XYZShift Fensters
                KukaLocation.KukaLocationsAktuellMirror.Add(Operation.MirrorLocation(KukaLocation.MirrorOverX, item));
            //Umwandeln von Location Objekten zu
            //String Objekten die vom Roboter gelesen werden können
            KukaLocation.KukaListeToFile(KukaLocation.KukaLocationsAktuellMirror);

            //löschen der letzten Datei
            File.Delete("tmpOutputKukaMirror.src");

            //Initialisieren der neuen Datei
            using (var file = new StreamWriter("tmpOutputKukaMirror.src"))
            {
                //Schreiben in die Datei
                //je Zeile ein String Objekt der Liste
                KukaLocation.LocationsAktuellString.ForEach(v => file.WriteLine(v));
            }

            //Öffnen der Datei mit dem festgelegten "StandartProgramm" des Betriebssystemes
            Process.Start("tmpOutputKukaMirror.src");


        }
        //Event Methode für den XYZShift Button
        public void MultiButton(object sender, EventArgs e)
        {
            KukaLocation kukaLocation;
            KukaLocation kukalocationInv;

            //leeren der Zwischenspeicher KukaLocation Liste
            KukaLocation.KukaLocationsAktuellMulti.Clear();

            //Merker für den OK-Button des XYZShift Fensters zurücksetzen
            Hand2nd.MulitOK = false;

            //Zwischenspeichern der KukaLocation Liste
            //Zwischenspeichern der KukaLocation Liste
            foreach (var item in KukaLocation.KukaLocationsAktuell)
                //Verschieben jedes Listen Elementes mit den X/Y/Y Werten des XYZShift Fensters
                
                //Changed for transformation from Location in files over a base 20200721
                //wrong order of matrix multiplication
                //KukaLocation.KukaLocationsAktuellMulti.Add(kukaLocation = new KukaLocation(Operation.MultiLocation(Hand2nd.kukaLocation, item)));
                KukaLocation.KukaLocationsAktuellMulti.Add(kukaLocation = new KukaLocation(Operation.MultiLocation(item, Hand2nd.kukaLocation)));

                //Umwandeln von Location Objekten zu
                //String Objekten die vom Roboter gelesen werden können
                KukaLocation.KukaListeToFile(KukaLocation.KukaLocationsAktuellMulti);

            //löschen der letzten Datei
            File.Delete("tmpOutputKukaMulti.src");

            //Initialisieren der neuen Datei
            using (var file = new StreamWriter("tmpOutputKukaMulti.src"))
            {
                //Schreiben in die Datei
                //je Zeile ein String Objekt der Liste
                KukaLocation.LocationsAktuellString.ForEach(v => file.WriteLine(v));
            }

            //Öffnen der Datei mit dem festgelegten "StandartProgramm" des Betriebssystemes
            Process.Start("tmpOutputKukaMulti.src");

        }

        private void Multi_Click(object sender, RoutedEventArgs e)
        {
            KukaLocation kukaLocation;
            //Initialisieren des XYZShift Fensters
            Hand2nd hand2nd = new Hand2nd();
            hand2nd.MultiLocationEinlesen += MultiButton;

            //Überprüfen, ob schon ein XYZShift Fenster geöffnet ist
            if (Hand2nd.MultiOpen == false && Hand2nd.MulitOK == false)
            {
                // öffnet ein XYZShift Fenster
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

                //leeren der Zwischenspeicher KukaLocation Liste
                KukaLocation.KukaLocationsAktuellMulti.Clear();

                //Merker für den OK-Button des XYZShift Fensters zurücksetzen
                Hand2nd.MulitOK = false;

                //Zwischenspeichern der KukaLocation Liste
                foreach (var item in KukaLocation.KukaLocationsAktuell)
                    //Verschieben jedes Listen Elementes mit den X/Y/Y Werten des XYZShift Fensters
                    KukaLocation.KukaLocationsAktuellMulti.Add(kukaLocation = new KukaLocation(Operation.MultiLocation(Hand2nd.kukaLocation, item)));

                //Umwandeln von Location Objekten zu
                //String Objekten die vom Roboter gelesen werden können
                KukaLocation.KukaListeToFile(KukaLocation.KukaLocationsAktuellMulti);

                //löschen der letzten Datei
                File.Delete("tmpOutputKukaMulti.src");

                //Initialisieren der neuen Datei
                using (var file = new StreamWriter("tmpOutputKukaMulti.src"))
                {
                    //Schreiben in die Datei
                    //je Zeile ein String Objekt der Liste
                    KukaLocation.LocationsAktuellString.ForEach(v => file.WriteLine(v));
                }

                //Öffnen der Datei mit dem festgelegten "StandartProgramm" des Betriebssystemes
                Process.Start("tmpOutputKukaMulti.src");

            }
        }
        //Event Methode für den XYZShift Button
        public void RelToolButton(object sender, EventArgs e)
        {
            KukaLocation kukaLocation;

            //leeren der Zwischenspeicher KukaLocation Liste
            KukaLocation.KukaLocationsAktuellMulti.Clear();

            //Merker für den OK-Button des XYZShift Fensters zurücksetzen
            XYZShift.XYZOK = false;

            //Zwischenspeichern der KukaLocation Liste
            foreach (var item in KukaLocation.KukaLocationsAktuell)
                //Verschieben jedes Listen Elementes mit den X/Y/Y Werten des XYZShift Fensters
                KukaLocation.KukaLocationsAktuellMulti.Add(kukaLocation = new KukaLocation(
                    Operation.RelToolLocation(XYZShift.matrixLocationRelValue, item)));

            //Umwandeln von Location Objekten zu
            //String Objekten die vom Roboter gelesen werden können
            KukaLocation.KukaListeToFile(KukaLocation.KukaLocationsAktuellMulti);

            //löschen der letzten Datei
            File.Delete("tmpOutputKukaMulti.src");

            //Initialisieren der neuen Datei
            using (var file = new StreamWriter("tmpOutputKukaMulti.src"))
            {
                //Schreiben in die Datei
                //je Zeile ein String Objekt der Liste
                KukaLocation.LocationsAktuellString.ForEach(v => file.WriteLine(v));
            }

            //Öffnen der Datei mit dem festgelegten "StandartProgramm" des Betriebssystemes
            Process.Start("tmpOutputKukaMulti.src");

        }

        private void RelTool_Click(object sender, RoutedEventArgs e)
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
                xyzShift.Show();
                xyzShift.X.Focus();

            }

            // überprüfen, ob der OK-Butten in einem XYZShift Fenster 
            // gedrückt wurde
            if (XYZShift.XYZOK == true)
            {

                //leeren der Zwischenspeicher KukaLocation Liste
                KukaLocation.KukaLocationsAktuellMulti.Clear();

                //Merker für den OK-Button des XYZShift Fensters zurücksetzen
                XYZShift.XYZOK = false;

                //Zwischenspeichern der KukaLocation Liste
                foreach (var item in KukaLocation.KukaLocationsAktuell)
                    //Verschieben jedes Listen Elementes mit den X/Y/Y Werten des XYZShift Fensters
                    KukaLocation.KukaLocationsAktuellMulti.Add(kukaLocation = new KukaLocation(Operation.RelToolLocation(XYZShift.matrixLocationRelValue, item)));

                    //Umwandeln von Location Objekten zu
                    //String Objekten die vom Roboter gelesen werden können
                    KukaLocation.KukaListeToFile(KukaLocation.KukaLocationsAktuellMulti);

                //löschen der letzten Datei
                File.Delete("tmpOutputKukaMulti.src");

                //Initialisieren der neuen Datei
                using (var file = new StreamWriter("tmpOutputKukaMulti.src"))
                {
                    //Schreiben in die Datei
                    //je Zeile ein String Objekt der Liste
                    KukaLocation.LocationsAktuellString.ForEach(v => file.WriteLine(v));
                }

                //Öffnen der Datei mit dem festgelegten "StandartProgramm" des Betriebssystemes
                Process.Start("tmpOutputKukaMulti.src");

            }
        }
    }
}
