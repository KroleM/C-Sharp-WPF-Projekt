using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class DzialB : DatabaseClass
    {
        public Dzial Dzial { get; set; }

        #region Konstruktory
        public DzialB(ProjektDesktopyEntities projektDesktopyEntities) : base(projektDesktopyEntities)
        {
        }
        #endregion

        #region Metody
        public int ObliczLiczebnosc(TypUmowy typ = null)
        {
            return Db.Pracownik.Where(item => item.DzialId == Dzial.Id).Count();
        }
        public List<KeyValuePair<string, int>> WyswietlPary()
        {
            var lista = new List<KeyValuePair<string, int>>();
            foreach (var typUmowy in Db.TypUmowy.Where(item => item.CzyAktywny))
            {
                lista.Add(new KeyValuePair<string, int>(typUmowy.Nazwa, Db.Pracownik.Where(item => item.DzialId == Dzial.Id && item.TypUmowyId == typUmowy.Id).Count()));
            }
            return lista;
        }
        #endregion
    }
}
