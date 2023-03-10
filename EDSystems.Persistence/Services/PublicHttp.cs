using System.Net.Http;

namespace EDSystems.Persistence.Services;

public class PublicHttp
{
    public HttpClient Client { get; private set; }

    public PublicHttp(HttpClient httpClient)
    {
        Client = httpClient;
    }
}