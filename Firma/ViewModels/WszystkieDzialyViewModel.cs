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
    public class WszystkieDzialyViewModel : WszystkieViewModel<Dzial>
    {
        #region Konstruktor
        public WszystkieDzialyViewModel()
            : base("Działy")
        {
        }
        #endregion
        #region Helpers

        protected override void Load()
        {
            List = new ObservableCollection<Dzial>
                (
                from dzial in ProjektDesktopyEntities.Dzial
                where dzial.CzyAktywny == true || dzial.CzyAktywny != CzyNieaktywne
                select dzial
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
                        List = new ObservableCollection<Dzial>(List.Where(item => item.Nazwa?.Contains(SearchText) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<Dzial>(List);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    // obsługa sortowania rosnąco i malejąco
                    List = new ObservableCollection<Dzial>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
            }
            //throw new NotImplementedException();
        }
        #endregion
    }
}
