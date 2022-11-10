using System;
using System.Collections.Generic;
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

namespace PunktAnzeigen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Shape ErzeugePunkt(int x, int y)
        {
            Ellipse punkt = new Ellipse();
            punkt.Width = 4;
            punkt.Height = 4;
            punkt.Fill = new SolidColorBrush(Colors.Chocolate);
            Canvas.SetLeft(punkt, x);
            Canvas.SetBottom(punkt, y);
            return punkt;
        }

        private void StatusAusgabe(string msg)
        {
            ausgabeFeld.Content += msg;
        }

        private void AusgabeFeldLoeschen()
        {
            ausgabeFeld.Content = "";
        }

        private void PunktAnzeigen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = Int32.Parse(xKoordinate.Text);
                int y = Int32.Parse(yKoordinate.Text);
                StatusAusgabe($"Punkt (x,y) = {(x, y)} wird gezeichnet\n");
                Shape punkt = ErzeugePunkt(x, y);
                leinwand.Children.Add(punkt);
            }
            catch
            {
                StatusAusgabe($"Fehler bei Eingabe {xKoordinate.Text}, {yKoordinate.Text}\n");
            }
        }

        private void Zurueck_Click(object sender, RoutedEventArgs e)
        {
            // Letztes Element wieder löschen
            if (leinwand.Children.Count > 0)
                leinwand.Children.RemoveAt(leinwand.Children.Count - 1);
        }

        private void AllesLoeschen_Click(object sender, RoutedEventArgs e)
        {
            leinwand.Children.Clear();
            AusgabeFeldLoeschen();
            AusgabeFeldLoeschen();
        }

    }
}
