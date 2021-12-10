using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using APIAlumnos.Models;
using APIAlumnos.Repositories;
using System.Threading.Tasks;

namespace APIAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadresController : ControllerBase
    {
        public calificacionesContext Context { get; }

        public PadresController(calificacionesContext context)
        {
            Context = context;
        }
        [HttpGet("{user}-{password}")]
        public IActionResult Get(string user, string password)
        {
            PadresRepository repository = new(Context);
            var alumno = repository.GetCalificacionesByAlumno(user, password);
            if (alumno == null)
            {
                return NotFound();
            }
            else
                return Ok(alumno);
        }
    }
}
