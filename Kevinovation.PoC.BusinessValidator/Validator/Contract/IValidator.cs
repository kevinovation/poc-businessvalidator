using Kevinovation.PoC.BusinessValidator.Library;

namespace Kevinovation.PoC.BusinessValidator.Validator.Contract
{
    public interface IValidator<T> where T : class
    {
        ValidatorResult Validate(T entity, ENUMContexteValidation peContexteValidation);
    }
}