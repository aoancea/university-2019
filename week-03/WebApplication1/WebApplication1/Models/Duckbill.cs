using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Duckbill
    {
        public Guid Id { get; set; }

        [MaxLength(10, ErrorMessage = "Name is too long. Max length is 10!")]
        [Required(ErrorMessage = "Name cannot be empty! Please provide a value!")]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$")]
        public string EmailByRegex { get; set; }
    }
}