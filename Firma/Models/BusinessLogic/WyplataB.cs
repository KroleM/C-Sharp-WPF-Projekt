using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class WyplataB : DatabaseClass
    {
        #region PolaIWlasciwosci

        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public Pracownik Pracownik { get; set; }

        #endregion

        #region Konstruktory

        public WyplataB(ProjektDesktopyEntities projektDesktopyEntities) : base(projektDesktopyEntities)
        {
        }

        #endregion

        #region Metody
        public decimal ObliczWyplaty()
        {
            var listaWyplat = Db.Wyplata.Where(item => item.OkresOd >= Od && item.OkresDo <= Do && item.PracownikId == Pracownik.Id);
            
            return listaWyplat.Count() == 0 ? 0 : listaWyplat.Sum(item => item.Kwota);

            // Poniższe wyrzuca błąd, gdy znaleziona lista wypłat (Where) jest pusta
            //return Db.Wyplata.Where(item => item.OkresOd >= Od && item.OkresDo <= Do && item.PracownikId == Pracownik.Id)
                                    //.Sum(item => item.Kwota);    //Sum(item => lambda...) zastępuje Select(...).Sum();

        }
        #endregion
    }
}
