using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Project1_WebAPI.ValidationAttributes;

namespace Project1_WebAPI.Dtos
{
    [AuthorFirstLastMustBeDifferentAttribute]
    public class AuthorForCreateDto
    {
        [Required(ErrorMessage = "Kolom FirstName harus diisi")]
        [MaxLength(50, ErrorMessage = "Tidak boleh lebih dari 50 karakter")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Kolom LastName harus diisi")]
        [MaxLength(50, ErrorMessage = "Tidak boleh lebih dari 50 karakter")]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        [Required(ErrorMessage = "Kolom MainCategory harus diisi")]
        [MaxLength(50, ErrorMessage = "Tidak boleh lebih dari 50 karakter")]
        public string MainCategory { get; set; }
    }
}
