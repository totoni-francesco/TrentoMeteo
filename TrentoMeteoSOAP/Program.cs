using SoapCore;
using static TrentoMeteoSOAP.Logic.ServiceLogic;

namespace TrentoMeteoSOAP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSoapCore();
            builder.Services.AddScoped<ISoapService, SoapService>();

            var app = builder.Build();  

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<ISoapService>("/Service.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });

            app.Run();
        }
    }
}