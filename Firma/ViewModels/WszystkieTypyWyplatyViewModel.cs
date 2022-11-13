using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class WszystkieTypyWyplatyViewModel : WszystkieViewModel<TypWyplaty>
    {
        #region Konstruktor
        public WszystkieTypyWyplatyViewModel()
            : base("Typy Wypłaty")
        {
        }
        #endregion
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<TypWyplaty>
                (
                from typWyplaty in ProjektTIUEntities.TypWyplaty
                where typWyplaty.CzyAktywny == true
                select typWyplaty
                );
        }
        #endregion
    }
}
