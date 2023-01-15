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
    public class WszystkieDzialyViewModel : WszystkieViewModel<Dzial>
    {
        #region Konstruktor
        public WszystkieDzialyViewModel()
            : base("Działy")
        {
        }
        #endregion
        #region Helpers

        protected override void Load()
        {
            List = new ObservableCollection<Dzial>
                (
                from dzial in ProjektDesktopyEntities.Dzial
                where dzial.CzyAktywny == true
                select dzial
                );
        }
        #endregion
    }
}
