using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string nombre { get;  set; }
        public string UniqueId { get; private set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas {get;set;}
        public List<Alumno> Alumnos {get;set;}
        public List<Evaluaciones> Evaluaciones {get;set;}
        public Curso() =>  UniqueId = Guid.NewGuid().ToString();
      
    }
}