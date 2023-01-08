using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class GrupaTowarowaForAllView : BaseForAllView
    {
        #region Properties
        public string Kod { get; set; }
        public int? GrupaNadrzednaId { get; set; }
        public string GrupaNadrzednaNazwa { get; set; }

        #endregion
    }
}
