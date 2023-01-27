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
using System.Windows.Automation.Peers;

namespace Firma.ViewModels
{
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForAllView>
    {
        #region Pola i Właściwości
        private int _PracownikId;
        public int PracownikId
        {
            get => _PracownikId;
            set
            {
                if (_PracownikId != value)
                {
                    _PracownikId = value;
                    OnPropertyChanged(() => PracownikId);
                    //TODO
                    //MessageBox.Show
                    WeakReferenceMessenger.Default.Send(ProjektDesktopyEntities.Pracownik.First(arg => arg.Id == value));
                    //WeakReferenceMessenger.Default.Send(ProjektDesktopyEntities.Pracownik.Where(arg => arg.Id == value).ToList()[0]);
                    OnRequestClose();
                }
            }
        }
        #endregion
        public WszyscyPracownicyViewModel() : base("Pracownicy") { }
        #region Helpers
        protected override void Load()
        {
            List = new ObservableCollection<PracownikForAllView>
                (
                    from pracownik in ProjektDesktopyEntities.Pracownik
                    where pracownik.CzyAktywny == true || pracownik.CzyAktywny != CzyNieaktywne
                    select new PracownikForAllView
                    {
                        Id = pracownik.Id,
                        Imie = pracownik.Imie,
                        Nazwisko = pracownik.Nazwisko,
                        PESEL = pracownik.PESEL,
                        PracownikAdres = pracownik.Adres.Nazwa,
                        PracownikTypUmowy = pracownik.TypUmowy.Nazwa,
                        PracownikDzial = pracownik.Dzial.Nazwa,
                        PracownikStanowisko = pracownik.Stanowisko.Nazwa + " (" + pracownik.Stanowisko.Kategoria.Trim() + ")",

                        Nazwa = pracownik.Nazwa,
                        CzyAktywny = pracownik.CzyAktywny,
                        DataUtworzenia = pracownik.DataUtworzenia,
                        DataModyfikacji = pracownik.DataModyfikacji,
                        KtoUtworzyl = pracownik.KtoUtworzyl,
                        KtoZmodyfikowal = pracownik.KtoZmodyfikowal,
                        Notatki = pracownik.Notatki
                    }   
                );
            AllList = new List<PracownikForAllView>(List);
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwisko", "Adres" };
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
                    case "Nazwisko":
                        List = new ObservableCollection<PracownikForAllView>(AllList.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                    case "Adres":
                        List = new ObservableCollection<PracownikForAllView>(AllList.Where(item => item.PracownikAdres?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<PracownikForAllView>(AllList);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwisko":
                    // obsługa sortowania rosnąco i malejąco
                    List = new ObservableCollection<PracownikForAllView>(SortDescending ? List.OrderByDescending(item => item.Nazwisko) : List.OrderBy(item => item.Nazwisko));
                    break;
            }
        }
        #endregion
    }
}
