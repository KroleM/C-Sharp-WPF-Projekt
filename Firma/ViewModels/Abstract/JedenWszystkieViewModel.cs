using CommunityToolkit.Mvvm.Messaging;
using Firma.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Abstract
{
    /// <summary>
    /// ViewModel realizujący połaczenie jeden do wielu. Np. jedna faktura posiada wiele pozycji faktury
    /// </summary>
    /// <typeparam name="J">Model typu "jeden", w tym wypadku Zamowienie</typeparam>
    /// <typeparam name="W">Model typu "wiele", np. PozycjaZamowienia</typeparam>
    public abstract class JedenWszystkieViewModel<J, W> : JedenViewModel<J>
    {
        #region PolaIWlasciwosci

        private string _DisplayListName;
        public string DisplayListName
        {
            get
            {
                return _DisplayListName;
            }
            set
            {
                if (value != _DisplayListName)
                {
                    _DisplayListName = value;
                    OnPropertyChanged(() => DisplayListName);
                }
            }
        }

        private ObservableCollection<W> _List;
        /// <summary>
        /// Lista z typem wiele, np. z pozycjami zamówienia
        /// </summary>
        public ObservableCollection<W> List
        {
            get
            {
                return _List;
            }
            set
            {
                if (value != _List)
                {
                    _List = value;
                    OnPropertyChanged(() => List);
                }
            }
        }

        private ICommand _ShowAddViewCommand;

        public ICommand ShowAddViewCommand
        {
            get
            {
                if (_ShowAddViewCommand == null)
                {
                    _ShowAddViewCommand = new BaseCommand(() => ShowAddView());
                }
                return _ShowAddViewCommand;
            }
        }

        #endregion

        #region Konstruktory
        public JedenWszystkieViewModel(string displayName, string displayListName)
            : base(displayName)
        {
            this.DisplayListName = displayListName;
        }

        #endregion

        #region Metody
        /// <summary>
        /// Metoda wysyła komunikat o otworzenie zakładki tworzenia nowego Modelu typu wiele. Np. wysyła komunikat, aby otworzyć zakładkę NowaPozycjaZamowieniaView.
        /// </summary>
        private void ShowAddView()
        {
            WeakReferenceMessenger.Default.Send(DisplayListName + " Add");
        }

        #endregion
    }
}
