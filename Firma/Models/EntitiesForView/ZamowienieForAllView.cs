using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class ZamowienieForAllView : BaseForAllView
    {
        #region Properties
        public string KontrahentNazwa { get; set; }
        public string KontrahentGrupaRabatowa { get; set; }
        public DateTime? DataWyslania { get; set; }

        #endregion
    }
}
