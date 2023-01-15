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
    public class WszystkieZamowieniaViewModel : WszystkieViewModel<ZamowienieForAllView>
    {
        public WszystkieZamowieniaViewModel() : base("Zamówienia")
        {
        }
        protected override void Load()
        {
            List = new ObservableCollection<ZamowienieForAllView>
                (
                    from zamowienie in ProjektDesktopyEntities.Zamowienie
                    select new ZamowienieForAllView
                    {
                        Id = zamowienie.Id,
                        KontrahentNazwa = zamowienie.Kontrahent.Nazwa,
                        KontrahentGrupaRabatowa = zamowienie.Kontrahent.GrupaRabatowa.Nazwa,    // ???
                        DataWyslania = zamowienie.DataWyslania,

                        Nazwa = zamowienie.Nazwa,
                        CzyAktywny = zamowienie.CzyAktywny,
                        DataUtworzenia = zamowienie.DataUtworzenia,
                        DataModyfikacji = zamowienie.DataModyfikacji,
                        KtoUtworzyl = zamowienie.KtoUtworzyl,
                        KtoZmodyfikowal = zamowienie.KtoZmodyfikowal,
                        Notatki = zamowienie.Notatki
                    }
                );
        }
    }
}
