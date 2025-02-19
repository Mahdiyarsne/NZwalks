using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZwalks.API.Controllers
{

    public class StudentsController : BaseApiController
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] students = ["Mahdiyar", "Sajad", "Jafar", "Mohamad"];

            return Ok(students);
        }
    }
}
