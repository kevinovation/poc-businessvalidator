using Kevinovation.PoC.BusinessValidator.Library;

namespace Kevinovation.PoC.BusinessValidator.Factory
{
    internal static class MessageFactory
    {
        public static Message GetNewErrorMessage(string message)
        {
            return new Message(message, ENUMMessageType.Error);
        }

        public static Message GetNewInformationMessage(string message)
        {
            return new Message(message, ENUMMessageType.Information);
        }

        public static Message GetNewWarningMessage(string message)
        {
            return new Message(message, ENUMMessageType.Warning);
        }
    }
}