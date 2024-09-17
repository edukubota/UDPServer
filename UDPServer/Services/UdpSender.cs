using System.Net.Sockets;
using System.Text;

namespace UDPServer.Services
{
    public class UdpSender
    {
        public UdpSender()
        {
        }

        public void Send(string remoteIp, int remotePort, string message)
        {
            // Mensagem a ser enviada
            byte[] data = Encoding.ASCII.GetBytes(message);
            // Criando um cliente UDP
            using var client = new UdpClient();
            // Enviando o datagrama
            client.Send(data, data.Length, remoteIp, remotePort);
            Console.WriteLine("Mensagem enviada: " + message);
        }
    }
}