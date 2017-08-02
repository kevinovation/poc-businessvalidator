using System;
using System.Collections.Generic;
using System.Text;

namespace Kevinovation.PoC.BusinessValidator.Library
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ContexteValidationAttribute : Attribute
    {
        public ENUMContexteValidation ContexteValidation { get; set; }

        public ContexteValidationAttribute(ENUMContexteValidation peContexteValidation)
        {
            this.ContexteValidation = peContexteValidation;
        }
    }
}
