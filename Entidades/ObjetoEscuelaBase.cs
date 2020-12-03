using System;

namespace CoreEscuela.Entidades
{
    public  class ObjetoEscuelaBase
    {
        public string UniqueId { get; set; }    
        public string Nombre { get; set; }



        public ObjetoEscuelaBase()
        {
            UniqueId =  Guid.NewGuid().ToString();
        }
    }
}