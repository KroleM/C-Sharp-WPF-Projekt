using CommunityToolkit.Mvvm.Messaging;
using Firma.Helpers;
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
    public class WszystkieTowaryViewModel : WszystkieViewModel<TowarForAllView>
    {
        #region Pola i Właściwości
        private int _TowarId;
        public int TowarId
        {
            get => _TowarId;
            set
            {
                if (_TowarId != value)
                {
                    _TowarId = value;
                    OnPropertyChanged(() => TowarId);
                    //TODO
                    //MessageBox.Show
                    //WeakReferenceMessenger.Default.Send(ProjektDesktopyEntities.Towar.Select(arg => arg.Id == value));  //być może trzeba wysyłać int, bo instancje BD mogą być różne
                    WeakReferenceMessenger.Default.Send(new MessengerNumberMessage<int> { Number = _TowarId});
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieTowaryViewModel() : base("Towary") { }
        #endregion
        protected override void Load()
        {
            List = new ObservableCollection<TowarForAllView>
                (
                    from towar in ProjektDesktopyEntities.Towar
                    where towar.CzyAktywny == true || towar.CzyAktywny != CzyNieaktywne
                    select new TowarForAllView
                    {
                        Id = towar.Id,
                        Kod = towar.Kod,
                        StawkaVatZakupu = towar.StawkaVatZakupu,
                        StawkaVatSprzedazy = towar.StawkaVatSprzedazy,
                        CenaNetto = towar.CenaNetto,
                        Waluta = towar.Waluta,
                        Marza = towar.Marza,
                        GrupaTowarowaNazwa = towar.GrupaTowarowa.Nazwa,
                        RynekSkrot = towar.Rynek.Skrot,

                        Nazwa = towar.Nazwa,
                        CzyAktywny = towar.CzyAktywny,
                        DataUtworzenia = towar.DataUtworzenia,
                        DataModyfikacji = towar.DataModyfikacji,
                        KtoUtworzyl = towar.KtoUtworzyl,
                        KtoZmodyfikowal = towar.KtoZmodyfikowal,
                        Notatki = towar.Notatki
                    }
                );
            AllList = new List<TowarForAllView>(List);
        }
        protected override List<string> getSearchComboBoxItems()
        {
            return new List<string>() { "Nazwa" };
        }

        protected override List<string> getSortComboBoxItems()
        {
            return new List<string>() { "Nazwa", "Cena netto" };
        }

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Nazwa":
                        List = new ObservableCollection<TowarForAllView>(AllList.Where(item => item.Nazwa?.ToLower().Contains(SearchText.Trim().ToLower()) ?? false));
                        break;
                }
            }
            else
            {
                List = new ObservableCollection<TowarForAllView>(AllList);
            }
            Sort();
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<TowarForAllView>(SortDescending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
                case "Cena netto":
                    List = new ObservableCollection<TowarForAllView>(SortDescending ? List.OrderByDescending(item => item.CenaNetto) : List.OrderBy(item => item.CenaNetto));
                    break;
            }
        }
    }
}
