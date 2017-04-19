using System;

namespace Kevinovation.PoC.BusinessValidator.Library
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class GroupValidatorAttribute : Attribute
    {
        private byte mGroupNumber;
        private byte mOrder;

        public GroupValidatorAttribute(byte pbytGroupNumber, byte pbytOrder)
        {
            this.mGroupNumber = pbytGroupNumber;
            this.mOrder = pbytOrder;
        }
    }
}