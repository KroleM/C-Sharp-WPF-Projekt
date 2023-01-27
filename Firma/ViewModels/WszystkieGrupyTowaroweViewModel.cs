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
    public class WszystkieGrupyTowaroweViewModel : WszystkieViewModel<GrupaTowarowaForAllView>
    {
        #region Konstruktor
        public WszystkieGrupyTowaroweViewModel()
            : base("Grupy towarowe")
        {
        }
        #endregion
        #region Helpers
        protected override void Load()
        {
            List = new ObservableCollection<GrupaTowarowaForAllView>
                (
                    from grupaTow in ProjektDesktopyEntities.GrupaTowarowa
                    where grupaTow.CzyAktywny == true || grupaTow.CzyAktywny != CzyNieaktywne
                    select new GrupaTowarowaForAllView
                    {
                        Id = grupaTow.Id,
                        Kod = grupaTow.Kod,
                        GrupaNadrzednaId = grupaTow.GrupaNadrzednaId,
                        GrupaNadrzednaNazwa = grupaTow.GrupaTowarowa2.Nazwa,

                        Nazwa = grupaTow.Nazwa,
                        CzyAktywny = grupaTow.CzyAktywny,
                        DataUtworzenia = grupaTow.DataUtworzenia,
                        DataModyfikacji = grupaTow.DataModyfikacji,
                        KtoUtworzyl = grupaTow.KtoUtworzyl,
                        KtoZmodyfikowal = grupaTow.KtoZmodyfikowal,
                        Notatki = grupaTow.Notatki
                    }
                );
            AllList = new List<GrupaTowarowaForAllView>(List);
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa" };
        }

        protected override List<string> getSortComboBoxItems()
        {
            return new List<string>() { "Nazwa", "ID grupy nadrzędnej" };
        }

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Nazwa":
                        List = new ObservableCollection<GrupaTowarowaForAllView>(AllList.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<GrupaTowarowaForAllView>(AllList);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    // obsługa sortowania rosnąco i malejąco
                    List = new ObservableCollection<GrupaTowarowaForAllView>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
                case "ID grupy nadrzędnej":
                    List = new ObservableCollection<GrupaTowarowaForAllView>(SortDescending ? List.OrderByDescending(item => item.GrupaNadrzednaId) : List.OrderBy(item => item.GrupaNadrzednaId));
                    break;
            }
        }
        #endregion
    }
}
