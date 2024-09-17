using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPServer.Interfaces.Services;

namespace UDPServer.BackgroundServices
{
    public class UdpReceiverBackgroundService : BackgroundService
    {
        private readonly IProcessorBuilder _processor;
        private readonly ILogger<UdpReceiverBackgroundService> _logger;
        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _localEndPoint;

        public UdpReceiverBackgroundService(IProcessorBuilder processor, ILogger<UdpReceiverBackgroundService> logger)
        {
            _processor = processor;
            _logger = logger;
            _localEndPoint = new IPEndPoint(IPAddress.Any, 12345); // Porta UDP para escutar
            _udpClient = new UdpClient(_localEndPoint);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("UDP Receiver Service iniciado na porta {Port}.", _localEndPoint.Port);

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    // Recebe dados via UDP
                    var receivedResults = await _udpClient.ReceiveAsync(stoppingToken);
                    string receivedData = Encoding.Default.GetString(receivedResults.Buffer);

                    _processor.Run(receivedResults.Buffer);
                    _logger.LogInformation("Mensagem recebida: {Message}", receivedData);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro no serviço de recepção UDP.");
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Parando o serviço UDP Receiver.");

            _udpClient?.Close();
            await base.StopAsync(cancellationToken);
        }
    }
}