using CalcFreelancer.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalcFreelancer.Repository
{
    public class AzureProjetoRepository
    {
        private IMobileServiceClient Client;
        private IMobileServiceTable<Projeto> Table;

        public AzureProjetoRepository()
        {
            string MyAppServiceURL = "https://calcfreelancer.azurewebsites.net";
            Client = new MobileServiceClient(MyAppServiceURL);
            Table = Client.GetTable<Projeto>();
        }

        public async void Insert(Projeto projeto)
        {
            await Table.InsertAsync(projeto);
        }

        public async Task<IEnumerable<Projeto>> GetAll()
        {
            var empty = new Projeto[0];
            try
            {
                return await Table.ToEnumerableAsync();
            }
            catch (Exception)
            {
                return empty;
            }
        }
    }
}
