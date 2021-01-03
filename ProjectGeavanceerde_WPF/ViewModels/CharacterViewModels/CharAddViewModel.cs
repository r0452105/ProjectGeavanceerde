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
    public class CharAddViewModel : BasisViewModel, IDisposable
    {
        #region getters and setters
    public bool Admincheck { get; set; }
    public ObservableCollection<Character> Characters { get; set; }
    public ObservableCollection<Species> Soorten { get; set; }
    public ObservableCollection<Bloodtype> Bloodtypes { get; set; }
    public ObservableCollection<Gender> Genders { get; set; }
    public ObservableCollection<Haki> Hakis { get; set; }
    public Character CharacterRecord = new Character();
    public string Foutmelding { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public int BloodtypeID { get; set; }
    public decimal? Bounty { get; set; }
    public string DevilFruit { get; set; }
    public int GenderID { get; set; }
    public int HakiID { get; set; }
    public int SpeciesID { get; set; }

        #endregion
        #region Controle en Functies
        public CharAddViewModel()
    {
            Birthday = new DateTime(2020, 1, 1);
            RefreshCharacters();
    }

    public override string this[string columnName]
    {
        get
        {
            return "";
        }
    }

    private void RefreshCharacters()
    {
        this.CloseWindowCommandCharBack = new RelayCommand<Window>(this.CloseWindowCharBack);
        this.CloseWindowCommandCharAdd = new RelayCommand<Window>(this.CloseWindowCharAdd);
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
            CharacterRecordInstellen();
            Foutmelding = "";
        }
        else
        {
            Foutmelding = this.Error;
        }
    }
    private void CharacterRecordInstellen()
    {
        CharacterRecord = new Character();
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
        public RelayCommand<Window> CloseWindowCommandCharAdd { get; private set; }
    public RelayCommand<Window> CloseWindowCommandCharBack { get; private set; }

        public void CloseWindowCharAdd(Window window)
        {
            CharacterRecord.Name = Name;
            CharacterRecord.Birthday = Birthday;
            CharacterRecord.BloodtypeID = BloodtypeID;
            CharacterRecord.Bounty = Bounty;
            CharacterRecord.DevilFruit = DevilFruit;
            CharacterRecord.GenderID = GenderID;
            CharacterRecord.HakiID = HakiID;
            CharacterRecord.SpeciesID = SpeciesID;

            if (CharacterRecord.IsGeldig()) //problem needs to be solved
            {

                unitOfWork.CharacterRepo.Toevoegen(CharacterRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Character is niet toegevoegd");
            
                    if (window != null)
                    {
                        CharacterView characterView = new CharacterView();
                        CharacterViewModel characterViewModel = new CharacterViewModel();
                        characterView.DataContext = characterViewModel;
                        characterViewModel.Admincheck = Admincheck;
                        characterView.Show();
                        window.Close();
                    }
            }
            else
            {
                Foutmelding = "Record is niet geldig, vul alle gegevens in.";
            }
        }
        public void CloseWindowCharBack(Window window)
        {
                if (window != null)
                {
                    CharacterView characterView = new CharacterView();
                    CharacterViewModel characterViewModel = new CharacterViewModel();
                    characterView.DataContext = characterViewModel;
                    characterViewModel.Admincheck = Admincheck;
                    characterView.Show();
                    window.Close();
                }
        }
        #endregion
    }
}