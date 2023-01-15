using CommunityToolkit.Mvvm.Messaging;
using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Firma.ViewModels
{
    public class WszystkieAdresyViewModel : WszystkieViewModel<Adres>
    {
        #region Pola i Właściwości
        private Adres _WybranyAdres;
        public Adres WybranyAdres
        {
            get => _WybranyAdres;
            set
            {
                if(_WybranyAdres != value)
                {
                    _WybranyAdres = value;
                    OnPropertyChanged(() => WybranyAdres);
                    //TODO
                    //MessageBox.Show
                    WeakReferenceMessenger.Default.Send(_WybranyAdres);
                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Konstruktor
        public WszystkieAdresyViewModel() : base("Adresy") { }
        #endregion

        #region Helpers
        protected override void Load()
        {
            List = new ObservableCollection<Adres>
                (
                from adres in ProjektDesktopyEntities.Adres
                where adres.CzyAktywny == true
                select adres
                );
        }
        #endregion
    }
}
