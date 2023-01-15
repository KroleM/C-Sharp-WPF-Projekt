using CommunityToolkit.Mvvm.Messaging;
using Firma.Helpers;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.Models.Validators;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class NowyPracownikViewModel : JedenViewModel<Pracownik>, IDataErrorInfo
    {
        #region Pola i Właściwości
        public List<Dzial> Dzialy { get; set; }
        public List<TypUmowy> TypyUmowy { get; set; }
        public List<ComboBoxKeyAndValue> Stanowiska { get; set; }
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
        private string _DaneAdresu;
        public string DaneAdresu
        {
            get
            {
                return _DaneAdresu;
            }
            set
            {
                if (value != _DaneAdresu)
                {
                    _DaneAdresu = value;
                    base.OnPropertyChanged(() => DaneAdresu);
                }
            }
        }
        private bool _CzyAdresWybrany;
        public bool CzyAdresWybrany
        {
            get => _DaneAdresu != null;
            set
            {
                if(value != _CzyAdresWybrany)
                {
                    _CzyAdresWybrany = value;
                    OnPropertyChanged(() => CzyAdresWybrany);
                }
            }
        }
        public string Imie
        {
            get
            {
                return Item.Imie;
            }
            set
            {
                if (value != Item.Imie)
                {
                    Item.Imie = value;
                    base.OnPropertyChanged(() => Imie);
                }
            }
        }
        public string Nazwisko
        { 
            get
            {
                return Item.Nazwisko;
            }
            set
            {
                if (value != Item.Nazwisko)
                {
                    Item.Nazwisko = value;
                    base.OnPropertyChanged(() => Nazwisko);
                }
            }
        }
        public string Pesel
        {
            get
            {
                return Item.PESEL;
            }
            set
            {
                if (value != Item.PESEL)
                {
                    Item.PESEL = value;
                    base.OnPropertyChanged(() => Pesel);
                }
            }
        }
        public int AdresId
        {
            get
            {
                return Item.AdresId;
            }
            set
            {
                if (value != Item.AdresId)
                {
                    Item.AdresId = value;
                    base.OnPropertyChanged(() => AdresId);
                }
            }
        }
        public int TypUmowyId
        {
            get
            {
                return Item.TypUmowyId;
            }
            set
            {
                if (value != Item.TypUmowyId)
                {
                    Item.TypUmowyId = value;
                    base.OnPropertyChanged(() => TypUmowyId);
                }
            }
        }
        public int DzialId
        {
            get
            {
                return Item.DzialId;
            }
            set
            {
                if (value != Item.DzialId)
                {
                    Item.DzialId = value;
                    base.OnPropertyChanged(() => DzialId);
                }
            }
        }
        public int StanowiskoId
        {
            get
            {
                return Item.StanowiskoId;
            }
            set
            {
                if (value != Item.StanowiskoId)
                {
                    Item.StanowiskoId = value;
                    base.OnPropertyChanged(() => StanowiskoId);
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
        public NowyPracownikViewModel() : base("Nowy pracownik")
        {
            Item = new Pracownik();

            Dzialy = Db.Dzial.Where(arg => arg.CzyAktywny == true).ToList();
            TypyUmowy = Db.TypUmowy.Where(arg => arg.CzyAktywny == true).ToList();

            Stanowiska = Db.Stanowisko.Where(arg => arg.CzyAktywny == true).Select(arg => new ComboBoxKeyAndValue()
            {
                Key = arg.Id,
                Value = arg.Kategoria.Trim() + ": " + arg.Nazwa
            }).ToList();

            // Odbiór wiadomości
            WeakReferenceMessenger.Default.Register<Adres>(this, (r, m) => przypiszAdres(m));
        }
        #endregion
        #region Komendy
        private ICommand _WybierzAdresCommand;
        public ICommand WybierzAdresCommand
        {
            get
            {
                if (_WybierzAdresCommand == null)
                {
                    _WybierzAdresCommand = new BaseCommand(() => wybierzAdres());
                }
                return _WybierzAdresCommand;
            }
        }
        #endregion
        #region Metody
        private void przypiszAdres(Adres adres)
        {
            DaneAdresu = $"{adres.Ulica} {adres.NrDomu.Trim()}" + (String.IsNullOrEmpty(adres.NrLokalu) ? "" : $"/{adres.NrLokalu.Trim()}")
                + $"\n{adres.KodPocztowy.Trim()}, {adres.Miejscowosc}"
                + $"\n{adres.Kraj}";
            Item.AdresId = adres.Id;
        }
        private void wybierzAdres()
        {
            //Tutaj należałoby jeszcze załączać nadawcę wiadomości!! FIXME
            WeakReferenceMessenger.Default.Send("Kontrahenci Show");
        }
        public override void Save()
        {
            Item.CzyAktywny = true;
            Item.DataUtworzenia = DateTime.Now;
            Item.DataModyfikacji = DateTime.Now;
            Item.KtoZmodyfikowal = Uzytkownik;
            Item.Nazwa = Imie + " " + Nazwisko;
            Db.Pracownik.AddObject(Item);
            Db.SaveChanges();
        }
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Imie):
                        return StringValidator.CannotBeTooLong(Imie) + StringValidator.CannotBeNull(Imie) + StringValidator.CannotBeEmpty(Imie);
                    case nameof(Nazwisko):
                        return StringValidator.CannotBeTooLong(Nazwisko) + StringValidator.CannotBeNull(Nazwisko) + StringValidator.CannotBeEmpty(Nazwisko);
                    case nameof(Pesel):
                        return StringValidator.CannotBeNull(Pesel);
                    case nameof(AdresId):
                        return DecimalValidator.CzyWybranyComboBox(AdresId);
                    case nameof(TypUmowyId):
                        return DecimalValidator.CzyWybranyComboBox(TypUmowyId);
                    case nameof(DzialId):
                        return DecimalValidator.CzyWybranyComboBox(DzialId);
                    case nameof(StanowiskoId):
                        return DecimalValidator.CzyWybranyComboBox(StanowiskoId);
                    case nameof(DaneAdresu):
                        return StringValidator.CannotBeNull(DaneAdresu);    // FIXME: Nie zaimplementowane!
                    default:
                        return string.Empty;
                }
            }
        }
        protected override bool IsValid()
        {
            return this[nameof(Imie)] == string.Empty
                && this[nameof(Nazwisko)] == string.Empty
                && this[nameof(Pesel)] == string.Empty
                && this[nameof(AdresId)] == string.Empty
                && this[nameof(TypUmowyId)] == string.Empty
                && this[nameof(DzialId)] == string.Empty
                && this[nameof(StanowiskoId)] == string.Empty;
        }
        #endregion
    }
}
