using Project1_WebAPI.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Project1_WebAPI.ValidationAttributes
{
    public class AuthorFirstLastMustBeDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var author = (AuthorForCreateDto)validationContext.ObjectInstance;
            if (author.FirstName == author.LastName)
            {
                return new ValidationResult("FirstName dan LastName tidak boleh sama",
                    new[] { nameof(AuthorForCreateDto) });
            }

            return ValidationResult.Success;
        }
    }
}