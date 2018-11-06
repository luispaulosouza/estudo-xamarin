using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using AppXamarin.Models;
using AppXamarin.Services;
using System.Threading.Tasks;

namespace AppXamarin.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Personagem> Personagens { get; }
        private MarvelApiService _marvelApiService;
        public Command<Personagem> ExibirPersonagemCommand { get; }

        public MainViewModel()
        {
            Personagens = new ObservableCollection<Personagem>();

            _marvelApiService = new MarvelApiService();

            Title = "Herois Marvel";

            ExibirPersonagemCommand = new Command<Personagem>(ExecuteExibirPersonagemCommand);

        }

        private async void ExecuteExibirPersonagemCommand(Personagem personagem)
        {
            if (personagem.Descricao.Length > 0)
                await Navigation.PushAsync<DetalhesViewModel>(false, personagem);
            else
                await Application.Current.MainPage.DisplayAlert("Atenção", "Este heroi não possui dados", "OK");
        }

        public override async Task LoadAsync()
        {
            IsBusy = true;
            try
            {
                var personagens = await _marvelApiService.GetPersonagensAsync();

                System.Diagnostics.Debug.WriteLine("FOUND {0} PERSONAGENS", personagens.Count);
                Personagens.Clear();
                foreach (var personagem in personagens)
                {
                    Personagens.Add(personagem);
                }

                OnPropertyChanged(nameof(Personagens));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERRO", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
