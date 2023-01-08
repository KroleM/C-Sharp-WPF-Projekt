using Firma.Helpers;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Firma.ViewModels.Abstract
{
    /// <summary>
    /// To jest klasa, z której będą dziedziczyły wszystkie zakładki dodające nowe rekordy do tabel bez kluczy obcych
    /// </summary>
    /// <typeparam name="T">T: typ modelu z bazy danych, np. Towar lub Faktura</typeparam>
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        public ProjektDesktopyEntities Db { get; set; }
        /// <summary>
        /// Klasa z warstwy modelu
        /// </summary>
        public T Item { get; set; }
        #endregion
        #region Konstruktor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;//tu ustawiamy nazwę zakładki
            Db = new ProjektDesktopyEntities();
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
        private void saveAndClose()
        {
            if (IsValid())
            {
                Save();                 //zapisuje towar
                MessageBox.Show("Zapis udany.", "Sukces");
                base.OnRequestClose();  //zamyka zakładkę
            }
            else
            {
                MessageBox.Show("Zapis nieudany. Popraw błędy.", "Błąd");
            }
        }
        /// <summary>
        /// Metoda określająca, czy można zapisać dane do BD;
        /// </summary>
        /// <returns>Zwraca True, jeśli można zapisać</returns>
        protected virtual bool IsValid() => true;
        #endregion

    }
}
