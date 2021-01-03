﻿using System;
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
    public class PlaceViewModel : BasisViewModel
    {
        #region getters en setters
        public bool Admincheck { get; set; }
        public ObservableCollection<Place> Places { get; set; }

        public Place PlaceRecord { get; set; }
        public string Foutmelding { get; set; }
        private Place _selectedPlace;
        public Place SelectedPlace
        {
            get { return _selectedPlace; }
            set
            {
                _selectedPlace = value;
                PlaceRecordInstellen();
            }
        }
        #endregion
        #region Controle en Functies
        public PlaceViewModel()
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
        public void Aanpassen()
        {
            if (SelectedPlace != null)
            {
                unitOfWork.PlaceRepo.ToevoegenOfAanpassen(PlaceRecord);

                int ok = unitOfWork.Save();
                RefreshPlaces();

                FoutmeldingInstellenNaSave(ok, "Orderlijn is niet aangepast");
            }
            else
            {
                Foutmelding = "Selecteer een orderlijn!";
                NotifyPropertyChanged("Foutmelding");
            }
        }
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
                SelectedPlace = null;
                PlaceRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }
        public void Verwijderen()
        {
            if (SelectedPlace != null)
            {
                Foutmelding = "We zitten al iere";
                unitOfWork.PlaceRepo.Verwijderen(SelectedPlace.PlaceID);
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
        private void PlaceRecordInstellen()
        {
            if (SelectedPlace != null)
            {
                PlaceRecord = SelectedPlace;
            }
            else
            {
                PlaceRecord = new Place();
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
        #endregion
        #region WindowCommands
        public RelayCommand<Window> CloseWindowCommandChar { get; private set; }
        public RelayCommand<Window> CloseWindowCommandAff { get; private set; }
        public RelayCommand<Window> CloseWindowCommandArc { get; private set; }
        public RelayCommand<Window> CloseWindowCommandPlace { get; private set; }
        public RelayCommand<Window> CloseWindowCommandPlaceEdit { get; private set; }
        public RelayCommand<Window> CloseWindowCommandPlaceAdd { get; private set; }
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

        public void CloseWindowPlaceEdit(Window window)
        {
            if (SelectedPlace != null)
            {
                PlaceEditView placeEditView = new PlaceEditView();
                PlaceEditViewModel placeEditViewModel = new PlaceEditViewModel();
                placeEditViewModel.SelectedPlace = SelectedPlace;
                placeEditView.DataContext = placeEditViewModel;
                placeEditViewModel.Admincheck = Admincheck;
                placeEditView.Show();

                if (window != null)
                {
                    window.Close();
                }
            }
            else
            {
                Foutmelding = "Eerst Place selecteren";
            }

        }
        public void CloseWindowPlaceAdd(Window window)
        {
            PlaceAddView placeAddView = new PlaceAddView();
            PlaceAddViewModel placeAddViewModel = new PlaceAddViewModel();
            placeAddView.DataContext = placeAddViewModel;
            placeAddViewModel.Admincheck = Admincheck;
            placeAddView.Show();

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
            this.CloseWindowCommandArc = new RelayCommand<Window>(this.CloseWindowArc);
            this.CloseWindowCommandPlace = new RelayCommand<Window>(this.CloseWindowPlace);
            this.CloseWindowCommandPlaceEdit = new RelayCommand<Window>(this.CloseWindowPlaceEdit);
            this.CloseWindowCommandPlaceAdd = new RelayCommand<Window>(this.CloseWindowPlaceAdd);
            this.CloseWindowCommandWT = new RelayCommand<Window>(this.CloseWindowWT);
        }
        #endregion

    }
}