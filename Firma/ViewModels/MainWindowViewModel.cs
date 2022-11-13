using Firma.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;

namespace Firma.ViewModels
{
    public class MainWindowViewModel: BaseViewModel
    {
        //będzie zawierała kolekcję komend pojawiających się w lewym menu oraz kolekcję zakładek
        #region Komendy menu i paska narzędzi
        public ICommand NowyTowarCommand //ta komenda zostanie podpięta pod menu i pasek narzędzi
        { 
            get
            {
                //return new BaseCommand(createTowar);//to jest komenda, która wywołuje funkcję createTowar
                return new BaseCommand(() => createView(new NowyTowarViewModel()));
            }
        }
        public ICommand TowaryCommand
        {
            get
            {
                return new BaseCommand(showAllTowary);
            }
        }

        public ICommand NowaFakturaCommand 
        {
            get
            {
                return new BaseCommand(()=>createView(new NowaFakturaViewModel()));
            }
        }
        public ICommand FakturyCommand
        {
            get
            {
                return new BaseCommand(showAllFaktury);
            }
        }
        public ICommand NowyKontrahentCommand
        {
            get
            {
                return new BaseCommand(() =>createView(new NowyKontrahentViewModel()));
            }
        }
        public ICommand OperacjeMagazynoweCommand
        {
            get
            {
                return new BaseCommand(showOperacjeMagazynowe);
            }
        }
        public ICommand SprzedazCommand
        {
            get
            {
                return new BaseCommand(() => createView(new SprzedazViewModel()));
            }
        }
        //public ICommand ZamykanieCommand
        //{
        //    get
        //    {
        //        return new BaseCommand(Zamykanie);
        //    }
        //}
        public ICommand ZamykanieCommand => new BaseCommand(zamykanieKart);
        public ICommand ZakonczCommand => new BaseCommand(zakonczClick);
        #endregion

