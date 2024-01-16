using Newtonsoft.Json;
using System.ServiceModel;
using static JSON.Class;

namespace TrentoMeteoSOAP.Logic
{
    public class ServiceLogic
    {
        [ServiceContract]
        public interface ISoapService
        {
            [OperationContract]
            Giorni[] GetWeather(string? day = null);
        }

        public class SoapService : ISoapService
        {
            public Giorni[] GetWeather(string? day = null)
            {
                string Uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(Uri).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            String result = content.ReadAsStringAsync().Result;
                            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(result);
                            Giorni[] dayData = data.previsione[0].giorni;
                            return day != null ? dayData.Where(d => d.giorno == day).ToArray() : dayData;
                        }
                    }
                }
            }
        }
    }
}
