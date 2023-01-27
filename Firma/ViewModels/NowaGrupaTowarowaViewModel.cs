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
    public class NowaGrupaTowarowaViewModel : JedenViewModel<GrupaTowarowa>, IDataErrorInfo
    {
        #region Pola i Właściwości
        public List<ComboBoxKeyAndValue> GrupyTowarowe { get; set; }
        public string Nazwa
        {
            get
            {
                return Item.Nazwa;
            }
            set
            {
                Console.WriteLine("Nazwa = {0}", value);
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
        public int? GrupaNadrzednaId
        {
            get
            {
                return Item.GrupaNadrzednaId;
            }
            set
            {
                if (value != Item.GrupaNadrzednaId)
                {
                    Item.GrupaNadrzednaId = value;
                    base.OnPropertyChanged(() => GrupaNadrzednaId);
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
        public NowaGrupaTowarowaViewModel() : base("Nowa grupa towarowa")
        {
            Item = new GrupaTowarowa();

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
            Db.GrupaTowarowa.AddObject(Item);
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
                        return StringValidator.CannotBeTooLong(Nazwa, 64) + StringValidator.CannotBeEmpty(Nazwa) + StringValidator.CannotBeNull(Nazwa);
                    case nameof(GrupaNadrzednaId):
                        return DecimalValidator.CzyWybranyComboBox(GrupaNadrzednaId);
                    case nameof(Notatka):
                        return StringValidator.CannotBeTooLong(Notatka, 1000);
                    case nameof(Uzytkownik):
                        return StringValidator.CannotBeTooLong(Uzytkownik, 64);
                    default:
                        return string.Empty;
                }
            }
        }
        protected override bool IsValid()
        {
            return this[nameof(Nazwa)] == string.Empty
                && this[nameof(Kod)] == string.Empty
                && this[nameof(GrupaNadrzednaId)] == string.Empty
                && this[nameof(Notatka)] == string.Empty
                && this[nameof(Uzytkownik)] == string.Empty;
        }
        #endregion
    }
}
