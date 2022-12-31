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
    public class WszystkieStanowiskaViewModel : WszystkieViewModel<Stanowisko>
    {
        #region Konstruktor
        public WszystkieStanowiskaViewModel()
            : base("Stanowiska")
        {
        }
        #endregion
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<Stanowisko>
                (
                from stanowisko in ProjektDesktopyEntities.Stanowisko
                where stanowisko.CzyAktywny == true
                select stanowisko
                );
        }
        #endregion
    }
}
