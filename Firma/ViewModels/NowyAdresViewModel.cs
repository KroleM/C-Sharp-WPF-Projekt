﻿using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class NowyAdresViewModel : JedenViewModel<Adres>
    {
        #region Konstruktor
        public NowyAdresViewModel()
            : base("Nowy adres")
        {
            Item = new Adres();
        }
        #endregion
        #region Properties
        public string Ulica
        {
            get
            {
                return Item.Ulica;
            }
            set
            {
                if (value != Item.Ulica)
                {
                    Item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string Miejscowosc
        {
            get
            {
                return Item.Miejscowosc;
            }
            set
            {
                if (value != Item.Miejscowosc)
                {
                    Item.Miejscowosc = value;
                    base.OnPropertyChanged(() => Miejscowosc);
                }
            }
        }
        public string NrDomu
        {
            get
            {
                return Item.NrDomu;
            }
            set
            {
                if (value != Item.NrDomu)
                {
                    Item.NrDomu = value;
                    base.OnPropertyChanged(() => NrDomu);
                }
            }
        }
        public string NrLokalu
        {
            get
            {
                return Item.NrLokalu;
            }
            set
            {
                if (value != Item.NrLokalu)
                {
                    Item.NrLokalu = value;
                    base.OnPropertyChanged(() => NrLokalu);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return Item.KodPocztowy;
            }
            set
            {
                if (value != Item.KodPocztowy)
                {
                    Item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        public string Poczta
        {
            get
            {
                return Item.Poczta;
            }
            set
            {
                if (value != Item.Poczta)
                {
                    Item.Poczta = value;
                    base.OnPropertyChanged(() => Poczta);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            //Item.CzyAktywny = true;
            Db.Adres.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
