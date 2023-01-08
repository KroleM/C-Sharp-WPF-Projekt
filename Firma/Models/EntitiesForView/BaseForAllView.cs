using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class BaseForAllView
    {
        #region Properties
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public bool CzyAktywny { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public DateTime DataModyfikacji { get; set; }
        public string KtoUtworzyl { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public string Notatki { get; set; }
        #endregion
    }
}
