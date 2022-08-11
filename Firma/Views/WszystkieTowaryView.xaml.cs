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

namespace Firma.Views
{
    /// <summary>
    /// Interaction logic for WszystkieTowaryView.xaml
    /// </summary>
    public partial class WszystkieTowaryView : UserControl
    {
        public WszystkieTowaryView()
        {
            InitializeComponent();
        }

        private void BZamowienia(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Po kliknięciu tego przycisku pojawi się tabela produktów dla celów zamówień (zaprojektowana poniżej).");               
        }
        private void BSprzedaz(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Po kliknięciu tego przycisku pojawi się tabela produktów dla celów sprzedaży.");
        }
        private void BMagazyn(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Po kliknięciu tego przycisku pojawi się tabela produktów dla celów operacji magazynowych.");
        }

    }
}
