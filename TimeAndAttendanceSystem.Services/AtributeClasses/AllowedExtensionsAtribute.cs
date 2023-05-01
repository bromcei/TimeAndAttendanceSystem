using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Services.AtributeClasses
{
    public class AllowedExtensionsAtribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAtribute(string[] extensions)
        {
            _extensions = extensions;
        }
         
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult("Not supported file");
                }
            }

            return ValidationResult.Success;
        }
    }
}
