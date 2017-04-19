using System;

namespace Kevinovation.PoC.BusinessValidator.Library
{
    public class Message
    {
        public string Value { get; set; }
        public ENUMMessageType Type { get; set; }

        public Message()
        {
        }

        public Message(string message, ENUMMessageType type)
        {
            this.Value = message;
            this.Type = type;
        }

        public override string ToString()
        {
            return String.Format("{0} : {1}", this.Type, this.Value);
        }
    }
}