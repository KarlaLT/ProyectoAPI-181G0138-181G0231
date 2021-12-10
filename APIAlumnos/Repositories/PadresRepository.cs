using System;
using System.Collections.Generic;
using System.Linq;
using APIAlumnos.Models;
using System.Threading.Tasks;

namespace APIAlumnos.Repositories
{
    public class PadresRepository : Repository<Alumno>
    {
        public override calificacionesContext Context { get; }
        public PadresRepository(calificacionesContext context) : base(context)
        {
            Context = context;
        }

        //public IEnumerable<Materias> GetCalificacionesById(string usuario, string password)
        //{
        //    return (IEnumerable<Materias>)Context.Set<Materias>().Where(x => x.IdAlumnoNavigation.Usuario == usuario
        //    && x.IdAlumnoNavigation.Contrasena == password);
        //}
        public Alumno GetCalificacionesByAlumno(string usuario, string password)
        {
            var alumno = Context.Set<Alumno>().FirstOrDefault(x => x.Usuario == usuario && x.Password == password);
            return alumno;
        }
    }
}
