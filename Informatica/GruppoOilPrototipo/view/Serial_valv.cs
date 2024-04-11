﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO.Packaging;
using System.Text.Json.Serialization;

namespace GruppoOilPrototipo.view
{
     public class Serial_valv
    {
        public string Codice_ser {  get; private set; }
        [JsonIgnore]
        static HttpClient client = new HttpClient();
        public Serial_valv(string codice_ser)
        {
            Codice_ser = codice_ser;
        }

        static public async Task<List<string>> Get_SerNum(string path)
        {
            List<string> product = new List<string>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await JsonSerializer.DeserializeAsync<List<string>>(await response.Content.ReadAsStreamAsync());
            }
            return product;
        }
        static public async Task<List<string>> POP_SER()
        {
            client.BaseAddress = new Uri("http://localhost/web_valves/web_service_valves.php/serial_number");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            List<string> Serials = null;
            try
            {
                Serials = await Get_SerNum("http://localhost/web_valves/web_service_valves.php/serial_number");
            }
            catch
            {
                throw new Exception("nessun codice seriale trovato");
            }
            return Serials;
        }
    }
}

