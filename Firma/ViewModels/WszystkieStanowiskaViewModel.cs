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
    public class WszystkieStanowiskaViewModel : WszystkieViewModel<Stanowisko>
    {
        #region Konstruktor
        public WszystkieStanowiskaViewModel()
            : base("Stanowiska")
        {
        }
        #endregion
        #region Helpers

        protected override void Load()
        {
            List = new ObservableCollection<Stanowisko>
                (
                from stanowisko in ProjektDesktopyEntities.Stanowisko
                where stanowisko.CzyAktywny == true || stanowisko.CzyAktywny != CzyNieaktywne
                select stanowisko
                );
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa", "Kategoria" };
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
                        List = new ObservableCollection<Stanowisko>(List.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                    case "Kategoria":
                        List = new ObservableCollection<Stanowisko>(List.Where(item => item.Kategoria?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<Stanowisko>(List);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<Stanowisko>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
            }
        }
        #endregion
    }
}
