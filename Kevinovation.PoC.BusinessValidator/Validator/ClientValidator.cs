using Kevinovation.PoC.BusinessValidator.Entity;
using Kevinovation.PoC.BusinessValidator.Factory;
using Kevinovation.PoC.BusinessValidator.Library;

namespace Kevinovation.PoC.BusinessValidator.Validator
{
    public class ClientValidator : Validator<Client>
    {
        [ContexteValidation(ENUMContexteValidation.Creation)]
        private void CheckNameIsNotEmpty(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.Name))
                this.validatorResult.AddMessage(MessageFactory.GetNewErrorMessage("Nom vide."));
        }

        //[PredicatValidator("CheckNameIsNotEmpty")]
        //[ContexteValidation(ENUMContexteValidation.Modification)]
        private void CheckContactIsNotEmpty(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.Name))
                this.validatorResult.AddMessage(MessageFactory.GetNewErrorMessage("CheckContactIsNotEmpty"));
        }
    }
}