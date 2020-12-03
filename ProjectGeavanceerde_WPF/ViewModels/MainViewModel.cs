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
                case "Voorbeeld1": return true;
                case "Voorbeeld2": return true;
            }
            return true;
        }
        public void Execute(object parameter)
        {
            //Via parameter kom je te weten op welke knop er gedrukt is,  
            //instelling via CommandParameter in xaml
            switch (parameter.ToString())
            {
                case "Voorbeeld1": OpenVoorbeeld1(); break;
                case "Voorbeeld2": OpenVoorbeeld2(); break;
            }
        }

        public void OpenVoorbeeld1()
        {
            Voorbeeld1View view = new Voorbeeld1View();
            view.Show();
        }
        public void OpenVoorbeeld2()
        {
            Voorbeeld2View view = new Voorbeeld2View();
            view.Show();
        }

    }
}

