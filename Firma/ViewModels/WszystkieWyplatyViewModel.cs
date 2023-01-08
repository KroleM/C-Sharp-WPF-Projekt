using Firma.Models.Entities;
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
                        Id = wyplata.Id,
                        PracownikImieNazwisko = wyplata.Pracownik.Imie + " " + wyplata.Pracownik.Nazwisko,
                        TypWyplatyNazwa = wyplata.TypWyplaty.Nazwa,
                        Kwota = wyplata.Kwota,
                        Waluta = wyplata.Waluta,
                        DataOd = wyplata.OkresOd,
                        DataDo = wyplata.OkresDo,

                        Nazwa = wyplata.Nazwa,
                        CzyAktywny = wyplata.CzyAktywny,
                        DataUtworzenia = wyplata.DataUtworzenia,
                        DataModyfikacji = wyplata.DataModyfikacji,
                        KtoUtworzyl = wyplata.KtoUtworzyl,
                        KtoZmodyfikowal = wyplata.KtoZmodyfikowal,
                        Notatki = wyplata.Notatki
                    }
                );
        }
        #endregion
    }
}
