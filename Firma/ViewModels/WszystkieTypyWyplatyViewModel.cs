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
    public class WszystkieTypyWyplatyViewModel : WszystkieViewModel<TypWyplaty>
    {
        #region Konstruktor
        public WszystkieTypyWyplatyViewModel()
            : base("Typy wypłaty")
        {
        }
        #endregion
        #region Helpers

        protected override void Load()
        {
            List = new ObservableCollection<TypWyplaty>
                (
                from typWyplaty in ProjektDesktopyEntities.TypWyplaty
                where typWyplaty.CzyAktywny == true || typWyplaty.CzyAktywny != CzyNieaktywne
                select typWyplaty
                );
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa" };
        }

        protected override List<string> getSortComboBoxItems()
        {
            return new List<string>() { "Nazwa", "Skrót" };
        }

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Nazwa":
                        List = new ObservableCollection<TypWyplaty>(List.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<TypWyplaty>(List);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<TypWyplaty>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
                case "Skrót":
                    List = new ObservableCollection<TypWyplaty>(SortDescending ? List.OrderByDescending(item => item.Skrot) : List.OrderBy(item => item.Skrot));
                    break;
            }
        }
        #endregion
    }
}
