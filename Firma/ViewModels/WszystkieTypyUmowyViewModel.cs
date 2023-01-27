using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                where typUmowy.CzyAktywny == true || typUmowy.CzyAktywny != CzyNieaktywne
                select typUmowy    //wybierz typ umowy
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
                        List = new ObservableCollection<TypUmowy>(List.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<TypUmowy>(List);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<TypUmowy>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
                case "Skrót":
                    List = new ObservableCollection<TypUmowy>(SortDescending ? List.OrderByDescending(item => item.Skrot) : List.OrderBy(item => item.Skrot));
                    break;
            }
        }
        #endregion
    }
}
