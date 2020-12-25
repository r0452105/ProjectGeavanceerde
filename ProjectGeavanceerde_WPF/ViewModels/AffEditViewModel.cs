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
    public class AffEditViewModel : BasisViewModel, IDisposable
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
            }
        }

        #endregion
        public AffEditViewModel()
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
            Factions = new ObservableCollection<Faction>(listFactions);
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
        public RelayCommand<Window> CloseWindowCommandAffEdit { get; private set; }

        public void CloseWindowAffEdit(Window window)
        {

            if (SelectedAffiliation != null)
            {
                if (AffiliationRecord.IsGeldig())
                    unitOfWork.AffiliationRepo.ToevoegenOfAanpassen(AffiliationRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Character is niet aangepast");
                if (window != null && ok > 0)
                {
                    AffiliationView affiliationView = new AffiliationView();
                    AffiliationViewModel affiliationViewModel = new AffiliationViewModel();
                    affiliationView.DataContext = affiliationViewModel;
                    affiliationView.Show();
                    window.Close();
                }
            }
            else
            {
                Foutmelding = "Selecteer een character!";
            }
        }

        public void WindowCommanding()
        {
            this.CloseWindowCommandAffEdit = new RelayCommand<Window>(this.CloseWindowAffEdit);
        }

        #endregion

    }
}
