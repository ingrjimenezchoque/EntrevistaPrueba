
#region Imports
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
#endregion

namespace ConsummerAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prm = new Program();
            prm.Get();
            Console.ReadKey();
        }

        public void Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/");
                var request = client.GetAsync("api/Employees").Result;
                if (request.IsSuccessStatusCode)
                {
                    var result = request.Content.ReadAsStringAsync().Result;
                    var list = JsonConvert.DeserializeObject<List<Employe>>(result);
                    foreach (var item in list)
                        Console.WriteLine(item.Name);
                }
            }
        }

        private void Post() {
            using (var client = new HttpClient())
            {
                Employe employe = new Employe();
                employe.Id = 100;
                employe.Name = "Prueba";
                employe.Profile = "ADMIN";
                employe.Age = 18;
                employe.DocumentNumber = "8888888";
                employe.Salary = 1400;
                employe.Adicional1 = "";
                employe.Adicional2 = "";

                var bodyJson = JsonConvert.SerializeObject(employe);
                var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
                client.PostAsync(new Uri("https://localhost:44398/api/Employees"), stringContent);
            }
        }
    }
}