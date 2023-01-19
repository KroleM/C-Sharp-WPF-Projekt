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
using System.Windows.Automation.Peers;

namespace Firma.ViewModels
{
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForAllView>
    {
        #region Pola i Właściwości
        private int _PracownikId;
        public int PracownikId
        {
            get => _PracownikId;
            set
            {
                if (_PracownikId != value)
                {
                    _PracownikId = value;
                    OnPropertyChanged(() => PracownikId);
                    //TODO
                    //MessageBox.Show
                    WeakReferenceMessenger.Default.Send(ProjektDesktopyEntities.Pracownik.Where(arg => arg.Id == value).ToArray()[0]);
                    OnRequestClose();
                }
            }
        }
        #endregion
        public WszyscyPracownicyViewModel() : base("Pracownicy") { }
        protected override void Load()
        {
            List = new ObservableCollection<PracownikForAllView>
                (
                    from pracownik in ProjektDesktopyEntities.Pracownik
                    select new PracownikForAllView
                    {
                        Id = pracownik.Id,
                        Imie = pracownik.Imie,
                        Nazwisko = pracownik.Nazwisko,
                        PESEL = pracownik.PESEL,
                        PracownikAdres = pracownik.Adres.Nazwa,
                        PracownikTypUmowy = pracownik.TypUmowy.Nazwa,
                        PracownikDzial = pracownik.Dzial.Nazwa,
                        PracownikStanowisko = pracownik.Stanowisko.Nazwa + " (" + pracownik.Stanowisko.Kategoria.Trim() + ")",

                        Nazwa = pracownik.Nazwa,
                        CzyAktywny = pracownik.CzyAktywny,
                        DataUtworzenia = pracownik.DataUtworzenia,
                        DataModyfikacji = pracownik.DataModyfikacji,
                        KtoUtworzyl = pracownik.KtoUtworzyl,
                        KtoZmodyfikowal = pracownik.KtoZmodyfikowal,
                        Notatki = pracownik.Notatki
                    }   
                );
        }
    }
}
