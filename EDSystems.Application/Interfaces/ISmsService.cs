using EDSystems.Domain.Entities;

namespace EDSystems.Application.Interfaces
{
    public interface ISmsService
    {
        void SendSmsToRecepient(SmsDetails smsDetails);
    }
}