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
    class ArcEditViewModel : BasisViewModel, IDisposable
    {
        #region getters en setters
        public bool Admincheck { get; set; }
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

        #endregion
        public ArcEditViewModel()
        {
            RefreshArcs();
            this.CloseWindowCommandArcEdit = new RelayCommand<Window>(this.CloseWindowArcEdit);
            this.CloseWindowCommandArcEditBack = new RelayCommand<Window>(this.CloseWindowArcEditBack);

        }
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }
        private void RefreshArcs()
        {
            List<Arc> listArc = unitOfWork.ArcRepo.Ophalen().ToList();
            Arcs = new ObservableCollection<Arc>(listArc);
        }
        #region Controle
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
        #region WindowCommands

        public RelayCommand<Window> CloseWindowCommandArcEdit { get; private set; }
        public RelayCommand<Window> CloseWindowCommandArcEditBack { get; private set; }

        public void CloseWindowArcEdit(Window window)
        {
            if (SelectedArc != null)
            {
                if (ArcRecord.IsGeldig())
                    unitOfWork.ArcRepo.ToevoegenOfAanpassen(ArcRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Arc is niet aangepast");
                if (window != null && ok > 0)
                {
                    ArcView arcView = new ArcView();
                    ArcViewModel arcViewModel = new ArcViewModel();
                    arcView.DataContext = arcViewModel;
                    arcViewModel.Admincheck = Admincheck;
                    arcView.Show();
                    window.Close();
                }
            }
            else
            {
                Foutmelding = "Vul alle gegevens in!";
            }

        }
        public void CloseWindowArcEditBack(Window window)
        {
                if (window != null)
                {
                    ArcView arcView = new ArcView();
                    ArcViewModel arcViewModel = new ArcViewModel();
                    arcView.DataContext = arcViewModel;
                    arcViewModel.Admincheck = Admincheck;
                    arcView.Show();
                    window.Close();
                }
        }
        #endregion
    }
}