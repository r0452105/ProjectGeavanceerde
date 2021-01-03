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
    public class PlaceAddViewModel : BasisViewModel, IDisposable
    {
        #region getters and setters
        public bool Admincheck { get; set; }
        public ObservableCollection<Place> Places { get; set; }
        public Place PlaceRecord = new Place();
        public string Foutmelding { get; set; }
        public string Name { get; set; }
        public string Ruler { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }

        #endregion
        public PlaceAddViewModel()
        {
            RefreshPlaces();
            WindowCommanding();
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        #region Controle en Functies
        private void RefreshPlaces()
        {
            List<Place> listPlaces = unitOfWork.PlaceRepo.Ophalen().ToList();
            Places = new ObservableCollection<Place>(listPlaces);
        }
        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshPlaces();
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
                PlaceRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }
        private void PlaceRecordInstellen()
        {
            PlaceRecord = new Place();
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
        #endregion
        #region Window Commanding

        public RelayCommand<Window> CloseWindowCommandPlaceAdd { get; private set; }
        public RelayCommand<Window> CloseWindowCommandPlaceAddBack { get; private set; }

        public void CloseWindowPlaceAdd(Window window)
        {
            PlaceRecord.Name = Name;
            PlaceRecord.Ruler = Ruler;
            PlaceRecord.Location = Location;
            PlaceRecord.Country = Country;

            if (PlaceRecord.IsGeldig()) //problem needs to be solved
            {
                unitOfWork.PlaceRepo.Toevoegen(PlaceRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Plaats is niet toegevoegd");

                if (window != null)
                {
                    PlaceView placeView = new PlaceView();
                    PlaceViewModel placeViewModel = new PlaceViewModel();
                    placeView.DataContext = placeViewModel;
                    placeViewModel.Admincheck = Admincheck;
                    placeView.Show();
                    window.Close();
                }
            }
            else
            {
                Foutmelding = "Vul alle gegevens in.";
            }
        }
        public void CloseWindowPlaceAddBack(Window window)
        {
                if (window != null)
                {
                    PlaceView placeView = new PlaceView();
                    PlaceViewModel placeViewModel = new PlaceViewModel();
                    placeView.DataContext = placeViewModel;
                    placeViewModel.Admincheck = Admincheck;
                    placeView.Show();
                    window.Close();
                }
        }
        public void WindowCommanding()
        {
            this.CloseWindowCommandPlaceAdd = new RelayCommand<Window>(this.CloseWindowPlaceAdd);
            this.CloseWindowCommandPlaceAddBack = new RelayCommand<Window>(this.CloseWindowPlaceAddBack);
        }
        #endregion
    }
}