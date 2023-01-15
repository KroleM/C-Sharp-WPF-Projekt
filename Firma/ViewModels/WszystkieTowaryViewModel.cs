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
    public class WszystkieTowaryViewModel : WszystkieViewModel<TowarForAllView>
    {
        #region Konstruktor
        public WszystkieTowaryViewModel() : base("Towary")
        {
        }
        #endregion
        protected override void Load()
        {
            List = new ObservableCollection<TowarForAllView>
                (
                    from towar in ProjektDesktopyEntities.Towar
                    select new TowarForAllView
                    {
                        Id = towar.Id,
                        Kod = towar.Kod,
                        StawkaVatZakupu = towar.StawkaVatZakupu,
                        StawkaVatSprzedazy = towar.StawkaVatSprzedazy,
                        CenaNetto = towar.CenaNetto,
                        Waluta = towar.Waluta,
                        Marza = towar.Marza,
                        GrupaTowarowaNazwa = towar.GrupaTowarowa.Nazwa,
                        RynekSkrot = towar.Rynek.Skrot,

                        Nazwa = towar.Nazwa,
                        CzyAktywny = towar.CzyAktywny,
                        DataUtworzenia = towar.DataUtworzenia,
                        DataModyfikacji = towar.DataModyfikacji,
                        KtoUtworzyl = towar.KtoUtworzyl,
                        KtoZmodyfikowal = towar.KtoZmodyfikowal,
                        Notatki = towar.Notatki
                    }
                );
        }
    }
}
