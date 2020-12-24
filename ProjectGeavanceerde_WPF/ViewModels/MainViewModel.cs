using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjectGeavanceerde_WPF.Views;

namespace ProjectGeavanceerde_WPF.ViewModels
{
    public class MainViewModel : ICommand
    {
        public event EventHandler CanExecuteChanged;
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
            CharacterView characterView = new CharacterView();
            CharacterViewModel characterViewModel = new CharacterViewModel();
            characterView.DataContext = characterViewModel;
            characterView.Show();
        }
    }
}

