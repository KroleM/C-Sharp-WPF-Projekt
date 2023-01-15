using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class WszystkieGrupyTowaroweViewModel : WszystkieViewModel<GrupaTowarowaForAllView>
    {
        #region Konstruktor
        public WszystkieGrupyTowaroweViewModel()
            : base("Grupy towarowe")
        {
        }
        #endregion
        #region Helpers
        protected override void Load()
        {
            List = new ObservableCollection<GrupaTowarowaForAllView>
                (
                    from grupaTow in ProjektDesktopyEntities.GrupaTowarowa
                    select new GrupaTowarowaForAllView
                    {
                        Id = grupaTow.Id,
                        Kod = grupaTow.Kod,
                        GrupaNadrzednaId = grupaTow.GrupaNadrzednaId,
                        GrupaNadrzednaNazwa = grupaTow.GrupaTowarowa2.Nazwa,


                        Nazwa = grupaTow.Nazwa,
                        CzyAktywny = grupaTow.CzyAktywny,
                        DataUtworzenia = grupaTow.DataUtworzenia,
                        DataModyfikacji = grupaTow.DataModyfikacji,
                        KtoUtworzyl = grupaTow.KtoUtworzyl,
                        KtoZmodyfikowal = grupaTow.KtoZmodyfikowal,
                        Notatki = grupaTow.Notatki
                    }
                );
        }
        #endregion
    }
}
