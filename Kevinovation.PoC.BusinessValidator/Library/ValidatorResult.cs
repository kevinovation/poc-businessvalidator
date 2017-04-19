using System;
using System.Collections.Generic;
using System.Linq;

namespace Kevinovation.PoC.BusinessValidator.Library
{
    public class ValidatorResult
    {
        public bool IsValid { get; set; }
        public List<Message> Messages { get; set; }

        public ValidatorResult()
        {
            this.IsValid = true;
            this.Messages = new List<Message>();
        }

        public void AddMessage(Message message)
        {
            this.Messages.Add(message);
            this.IsValid = !(message.Type == ENUMMessageType.Error);
        }

        public void AddValidatorResult(ValidatorResult validatorResult)
        {
            this.Messages.AddRange(validatorResult.Messages);
            if (this.Messages.Any(poMessage => poMessage.Type == ENUMMessageType.Error))
            {
                this.IsValid = false;
            }
        }

        public override string ToString()
        {
            var lstrResultat = "";

            foreach (var loMessage in this.Messages)
            {
                lstrResultat = string.Concat(lstrResultat, Environment.NewLine, loMessage.ToString());
            }

            return lstrResultat;
        }
    }
}