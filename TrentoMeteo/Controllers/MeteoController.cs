using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using TrentoMeteo.ViewModel;


namespace TrentoMeteo.Controllers
{
    public class MeteoController : Controller
    { 
        //Azione Index che restituisce una vista con i dati meteorologici in base al giorno specificato
        public ActionResult Index(string day)
        {
            //controllo per il caso in cui il day è null
            if(day == null) 
            {
                return View("null");
            }
            else 
            {
                //canale di comunicazione con servizio Soap
                ISoapService service = new SoapServiceClient(SoapServiceClient.EndpointConfiguration.BasicHttpBinding_ISoapService_soap);
                //usa il servizio Soap per ottenere i dati meteorologici
                var variabile = service.GetWeatherAsync(new GetWeatherRequest()
                {
                    Body = new GetWeatherRequestBody()
                    {
                        day = day
                    }

                }).Result;

                //Inserisce i dati ottenuti dal servizio
                MeteoViewModel ViewModel = new MeteoViewModel()
                {
                    giorni = variabile.Body.GetWeatherResult.ToArray()
                };
                //restituisce la vista con il modello di vista con i dati inseriti
                return View(ViewModel);

            }

            


        }
        

        
    }
}
