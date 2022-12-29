using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class WszystkieRodzajeViewModel : WszystkieViewModel<RodzajKontrahenta>
    {
        #region Konstruktor
        public WszystkieRodzajeViewModel()
            : base("Rodzaje kontrahenta")
        {
        }
        #endregion
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<RodzajKontrahenta>
                (
                //zapytanie LINQ (obiektowa wersja SQL)
                from rodzaj in ProjektDesktopyEntities.RodzajKontrahenta // dla każdego typu umowy z tabeli TypUmowy (w SQL: select * from TypUmowy)
                where rodzaj.CzyAktywny == true
                select rodzaj    //wybierz typ umowy
                );
        }
        #endregion
    }
}
