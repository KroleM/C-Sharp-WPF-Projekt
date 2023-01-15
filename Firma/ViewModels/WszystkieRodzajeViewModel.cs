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
            : base("Rodzaje kontrahentów")
        {
        }
        #endregion
        #region Helpers

        protected override void Load()
        {
            List = new ObservableCollection<RodzajKontrahenta>
                (
                //zapytanie LINQ (obiektowa wersja SQL)
                from rodzaj in ProjektDesktopyEntities.RodzajKontrahenta
                where rodzaj.CzyAktywny == true
                select rodzaj
                );
        }
        #endregion
    }
}
