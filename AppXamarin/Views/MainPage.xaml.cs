using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppXamarin.ViewModel;
using System.ComponentModel;

namespace AppXamarin
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();

         //   NavigationPage.SetBackButtonTitle(this, "De volta!");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null) return;
            Title = ViewModel.Title;
            ViewModel.PropertyChanged += TitlePropertyChanged;
            await ViewModel.LoadAsync();
        }

        private void TitlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ViewModel.Title)) return;

            Title = ViewModel.Title;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.ExibirPersonagemCommand.Execute(e.SelectedItem);
            }
        }
    }
}
