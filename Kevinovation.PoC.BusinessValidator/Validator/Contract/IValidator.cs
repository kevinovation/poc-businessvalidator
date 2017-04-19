using Kevinovation.PoC.BusinessValidator.Library;

namespace Kevinovation.PoC.BusinessValidator.Validator.Contract
{
    public interface IValidator
    {
        ValidatorResult Validate(object entity);
    }
}