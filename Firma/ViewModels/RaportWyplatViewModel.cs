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
    public class RaportWyplatViewModel : WorkspaceViewModel
    {
        #region PolaIWlasciwosci
        public List<Pracownik> Pracownicy { get; set; }
        public ProjektDesktopyEntities Db { get; set; }

        private Pracownik _WybranyPracownik;
        public Pracownik WybranyPracownik
        {
            get => _WybranyPracownik;
            set
            {
                if (value != _WybranyPracownik)
                {
                    _WybranyPracownik = value;
                    OnPropertyChanged(() => WybranyPracownik);
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

        private decimal _SumaWyplat;
        public decimal SumaWyplat
        {
            get => _SumaWyplat;
            set
            {
                if (value != _SumaWyplat)
                {
                    _SumaWyplat = value;
                    OnPropertyChanged(() => SumaWyplat);
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

        public WyplataB WyplataB { get; set; }

        #endregion

        #region Konstruktor
        public RaportWyplatViewModel()
        {
            base.DisplayName = "Raport wypłat";

            Db = new ProjektDesktopyEntities();

            Pracownicy = (from pracownik in Db.Pracownik
                      where pracownik.CzyAktywny == true
                      select pracownik).ToList();

            WyplataB = new WyplataB(Db);

            Od = DateTime.Now;
            Do = DateTime.Now;
        }
        #endregion

        #region Metody

        private void Oblicz()
        {
            WyplataB.Od = Od; // te 3 przypisania mogłyby również być zrobione w setterach
            WyplataB.Do = Do;
            WyplataB.Pracownik = WybranyPracownik;
            SumaWyplat = WyplataB.ObliczWyplaty();
        }

        #endregion
    }
}
