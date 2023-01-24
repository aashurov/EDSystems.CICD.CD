using EDSystems.Application.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EDSystems.Persistence.Services
{
    public class GetExchangeRateService : IGetExchangeRateService
    {
        private string responseBody = null;
        private readonly IDateTimeService _dateTimeService;
        public HttpClient httpClient = GetHttpClientMtl();

        public GetExchangeRateService(IDateTimeService dateTimeService) => _dateTimeService = dateTimeService;

        public async Task<string> Handle(string currency)
        {
            string requestURL = string.Format("https://cbu.uz/ru/arkhiv-kursov-valyut/json/{0}/{1}/", currency, _dateTimeService.Now.ToString("yyyy-MM-dd"));

            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(requestURL))
                {
                    if ((int)response.StatusCode == 200)
                    {
                        responseBody = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()).ToString();
                        //_loggingBehavior.WriteToFile(((int)response.StatusCode).ToString());
                    }
                    else if ((int)response.StatusCode == 400 ||
                            (int)response.StatusCode == 404 ||
                            (int)response.StatusCode == 500 ||
                            (int)response.StatusCode == 503)
                    {
                        responseBody = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()).ToString();
                        //_loggingBehavior.WriteToFile(((int)response.StatusCode).ToString());
                    }
                }
            }
            catch (WebException e)
            {
                responseBody = e.Response.ToString();
                //_loggingBehavior.WriteToFile(e.Message.ToString());
            }

            return responseBody;
        }

        public static HttpClient GetHttpClientMtl()
        {
            WebProxy proxy = new WebProxy("in-009.uzkdb.local", 3128);
            var handler = new HttpClientHandler
            {
                //Proxy = proxy,
                //UseProxy = true,
                ClientCertificateOptions = ClientCertificateOption.Manual
            };
            HttpClient httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}