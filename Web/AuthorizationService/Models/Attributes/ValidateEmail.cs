using System.ComponentModel.DataAnnotations;
namespace AuthorizationService.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ValidateEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string userName = (string)validationContext.ObjectType.GetProperty("UserName").GetValue(validationContext.ObjectInstance, null);

            string email = (string)validationContext.ObjectType.GetProperty("Email").GetValue(validationContext.ObjectInstance, null);

            //check at least one has a value
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email))
                return new ValidationResult("Only one of them can be exist!");

            return ValidationResult.Success;
        }
    }
}
