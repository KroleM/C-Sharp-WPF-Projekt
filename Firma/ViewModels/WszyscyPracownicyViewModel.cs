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
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForAllView>
    {
        public WszyscyPracownicyViewModel() : base("Pracownicy")
        {
        }
        public override void Load()
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
                        PracownikStanowisko = pracownik.Stanowisko.Nazwa + " (" + pracownik.Stanowisko.Kategoria + ")",

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
