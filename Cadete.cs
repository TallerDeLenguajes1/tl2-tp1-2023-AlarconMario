using System;
using System.Reflection.Emit;
using spaceCadeteria;
using spacePedido;

namespace spaceCadete
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telf;
        

        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telf { get => telf; set => telf = value; }
       

     
        public Cadete(int id, string nombre, string direccion, string telf)
        {
             this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telf = telf;
        }

        
        
       

    }
}
