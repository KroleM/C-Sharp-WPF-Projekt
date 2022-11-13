using Firma.Helpers;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Abstract
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        public ProjektTIUEntities Db { get; set; }
        public T Item { get; set; }
        #endregion
        #region Konstruktor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;//tu ustawiamy nazwę zakładki
            Db = new ProjektTIUEntities();
        }
        #endregion

        #region Commands
        // To jest komenda, która zostanie podpięta (zbindowana) z przyciskiem "Zapisz i zamknij"
        // Komenda ta wywołuje funkcję "SaveAndClose()"
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveAndCloseCommand;
            }
        }

        #endregion
        #region Save
        public abstract void Save();
        public void saveAndClose()
        {
            Save();                 //zapisuje towar
            base.OnRequestClose();  //zamyka zakładkę
        }
        #endregion

    }
}
