using Firma.Helpers;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Abstract
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        // Obiekt do operacji na bazie danych
        private readonly ProjektTIUEntities projektTIUEntities;   //ewentualnie to może być protected, a wtedy nie będzie Propertisa
        public ProjektTIUEntities ProjektTIUEntities
        {
            get
            {
                return projektTIUEntities;
            }
        }
        // To jest komenda do załadowania towarów
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load());
                }
                return _LoadCommand;
            }
        }
        // W tym obiekcie będą wszystkie towary
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) //gdy lista jest pusta wywołujemy Load(), żeby załadować towary
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName; //tu ustawiamy nazwę zakładki
            this.projektTIUEntities = new ProjektTIUEntities();
        }
        #endregion
        #region Helpers
        public abstract void Load();
        #endregion
    }
}
