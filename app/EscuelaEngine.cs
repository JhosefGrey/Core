using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela.app
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }


        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Adacemy", 2012, TiposEscuela.Primaria,
          ciudad: "Bogota", pais: "Colombia"
          );
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            foreach(var curso in Escuela.Cursos){
                foreach(var asignatura in curso.Asignaturas){
                    foreach(var alumno in curso.Alumnos){
                        var rnd = new Random(System.Environment.TickCount);

                        for(int i = 0; i<5; i++){
                            var ev = new Evaluaciones{
                                Asignatura = asignatura,
                                nombre = $"{asignatura.nombre} Ev#{i + 1}",
                                nota = (float)(5* rnd.NextDouble()),
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
                    new Asignatura{nombre="Matematicas"},
                    new Asignatura{nombre="Educacion Fisica"},
                    new Asignatura{nombre="Castellano"},
                    new Asignatura{nombre="Ciencias Naturales"},
                    new Asignatura{nombre="Ingles"},
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
                               select new Alumno { nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){ nombre = "101", Jornada=TiposJornada.Matutina },
                new Curso(){ nombre = "201" , Jornada=TiposJornada.Matutina},
                new Curso(){ nombre = "301", Jornada=TiposJornada.Matutina },
                new Curso(){ nombre = "401", Jornada=TiposJornada.Matutina },
                new Curso(){ nombre = "501" , Jornada=TiposJornada.Matutina},
                new Curso(){ nombre = "601", Jornada=TiposJornada.Matutina },
            };
            Random rnd = new Random();

            foreach (var curso in Escuela.Cursos)
            {
                int cantidadRamdom = rnd.Next(5, 20); ;
                curso.Alumnos = GenerarAlumnosAlAzar(cantidadRamdom);
            }
        }

    }
}