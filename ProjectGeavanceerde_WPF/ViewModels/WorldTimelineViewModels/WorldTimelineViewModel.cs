using System;
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
    public class WorldTimelineViewModel : BasisViewModel, IDisposable
    {
        public bool Admincheck { get; set; }
        public string Foutmelding { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public Event EventRecord { get; set; }

        private Event _selectedEvent;
        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                EventRecordInstellen();
                NotifyPropertyChanged("SelectedEvent");

            }
        }
        public WorldTimelineViewModel()
        {
            RefreshEvents();
            EventRecordInstellen();

            this.CloseWindowCommandChar = new RelayCommand<Window>(this.CloseWindowChar);
            this.CloseWindowCommandAff = new RelayCommand<Window>(this.CloseWindowAff);
            this.CloseWindowCommandArc = new RelayCommand<Window>(this.CloseWindowArc);
            this.CloseWindowCommandPlace = new RelayCommand<Window>(this.CloseWindowPlace);
            this.CloseWindowCommandWT = new RelayCommand<Window>(this.CloseWindowWT);
            this.CloseWindowCommandWTEdit = new RelayCommand<Window>(this.CloseWindowWTEdit);
            this.CloseWindowCommandWTAdd = new RelayCommand<Window>(this.CloseWindowWTAdd);

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
            if (SelectedEvent != null)
            {
                    unitOfWork.EventRepo.ToevoegenOfAanpassen(EventRecord);

                    int ok = unitOfWork.Save();
                    RefreshEvents();

                    FoutmeldingInstellenNaSave(ok, "Orderlijn is niet aangepast");
            }
            else
            {
                Foutmelding = "Selecteer een orderlijn!";
                NotifyPropertyChanged("Foutmelding");
            }
        }
        private void RefreshEvents()
        {
            List<Event> listEvents = unitOfWork.EventRepo.Ophalen().ToList();
            Events = new ObservableCollection<Event>(listEvents);
        }
        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshEvents();
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
                SelectedEvent = null;
                EventRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }
        public void Verwijderen()
        {
            if (SelectedEvent != null)
            {
                Foutmelding = "We zitten al iere";
                unitOfWork.EventRepo.Verwijderen(SelectedEvent.EventID);
                int ok = unitOfWork.Save();
                NotifyPropertyChanged("Foutmelding");
                FoutmeldingInstellenNaSave(ok, "Orderlijn is niet verwijderd");

            }
            else
            {
                Foutmelding = "Eerst Orderlijn selecteren";
                NotifyPropertyChanged("Foutmelding");
            }
        }
        public void Toevoegen()
        {
                if (EventRecord.IsGeldig())
                {
                    unitOfWork.EventRepo.Toevoegen(EventRecord);
                    int ok = unitOfWork.Save();

                    FoutmeldingInstellenNaSave(ok, "Orderlijn is niet toegevoegd");
                }
        }
        private void EventRecordInstellen()
        {
            if (SelectedEvent != null)
            {
                EventRecord = SelectedEvent;
            }
            else
            {
                EventRecord = new Event();
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Verwijderen": return true;
                case "Aanpassen": return true;
                case "Toevoegen": return true;
            }
                    return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Verwijderen": Verwijderen(); break;
                case "Aanpassen": Aanpassen(); break;
                case "Toevoegen": Toevoegen(); break;
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
        public RelayCommand<Window> CloseWindowCommandWTEdit { get; private set; }
        public RelayCommand<Window> CloseWindowCommandWTAdd { get; private set; }

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
                worldTimelineView.DataContext = worldTimelineViewModel;
                worldTimelineViewModel.Admincheck = Admincheck;
                worldTimelineView.Show();
            }
            else
            {
                WorldTimelineUserView worldTimelineView = new WorldTimelineUserView();
                WorldTimelineViewModel worldTimelineViewModel = new WorldTimelineViewModel();
                worldTimelineView.DataContext = worldTimelineViewModel;
                worldTimelineViewModel.Admincheck = Admincheck;
                worldTimelineView.Show();
            }

            if (window != null)
            {
                window.Close();
            }
        }
        public void CloseWindowWTEdit(Window window)
        {
            if (SelectedEvent != null)
            {
                WTEditView wTEditView = new WTEditView();
                WTEditViewModel wTEditViewModel = new WTEditViewModel();
                wTEditViewModel.SelectedEvent = SelectedEvent;
                wTEditView.DataContext = wTEditViewModel;
                wTEditView.Show();

                if (window != null)
                {
                    window.Close();
                }
            }
            else
            {
                Foutmelding = "Selecteer een event";
            }
        }
        public void CloseWindowWTAdd(Window window)
        {
            WTAddView wTAddView = new WTAddView();
            WTAddViewModel wTAddViewModel = new WTAddViewModel();
            wTAddView.DataContext = wTAddViewModel;
            wTAddView.Show();

            if (window != null)
            {
                window.Close();
            }
        }
        #endregion

    }
}
