using static System.Console;
namespace CoreEscuela.Util

{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 70){
            WriteLine("".PadLeft(tam, '='));
        }

             public static void DibujarTitulo(string titulo){
                 DibujarLinea();
                 WriteLine($"| {titulo}");
                 DibujarLinea(); 
        }

            public static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1){
            while (cantidad-- > 0)
            {
                System.Console.Beep(hz, tiempo);
            }
        }

    }
}