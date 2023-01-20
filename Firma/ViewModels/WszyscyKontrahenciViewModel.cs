using CommunityToolkit.Mvvm.Messaging;
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
        #region Pola i Właściwości
        private int _KontrahentId;
        public int KontrahentId
        {
            get => _KontrahentId;
            set
            {
                if (_KontrahentId != value)
                {
                    _KontrahentId = value;
                    OnPropertyChanged(() => KontrahentId);
                    //TODO
                    //MessageBox.Show
                    WeakReferenceMessenger.Default.Send(ProjektDesktopyEntities.Towar.Select(arg => arg.Id == value));
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Konstruktor
        public WszyscyKontrahenciViewModel() : base("Kontrahenci")
        {
        }            
        #endregion
        protected override void Load()
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
