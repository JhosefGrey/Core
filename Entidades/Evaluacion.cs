using System;
using System.Collections.Generic;
namespace CoreEscuela.Entidades

{
    public class Evaluacion: ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura{ get; set; }
        public float nota { get; set; }

        public override string ToString()
        {
            return $"{nota},{Alumno.Nombre},{Asignatura.Nombre}";
        }
    }
}