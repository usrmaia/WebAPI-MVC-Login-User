using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models.Course;
using API.Models.ErrorMessage;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using API.Context;
using API.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class CourseController : ControllerBase
    {
        private readonly CourseContext _context;

        public CourseController(CourseContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        [SwaggerResponse(statusCode: 201, description:"Successfully in registering course", type:typeof(CourseInput))]
        [SwaggerResponse(statusCode: 401, description:"Not authorized")]
        public IActionResult Post(CourseInput courseInput)
        {
            var userId = int.Parse(User.FindFirst(match => match.Type == ClaimTypes.NameIdentifier)?.Value);
            
            Course course = new Course();
            course.Name = courseInput.Name;
            course.Description = courseInput.Description;
            course.UserId = userId;

            _context.Course.Add(course);
            _context.SaveChanges();

            return Created(userId.ToString(), course);
        }

        [HttpGet]
        [SwaggerResponse(statusCode: 200, description:"Successfully in get course", type:typeof(CourseOutput))]
        [SwaggerResponse(statusCode: 401, description:"Not authorized")]
        public IActionResult Get()
        {
            var userId = int.Parse(User.FindFirst(match => match.Type == ClaimTypes.NameIdentifier)?.Value);
            List<Course> courses = _context.Course.Where(p => p.UserId == userId).ToList();

            return Ok(courses);
        }
    }
}