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
    public class WszystkieAdresyViewModel : WszystkieViewModel<Adres>
    {
        #region Konstruktor
        public WszystkieAdresyViewModel()
            : base("Adresy")
        {
        }
        #endregion
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<Adres>
                (
                from adres in ProjektTIUEntities.Adres
                //where adres.CzyAktywny == true
                select adres
                );
        }
        #endregion
    }
}
