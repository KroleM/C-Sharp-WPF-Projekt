using CommunityToolkit.Mvvm.Messaging;
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
    public class WszyscyKontrahenciViewModel : WszystkieViewModel<KontrahentForAllView>
    {
        #region Pola i Właściwości
        private int _KontrahentId;
        public int KontrahentId
        {
            get => _KontrahentId;
            set
            {
                if (_KontrahentId != value)
                {
                    _KontrahentId = value;
                    OnPropertyChanged(() => KontrahentId);
                    //TODO
                    //MessageBox.Show
                    //Czy trzeba wysyłać samo ID?
                    WeakReferenceMessenger.Default.Send(ProjektDesktopyEntities.Kontrahent.First(arg => arg.Id == value));
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Konstruktor
        public WszyscyKontrahenciViewModel() : base("Kontrahenci")
        {
        }
        #endregion
        #region Helpers
        protected override void Load()
        {
            List = new ObservableCollection<KontrahentForAllView>
                (
                    from kontrahent in ProjektDesktopyEntities.Kontrahent
                    where kontrahent.CzyAktywny == true || kontrahent.CzyAktywny != CzyNieaktywne
                    select new KontrahentForAllView
                    {
                        Id = kontrahent.Id,
                        Kod = kontrahent.Kod,
                        NIP = kontrahent.NIP,
                        RodzajKontrahenta = kontrahent.RodzajKontrahenta.Nazwa,
                        Adres = kontrahent.Adres.Nazwa,
                        GrupaRabatowa = kontrahent.GrupaRabatowa.Nazwa,

                        Nazwa = kontrahent.Nazwa,
                        CzyAktywny = kontrahent.CzyAktywny,
                        DataUtworzenia = kontrahent.DataUtworzenia,
                        DataModyfikacji = kontrahent.DataModyfikacji,
                        KtoUtworzyl = kontrahent.KtoUtworzyl,
                        KtoZmodyfikowal = kontrahent.KtoZmodyfikowal,
                        Notatki = kontrahent.Notatki
                    }
                );
            AllList = new List<KontrahentForAllView>(List);
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa", "NIP" };
        }

        protected override List<string> getSortComboBoxItems()
        {
            return new List<string>() { "Nazwa", "NIP" };
        }

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Nazwa":
                        List = new ObservableCollection<KontrahentForAllView>(AllList.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                    case "NIP":
                        List = new ObservableCollection<KontrahentForAllView>(AllList.Where(item => item.NIP?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<KontrahentForAllView>(AllList);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    // obsługa sortowania rosnąco i malejąco
                    List = new ObservableCollection<KontrahentForAllView>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
                case "NIP":
                    List = new ObservableCollection<KontrahentForAllView>(SortDescending ? List.OrderByDescending(item => int.Parse(item.NIP)) : List.OrderBy(item => int.Parse(item.NIP)));
                    break;
            }
        }
        #endregion
    }
}
