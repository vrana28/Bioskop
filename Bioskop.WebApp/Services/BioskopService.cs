using Bioskop.Domen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Text.Json;

namespace Bioskop.WebApp.Services
{
    public class BioskopService
    { // za pozivanje kontrolera iz Web.Api-ja
        public HttpClient Client  { get; set; }

        public BioskopService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44300/api/projekcija");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client = client;
        }

        public async Task<List<Film>> GetStudents() {
            var response = await Client.GetAsync("");
            //GetAsync - BITNO - nacin za asinhrono programiranje !!! mora Task
            response.EnsureSuccessStatusCode(); // provera da li je sve uspesno proslo
            using var responseStream = await response.Content.ReadAsStreamAsync(); // uzimanje streama iz body-a
            return await System.Text.Json.JsonSerializer.DeserializeAsync<List<Film>>(responseStream);

        }

    }
}
