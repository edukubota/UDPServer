using System.Text;

namespace UDPServer.Entities
{
    public class TelegramBase
    {
        public static string GetStringFromBytes(byte[] requestMessage, int offset, int size)
        {
            byte[] infoBytes = new byte[size];
            for (int i = 0; i < infoBytes.Length; i++)
            {
                infoBytes[i] = requestMessage[offset + i];
            }

            return Encoding.Default.GetString(infoBytes);
        }
    }
}