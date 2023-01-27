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
    public class WszystkieGrupyRabatoweViewModel : WszystkieViewModel<GrupaRabatowa>
    {
        #region Konstruktor
        public WszystkieGrupyRabatoweViewModel()
            : base("Grupy rabatowe")
        {
        }
        #endregion
        #region Helpers

        protected override void Load()
        {
            List = new ObservableCollection<GrupaRabatowa>
                (
                //zapytanie LINQ (obiektowa wersja SQL)
                from grupa in ProjektDesktopyEntities.GrupaRabatowa // dla każdego typu umowy z tabeli TypUmowy (w SQL: select * from TypUmowy)
                where grupa.CzyAktywny == true || grupa.CzyAktywny != CzyNieaktywne 
                select grupa    //wybierz typ umowy
                );
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa" };
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
                        List = new ObservableCollection<GrupaRabatowa>(List.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<GrupaRabatowa>(List);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    // obsługa sortowania rosnąco i malejąco
                    List = new ObservableCollection<GrupaRabatowa>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
            }
        }
        #endregion
    }
}
