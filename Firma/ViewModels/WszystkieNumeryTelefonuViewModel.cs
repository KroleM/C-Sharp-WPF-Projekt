using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Firma.ViewModels
{
    public class WszystkieNumeryTelefonuViewModel : WszystkieViewModel<NumerTelefonuForAllView>
    {
        #region Konstruktor
        public WszystkieNumeryTelefonuViewModel() : base("Numery telefonów")
        {
        }
        #endregion
        #region Helpers
        protected override void Load()
        {
            List = new ObservableCollection<NumerTelefonuForAllView>
                (
                    from numerTel in ProjektDesktopyEntities.NumerTelefonu
                    where numerTel.CzyAktywny == true || numerTel.CzyAktywny != CzyNieaktywne
                    select new NumerTelefonuForAllView
                    {
                        Id = numerTel.Id,
                        Numer = numerTel.Numer,
                        Kraj = numerTel.Kraj,
                        Pracownik = numerTel.Pracownik.Nazwa,

                        Nazwa = numerTel.Nazwa,
                        CzyAktywny = numerTel.CzyAktywny,
                        DataUtworzenia = numerTel.DataUtworzenia,
                        DataModyfikacji = numerTel.DataModyfikacji,
                        KtoUtworzyl = numerTel.KtoUtworzyl,
                        KtoZmodyfikowal = numerTel.KtoZmodyfikowal,
                        Notatki = numerTel.Notatki
                    }
                );
            AllList = new List<NumerTelefonuForAllView>(List);
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Kraj" };
        }

        protected override List<string> getSortComboBoxItems()
        {
            return new List<string>() { "Kraj" };
        }

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Kraj":
                        List = new ObservableCollection<NumerTelefonuForAllView>(AllList.Where(item => item.Kraj?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<NumerTelefonuForAllView>(AllList);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Kraj":
                    // obsługa sortowania rosnąco i malejąco
                    List = new ObservableCollection<NumerTelefonuForAllView>(SortDescending ? List.OrderByDescending(item => item.Kraj) : List.OrderBy(item => item.Kraj));
                    break;
            }
        }
        #endregion
    }
}
