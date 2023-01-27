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
    public class WszystkieZamowieniaViewModel : WszystkieViewModel<ZamowienieForAllView>
    {
        public WszystkieZamowieniaViewModel() : base("Zamówienia")
        {
        }
        protected override void Load()
        {
            List = new ObservableCollection<ZamowienieForAllView>
                (
                    from zamowienie in ProjektDesktopyEntities.Zamowienie
                    where zamowienie.CzyAktywny == true || zamowienie.CzyAktywny != CzyNieaktywne
                    select new ZamowienieForAllView
                    {
                        Id = zamowienie.Id,
                        KontrahentNazwa = zamowienie.Kontrahent.Nazwa,
                        KontrahentGrupaRabatowa = zamowienie.Kontrahent.GrupaRabatowa.Nazwa,    // ???
                        DataWyslania = zamowienie.DataWyslania,

                        Nazwa = zamowienie.Nazwa,
                        CzyAktywny = zamowienie.CzyAktywny,
                        DataUtworzenia = zamowienie.DataUtworzenia,
                        DataModyfikacji = zamowienie.DataModyfikacji,
                        KtoUtworzyl = zamowienie.KtoUtworzyl,
                        KtoZmodyfikowal = zamowienie.KtoZmodyfikowal,
                        Notatki = zamowienie.Notatki
                    }
                );
            AllList = new List<ZamowienieForAllView>(List);
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa kontrahenta" };
        }

        protected override List<string> getSortComboBoxItems()
        {
            return new List<string>() { "Data wysyłki", "ID" };
        }

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Nazwa kontrahenta":
                        List = new ObservableCollection<ZamowienieForAllView>(AllList.Where(item => item.KontrahentNazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<ZamowienieForAllView>(AllList);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Data wysyłki":
                    // obsługa sortowania rosnąco i malejąco
                    List = new ObservableCollection<ZamowienieForAllView>(SortDescending ? List.OrderByDescending(item => item.DataWyslania) : List.OrderBy(item => item.DataWyslania));
                    break;
                case "ID":
                    List = new ObservableCollection<ZamowienieForAllView>(SortDescending ? List.OrderByDescending(item => item.Id) : List.OrderBy(item => item.Id));
                    break;
            }
        }
    }
}
