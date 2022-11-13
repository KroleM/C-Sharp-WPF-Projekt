using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class WszystkieGrupyRabatoweViewModel : WszystkieViewModel<GrupaRabatowa>
    {
        #region Konstruktor
        public WszystkieGrupyRabatoweViewModel()
            : base("Grupy rabatowe")
        {
        }
        #endregion
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<GrupaRabatowa>
                (
                //zapytanie LINQ (obiektowa wersja SQL)
                from grupa in FakturyEntities.GrupaRabatowa // dla każdego typu umowy z tabeli TypUmowy (w SQL: select * from TypUmowy)
                where grupa.CzyAktywny == true
                select grupa    //wybierz typ umowy
                );
        }
        #endregion
    }
}
