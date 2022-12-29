using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class WszystkieWyplatyViewModel : WszystkieViewModel<WyplataForAllView>
    {
        #region Konstruktor
        public WszystkieWyplatyViewModel()
            :base("Wszystkie wypłaty")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<WyplataForAllView>
                (
                    from wyplata in ProjektDesktopyEntities.Wyplata
                    select new WyplataForAllView
                    {
                        IdWyplaty = wyplata.Id,
                        PracownikImieNazwisko = wyplata.Pracownik.Imie + " " + wyplata.Pracownik.Nazwisko,
                        IdPracownika = wyplata.Pracownik.Id,
                        TypWyplatyNazwa = wyplata.TypWyplaty.Nazwa,
                        Kwota = wyplata.Kwota,
                        Waluta = wyplata.Waluta,
                        DataOd = wyplata.OkresOd,
                        DataDo = wyplata.OkresDo
                    }
                );
        }
        #endregion
    }
}
