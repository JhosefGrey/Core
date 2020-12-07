using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela.app
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }
        public EscuelaEngine()
        {

        }
        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
          ciudad: "Bogota", pais: "Colombia"
          );
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }
        public List<ObjetoEscuelaBase> GetObjetosEscuela()
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.Cursos);

            foreach (var curso in Escuela.Cursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluaciones);
                }
            }

            return listaObj;
        }
        #region Metodos de Carga
        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }
        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Educacion Fisica"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"},
                    new Asignatura{Nombre="Ingles"},
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }
        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }
        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){ Nombre = "101", Jornada=TiposJornada.Matutina },
                new Curso(){ Nombre = "201" , Jornada=TiposJornada.Matutina},
                new Curso(){ Nombre = "301", Jornada=TiposJornada.Matutina },
                new Curso(){ Nombre = "401", Jornada=TiposJornada.Matutina },
                new Curso(){ Nombre = "501" , Jornada=TiposJornada.Matutina},
                new Curso(){ Nombre = "601", Jornada=TiposJornada.Matutina },
            };
            Random rnd = new Random();

            foreach (var curso in Escuela.Cursos)
            {
                int cantidadRamdom = rnd.Next(5, 20); ;
                curso.Alumnos = GenerarAlumnosAlAzar(cantidadRamdom);
            }
        }
        #endregion
    }
}