using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Course
{
    public class CourseInput
    {
        [Required(ErrorMessage = "Inform Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Inform Description")]
        public string Description { get; set; }
    }
}