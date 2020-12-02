using System;
using System.Collections.Generic;
namespace CoreEscuela.Entidades

{
    public class Evaluaciones
    {
        public string nombre { get; set; }
        public string UniqueId { get; private set; }
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura{ get; set; }
        public float nota { get; set; }
        public Evaluaciones() => UniqueId = Guid.NewGuid().ToString();
    }
}