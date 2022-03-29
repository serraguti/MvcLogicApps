using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using MvcLogicApps.Models;
using Newtonsoft.Json;
using System.Text;

namespace MvcLogicApps.Services
{
    public class ServiceLogicApps
    {
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceLogicApps()
        {
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task SendMailAsync
            (string email, string subject, string body)
        {
            string urlMail =
                "https://prod-166.westeurope.logic.azure.com:443/workflows/7ca93169c9784542b0c757c8c3c6e898/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=vKHU8c_2C9Npn4bWFDhi717SPnRFuSZV1G4l4kZRp8s";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                EmailModel emailModel = new EmailModel
                {
                     Email = email, Subject = subject, Body = body
                };
                //CONVERTIMOS EL MODEL A JSON
                string json = JsonConvert.SerializeObject(emailModel);
                //LA PETICIONES POST Y RECIBE LA INFORMACION EN JSON
                //MEDIANTE STRINGCONTENT
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(urlMail, content);
            }
        }

        public async Task<string> SumarNumerosAsync(int numero1, int numero2)
        {
            string urlFlowSuma =
                "https://prod-69.westeurope.logic.azure.com:443/workflows/eee588f078d249c793d2ad51c3a1d9ee/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=3goBe3PPMpPbRuTw1P6-cRbE_oZNs2-TyEmywLU2Sts";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                var sumaModel = new
                {
                    Numero1 = numero1, Numero2 = numero2
                };
                var json = JsonConvert.SerializeObject(sumaModel);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(urlFlowSuma, content);
                if (response.IsSuccessStatusCode)
                {
                    string data =
                        await response.Content.ReadAsStringAsync();
                    return "La suma es " + data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Tabla>> TablaMultiplicarAsync(int numero)
        {
            string urlTabla =
                "https://prod-109.westeurope.logic.azure.com:443/workflows/040233c6dd1b4bceb1fdbf64027c5e57/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=ROzEZIbPoZM4V2GPP9qVnHgpnx_BjqdH3RbB7CLZiuU";
            using (HttpClient client = new HttpClient())
            {
                var modelNumero = new
                {
                    Numero = numero
                };
                var json = JsonConvert.SerializeObject(modelNumero);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(urlTabla, content);
                if (response.IsSuccessStatusCode)
                {
                    List<Tabla> tabla =
                        await response.Content.ReadAsAsync<List<Tabla>>();
                    return tabla;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
