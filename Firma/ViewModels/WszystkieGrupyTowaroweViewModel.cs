using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class WszystkieGrupyTowaroweViewModel : WszystkieViewModel<GrupaTowarowa>
    {
        #region Konstruktor
        public WszystkieGrupyTowaroweViewModel()
            : base("Grupy towarowe")
        {
        }
        #endregion
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<GrupaTowarowa>
                (
                from grupa in FakturyEntities.GrupaTowarowa
                where grupa.CzyAktywny == true
                select grupa
                );
        }
        #endregion
    }
}
