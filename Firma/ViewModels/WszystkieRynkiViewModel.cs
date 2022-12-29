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
    public class WszystkieRynkiViewModel : WszystkieViewModel<Rynek>
    {
        #region Konstruktor
        public WszystkieRynkiViewModel()
            : base("Rynki")
        {
        }
        #endregion
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<Rynek>
                (
                //zapytanie LINQ (obiektowa wersja SQL)
                from rynek in ProjektDesktopyEntities.Rynek // dla każdego typu umowy z tabeli TypUmowy (w SQL: select * from TypUmowy)
                where rynek.CzyAktywny == true
                select rynek    //wybierz typ umowy
                );
        }
        #endregion
    }
}
