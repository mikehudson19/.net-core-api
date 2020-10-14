using System;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers
{
    [ApiController] // This is the ApiController attribute - not strictly necessary, but improves the development experience.
    public class AuthorsController : ControllerBase // The ControllerBase class contains all the basic functionality that a controller class needs.
    {

        private readonly ICourseLibraryRepository _courseLibraryRepository; // We are not going to change this, so we use a readonly field. 

        public AuthorsController (ICourseLibraryRepository courseLibraryRepository) // Injecting an instance of the repository through constructor injection.
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
        }

       [HttpGet("api/authors")]
       public IActionResult GetAuthors() // This is called an 'action method'. 
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
            return new JsonResult(authorsFromRepo); // Formats the given result as JSON.    
        }
    }
}
