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
    public class RaportDzialyViewModel : WorkspaceViewModel
    {
        public List<Dzial> Dzialy { get; set; }
        public ProjektDesktopyEntities Db { get; set; }
        private Dzial _WybranyDzial;
        public Dzial WybranyDzial
        {
            get => _WybranyDzial;
            set
            {
                if (value != _WybranyDzial)
                {
                    _WybranyDzial = value;
                    OnPropertyChanged(() => WybranyDzial);
                }
            }
        }
        private BaseCommand _ObliczCommand;
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
        public bool CzyWybrane { get; set; }
        public DzialB DzialB { get; set; }
        private List<KeyValuePair<string, int>> _TypUmowyPracownik;
        public List<KeyValuePair<string, int>> TypUmowyPracownik
        {
            get => _TypUmowyPracownik;
            set
            {
                if (value != _TypUmowyPracownik)
                {
                    _TypUmowyPracownik = value;
                    OnPropertyChanged(() => TypUmowyPracownik);
                }
            }
        }
        private int _LiczebnoscDzialu;
        public int LiczebnoscDzialu
        {
            get => _LiczebnoscDzialu;
            set
            {
                if (value != _LiczebnoscDzialu)
                {
                    _LiczebnoscDzialu = value;
                    OnPropertyChanged(() => LiczebnoscDzialu);
                }
            }
        }

        #region Konstruktor
        public RaportDzialyViewModel()
        {
            base.DisplayName = "Raport zatrudnienia w działach";

            Db = new ProjektDesktopyEntities();

            Dzialy = (from dzial in Db.Dzial
                           where dzial.CzyAktywny == true
                           select dzial).ToList();

            DzialB = new DzialB(Db);

        }
        #endregion

        #region Metody

        private void Oblicz()
        {
            DzialB.Dzial = WybranyDzial;
            LiczebnoscDzialu = DzialB.ObliczLiczebnosc();
            TypUmowyPracownik = DzialB.WyswietlPary();

            if (!CzyWybrane)
            {
                CzyWybrane = true;
                OnPropertyChanged(() => CzyWybrane);
            }
        }

        #endregion
    }
}
