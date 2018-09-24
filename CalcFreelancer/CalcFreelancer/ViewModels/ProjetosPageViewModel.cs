using CalcFreelancer.Models;
using CalcFreelancer.Services;
using CalcFreelancer.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalcFreelancer.ViewModels
{
    class ProjetosPageViewModel : ViewModelBase
    {
        private readonly ProjetoService ProjetoService;

        public ObservableCollection<Projeto> Projetos { get; set; }

        private bool atualizando;
        public bool Atualizando
        {
            get { return atualizando; }
            set { SetProperty(ref atualizando, value); }
        }

        public Command AtualizarDados { get; }

        public ProjetosPageViewModel(ProjetoService projetoService)
        {
            ProjetoService = projetoService;
            Projetos = new ObservableCollection<Projeto>();
            ObterProjetos();
            AtualizarDados = new Command(ExecuteAtualizarDados);
        }

        public ProjetosPageViewModel()
        {
        }

        private async void ExecuteAtualizarDados()
        {
            Atualizando = true;
            await ObterProjetos();
            Atualizando = false;
        }

        private async Task ObterProjetos()
        {
            var projetos = await ProjetoService.ObterTodos();

            if (Projetos.Count > 0)
            {
                Projetos.Clear();
            }

            foreach (var projeto in projetos)
            {
                Projetos.Add(projeto);
            }
        }

        private Projeto projeto;
        public Projeto Projeto
        {
            get { return projeto; }
            set {
                SetProperty(ref projeto, value);
                if (projeto != null)
                    App.Current.MainPage.DisplayAlert("Projeto", projeto.Nome, "ok");
            }
        }
    }
}
