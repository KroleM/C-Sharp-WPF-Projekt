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
    public class WszystkieRynkiViewModel : WszystkieViewModel<Rynek>
    {
        #region Konstruktor
        public WszystkieRynkiViewModel()
            : base("Rynki")
        {
        }
        #endregion
        #region Helpers

        protected override void Load()
        {
            List = new ObservableCollection<Rynek>
                (ProjektDesktopyEntities.Rynek.Where(arg => arg.CzyAktywny == true || arg.CzyAktywny != CzyNieaktywne).ToList());
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
                        List = new ObservableCollection<Rynek>(List.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<Rynek>(List);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    // obsługa sortowania rosnąco i malejąco
                    List = new ObservableCollection<Rynek>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
            }
        }
        #endregion
    }
}
