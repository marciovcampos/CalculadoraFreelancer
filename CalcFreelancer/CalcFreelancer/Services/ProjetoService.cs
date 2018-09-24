using CalcFreelancer.Models;
using CalcFreelancer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalcFreelancer.Services
{
    public class ProjetoService
    {
        private readonly AzureProjetoRepository ProjetoRepository;

        public ProjetoService()
        {
            ProjetoRepository = new AzureProjetoRepository();
        }
        public void Inserir(Projeto projeto)
        {
            ProjetoRepository.Insert(projeto);
        }


        public Task<IEnumerable<Projeto>> ObterTodos()
        {
            return ProjetoRepository.GetAll();
        }
    }
}
