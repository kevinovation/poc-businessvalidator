using System;

namespace Kevinovation.PoC.BusinessValidator.Library
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class IsDisabledValidatorAttribute : Attribute
    {
    }
}