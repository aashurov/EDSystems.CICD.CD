using System.Threading.Tasks;

namespace EDSystems.Application.Interfaces
{
    public interface IGetExchangeRateService
    {
        Task<string> Handle(string currency);
    }
}