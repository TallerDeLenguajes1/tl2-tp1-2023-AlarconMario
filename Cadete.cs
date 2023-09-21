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
       

     
        public Cadete(int _id, string _nombre, string _direccion, string _telf)
        {
             id = _id;
             nombre = _nombre;
             direccion = _direccion;
             telf = _telf;
        }

        
        
       

    }
}
