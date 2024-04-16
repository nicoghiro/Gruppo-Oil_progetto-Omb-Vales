using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;

namespace GruppoOilPrototipo.view
{
    public class WebMenager
    {
       public WebMenager()
        {
         
            Codice_seriale = null;
            inf_misurazioni = null;
            mis=null;
        }
         public Serial_valv Codice_seriale { get; set; }
         public Inf_misurazioni inf_misurazioni { get;  set; }
        public Misurazioni mis {get;  set; }
        [JsonIgnore]
        static HttpClient client = new HttpClient();

        public async Task<Uri> Invio_Dati(WebMenager web) {
            client.BaseAddress = new Uri("http://localhost/web_valves/index.php");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string json = JsonSerializer.Serialize(web, new JsonSerializerOptions { WriteIndented = true });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost/web_valves/index.php", content);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        
        
    }
}
