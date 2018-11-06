using System;
using System.Collections.Generic;
using System.ComponentModel;
using AppXamarin.ViewModel;
using Xamarin.Forms;

namespace AppXamarin
   
{
    public partial class DetalhesPage : ContentPage
    {
        private DetalhesViewModel ViewModel => BindingContext as DetalhesViewModel;

        public DetalhesPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null) return;
            Title = ViewModel.Title;
            ViewModel.PropertyChanged += TitlePropertyChanged;
         //   await ViewModel.LoadAsync();
        }

        private void TitlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ViewModel.Title)) return;

            Title = ViewModel.Title;
        }

    }
}
