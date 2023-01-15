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
    public class WszystkieTypyUmowyViewModel : WszystkieViewModel<TypUmowy>
    {
        #region Konstruktor
        public WszystkieTypyUmowyViewModel()
            : base("Typy umowy")
        {
        }
        #endregion
        #region Helpers

        protected override void Load()
        {
            List = new ObservableCollection<TypUmowy>
                (
                //zapytanie LINQ (obiektowa wersja SQL)
                from typUmowy in ProjektDesktopyEntities.TypUmowy // dla każdego typu umowy z tabeli TypUmowy (w SQL: select * from TypUmowy)
                where typUmowy.CzyAktywny == true
                select typUmowy    //wybierz typ umowy
                );
        }
        #endregion
    }
}
