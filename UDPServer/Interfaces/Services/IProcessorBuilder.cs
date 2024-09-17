namespace UDPServer.Interfaces.Services
{
    public interface IProcessorBuilder
    {
        void Run(byte[] messageData);
    }
}