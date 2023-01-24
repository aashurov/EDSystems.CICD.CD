namespace EDSystems.Application.Interfaces
{
    public interface ICustomLoggingBehavoir
    {
        void WriteToFileSuccess(string ClassName, object Message);
    }
}