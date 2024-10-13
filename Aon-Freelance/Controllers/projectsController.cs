using Aon_Freelance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Aon_Freelance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class projectsController : ControllerBase
    {
        // Object list from model(Project)
        private static List<Project> projectsList = new List<Project>();

        // /api/v1/projects GET (To Get All projects)
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(projectsList);
        }

        // /api/v1/projects POST (to store new project)
        [HttpPost]
        public IActionResult Create([FromBody] Project Newitem)
        {
            projectsList.Add(Newitem);
            return CreatedAtAction("Create", new { Id = Newitem.Id }, projectsList);
        }

        // /api/v1/projects/{id} GET (to get specific project by ID)
        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            Project pr = projectsList.FirstOrDefault(p => p.Id == id);
            if (pr == null)
            {
                return NotFound("The resoucre is not found!");
            }

            return Ok(pr);
        }

        // /api/v1/projects/{id} DELETE (to delete specific project)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Project pr = projectsList.FirstOrDefault(p => p.Id == id);
            if (pr != null)
            {
                projectsList.Remove(pr);
                return Ok("Deleted");
            }

            return NotFound();
        }

    }
}