        #region Przyciski w menu po lewej stronie
        private ReadOnlyCollection<CommandViewModel> _Commands; //to jest kolekcja komend w menu lewym
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get 
            { 
                if(_Commands == null) //sprawdza, czy przyciski z lewej strony menu nie zostały już zainicjalizowane
                {
                    List<CommandViewModel> cmds = this.CreateCommands();//tworzę listę przycisków za pomocą funkcji CreateCommands
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);//tę listę przypisuję do ReadOnlyCollection (bo ReadOnlyCollection można tylko tworzyć, nie można do niej dodawać)
                }
                return _Commands; 
            }
        }
        private List<CommandViewModel> CreateCommands() //tu decydujemy jakie przyciski są w lewym menu
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Towary", 
                    new BaseCommand(() => this.showAllTowary())), //to tworzy pierwszy przycisk o nazwie Towary, który pokaże zakładkę wszystkie towary
                new CommandViewModel(
                    "Nowy towar", 
                    new BaseCommand(()=>createView(new NowyTowarViewModel()))), //drugi przycisk, w nawiasie jest nazwa funkcji
                new CommandViewModel(
                    "Nowa faktura", 
                    new BaseCommand(()=>createView(new NowaFakturaViewModel()))),
                new CommandViewModel(
                    "Faktury",
                    new BaseCommand(() => this.showAllFaktury())),
                new CommandViewModel(
                    "Nowy kontrahent", 
                    new BaseCommand(() =>createView(new NowyKontrahentViewModel()))),
                new CommandViewModel(
                    "Operacje magazynowe",
                    new BaseCommand(() => this.showOperacjeMagazynowe())),
                new CommandViewModel(
                    "Nowy typ umowy",
                    new BaseCommand(() =>createView(new NowyTypUmowyViewModel()))),
                new CommandViewModel(
                    "Typy umowy",
                    new BaseCommand(() => this.showTypyUmowy())),
                new CommandViewModel(
                    "Nowy typ wypłaty",
                    new BaseCommand(()  =>createView(new NowyTypWyplatyViewModel()))),
                new CommandViewModel(
                    "Typy wypłaty",
                    new BaseCommand(() => this.showTypyWyplaty())),
                new CommandViewModel(
                    "Nowy adres",
                    new BaseCommand(()  =>createView(new NowyAdresViewModel()))),
                new CommandViewModel(
                    "Wszystkie adresy",
                    new BaseCommand(() => this.showAllAdresy())),                
                new CommandViewModel(
                    "Nowy rodzaj kontrah.",
                    new BaseCommand(()  =>createView(new NowyRodzajViewModel()))),
                new CommandViewModel(
                    "Rodzaje kontrahentów",
                    new BaseCommand(() => this.showAllRodzaje())),                
                new CommandViewModel(
                    "Nowa grupa rabatowa",
                    new BaseCommand(()  =>createView(new NowaGrupaRabatowaViewModel()))),
                new CommandViewModel(
                    "Grupy rabatowe",
                    new BaseCommand(() => this.showGrupyRabatowe())),                
                new CommandViewModel(
                    "Nowy rynek",
                    new BaseCommand(()  =>createView(new NowyRynekViewModel()))),
                new CommandViewModel(
                    "Rynki",
                    new BaseCommand(() => this.showAllRynki())),
            };
        }
        #endregion

        #region Zakładki
        //Workspaces
        private ObservableCollection<WorkspaceViewModel> _Workspaces; //to jest kolekcja zakładek
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if(_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChange;
                }
                return _Workspaces;
            }
        }

        private void onWorkspacesChange(object sender, NotifyCollectionChangedEventArgs e) 
        {
            if (e.NewItems != null && e.NewItems.Count != 0) 
                foreach (WorkspaceViewModel workspace in e.NewItems) 
                    workspace.RequestClose += this.OnWorkspaceRequestClose; 
            
            if (e.OldItems != null && e.OldItems.Count != 0) 
                foreach (WorkspaceViewModel workspace in e.OldItems) 
                    workspace.RequestClose -= this.OnWorkspaceRequestClose; 
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel; 
            //workspace.Dispose();
            this.Workspaces.Remove(workspace); 
        }
        #endregion

        #region Funkcje Pomocnicze
        //uniwersalny kreator widoku - niepowtarzalnosc kodu!!
        private void createView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        //private void createFaktura()
        //{
        //    NowaFakturaViewModel workspace = new NowaFakturaViewModel();
        //    this.Workspaces.Add(workspace);
        //    this.SetActiveWorkspace(workspace);
        //}
        private void showAllFaktury()
        {
            WszystkieFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel) as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        //to jest funkcja, która otwiera nową zakładkę
        //za każdym razem tworzy NOWĄ zakładkę do dodawania towaru
        /*
        private void createTowar()
        {
            //tworzymmy zakładkę(ViewModel) NowyTowar
            NowyTowarViewModel workspace = new NowyTowarViewModel();
            //dodajemy ją do kolekcji aktywnych zakładek
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        } */
        //to jest funkcja, która otwiera zakładkę ze wszystkimi towarami
        //za każdym razem sprawdza, czy zakładka z towarami jest już otwarta
        //jak jest, to ją aktywuje, jak nie ma, to tworzy
        private void showAllTowary()
        {
            //szukamy w kolekcji zakładek takiej zakładki (vm), która jest wszystkimi towarami
            WszystkieTowaryViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel) as WszystkieTowaryViewModel;
            //jeżeli takiej zakładki nie ma, to będziemy ją tworzyć
            if(workspace == null)
            {
                //tworzymy nową zakładkę Wszystkie Towary
                workspace = new WszystkieTowaryViewModel();
                //i dodajemy ją do kolekcji zakładek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakładkę
            this.SetActiveWorkspace(workspace);
        }
        private void showOperacjeMagazynowe()
        {
            OperacjeMagazynoweViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is OperacjeMagazynoweViewModel) as OperacjeMagazynoweViewModel;
            if (workspace == null)
            {
                //tworzymy nową zakładkę Wszystkie Towary
                workspace = new OperacjeMagazynoweViewModel();
                //i dodajemy ją do kolekcji zakładek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakładkę
            this.SetActiveWorkspace(workspace);
        }
        private void showTypyUmowy()
        {
            WszystkieTypyUmowyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTypyUmowyViewModel) as WszystkieTypyUmowyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyUmowyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void showTypyWyplaty()
        {
            WszystkieTypyWyplatyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTypyWyplatyViewModel) as WszystkieTypyWyplatyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyWyplatyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void showAllAdresy()
        {
            WszystkieAdresyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel) as WszystkieAdresyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void showAllRodzaje()
        {
            WszystkieRodzajeViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajeViewModel) as WszystkieRodzajeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void showGrupyRabatowe()
        {
            WszystkieGrupyRabatoweViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieGrupyRabatoweViewModel) as WszystkieGrupyRabatoweViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieGrupyRabatoweViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void showAllRynki()
        {
            WszystkieRynkiViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieRynkiViewModel) as WszystkieRynkiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRynkiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void zamykanieKart()
        {
            this.Workspaces.Clear();
        }
        private void zakonczClick()
        {
            Application.Current.Shutdown();
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace) 
        { 
            Debug.Assert(this.Workspaces.Contains(workspace)); 
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces); 
            if (collectionView != null) 
                collectionView.MoveCurrentTo(workspace); 
        }

        #endregion

        #region Konstruktor
        public MainWindowViewModel()
        {

        }
        #endregion
    }
}
