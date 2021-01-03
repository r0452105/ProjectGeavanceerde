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
    public class ArcAddViewModel : BasisViewModel, IDisposable
    {
        #region getters and setters
        public bool Admincheck { get; set; }
        public ObservableCollection<Arc> Arcs { get; set; }
        public Arc ArcRecord = new Arc();
        public string Foutmelding { get; set; }
        public string Name { get; set; }
        public int Startingchapter { get; set; }
        public int Endingchapter { get; set; }

        #endregion
        public ArcAddViewModel()
        {
            RefreshArcs();
            WindowCommanding();
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
            List<Arc> listArcs = unitOfWork.ArcRepo.Ophalen().ToList();
            Arcs = new ObservableCollection<Arc>(listArcs);
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
            ArcRecord = new Arc();
        }

        public override bool CanExecute(object parameter)
        {
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

        public RelayCommand<Window> CloseWindowCommandArcAdd { get; private set; }
        public RelayCommand<Window> CloseWindowCommandArcAddBack { get; private set; }

        public void CloseWindowArcAdd(Window window)
        {
            ArcRecord.Name = Name;
            ArcRecord.Startingchapter = Startingchapter;
            ArcRecord.Endingchapter = Endingchapter;

            if (ArcRecord.IsGeldig()) //problem needs to be solved
            {
                unitOfWork.ArcRepo.Toevoegen(ArcRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Arc is niet toegevoegd");

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
            else
            {
                Foutmelding = "Vul alle gegevens in.";
            }
        }
        public void CloseWindowArcAddBack(Window window)
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
        public void WindowCommanding()
        {
            this.CloseWindowCommandArcAdd = new RelayCommand<Window>(this.CloseWindowArcAdd);
            this.CloseWindowCommandArcAddBack = new RelayCommand<Window>(this.CloseWindowArcAddBack);
        }
        #endregion
    }
}