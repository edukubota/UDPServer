using System.Diagnostics;
using System.Text;
using UDPServer.Entities;
using UDPServer.Interfaces.Services;

namespace UDPServer.Services
{
    public class ProcessorBuilder : IProcessorBuilder
    {
        private readonly ILogger<ProcessorBuilder> _logger;
        private readonly UdpSender _sender;

        public ProcessorBuilder(UdpSender sender, ILogger<ProcessorBuilder> logger)
        {
            _logger = logger;
            _sender = sender;
        }

        public void Run(byte[] messageData)
        {
            var stMessageData = Encoding.Default.GetString(messageData);

            Debug.WriteLine($"MessageData {stMessageData}");
            _logger.LogDebug("MessageData  {Data}", stMessageData);

            var telegramType = GetTelegramType(messageData);

            Debug.WriteLine($"Telegrama {telegramType}");
            _logger.LogDebug("Telegrama {Telegrama}", telegramType);
            //Fatory
            switch (telegramType)
            {
                //...
            }
            //...
            _sender.Send("localhost", 50515, "OK");
        }

        private string GetTelegramType(byte[] messageData)
        {
            return TelegramBase.GetStringFromBytes(messageData, CTelegramBase.TelegramIdentificationCode_OFFSET, CTelegramBase.TelegramIdentificationCode_SIZE);
        }
    }
}