using Firma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class NowyTowarViewModel: WorkspaceViewModel //wszystkie zakładki dziedziczą po WorkspaceViewModel
    {
        //#region Wlasciwosci
        //private List<TowarCeny> _ceny;
        //public List<TowarCeny> Ceny 
        //{ 
        //    get 
        //    {
        //        _ceny = new List<TowarCeny>();
        //        _ceny.Add(new TowarCeny() { Priorytet = "1"});
        //        _ceny.Add(new TowarCeny() { Priorytet = "2"});
        //        return _ceny;
        //    } 
        //}
        //#endregion
        #region Konstruktor
        public NowyTowarViewModel()
        {
            base.DisplayName = "Towar"; //tu ustawiamy nazwę zakładki
        }
        #endregion
    }
}
