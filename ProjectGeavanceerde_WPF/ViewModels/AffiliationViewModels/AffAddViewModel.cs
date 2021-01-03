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
    public class AffAddViewModel : BasisViewModel, IDisposable
    {
        #region getters and setters
        public bool Admincheck { get; set; }
        public ObservableCollection<Faction> Factions { get; set; }
        public ObservableCollection<Affiliation> Affiliations { get; set; }
        public Affiliation AffiliationRecord = new Affiliation();
        public string Foutmelding { get; set; }
        public string Name { get; set; }
        public int FactionID { get; set; }


        #endregion
        public AffAddViewModel()
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
           AffiliationRecord = new Affiliation();
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

        public RelayCommand<Window> CloseWindowCommandAffAdd { get; private set; }
        public RelayCommand<Window> CloseWindowCommandAffAddBack { get; private set; }

        public void CloseWindowAffAdd(Window window)
        {
            AffiliationRecord.Name = Name;
            AffiliationRecord.FactionID = FactionID;

            if (!AffiliationRecord.IsGeldig()) //problem needs to be solved
            {
                unitOfWork.AffiliationRepo.Toevoegen(AffiliationRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Affiliation is niet toegevoegd");

                AffiliationView affiliationView = new AffiliationView();
                AffiliationViewModel affiliationViewModel = new AffiliationViewModel();
                affiliationView.DataContext = affiliationViewModel;
                affiliationViewModel.Admincheck = Admincheck;
                affiliationView.Show();

                if (window != null)
                {

                    window.Close();
                }
            }
            else
            {
                Foutmelding = "Record is niet geldig";
            }
        }

        public void CloseWindowAffAddBack(Window window)
        {
                AffiliationView affiliationView = new AffiliationView();
                AffiliationViewModel affiliationViewModel = new AffiliationViewModel();
                affiliationView.DataContext = affiliationViewModel;
                affiliationViewModel.Admincheck = Admincheck;
                affiliationView.Show();

                if (window != null)
                {
                    window.Close();
                }
        }


        public void WindowCommanding()
        {
            this.CloseWindowCommandAffAdd = new RelayCommand<Window>(this.CloseWindowAffAdd);
            this.CloseWindowCommandAffAddBack = new RelayCommand<Window>(this.CloseWindowAffAddBack);
        }
    }
}