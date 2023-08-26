using System;
using WebApp.Entidades;

namespace ServicioDeCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string telf;
        private List<Cadete> cadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telf { get => telf; set => telf = value; }
        public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

        public Cadeteria(string nombre, string telf, List<Cadete> _cadetes)
        {
            this.nombre = nombre;
            this.telf = telf;
            this.cadetes = _cadetes;
        }

    
    }

    
}