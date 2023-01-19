using CommunityToolkit.Mvvm.Messaging;
using Firma.Helpers;
using Firma.Models.Entities;
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
    public class NowyNumerTelefonuViewModel : JedenViewModel<NumerTelefonu>, IDataErrorInfo
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
        public string Numer
        {
            get
            {
                return Item.Numer;
            }
            set
            {
                if (value != Item.Numer)
                {
                    Item.Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        public string Kraj
        {
            get
            {
                return Item.Kraj;
            }
            set
            {
                if (value != Item.Kraj)
                {
                    Item.Kraj = value;
                    base.OnPropertyChanged(() => Kraj);
                }
            }
        }
        public int? PracownikId
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
        public NowyNumerTelefonuViewModel() : base("Nowy numer telefonu")
        {
            Item = new NumerTelefonu();

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
            Db.NumerTelefonu.AddObject(Item);
            Db.SaveChanges();
        }
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Nazwa):
                        return StringValidator.CannotBeTooLong(Nazwa, 64) + StringValidator.CannotBeEmpty(Nazwa);
                    case nameof(Numer):
                        return StringValidator.CannotBeTooLong(Numer, 20) + StringValidator.CannotBeEmpty(Numer);
                    case nameof(Kraj):
                        return StringValidator.CannotBeTooLong(Kraj, 64) + StringValidator.CannotBeEmpty(Kraj);
                    default:
                        return string.Empty;
                }
            }
        }
        protected override bool IsValid()
        {
            return this[nameof(Nazwa)] == string.Empty
                && this[nameof(Numer)] == string.Empty
                && this[nameof(Kraj)] == string.Empty;
        }
        #endregion

    }
}
