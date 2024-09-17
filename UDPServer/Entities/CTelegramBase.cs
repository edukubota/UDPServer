namespace UDPServer.Entities
{
    public class CTelegramBase
    {
        public const int TelegramLength_OFFSET = 0; public const int TelegramLength_SIZE = 4;
        public const int TelegramType_OFFSET = 4; public const int TelegramType_SIZE = 1;
        public const int OriginatingSourceIdentification_OFFSET = 5; public const int OriginatingSourceIdentification_SIZE = 4;
        public const int TelegramIdentificationCode_OFFSET = 9; public const int TelegramIdentificationCode_SIZE = 4;
    }
}