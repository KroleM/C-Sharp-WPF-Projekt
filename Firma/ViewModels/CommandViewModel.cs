using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels
{
    //to jest klasa, która jest po to, żeby tworzyć komendy w Menu z lewej strony
    public class CommandViewModel:BaseViewModel
    {
        #region Properties
        public string DisplayName { get; set; } //to jest nazwa przycisku w menu z lewej strony
        public ICommand Command { get; set; } //każdy przycisk zawiera komendę, która wywołuje funkcję, która otwiera zakładkę
        #endregion
        #region Constructor
        public CommandViewModel(string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("Command");
            this.DisplayName = displayName;
            this.Command = command;
        }
        #endregion
    }
}
