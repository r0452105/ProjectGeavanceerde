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
                //NotifyPropertyChanged("SelectedOrderlijn");
                //NotifyPropertyChanged(); //omdat er gewerkt wordt met nuget package Propertychanged.Fody hoeft dit niet meer

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
        public void Aanpassen()
        {
            if (SelectedAffiliation != null)
            {
                unitOfWork.AffiliationRepo.ToevoegenOfAanpassen(AffiliationRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Affiliation is niet aangepast");
            }
            else
            {
                Foutmelding = "Selecteer een affiliation!";
            }
        }
        private void RefreshAffiliations()
        {
            List<Faction> listFactions = unitOfWork.FactionRepo.Ophalen().ToList();
            List<Affiliation> listAffiliations = unitOfWork.AffiliationRepo.Ophalen().ToList();
            Affiliations = new ObservableCollection<Affiliation>(listAffiliations);
        }
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
                case "Aanpassen": return true;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Verwijderen": Verwijderen(); break;
                case "Aanpassen": Aanpassen(); break;
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }

        #region WindowCommands
        public RelayCommand<Window> CloseWindowCommandChar { get; private set; }
        public RelayCommand<Window> CloseWindowCommandAff { get; private set; }
        public RelayCommand<Window> CloseWindowCommandArc { get; private set; }
        public RelayCommand<Window> CloseWindowCommandPlace { get; private set; }
        public RelayCommand<Window> CloseWindowCommandWT { get; private set; }


        public void CloseWindowChar(Window window)
        {
            CharacterView characterView = new CharacterView();
            CharacterViewModel characterViewModel = new CharacterViewModel();
            characterView.DataContext = characterViewModel;
            characterView.Show();

            if (window != null)
            {
                window.Close();
            }
        }

        public void CloseWindowAff(Window window)
        {
            AffiliationView affiliationView = new AffiliationView();
            AffiliationViewModel affiliationViewModel = new AffiliationViewModel();
            affiliationView.DataContext = affiliationViewModel;
            affiliationView.Show();

            if (window != null)
            {
                window.Close();
            }
        }

        public void CloseWindowArc(Window window)
        {
            ArcView arcView = new ArcView();
            ArcViewModel arcViewModel = new ArcViewModel();
            arcView.DataContext = arcViewModel;
            arcView.Show();

            if (window != null)
            {
                window.Close();
            }
        }

        public void CloseWindowPlace(Window window)
        {
            PlaceView placeView = new PlaceView();
            PlaceViewModel placeViewModel = new PlaceViewModel();
            placeView.DataContext = placeViewModel;
            placeView.Show();

            if (window != null)
            {
                window.Close();
            }
        }

        public void CloseWindowWT(Window window)
        {
            WorldTimelineView worldTimelineView = new WorldTimelineView();
            WorldTimelineViewModel worldTimelineViewModel = new WorldTimelineViewModel();
            worldTimelineView.DataContext = worldTimelineViewModel;
            worldTimelineView.Show();

            if (window != null)
            {
                window.Close();
            }
        }
        public void WindowCommanding()
        {
            this.CloseWindowCommandChar = new RelayCommand<Window>(this.CloseWindowChar);
            this.CloseWindowCommandAff = new RelayCommand<Window>(this.CloseWindowAff);
            this.CloseWindowCommandArc = new RelayCommand<Window>(this.CloseWindowArc);
            this.CloseWindowCommandPlace = new RelayCommand<Window>(this.CloseWindowPlace);
            this.CloseWindowCommandWT = new RelayCommand<Window>(this.CloseWindowWT);
        }

        #endregion

    }
}
