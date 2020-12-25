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
    public class ArcViewModel : BasisViewModel
    {
        public ObservableCollection<Arc> Arcs { get; set; }
        public Arc ArcRecord { get; set; }
        public string Foutmelding { get; set; }
        private Arc _selectedArc;
        public Arc SelectedArc
        {
            get { return _selectedArc; }
            set
            {
                _selectedArc = value;
                ArcRecordInstellen();

            }
        }
        public ArcViewModel()
        {
            RefreshArcs();
            this.CloseWindowCommandChar = new RelayCommand<Window>(this.CloseWindowChar);
            this.CloseWindowCommandAff = new RelayCommand<Window>(this.CloseWindowAff);
            this.CloseWindowCommandArc = new RelayCommand<Window>(this.CloseWindowArc);
            this.CloseWindowCommandArcEdit = new RelayCommand<Window>(this.CloseWindowArcEdit);
            this.CloseWindowCommandPlace = new RelayCommand<Window>(this.CloseWindowPlace);
            this.CloseWindowCommandWT = new RelayCommand<Window>(this.CloseWindowWT);
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
            if (SelectedArc != null)
            {
                unitOfWork.ArcRepo.ToevoegenOfAanpassen(ArcRecord);

                int ok = unitOfWork.Save();
                RefreshArcs();

                FoutmeldingInstellenNaSave(ok, "Orderlijn is niet aangepast");
            }
            else
            {
                Foutmelding = "Selecteer een orderlijn!";
                NotifyPropertyChanged("Foutmelding");
            }
        }
        private void RefreshArcs()
        {
            List<Arc> listArc = unitOfWork.ArcRepo.Ophalen().ToList();
            Arcs = new ObservableCollection<Arc>(listArc);
        }
        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshArcs();
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
                SelectedArc = null;
                ArcRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }
        public void Verwijderen()
        {
            if (SelectedArc != null)
            {
                Foutmelding = "We zitten al iere";
                unitOfWork.ArcRepo.Verwijderen(SelectedArc.ArcID);
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
        private void ArcRecordInstellen()
        {
            if (SelectedArc != null)
            {
                ArcRecord = SelectedArc;
            }
            else
            {
                ArcRecord = new Arc();
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
        public RelayCommand<Window> CloseWindowCommandArcEdit { get; private set; }
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
        public void CloseWindowArcEdit(Window window)
        {
            ArcEditView arcEditView = new ArcEditView();
            ArcEditViewModel arcEditViewModel = new ArcEditViewModel();
            arcEditViewModel.SelectedArc = SelectedArc;
            arcEditView.DataContext = arcEditViewModel;
            arcEditView.Show();

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
        #endregion

    }
}