using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAlumnos.Models;
using APIAlumnos.Repositories;

namespace APIAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoraController : ControllerBase
    {
        public calificacionesContext Context { get; }
        Repository<Alumno> repository;
        public ProfesoraController(calificacionesContext context)
        {
            Context = context;
            repository = new(Context);
        }
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            var lista = repository.GetAll().OrderBy(x => x.Nombre);
            return lista;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var alumno = repository.Get(id);
            if (alumno == null)
            {
                return NotFound();
            }
            else
                return Ok(alumno);
        }
        [HttpPost]
        public IActionResult Post(Alumno al)
        {
            if (al == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(al.Nombre))
            {
                ModelState.AddModelError("", "Proporcione los nombres del alumno.");
            }
            if (string.IsNullOrWhiteSpace(al.Apellido))
            {
                ModelState.AddModelError("", "Proporcione los apellidos del alumno.");

            }
            if (string.IsNullOrWhiteSpace(al.Usuario))
            {
                ModelState.AddModelError("", "Proporcione el usuario del alumno.");
            }
            if (string.IsNullOrWhiteSpace(al.Password))
            {
                ModelState.AddModelError("", "Proporcione la contraseña del alumno.");
            }
            if (ModelState.IsValid)
            {
                repository.Insert(al);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        public IActionResult Put(Alumno al)
        {
            var alumno = repository.Get(al.IdAlumno);
            if (alumno == null)
            {
                return NotFound();
            }
            if (al == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(al.Nombre))
            {
                ModelState.AddModelError("", "Proporcione los nombres del alumnos");
            }
            if (string.IsNullOrWhiteSpace(al.Apellido))
            {
                ModelState.AddModelError("", "Proporcione los apellidos del alumnos");

            }
            if (string.IsNullOrWhiteSpace(al.Usuario))
            {
                ModelState.AddModelError("", "Proporcione el usuario del alumno");
            }
            if (string.IsNullOrWhiteSpace(al.Password))
            {
                ModelState.AddModelError("", "Proporcione la contraseña del alumno");
            }
            if (ModelState.IsValid)
            {
                alumno.Nombre = al.Nombre;
                alumno.Apellido = al.Apellido;
                alumno.Usuario = al.Usuario;
                alumno.Password = al.Password;
                alumno.EspanolEv1 = al.EspanolEv1;
                alumno.EspanolEv2 = al.EspanolEv2;
                alumno.EspanolEv3 = al.EspanolEv3;
                alumno.MatematicasEv1 = al.MatematicasEv1;
                alumno.MatematicasEv2 = al.MatematicasEv2;
                alumno.MatematicasEv3 = al.MatematicasEv3;
                alumno.Cnev1 = al.Cnev1;
                alumno.Cnev2 = al.Cnev2;
                alumno.Cnev3 = al.Cnev3;

                alumno.PromEspanol = (al.EspanolEv1 + al.EspanolEv2 + al.EspanolEv3) / 3;
                alumno.PromMate = (al.MatematicasEv1 + al.MatematicasEv2 + al.MatematicasEv3) / 3;
                alumno.PromCn = (al.Cnev1 + al.Cnev2 + al.Cnev3) / 3;

                repository.Update(alumno);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alumno = repository.Get(id);
            if (alumno == null)
            {
                return NotFound();
            }
            repository.Delete(alumno);
            return Ok();
        }

    }
}

