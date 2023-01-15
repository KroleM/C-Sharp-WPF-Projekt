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

        protected override void Load()
        {
            List = new ObservableCollection<Rynek>
                (
                //zapytanie LINQ (obiektowa wersja SQL)
                from rynek in ProjektDesktopyEntities.Rynek
                where rynek.CzyAktywny == true
                select rynek
                );
        }
        #endregion
    }
}
