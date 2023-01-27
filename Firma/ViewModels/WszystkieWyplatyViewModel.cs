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
        protected override void Load()
        {
            List = new ObservableCollection<WyplataForAllView>
                (
                    from wyplata in ProjektDesktopyEntities.Wyplata
                    where wyplata.CzyAktywny == true || wyplata.CzyAktywny != CzyNieaktywne
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
            AllList = new List<WyplataForAllView>(List);
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa", "PracownikImieNazwisko" };
        }

        protected override List<string> getSortComboBoxItems()
        {
            return new List<string>() { "Kwota", "Data od" };
        }

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Nazwa":
                        List = new ObservableCollection<WyplataForAllView>(AllList.Where(item => item.TypWyplatyNazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                    case "PracownikImieNazwisko":
                        List = new ObservableCollection<WyplataForAllView>(AllList.Where(item => item.PracownikImieNazwisko?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<WyplataForAllView>(AllList);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Kwota":
                    List = new ObservableCollection<WyplataForAllView>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
                case "Data od":
                    List = new ObservableCollection<WyplataForAllView>(SortDescending ? List.OrderByDescending(item => item.DataOd) : List.OrderBy(item => item.DataOd));
                    break;
            }
        }
        #endregion
    }
}
