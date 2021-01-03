using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ProjectGeavanceerde_WPF.Views;
using System.Threading.Tasks;
using ProjectGeavanceerde_DAL;
using ProjectGeavanceerde_DAL.Data;
using ProjectGeavanceerde_DAL.Data.unitOfWork;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;


namespace ProjectGeavanceerde_WPF.ViewModels
{
    public class AffiliationViewModel : BasisViewModel
    {
        #region getters and setters
        public bool Admincheck { get; set; }
        public ObservableCollection<Affiliation> Affiliations { get; set; }
        public ObservableCollection<Faction> Factions { get; set; }
        public Affiliation AffiliationRecord { get; set; }
        public string Foutmelding { get; set; }
        private Affiliation _selectedAffiliation;
        public Affiliation SelectedAffiliation
        {
            get { return _selectedAffiliation; }
            set
            {
                _selectedAffiliation = value;
                AffiliationRecordInstellen();
            }
        }

        #endregion
        public AffiliationViewModel()
        {
            RefreshAffiliations();
            WindowCommanding();
        }
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }
        private void RefreshAffiliations()
        {
            List<Faction> listFactions = unitOfWork.FactionRepo.Ophalen().ToList();
            List<Affiliation> listAffiliations = unitOfWork.AffiliationRepo.Ophalen().ToList();
            Affiliations = new ObservableCollection<Affiliation>(listAffiliations);
        }
        #region Controle
        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshAffiliations();
                Resetten();
            }
            else
            {
                Foutmelding = melding;
            }
        }
        public void Resetten()
        {
            if (this.IsGeldig())
            {
                SelectedAffiliation = null;
                AffiliationRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }
        public void Verwijderen()
        {
            if (SelectedAffiliation != null)
            {
                unitOfWork.AffiliationRepo.Verwijderen(SelectedAffiliation.AffiliationID);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Affiliation is niet verwijderd");
            }
            else
            {
                Foutmelding = "Eerst Affiliation selecteren";
            }
        }
        private void AffiliationRecordInstellen()
        {
            if (SelectedAffiliation != null)
            {
                AffiliationRecord = SelectedAffiliation;
            }
            else
            {
                AffiliationRecord = new Affiliation();
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Verwijderen": return true;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Verwijderen": Verwijderen(); break;
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
        #endregion
        #region WindowCommands
        public RelayCommand<Window> CloseWindowCommandChar { get; private set; }
        public RelayCommand<Window> CloseWindowCommandAff { get; private set; }
        public RelayCommand<Window> CloseWindowCommandAffEdit { get; private set; }
        public RelayCommand<Window> CloseWindowCommandAffAdd { get; private set; }
        public RelayCommand<Window> CloseWindowCommandArc { get; private set; }
        public RelayCommand<Window> CloseWindowCommandPlace { get; private set; }
        public RelayCommand<Window> CloseWindowCommandWT { get; private set; }


        public void CloseWindowChar(Window window)
        {
            if (Admincheck)
            {
                CharacterView characterView = new CharacterView();
                CharacterViewModel characterViewModel = new CharacterViewModel();
                characterView.DataContext = characterViewModel;
                characterViewModel.Admincheck = Admincheck;
                characterView.Show();
            }
            else
            {
                CharacterUserView characterView = new CharacterUserView();
                CharacterViewModel characterViewModel = new CharacterViewModel();
                characterView.DataContext = characterViewModel;
                characterViewModel.Admincheck = Admincheck;
                characterView.Show();
            }



            if (window != null)
            {
                window.Close();
            }
        }

        public void CloseWindowAff(Window window)
        {
            if (Admincheck)
            {
                AffiliationView affiliationView = new AffiliationView();
                AffiliationViewModel affiliationViewModel = new AffiliationViewModel();
                affiliationView.DataContext = affiliationViewModel;
                affiliationViewModel.Admincheck = Admincheck;
                affiliationView.Show();
            }
            else
            {
                AffiliationUserView affiliationView = new AffiliationUserView();
                AffiliationViewModel affiliationViewModel = new AffiliationViewModel();
                affiliationView.DataContext = affiliationViewModel;
                affiliationViewModel.Admincheck = Admincheck;
                affiliationView.Show();
            }

            if (window != null)
            {
                window.Close();
            }
        }
        public void CloseWindowAffEdit(Window window)
        {
            if (SelectedAffiliation != null)
            {
                AffEditView affEditView = new AffEditView();
                AffEditViewModel affEditViewModel = new AffEditViewModel();
                affEditViewModel.SelectedAffiliation = SelectedAffiliation;
                affEditView.DataContext = affEditViewModel;
                affEditViewModel.Admincheck = Admincheck;
                affEditView.Show();

                if (window != null)
                {
                    window.Close();
                }
            }
            else
            {
                Foutmelding = "Selecteer een character !";
            }
        }
        public void CloseWindowAffAdd(Window window)
        {
                AffAddView affAddView = new AffAddView();
                AffAddViewModel affAddViewModel = new AffAddViewModel();
                affAddView.DataContext = affAddViewModel;
                affAddViewModel.Admincheck = Admincheck;
                affAddView.Show();

                if (window != null)
                {
                    window.Close();
                }
        }

        public void CloseWindowArc(Window window)
        {
            if (Admincheck)
            {
                ArcView arcView = new ArcView();
                ArcViewModel arcViewModel = new ArcViewModel();
                arcView.DataContext = arcViewModel;
                arcViewModel.Admincheck = Admincheck;
                arcView.Show();
            }
            else
            {
                ArcUserView arcView = new ArcUserView();
                ArcViewModel arcViewModel = new ArcViewModel();
                arcView.DataContext = arcViewModel;
                arcViewModel.Admincheck = Admincheck;
                arcView.Show();
            }

            if (window != null)
            {
                window.Close();
            }
        }

        public void CloseWindowPlace(Window window)
        {

            if (Admincheck)
            {
                PlaceView placeView = new PlaceView();
                PlaceViewModel placeViewModel = new PlaceViewModel();
                placeView.DataContext = placeViewModel;
                placeViewModel.Admincheck = Admincheck;
                placeView.Show();
            }
            else
            {
                PlaceUserView placeView = new PlaceUserView();
                PlaceViewModel placeViewModel = new PlaceViewModel();
                placeView.DataContext = placeViewModel;
                placeViewModel.Admincheck = Admincheck;
                placeView.Show();
            }

            if (window != null)
            {
                window.Close();
            }
        }

        public void CloseWindowWT(Window window)
        {
            if (Admincheck)
            {
                WorldTimelineView worldTimelineView = new WorldTimelineView();
                WorldTimelineViewModel worldTimelineViewModel = new WorldTimelineViewModel();
                worldTimelineViewModel.Admincheck = Admincheck;
                worldTimelineView.DataContext = worldTimelineViewModel;
                worldTimelineView.Show();
            }
            else
            {
                WorldTimelineUserView worldTimelineView = new WorldTimelineUserView();
                WorldTimelineViewModel worldTimelineViewModel = new WorldTimelineViewModel();
                worldTimelineViewModel.Admincheck = Admincheck;
                worldTimelineView.DataContext = worldTimelineViewModel;
                worldTimelineView.Show();
            }

            if (window != null)
            {
                window.Close();
            }
        }
        public void WindowCommanding()
        {
            this.CloseWindowCommandChar = new RelayCommand<Window>(this.CloseWindowChar);
            this.CloseWindowCommandAff = new RelayCommand<Window>(this.CloseWindowAff);
            this.CloseWindowCommandAffEdit = new RelayCommand<Window>(this.CloseWindowAffEdit);
            this.CloseWindowCommandAffAdd = new RelayCommand<Window>(this.CloseWindowAffAdd);
            this.CloseWindowCommandArc = new RelayCommand<Window>(this.CloseWindowArc);
            this.CloseWindowCommandPlace = new RelayCommand<Window>(this.CloseWindowPlace);
            this.CloseWindowCommandWT = new RelayCommand<Window>(this.CloseWindowWT);
        }

        #endregion

    }
}
