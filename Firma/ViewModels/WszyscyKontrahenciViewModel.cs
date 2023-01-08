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
    public class WszyscyKontrahenciViewModel : WszystkieViewModel<KontrahentForAllView>
    {
        #region Konstruktor
        public WszyscyKontrahenciViewModel() : base("Kontrahenci")
        {
        }            
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<KontrahentForAllView>
                (
                    from kontrahent in ProjektDesktopyEntities.Kontrahent
                    select new KontrahentForAllView
                    {
                        Id = kontrahent.Id,
                        Kod = kontrahent.Kod,
                        NIP = kontrahent.NIP,
                        RodzajKontrahenta = kontrahent.RodzajKontrahenta.Nazwa,
                        Adres = kontrahent.Adres.Nazwa,
                        GrupaRabatowa = kontrahent.GrupaRabatowa.Nazwa,

                        Nazwa = kontrahent.Nazwa,
                        CzyAktywny = kontrahent.CzyAktywny,
                        DataUtworzenia = kontrahent.DataUtworzenia,
                        DataModyfikacji = kontrahent.DataModyfikacji,
                        KtoUtworzyl = kontrahent.KtoUtworzyl,
                        KtoZmodyfikowal = kontrahent.KtoZmodyfikowal,
                        Notatki = kontrahent.Notatki
                    }
                );
        }
    }
}
