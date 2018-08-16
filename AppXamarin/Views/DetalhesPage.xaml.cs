using System;
using System.Collections.Generic;
using AppXamarin.ViewModel;
using Xamarin.Forms;

namespace AppXamarin.Views
{
    public partial class DetalhesPage : ContentPage
    {
        public DetalhesPage()
        {
            InitializeComponent();
            this.BindingContext = new DetalhesViewModel();
        }
    }
}
