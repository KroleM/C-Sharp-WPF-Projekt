using CommunityToolkit.Mvvm.Messaging;
using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Firma.ViewModels
{
    public class WszystkieAdresyViewModel : WszystkieViewModel<Adres>
    {
        #region Pola i Właściwości
        private Adres _WybranyAdres;
        public Adres WybranyAdres
        {
            get => _WybranyAdres;
            set
            {
                if(_WybranyAdres != value)
                {
                    _WybranyAdres = value;
                    OnPropertyChanged(() => WybranyAdres);
                    //TODO
                    //MessageBox.Show
                    WeakReferenceMessenger.Default.Send(_WybranyAdres);
                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Konstruktor
        public WszystkieAdresyViewModel() : base("Adresy") { }
        #endregion

        #region Helpers
        protected override void Load()
        {
            List = new ObservableCollection<Adres>
                (
                from adres in ProjektDesktopyEntities.Adres
                where adres.CzyAktywny == true || adres.CzyAktywny != CzyNieaktywne
                select adres
                );
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa" };
        }

        protected override List<string> getSortComboBoxItems()
        {
            return new List<string>() { "Miejscowość" };
        }

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Nazwa":
                        List = new ObservableCollection<Adres>(List.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<Adres>(List);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Miejscowość":
                    // obsługa sortowania rosnąco i malejąco
                    List = new ObservableCollection<Adres>(SortDescending ? List.OrderByDescending(item => item.Miejscowosc) : List.OrderBy(item => item.Miejscowosc));
                    break;
            }
        }
        #endregion
    }
}
