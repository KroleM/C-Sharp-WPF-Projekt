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
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class NowaWyplataViewModel : JedenViewModel<Wyplata>, IDataErrorInfo
    {
        #region Pola i Właściwości
        public List<TypWyplaty> TypyWyplaty { get; set; }
        private string _DanePracownika;
        public string DanePracownika
        {
            get
            {
                return _DanePracownika;
            }
            set
            {
                if (value != _DanePracownika)
                {
                    _DanePracownika = value;
                    base.OnPropertyChanged(() => _DanePracownika);
                }
            }
        }
        private bool _CzyPracownikWybrany;
        public bool CzyPracownikWybrany
        {
            get => _DanePracownika != null;
            set
            {
                if (value != _CzyPracownikWybrany)
                {
                    _CzyPracownikWybrany = value;
                    OnPropertyChanged(() => _CzyPracownikWybrany);
                }
            }
        }
        public decimal Kwota
        {
            get
            {
                return Item.Kwota;
            }
            set
            {
                if (value != Item.Kwota)
                {
                    Item.Kwota = value;
                    base.OnPropertyChanged(() => Kwota);
                }
            }
        }
        public string Waluta
        {
            get
            {
                return Item.Waluta;
            }
            set
            {
                if (value != Item.Waluta)
                {
                    Item.Waluta = value;
                    base.OnPropertyChanged(() => Waluta);
                }
            }
        }
        public DateTime OkresOd
        {
            get
            {
                return Item.OkresOd;
            }
            set
            {
                if (value != Item.OkresOd)
                {
                    Item.OkresOd = value;
                    base.OnPropertyChanged(() => OkresOd);
                }
            }
        }
        public DateTime OkresDo
        {
            get
            {
                return Item.OkresDo;
            }
            set
            {
                if (value != Item.OkresDo)
                {
                    Item.OkresDo = value;
                    base.OnPropertyChanged(() => OkresDo);
                }
            }
        }
        public int PracownikId
        {
            get
            {
                return Item.PracownikId;
            }
            set
            {
                if (value != Item.PracownikId)
                {
                    Item.PracownikId = value;
                    base.OnPropertyChanged(() => PracownikId);
                }
            }
        }
        public int TypWyplatyId
        {
            get
            {
                return Item.TypWyplatyId;
            }
            set
            {
                if (value != Item.TypWyplatyId)
                {
                    Item.TypWyplatyId = value;
                    base.OnPropertyChanged(() => TypWyplatyId);
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
        public NowaWyplataViewModel() : base("Nowa wypłata")
        {
            Item = new Wyplata();
            Item.OkresOd = DateTime.Now;
            Item.OkresDo = DateTime.Now;

            TypyWyplaty = Db.TypWyplaty.Where(arg => arg.CzyAktywny == true).ToList();

            // Odbiór wiadomości
            WeakReferenceMessenger.Default.Register<Pracownik>(this, (r, m) => przypiszPracownika(m));
        }
        #endregion
        #region Komendy
        private ICommand _WybierzPracownikaCommand;
        public ICommand WybierzPracownikaCommand
        {
            get
            {
                if (_WybierzPracownikaCommand == null)
                {
                    _WybierzPracownikaCommand = new BaseCommand(() => wybierzPracownika());
                }
                return _WybierzPracownikaCommand;
            }
        }
        #endregion
        #region Metody
        private void przypiszPracownika(Pracownik pracownik)
        {
            DanePracownika = pracownik.Nazwa + $"\n{Db.Dzial.Where(arg => arg.Id == pracownik.DzialId).ToList()[0].Nazwa}";

            Item.PracownikId = pracownik.Id;
        }
        private void wybierzPracownika()
        {
            //Tutaj należałoby jeszcze załączać nadawcę wiadomości!! FIXME
            WeakReferenceMessenger.Default.Send("Pracownicy Show");
        }
        public override void Save()
        {
            Item.CzyAktywny = true;
            Item.DataUtworzenia = DateTime.Now;
            Item.DataModyfikacji = DateTime.Now;
            Item.KtoZmodyfikowal = Uzytkownik;
            Item.Nazwa = Db.TypWyplaty.Where(arg => arg.Id == TypWyplatyId).ToList()[0]?.Skrot.Trim()
                + $" {Item.DataUtworzenia.Year}.{Item.DataUtworzenia.Month}.{Item.DataUtworzenia.Day}: "
                + Db.Pracownik.Where(arg => arg.Id == PracownikId).ToList()[0]?.Nazwa;
            Db.Wyplata.AddObject(Item);
            Db.SaveChanges();
        }
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Kwota):
                        return DecimalValidator.CzyWiekszeOdZera(Kwota);
                    case nameof(Waluta):
                        return StringValidator.CannotBeNull(Waluta) + StringValidator.CannotBeTooLong(Waluta, 8);
                    case nameof(TypWyplatyId):
                        return DecimalValidator.CzyWybranyComboBox(TypWyplatyId);
                    case nameof(DanePracownika):
                        return StringValidator.CannotBeNull(DanePracownika);
                    default:
                        return string.Empty;
                }
            }
        }
        protected override bool IsValid()
        {
            return this[nameof(Kwota)] == string.Empty
                && this[nameof(Waluta)] == string.Empty
                && this[nameof(TypWyplatyId)] == string.Empty
                && this[nameof(DanePracownika)] == string.Empty;
        }
        #endregion
    }
}
