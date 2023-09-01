using System;

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

        public void AgregarCadete(Cadete cadete)
        {
            cadetes.Add(cadete);
        }
        public void AsignarPedido(Pedido pedido, Cadete cad)
        {
            if (cadetes.Contains(cad))
            {
                cad.pedidos.Add(pedido);
            }
            else
            {
                cadetes.Add(cad);
                cad.pedidos.Add(pedido);
            }
        }
        public void verCadetes(List<Cadete> cad)
        {
            foreach(var c in cad)
            {
                Console.WriteLine($"Nombre: {c.Nombre}, ID : {c.Id}, Telf: {c.Telf}, Direccion: {c.Direccion}");
            }
        }

        public void ReasignarPedido(Pedido pedido, Cadete cad1, Cadete cad2)
        {
            if (cad1.pedidos.Contains(pedido))
            {
                cad1.pedidos.RemoveAt(pedido.Num);
                cad2.pedidos.Add(pedido);
            }
            else
            {
                cad2.pedidos.Add(pedido);
            }
        }
    
    }

    
}