using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicioDeCadeteria;

namespace WebApp.Entidades
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telf;
        public List<Pedido> pedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telf { get => telf; set => telf = value; }
       
        public Cadete(string _nombre, int _id, string _telf, string _direccion, List<Pedido> _pedidos)
        {
            this.nombre = _nombre;
            this.id = _id;
            this.telf = _telf;
            this.direccion = _direccion;
            this.pedidos = _pedidos;
        }
        
    }
}
