using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1_WebAPI.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

        public Author Authors { get; set; }
    }
}
