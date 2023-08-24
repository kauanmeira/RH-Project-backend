using System;

namespace RH_Project.Models.enums
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RestrictAttribute : Attribute
    {
        public string ErrorMessage { get; }

        public RestrictAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
