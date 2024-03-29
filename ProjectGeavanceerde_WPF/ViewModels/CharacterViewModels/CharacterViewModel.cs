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
    public class CharacterViewModel : BasisViewModel, IDisposable
    {
        #region getters and setters
        public bool Admincheck { get; set; }
        public bool CharacterIDcheck { get; set; }
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Species> Soorten { get; set; }
        public ObservableCollection<Bloodtype> Bloodtypes { get; set; }
        public ObservableCollection<Gender> Genders { get; set; }
        public ObservableCollection<Haki> Hakis { get; set; }
        public Character CharacterRecord { get; set; }
        public string Foutmelding { get; set; }
        private Character _selectedCharacter;
        public Character SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                CharacterRecordInstellen();
            }
        }

        #endregion
        #region Controle en Functies
        public CharacterViewModel()
        {
            RefreshCharacters();
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
            if (SelectedCharacter != null)
            {
                unitOfWork.CharacterRepo.ToevoegenOfAanpassen(CharacterRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Character is niet aangepast");
            }
            else
            {
                Foutmelding = "Selecteer een character!";
            }
        }
        private void RefreshCharacters()
        {
            List<Character> listCharacters = unitOfWork.CharacterRepo.Ophalen().ToList();
            Characters = new ObservableCollection<Character>(listCharacters);
            List<Bloodtype> listBloodtypes = unitOfWork.BloodtypeRepo.Ophalen().ToList();
            Bloodtypes = new ObservableCollection<Bloodtype>(listBloodtypes);
            List<Species> listSoorten = unitOfWork.SpeciesRepo.Ophalen().ToList();
            Soorten = new ObservableCollection<Species>(listSoorten);
            List<Gender> listGenders = unitOfWork.GenderRepo.Ophalen().ToList();
            Genders = new ObservableCollection<Gender>(listGenders);
            List<Haki> listHakis = unitOfWork.HakiRepo.Ophalen().ToList();
            Hakis = new ObservableCollection<Haki>(listHakis);

        }
        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshCharacters();
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
                SelectedCharacter = null;
                CharacterRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }
        public void Verwijderen()
        {
            if (SelectedCharacter != null)
            {
                unitOfWork.CharacterRepo.Verwijderen(SelectedCharacter.CharacterID);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Orderlijn is niet verwijderd");
            }
            else
            {
                Foutmelding = "Eerst Character selecteren";
            }
        }
        private void CharacterRecordInstellen()
        {
            if (SelectedCharacter != null)
            {
                CharacterRecord = SelectedCharacter;
            }
            else
            {
                CharacterRecord = new Character();
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
        public RelayCommand<Window> CloseWindowCommandCharEdit { get; private set; }
        public RelayCommand<Window> CloseWindowCommandCharAdd { get; private set; }
        public RelayCommand<Window> CloseWindowCommandAff { get; private set; }
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
        public void CloseWindowCharEdit(Window window)
        {
            if(SelectedCharacter!= null)
            {
                CharEditView charEditView = new CharEditView();
                CharEditViewModel charEditViewModel = new CharEditViewModel();
                charEditViewModel.SelectedCharacter = SelectedCharacter;
                charEditViewModel.Admincheck = Admincheck;
                charEditView.DataContext = charEditViewModel;
                charEditView.Show();

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
        public void CloseWindowCharAdd(Window window)
        {
                CharAddView charAddView = new CharAddView();
                CharAddViewModel charAddViewModel = new CharAddViewModel();
                charAddView.DataContext = charAddViewModel;
                charAddViewModel.Admincheck = Admincheck;
                charAddView.Show();

                if (window != null)
                {
                    window.Close();
                }
        }
        public void WindowCommanding()
        {
            this.CloseWindowCommandChar = new RelayCommand<Window>(this.CloseWindowChar);
            this.CloseWindowCommandCharEdit = new RelayCommand<Window>(this.CloseWindowCharEdit);
            this.CloseWindowCommandCharAdd = new RelayCommand<Window>(this.CloseWindowCharAdd);
            this.CloseWindowCommandAff = new RelayCommand<Window>(this.CloseWindowAff);
            this.CloseWindowCommandArc = new RelayCommand<Window>(this.CloseWindowArc);
            this.CloseWindowCommandPlace = new RelayCommand<Window>(this.CloseWindowPlace);
            this.CloseWindowCommandWT = new RelayCommand<Window>(this.CloseWindowWT);
        }

        #endregion
    }
}
