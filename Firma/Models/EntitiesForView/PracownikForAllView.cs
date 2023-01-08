using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class PracownikForAllView : BaseForAllView
    {
        #region Properties
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string PESEL { get; set; }
        public string PracownikAdres { get; set; }
        public string PracownikTypUmowy { get; set; }
        public string PracownikDzial { get; set; }
        public string PracownikStanowisko { get; set; }
        #endregion
    }
}
