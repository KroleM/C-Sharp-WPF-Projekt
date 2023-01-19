using Firma.Models;
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

namespace Firma.ViewModels
{
    public class NowyTowarViewModel : JedenViewModel<Towar>, IDataErrorInfo
    {
        #region Pola i Właściwości
        public List<Rynek> Rynki { get; set; }
        public List<ComboBoxKeyAndValue> GrupyTowarowe { get; set; }
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
        public decimal StawkaVatZakupu
        {
            get
            {
                return Item.StawkaVatZakupu;
            }
            set
            {
                if (value != Item.StawkaVatZakupu)
                {
                    Item.StawkaVatZakupu = value;
                    base.OnPropertyChanged(() => StawkaVatZakupu);
                }
            }
        }
        public decimal StawkaVatSprzedazy
        {
            get
            {
                return Item.StawkaVatSprzedazy;
            }
            set
            {
                if (value != Item.StawkaVatSprzedazy)
                {
                    Item.StawkaVatSprzedazy = value;
                    base.OnPropertyChanged(() => StawkaVatSprzedazy);
                }
            }
        }
        public decimal CenaNetto
        {
            get
            {
                return Item.CenaNetto;
            }
            set
            {
                if (value != Item.CenaNetto)
                {
                    Item.CenaNetto = value;
                    base.OnPropertyChanged(() => CenaNetto);
                    base.OnPropertyChanged(() => CenaNettoSprzedazy);
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
        public decimal Marza
        {
            get
            {
                return Item.Marza;
            }
            set
            {
                if (value != Item.Marza)
                {
                    Item.Marza = value;
                    base.OnPropertyChanged(() => Marza);
                    base.OnPropertyChanged(() => CenaNettoSprzedazy);
                }
            }
        }
        public decimal CenaNettoSprzedazy
        {
            get
            {
                return (100 * CenaNetto) / (100 - Marza);
            }
        }
        public int GrupaTowarowaId
        {
            get
            {
                return Item.GrupaTowarowaId;
            }
            set
            {                
                if (value != Item.GrupaTowarowaId)
                {
                    Item.GrupaTowarowaId = value;
                    base.OnPropertyChanged(() => GrupaTowarowaId);
                }
            }
        }
        public int RynekId
        {
            get
            {
                return Item.RynekId;
            }
            set
            {               
                if (value != Item.RynekId)
                {
                    Item.RynekId = value;
                    base.OnPropertyChanged(() => RynekId);
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
        public NowyTowarViewModel() : base("Nowy towar")
        {
            Item = new Towar();

            Rynki = Db.Rynek.Where(arg => arg.CzyAktywny == true).ToList();

            GrupyTowarowe = Db.GrupaTowarowa.Where(arg => arg.CzyAktywny == true).Select(arg => new ComboBoxKeyAndValue()
            {
                Key = arg.Id,
                Value = arg.Nazwa + " (" + arg.Kod.Trim() + ")"
            }).ToList();
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Item.DataUtworzenia = DateTime.Now;
            Item.DataModyfikacji = DateTime.Now;
            Item.KtoZmodyfikowal = Uzytkownik;
            Db.Towar.AddObject(Item);
            Db.SaveChanges();
        }
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Kod):
                        return StringValidator.CannotBeNull(Kod);
                    case nameof(Nazwa):
                        return StringValidator.CannotBeTooLong(Nazwa, 64) + StringValidator.CannotBeNull(Nazwa) + StringValidator.CannotBeEmpty(Nazwa);
                    case nameof(StawkaVatZakupu):
                        return DecimalValidator.CzyProcent(StawkaVatZakupu);
                    case nameof(StawkaVatSprzedazy):
                        return DecimalValidator.CzyProcent(StawkaVatSprzedazy);
                    case nameof(CenaNetto):
                        return DecimalValidator.CzyWiekszeOdZera(CenaNetto);
                    case nameof(Marza):
                        return DecimalValidator.CzyProcent(Marza);
                    case nameof(Waluta):
                        return StringValidator.CannotBeNull(Waluta);
                    case nameof(GrupaTowarowaId):
                        return DecimalValidator.CzyWybranyComboBox(GrupaTowarowaId);
                    case nameof(RynekId):
                        return DecimalValidator.CzyWybranyComboBox(RynekId);
                    default:
                        return string.Empty;
                }
            }
        }
        protected override bool IsValid()
        {
            return this[nameof(Nazwa)] == string.Empty
                && this[nameof(Kod)] == string.Empty
                && this[nameof(StawkaVatZakupu)] == string.Empty
                && this[nameof(StawkaVatSprzedazy)] == string.Empty
                && this[nameof(CenaNetto)] == string.Empty
                && this[nameof(Marza)] == string.Empty
                && this[nameof(Waluta)] == string.Empty
                && this[nameof(RynekId)] == string.Empty
                && this[nameof(GrupaTowarowaId)] == string.Empty;
        }
        #endregion
    }
}
