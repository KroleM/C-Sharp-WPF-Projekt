using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class PozycjaZamowieniaForAllView
    {
        #region PolaIWlasciwosci

        private string _TowarKod;
        public string TowarKod
        {
            get
            {
                return _TowarKod;
            }
            set
            {
                _TowarKod = value;
            }
        }

        private string _TowarNazwa;
        public string TowarNazwa
        {
            get
            {
                return _TowarNazwa;
            }
            set
            {
                _TowarNazwa = value;
            }
        }

        private decimal _CenaNetto;  
        public decimal CenaNetto
        {
            get
            {
                return _CenaNetto;
            }
            set
            {
                _CenaNetto = value;
            }
        }

        private string _Waluta;
        public string Waluta
        {
            get
            {
                return _Waluta;
            }
            set
            {
                _Waluta = value;
            }
        }

        private decimal _StawkaVAT;
        public decimal StawkaVAT
        {
            get
            {
                return _StawkaVAT;
            }
            set
            {
                _StawkaVAT = value;
            }
        }

        private decimal _Sztuki;
        public decimal Sztuki
        {
            get
            {
                return _Sztuki;
            }
            set
            {
                _Sztuki = value;
            }
        }

        private decimal _Rabat;
        public decimal Rabat
        {
            get
            {
                return _Rabat;
            }
            set
            {
                _Rabat = value;
            }
        }
        #endregion
    }
}
