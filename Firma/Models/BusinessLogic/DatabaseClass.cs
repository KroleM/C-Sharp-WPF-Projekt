using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    /// <summary>
    /// Klasa bazodanowa - zawiera połączenie z bazą danych.
    /// Stanowi klasę bazową dla wyższych klas logiki biznesowej.
    /// </summary>
    public class DatabaseClass
    {
        #region PolaIWlasciwosci
        public ProjektDesktopyEntities Db { get; set; }
        #endregion

        #region Konstruktory

        public DatabaseClass(ProjektDesktopyEntities projektDesktopyEntities)
        {
            Db = projektDesktopyEntities;
        }
        #endregion
    }
}
