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
    /// Interaction logic for OperacjeMagazynoweView.xaml
    /// </summary>
    public partial class OperacjeMagazynoweView : UserControl
    {
        public OperacjeMagazynoweView()
        {
            InitializeComponent();
		}
        //Checkboxy "zlecone", "bufor", "zatwierdzone", "wszystkie" - prosty behind code. Aby sterować Modelem potrzebny jest jeszcze kod w warstwie ViewModel - pola, komendy, itp.
        //Checkbox "wszystkie" ma 3 stany (IsThreeState="True"): true, false, null. W tym prostym przykładzie wystarczyłby zwykły dwustanowy checkbox.
        private void cbWszystkie_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbWszystkie.IsChecked == true);
            cbZlecone.IsChecked = newVal;
            cbBufor.IsChecked = newVal;
            cbZatwierdzone.IsChecked = newVal;
        }
        private void cb_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbWszystkie.IsChecked = null;
            if ((cbZlecone.IsChecked == true) && (cbBufor.IsChecked == true) && (cbZatwierdzone.IsChecked == true))
                cbWszystkie.IsChecked = true;
            if ((cbZlecone.IsChecked == false) && (cbBufor.IsChecked == false) && (cbZatwierdzone.IsChecked == false))
                cbWszystkie.IsChecked = false;
        }
    }
}
