using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class KontrahentForAllView : BaseForAllView
    {
        #region Properties
        public string Kod { get; set; }
        public string NIP { get; set; }
        public string RodzajKontrahenta { get; set; }
        public string Adres { get; set; }
        public string GrupaRabatowa { get; set; }
        #endregion
    }
}
