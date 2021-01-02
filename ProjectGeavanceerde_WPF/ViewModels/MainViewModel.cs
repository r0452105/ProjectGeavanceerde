using System;
using ProjectGeavanceerde_WPF.Views;
using System.Windows.Input;
using System.ComponentModel;

namespace ProjectGeavanceerde_WPF.ViewModels
{
    public class MainViewModel : ICommand, INotifyPropertyChanged
    {
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _admincheck;
        public bool Admincheck
        {
            get { return _admincheck; }
            set
            {
                _admincheck = value;
                _admincheck = _admincheck ? value : false;
                OnPropertyChanged("Admincheck");
            }
        }
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public bool CanExecute(object parameter)
        {
            //returnwaarde true -> methode mag uitgevoerd worden
            //returnwaarde false -> methode mag niet uitgevoerd worden
            switch (parameter.ToString())
            {
                case "Characters": return true;
            }
            return true;
        }
        public void Execute(object parameter)
        {
            //Via parameter kom je te weten op welke knop er gedrukt is,  
            //instelling via CommandParameter in xaml
            switch (parameter.ToString())
            {
                case "Characters": OpenCharacters(); break;
            }
        }
        public void OpenCharacters()
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
                characterView.Show();
            }
        }
    }
}

