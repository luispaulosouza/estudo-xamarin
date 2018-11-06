﻿using System;
using System.ComponentModel;
using AppXamarin.Models;

namespace AppXamarin.ViewModel
{
    public class DetalhesViewModel: BaseViewModel
    {
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
        }

        private string _imagem;
        public string Imagem
        {
            get { return _imagem; }
            set { SetProperty(ref _imagem, value); }
        }

        public DetalhesViewModel(Personagem personagem)
        {

            Nome = personagem.Nome;
            Descricao = personagem.Descricao;
            Imagem = personagem.UrlImagem;

            Title = "Detalhes";
        }

    }
}
