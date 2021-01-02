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
    public class WTAddViewModel : BasisViewModel, IDisposable
    {
        #region getters and setters
        public ObservableCollection<Event> Events { get; set; }
        public Event EventRecord = new Event();
        public string Foutmelding { get; set; }
        public string Omschrijving { get; set; }
        public int Date { get; set; }
        #endregion
        public WTAddViewModel()
        {
            RefreshEvents();
            WindowCommanding();
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
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
            EventRecord = new Event();
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

        public RelayCommand<Window> CloseWindowCommandWTAdd { get; private set; }

        public void CloseWindowWTAdd(Window window)
        {
            EventRecord.Omschrijving = Omschrijving;
            EventRecord.Date = Date;

            if (EventRecord.IsGeldig()) //problem needs to be solved
            {
                Foutmelding = "no work?";
                unitOfWork.EventRepo.Toevoegen(EventRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Event is niet toegevoegd");

                if (window != null)
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
                Foutmelding = "Record is niet geldig";
            }
        }
        public void WindowCommanding()
        {
            this.CloseWindowCommandWTAdd = new RelayCommand<Window>(this.CloseWindowWTAdd);
        }
    }
}