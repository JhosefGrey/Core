using System;
using System.Linq;
using CoreEscuela.app;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.DibujarTitulo("Bienvenidos a la Escuela");
            // Printer.Beep(10000, cantidad: 10);
            ImprimirCursosEscula(engine.Escuela);
            var listaObjetos = engine.GetObjetosEscuela();

            var listaIlugar = from obj in listaObjetos
                              where obj is iLugar
                              select (iLugar)obj;

            // engine.Escuela.LimpiarLugar();

        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
        }


        private static void ImprimirCursosEscula(Escuela escuela)
        {
            Printer.DibujarTitulo("Cursos de la Escuela");

            if (escuela.Cursos == null)
            {
                return;
            }
            else
            {
                foreach (var curso in escuela.Cursos)
                {
                    Console.WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                }
            }
        }


    }
}
