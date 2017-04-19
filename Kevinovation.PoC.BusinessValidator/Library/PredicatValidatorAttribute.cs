using System;

namespace Kevinovation.PoC.BusinessValidator.Library
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class PredicatValidatorAttribute : Attribute
    {
        public string MethodName { get; set; }

        public PredicatValidatorAttribute(string pstrMethodPredicate)
        {
            this.MethodName = pstrMethodPredicate;
        }
    }
}