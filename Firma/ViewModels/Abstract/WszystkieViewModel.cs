using CommunityToolkit.Mvvm.Messaging;
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
        #region Fields & Properties
        // Obiekt do operacji na bazie danych
        private readonly ProjektDesktopyEntities projektDesktopyEntities;   //ewentualnie to może być protected, a wtedy nie będzie Propertisa
        public ProjektDesktopyEntities ProjektDesktopyEntities
        {
            get
            {
                return projektDesktopyEntities;
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
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => Add());
                }
                return _AddCommand;
            }
        }
        // W tym obiekcie będą wszystkie przedstawiane obiekty T
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
        private bool _CzyNieaktywne;
        public bool CzyNieaktywne
        {
            get => _CzyNieaktywne;
            set
            {
                if(_CzyNieaktywne != value)
                {
                    _CzyNieaktywne = value;
                    Load();
                    OnPropertyChanged(() => CzyNieaktywne);
                }
            }
        }
        public List<T> AllList { get; set; }
        public List<string> SortComboBoxItems { get; set; }
        public string SortField { get; set; }
        public bool SortDescending { get; set; }

        private ICommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }

        public List<string> SearchComboBoxItems { get; set; }
        public string SearchField { get; set; }
        private ICommand _SearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new BaseCommand(() => Search());
                }
                return _SearchCommand;
            }
        }

        private string _SearchText;
        public string SearchText
        {
            get => _SearchText;
            set
            {
                if (value != _SearchText)
                {
                    _SearchText = value?.ToLower().Trim();
                    OnPropertyChanged(() => SearchText);
                }
            }
        }
        #endregion
        #region Constructor
        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName; //tu ustawiamy nazwę zakładki
            this.projektDesktopyEntities = new ProjektDesktopyEntities();
            _CzyNieaktywne = false;
            SortComboBoxItems = getSortComboBoxItems();
            SearchComboBoxItems = getSearchComboBoxItems();
            SearchField = SearchComboBoxItems.First();
            SortField = SortComboBoxItems.First();
        }
        #endregion
        #region Helpers
        private void Add()
        {
            WeakReferenceMessenger.Default.Send(DisplayName + " Add");
        }
        protected abstract void Load();
        abstract protected List<string> getSortComboBoxItems();
        abstract protected void Sort();
        abstract protected List<string> getSearchComboBoxItems();
        abstract protected void Search();
        #endregion
    }
}
