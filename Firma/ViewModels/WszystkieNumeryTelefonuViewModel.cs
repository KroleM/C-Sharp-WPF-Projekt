using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Firma.ViewModels
{
    public class WszystkieNumeryTelefonuViewModel : WszystkieViewModel<NumerTelefonuForAllView>
    {
        #region Konstruktor
        public WszystkieNumeryTelefonuViewModel() : base("Numery telefonów")
        {
        }
        #endregion
        protected override void Load()
        {
            List = new ObservableCollection<NumerTelefonuForAllView>
                (
                    from numerTel in ProjektDesktopyEntities.NumerTelefonu
                    select new NumerTelefonuForAllView
                    {
                        Id = numerTel.Id,
                        Numer = numerTel.Numer,
                        Kraj = numerTel.Kraj,
                        Pracownik = numerTel.Pracownik.Nazwa,

                        Nazwa = numerTel.Nazwa,
                        CzyAktywny = numerTel.CzyAktywny,
                        DataUtworzenia = numerTel.DataUtworzenia,
                        DataModyfikacji = numerTel.DataModyfikacji,
                        KtoUtworzyl = numerTel.KtoUtworzyl,
                        KtoZmodyfikowal = numerTel.KtoZmodyfikowal,
                        Notatki = numerTel.Notatki
                    }
                );
        }
    }
}
