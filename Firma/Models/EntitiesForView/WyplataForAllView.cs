using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class WyplataForAllView
    {
        #region Properties
        public int IdWyplaty { get; set; }
        public string PracownikImieNazwisko { get; set; }
        public int IdPracownika { get; set; }
        public string TypWyplatyNazwa { get; set; }
        public decimal? Kwota { get; set; }
        public string Waluta { get; set; }
        public DateTime? DataOd { get; set; }
        public DateTime? DataDo { get; set; }
        #endregion
    }
}
