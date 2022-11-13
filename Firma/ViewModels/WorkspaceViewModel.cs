using Firma.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels
{
    //to jest klasa, z której dziedziczyć będą wszystkie ViewModele zakładek
    //każde View ma swój ViewModel
    public class WorkspaceViewModel : BaseViewModel
    {
        #region Pola i Komendy
        //każda zakładka ma minimum nazwę i zamknij
        public string DisplayName { get; set; } //w tym propertisie będzie przechowywana nazwa zakładki
        //private readonly BaseViewModel _CloseCommand; ???
        private BaseCommand _CloseCommand; //to jest komenda do obsługi zamykania okna (zakładki)

        public WorkspaceViewModel()
        {
        }

        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(() => this.OnRequestClose()); //ta komenda wywoła funkcję zamykającą zakładkę
                return _CloseCommand;
            }
        }
        #endregion
        #region RequestClose [event] 
        public event EventHandler RequestClose;
        public void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion
    }
}

