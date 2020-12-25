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
    class PlaceEditViewModel : BasisViewModel, IDisposable
    {
        public ObservableCollection<Place> Places{ get; set; }
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
    public PlaceEditViewModel()
    {
        RefreshPlaces();
        this.CloseWindowCommandPlaceEdit = new RelayCommand<Window>(this.CloseWindowPlaceEdit);
    }
    public override string this[string columnName]
    {
        get
        {
            return "";
        }
    }
    private void RefreshPlaces()
    {
        List<Place> listPlace = unitOfWork.PlaceRepo.Ophalen().ToList();
        Places = new ObservableCollection<Place>(listPlace);
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

    public RelayCommand<Window> CloseWindowCommandPlaceEdit { get; private set; }

    public void CloseWindowPlaceEdit(Window window)
    {
        if (SelectedPlace != null)
        {
            if (PlaceRecord.IsGeldig())
                unitOfWork.PlaceRepo.ToevoegenOfAanpassen(PlaceRecord);
            int ok = unitOfWork.Save();
            FoutmeldingInstellenNaSave(ok, "Arc is niet aangepast");
            if (window != null && ok > 0)
            {
                PlaceView placeView = new PlaceView();
                PlaceViewModel placeViewModel = new PlaceViewModel();
                placeView.DataContext = placeViewModel;
                placeView.Show();
                window.Close();
            }
        }
        else
        {
            Foutmelding = "Selecteer een character!";
        }

    }
    #endregion
}
}