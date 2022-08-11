using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class WszystkieTowaryViewModel:WorkspaceViewModel //bo wszystkie zakładki dziedziczą po WorkspaceViewModel
    {
        #region Konstruktor
        public WszystkieTowaryViewModel()
        {
            base.DisplayName = "Wszystkie towary"; //tu ustawiamy nazwę zakładki
        }
        #endregion 
    }
}
