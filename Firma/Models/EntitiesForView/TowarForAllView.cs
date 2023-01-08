using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class TowarForAllView : BaseForAllView
    {
        #region Properties
        public string Kod { get; set; }
        public decimal StawkaVatZakupu { get; set; }
        public decimal StawkaVatSprzedazy { get; set; }
        public decimal CenaNetto { get; set; }
        public decimal CenaBrutto { get; set; }
        public string Waluta { get; set; }
        public decimal Marza { get; set; }
        public string GrupaTowarowaNazwa { get; set; }
        public string RynekSkrot { get; set; }
        #endregion
    }
}
