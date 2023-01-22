using CommunityToolkit.Mvvm.Messaging;
using Firma.Helpers;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class NoweZamowienieViewModel : JedenWszystkieViewModel<Zamowienie, PozycjaZamowieniaForAllView>
    {
        #region PolaIWlasciwosci
        private string _DaneKontrahenta;
        public string DaneKontrahenta
        {
            get { return _DaneKontrahenta; }
            set
            {
                if (value != _DaneKontrahenta)
                {
                    _DaneKontrahenta = value;
                    OnPropertyChanged(() => DaneKontrahenta);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return Item.Nazwa;
            }
            set
            {
                if (value != Item.Nazwa)
                {
                    Item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public DateTime? DataWyslania
        {
            get
            {
                return Item.DataWyslania;
            }
            set
            {
                if (value != Item.DataWyslania)
                {
                    Item.DataWyslania = value;
                    base.OnPropertyChanged(() => DataWyslania);
                }
            }
        }
        public int KontrahentId
        {
            get
            {
                return Item.KontrahentId;
            }
            set
            {
                if (value != Item.KontrahentId)
                {
                    Item.KontrahentId = value;
                    base.OnPropertyChanged(() => KontrahentId);
                }
            }
        }
        public bool CzyAktywny
        {
            get
            {
                return Item.CzyAktywny;
            }
            set
            {
                if (value != Item.CzyAktywny)
                {
                    Item.CzyAktywny = value;
                    base.OnPropertyChanged(() => CzyAktywny);
                }
            }
        }
        public string Notatka
        {
            get
            {
                return Item.Notatki;
            }
            set
            {
                if (value != Item.Notatki)
                {
                    Item.Notatki = value;
                    base.OnPropertyChanged(() => Notatka);
                }
            }
        }
        public string Uzytkownik
        {
            get
            {
                return Item.KtoUtworzyl;
            }
            set
            {
                if (value != Item.KtoUtworzyl)
                {
                    Item.KtoUtworzyl = value;
                    base.OnPropertyChanged(() => Uzytkownik);
                }
            }
        }
        #endregion

        #region Konstruktor
        public NoweZamowienieViewModel() : base("Nowe zamówienie", "Pozycja zamówienia")
        {
            Item = new Zamowienie();

            WeakReferenceMessenger.Default.Register<Kontrahent>(this, (r, m) => przypiszKontrahenta(m));
            //Zarejestrowanie wiadomości
            WeakReferenceMessenger.Default.Register<PozycjaZamowienia>(this, (r, m) => addPozycjaZamowienia(m));
            //Poniżej odbiór wiadomości ze sprawdzeniem, czy dany obiekt tej klasy był nadawcą (aby uniknąć błędów z instancjami bazy danych)
            WeakReferenceMessenger.Default.Register<MessengerMessage<NoweZamowienieViewModel, PozycjaZamowienia>>(this, (r, m) => addPozycja(m));

            List = new ObservableCollection<PozycjaZamowieniaForAllView>(Item.PozycjaZamowienia.Select(item => new PozycjaZamowieniaForAllView()
            {
                TowarKod = item.Towar.Kod,
                TowarNazwa = item.Towar.Nazwa,
                CenaNetto = item.Towar.CenaNetto,
                Waluta = item.Towar.Waluta,
                StawkaVAT = item.Towar.StawkaVatSprzedazy,
                Sztuki = item.Sztuki,
                Rabat = item.Zamowienie.Kontrahent.GrupaRabatowa.Rabat
            }).ToList());
        }

        private void addPozycja(MessengerMessage<NoweZamowienieViewModel, PozycjaZamowienia> obj)       // zły argument?
        {
            bool cond = obj.Nadawca == this;    // FIXME
        }
        #endregion

        #region Komendy
        private ICommand _WybierzKontrahentaCommand;
        public ICommand WybierzKontrahentaCommand
        {
            get
            {
                if (_WybierzKontrahentaCommand == null)
                {
                    _WybierzKontrahentaCommand = new BaseCommand(() => wybierzKontrahenta());
                }
                return _WybierzKontrahentaCommand;
            }
        }
        #endregion

        #region Metody
        private void przypiszKontrahenta(Kontrahent kontrahent)
        {
            DaneKontrahenta = $"{kontrahent.Nazwa} - {kontrahent.NIP} ({kontrahent.Kod.Trim()})";
            //kontrahent.IdKontrahenta = kontrahent.IdKontrahenta;
            //IdKontrahenta = kontrahent.IdKontrahenta; ??
            KontrahentId = kontrahent.Id;
        }
        private void wybierzKontrahenta()
        {
            //Tutaj należałoby jeszcze załączać nadawcę wiadomości!! FIXME
            WeakReferenceMessenger.Default.Send("Kontrahenci Show");
        }
        private void addPozycjaZamowienia(PozycjaZamowienia pozycjaZamowienia)
        {
            //Item z klasy JedenViewModel -> PozycjaZamowienia to kolekcja
            //Jeśli PozycjaZamowienia pochodzi z innego kontekstu, to należy stworzyć nową PozycjęZamowienia i przepisać wartość
            //Item.PozycjaZamowienia.Add(pozycjaZamowienia);
            Item.PozycjaZamowienia.Add(new PozycjaZamowienia()    //to jest rozwiązanie zastępcze, trochę naokoło
            {
                Nazwa = pozycjaZamowienia.Nazwa,
                DataUtworzenia = pozycjaZamowienia.DataUtworzenia,
                DataModyfikacji = pozycjaZamowienia.DataModyfikacji,
                CzyAktywny = pozycjaZamowienia.CzyAktywny,
                Notatki = pozycjaZamowienia.Notatki,
                KtoUtworzyl = pozycjaZamowienia.KtoUtworzyl,
                KtoZmodyfikowal = pozycjaZamowienia.KtoZmodyfikowal,
                TowarId = pozycjaZamowienia.TowarId,
                ZamowienieId = pozycjaZamowienia.ZamowienieId,
                Sztuki = pozycjaZamowienia.Sztuki,
            });

            // towar musi zostać wyciągnięty z BD na podstawie uzyskanego IdTowaru
            //Towar towar = (from item in Db.Towar
            //               where item.IdTowaru == pozycjaFaktury.IdTowaru
            //               select item).First();
            Towar towar = Db.Towar.First(item => item.Id == pozycjaZamowienia.TowarId);

            List.Add(new PozycjaZamowieniaForAllView()
            {
                TowarKod = towar.Kod,
                TowarNazwa = towar.Nazwa,
                CenaNetto = towar.CenaNetto,
                Waluta = towar.Waluta,
                StawkaVAT = towar.StawkaVatSprzedazy,
                Sztuki = pozycjaZamowienia.Sztuki,
                //Rabat = pozycjaZamowienia.Zamowienie.Kontrahent.GrupaRabatowa.Rabat   // problem z Rabatem - przenieść do property?
                //TowarKod = pozycjaZamowienia.Towar.Kod,
                //TowarNazwa = pozycjaZamowienia.Towar.Nazwa,
                //CenaNetto = pozycjaZamowienia.Towar.CenaNetto,
                //Waluta = pozycjaZamowienia.Towar.Waluta,
                //StawkaVAT = pozycjaZamowienia.Towar.StawkaVatSprzedazy,
                //Sztuki = pozycjaZamowienia.Sztuki,
                //Rabat = pozycjaZamowienia.Zamowienie.Kontrahent.GrupaRabatowa.Rabat
            });
        }
        
        public override void Save()
        {
            Item.DataUtworzenia = DateTime.Now;
            Item.DataModyfikacji = DateTime.Now;
            Item.KtoZmodyfikowal = Uzytkownik;
            Item.Nazwa = $"Order {KontrahentId}/{Item.DataUtworzenia} ";
            Db.Zamowienie.AddObject(Item);

            Db.SaveChanges();
        }
        #endregion

    }
}
