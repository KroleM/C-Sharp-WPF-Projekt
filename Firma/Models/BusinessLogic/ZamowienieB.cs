using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class ZamowienieB : DatabaseClass
    {
        #region PolaIWlasciwosci

        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public Kontrahent Kontrahent { get; set; }

        #endregion

        #region Konstruktor
        public ZamowienieB(ProjektDesktopyEntities projektDesktopyEntities) : base(projektDesktopyEntities)
        {
        }
        #endregion

        #region Metody
        public decimal ObliczWartoscZamowien()
        {
            var listaZamowien = Db.Zamowienie.Where(item => item.DataWyslania >= Od && item.DataWyslania <= Do && item.KontrahentId == Kontrahent.Id);

            return listaZamowien.Count() == 0 ? 0 : listaZamowien.Sum(item => item.PozycjaZamowienia.Sum(arg => arg.Sztuki * Db.Towar.FirstOrDefault(x => x.Id == arg.TowarId).CenaNetto));

            // Poniższe wyrzuca błąd, gdy znaleziona lista wypłat (Where) jest pusta
            //return Db.Wyplata.Where(item => item.OkresOd >= Od && item.OkresDo <= Do && item.PracownikId == Pracownik.Id)
            //.Sum(item => item.Kwota);    //Sum(item => lambda...) zastępuje Select(...).Sum();
        }
        #endregion
    }
}
