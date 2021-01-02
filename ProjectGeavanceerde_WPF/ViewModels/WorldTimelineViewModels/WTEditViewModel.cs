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
    class WTEditViewModel : BasisViewModel, IDisposable
    {
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
        public WTEditViewModel()
        {
            RefreshEvents();
            EventRecordInstellen();

            this.CloseWindowCommandWTEdit = new RelayCommand<Window>(this.CloseWindowWTEdit);
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
                case "Aanpassen": return true;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
        #region WindowCommands

        public RelayCommand<Window> CloseWindowCommandWTEdit { get; private set; }

        public void CloseWindowWTEdit(Window window)
        {
            if (SelectedEvent != null)
            {
                if (EventRecord.IsGeldig())
                    unitOfWork.EventRepo.ToevoegenOfAanpassen(EventRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Event is niet aangepast");
                if (window != null && ok > 0)
                {
                    WorldTimelineView worldTimelineView = new WorldTimelineView();
                    WorldTimelineViewModel worldTimelineViewModel = new WorldTimelineViewModel();
                    worldTimelineView.DataContext = worldTimelineViewModel;
                    worldTimelineView.Show();
                    window.Close();
                }
            }
            else
            {
                Foutmelding = "Selecteer een Event!";
            }

        }
        #endregion
    }
}