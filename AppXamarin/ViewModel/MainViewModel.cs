using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AppXamarin.Views;

namespace AppXamarin.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                SetProperty(ref _login, value);
            }
        }

        private string _senha;
        public string Senha
        {
            get
            {
                return _senha;
            }
            set
            {
                SetProperty(ref _senha, value);
            }
        }


        public Command Logar { get; set; }
        public MainViewModel()
        {
             Logar = new Command(HandleAction);
        }



        void HandleAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new DetalhesPage());
        }

    }
}
