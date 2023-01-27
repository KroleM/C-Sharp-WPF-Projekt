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
                where rodzaj.CzyAktywny == true || rodzaj.CzyAktywny != CzyNieaktywne
                select rodzaj
                );
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa", "Opis" };
        }

        protected override List<string> getSortComboBoxItems()
        {
            return new List<string>() { "Nazwa" };
        }

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Nazwa":
                        List = new ObservableCollection<RodzajKontrahenta>(List.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                    case "Opis":
                        List = new ObservableCollection<RodzajKontrahenta>(List.Where(item => item.Opis?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<RodzajKontrahenta>(List);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<RodzajKontrahenta>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
            }
        }
        #endregion
    }
}
