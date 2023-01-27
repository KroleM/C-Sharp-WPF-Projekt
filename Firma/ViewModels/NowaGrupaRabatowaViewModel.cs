using Firma.Models.Entities;
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
    public class NowaGrupaRabatowaViewModel : JedenViewModel<GrupaRabatowa>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaGrupaRabatowaViewModel()
            : base("Grupa rabatowa")
        {
            Item = new GrupaRabatowa();
        }
        #endregion
        #region Properties
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
        public decimal Rabat
        {
            get
            {
                return Item.Rabat;
            }
            set
            {
                if (value != Item.Rabat)
                {
                    Item.Rabat = value;
                    base.OnPropertyChanged(() => Rabat);
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

        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Item.DataUtworzenia = DateTime.Now;
            Item.DataModyfikacji = DateTime.Now;
            Item.KtoZmodyfikowal = Uzytkownik;
            Db.GrupaRabatowa.AddObject(Item);
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
                        return StringValidator.CannotBeTooLong(Nazwa, 64) + StringValidator.CannotBeEmpty(Nazwa) + StringValidator.CannotBeNull(Nazwa);
                    case nameof(Rabat):
                        return DecimalValidator.CzyProcent(Rabat);
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
                && this[nameof(Rabat)] == string.Empty
                && this[nameof(Notatka)] == string.Empty
                && this[nameof(Uzytkownik)] == string.Empty;
        }
        #endregion
    }
}
