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
            client.BaseAddress = new Uri("http://localhost/web_valves/web_service_valves.php");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Codice_seriale = null;
            inf_misurazioni = null;
            mis=null;
        }
        static public Serial_valv Codice_seriale { get; set; }
        static public Inf_misurazioni inf_misurazioni { get; set; }
        static public Misurazioni mis {get; set; }
        [JsonIgnore]
        static HttpClient client = new HttpClient();
        public async Task<Uri> Invio_Dati(WebMenager web) {

            string json = JsonSerializer.Serialize(web);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("new_value", content);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        
    }
}
