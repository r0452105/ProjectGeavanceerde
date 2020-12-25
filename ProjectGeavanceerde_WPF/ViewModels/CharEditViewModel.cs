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
    public class CharEditViewModel : BasisViewModel, IDisposable
    {
        #region getters and setters
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
        public CharEditViewModel()
        {
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
            this.CloseWindowCommandCharEdit = new RelayCommand<Window>(this.CloseWindowCharEdit);
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

        public RelayCommand<Window> CloseWindowCommandCharEdit { get; private set; }

        public void CloseWindowCharEdit(Window window)
        {
            if (SelectedCharacter != null)
            {
                if(CharacterRecord.IsGeldig())
                unitOfWork.CharacterRepo.ToevoegenOfAanpassen(CharacterRecord);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Character is niet aangepast");
                if (window != null && ok>0)
                {
                    CharacterView characterView = new CharacterView();
                    CharacterViewModel characterViewModel = new CharacterViewModel();
                    characterView.DataContext = characterViewModel;
                    characterView.Show();
                    window.Close();
                }
            }
            else
            {
                Foutmelding = "Selecteer een character!";
            }
            
        }
    }
}