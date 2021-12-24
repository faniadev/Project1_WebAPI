using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1_WebAPI.Dtos
{
    public class CourseForCreateDto
    {
        [Required]
        public int AuthorID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

    }
}