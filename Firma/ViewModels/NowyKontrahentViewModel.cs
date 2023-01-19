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
    public class NowyKontrahentViewModel : JedenViewModel<Kontrahent>, IDataErrorInfo
    {
        #region Pola i Właściwości
        public List<RodzajKontrahenta> RodzajeKontrahenta { get; set; }
        public List<ComboBoxKeyAndValue> GrupyRabatowe { get; set; }
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
                if (value != _CzyAdresWybrany)
                {
                    _CzyAdresWybrany = value;
                    OnPropertyChanged(() => CzyAdresWybrany);
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
        public string Kod
        {
            get
            {
                return Item.Kod;
            }
            set
            {
                if (value != Item.Kod)
                {
                    Item.Kod = value;
                    base.OnPropertyChanged(() => Kod);
                }
            }
        }
        public string NIP
        {
            get
            {
                return Item.NIP;
            }
            set
            {
                if (value != Item.NIP)
                {
                    Item.NIP = value;
                    base.OnPropertyChanged(() => NIP);
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
        public int RodzajId
        {
            get
            {
                return Item.RodzajId;
            }
            set
            {
                if (value != Item.RodzajId)
                {
                    Item.RodzajId = value;
                    base.OnPropertyChanged(() => RodzajId);
                }
            }
        }
        public int GrupaRabatowaId
        {
            get
            {
                return Item.GrupaRabatowaId;
            }
            set
            {
                if (value != Item.GrupaRabatowaId)
                {
                    Item.GrupaRabatowaId = value;
                    base.OnPropertyChanged(() => GrupaRabatowaId);
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
        public NowyKontrahentViewModel() : base("Nowy kontrahent")
        {
            Item = new Kontrahent();

            RodzajeKontrahenta = Db.RodzajKontrahenta.Where(arg => arg.CzyAktywny == true).ToList();

            GrupyRabatowe = Db.GrupaRabatowa.Where(arg => arg.CzyAktywny == true).Select(arg => new ComboBoxKeyAndValue()
            {
                Key = arg.Id,
                Value = arg.Nazwa + " (" + arg.Nazwa + ")"
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
            WeakReferenceMessenger.Default.Send("Adresy Show");
        }
        public override void Save()
        {
            Item.CzyAktywny = true;
            Item.DataUtworzenia = DateTime.Now;
            Item.DataModyfikacji = DateTime.Now;
            Item.KtoZmodyfikowal = Uzytkownik;
            Db.Kontrahent.AddObject(Item);
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
                        return StringValidator.CannotBeTooLong(Nazwa, 64) + StringValidator.CannotBeNull(Nazwa) + StringValidator.CannotBeEmpty(Nazwa);
                    case nameof(Kod):
                        return StringValidator.CannotBeNull(Kod) + StringValidator.CannotBeTooLong(Kod, 8);
                    case nameof(NIP):
                        return StringValidator.CannotBeNull(NIP) + StringValidator.CannotBeTooLong(NIP, 10);
                    case nameof(AdresId):
                        return DecimalValidator.CzyWybranyComboBox(AdresId);
                    case nameof(RodzajId):
                        return DecimalValidator.CzyWybranyComboBox(RodzajId);
                    case nameof(GrupaRabatowaId):
                        return DecimalValidator.CzyWybranyComboBox(GrupaRabatowaId);
                    case nameof(DaneAdresu):
                        return StringValidator.CannotBeNull(DaneAdresu);    // FIXME: Nie zaimplementowane!
                    default:
                        return string.Empty;
                }
            }
        }
        protected override bool IsValid()
        {
            return this[nameof(Nazwa)] == string.Empty
                && this[nameof(Kod)] == string.Empty
                && this[nameof(NIP)] == string.Empty
                && this[nameof(AdresId)] == string.Empty
                && this[nameof(RodzajId)] == string.Empty
                && this[nameof(GrupaRabatowaId)] == string.Empty
                && this[nameof(DaneAdresu)] == string.Empty;
        }
        #endregion
    }
}
