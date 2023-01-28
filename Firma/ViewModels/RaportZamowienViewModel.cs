using Firma.Helpers;
using Firma.Models.BusinessLogic;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class RaportZamowienViewModel : WorkspaceViewModel
    {
        #region PolaIWlasciwosci
        public List<Kontrahent> Kontrahenci { get; set; }
        public ProjektDesktopyEntities Db { get; set; }

        private Kontrahent _WybranyKontrahent;
        public Kontrahent WybranyKontrahent
        {
            get => _WybranyKontrahent;
            set
            {
                if (value != _WybranyKontrahent)
                {
                    _WybranyKontrahent = value;
                    OnPropertyChanged(() => WybranyKontrahent);
                }
            }
        }

        private DateTime _Od;
        public DateTime Od
        {
            get => _Od;
            set
            {
                if (value != _Od)
                {
                    _Od = value;
                    OnPropertyChanged(() => Od);
                }
            }
        }

        private DateTime _Do;
        public DateTime Do
        {
            get => _Do;
            set
            {
                if (value != _Do)
                {
                    _Do = value;
                    OnPropertyChanged(() => Do);
                }
            }
        }

        private decimal _KwotaZamowien;
        public decimal KwotaZamowien
        {
            get => _KwotaZamowien;
            set
            {
                if (value != _KwotaZamowien)
                {
                    _KwotaZamowien = value;
                    OnPropertyChanged(() => KwotaZamowien);
                }
            }
        }

        private ICommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => Oblicz());
                }
                return _ObliczCommand;
            }
        }

        public ZamowienieB ZamowienieB { get; set; }

        #endregion

        #region Konstruktor
        public RaportZamowienViewModel()
        {
            base.DisplayName = "Raport zamówień";

            Db = new ProjektDesktopyEntities();

            Kontrahenci = (from kontrahent in Db.Kontrahent
                          where kontrahent.CzyAktywny == true
                          select kontrahent).ToList();

            ZamowienieB = new ZamowienieB(Db);

            Od = DateTime.Now;
            Do = DateTime.Now;
        }
        #endregion

        #region Metody

        private void Oblicz()
        {
            ZamowienieB.Od = Od; // te 3 przypisania mogłyby również być zrobione w setterach
            ZamowienieB.Do = Do;
            ZamowienieB.Kontrahent = WybranyKontrahent;
            KwotaZamowien = ZamowienieB.ObliczWartoscZamowien();
        }

        #endregion
    }
}
