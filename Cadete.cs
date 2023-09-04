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
        public List<Pedido> listPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telf { get => telf; set => telf = value; }
       

        public Cadete(string _nombre, int _id, string _telf, string _direccion)
        {
            this.nombre = _nombre;
            this.id = _id;
            this.telf = _telf;
            this.direccion = _direccion;
            this.listPedidos = new List<Pedido>();
            
        }

        public float jornal()
        {
            float total = 0;
            foreach(var p in listPedidos)
            {
                if(p.Estado == "Entregado")
                {   
                    total+= 500;
                }
            }
            return total;
        }
        public void altaPedido(int indice)
        {
            listPedidos.RemoveAt(indice);
        }

        public static void cambiarEstado(List<Pedido> ped)
        {
            //muestro por pantalla los pedidos asignados.
            int j = 0;
            
            List<Pedido> aux = new List<Pedido>();
            foreach(var p in ped)
            {
                if(p.Estado != "SinAsignar")
                {
                    Console.WriteLine($"{j+1})Pedido Nro: {p.Nro} - Estado: {p.Estado}");
                    aux.Add(p);
                    j++;
                }
            }
            Console.WriteLine("Seleccione un pedido:");
            int longitudEnum = Enum.GetValues(typeof(Pedido.estadoPedido)).Length;
            Pedido.estadoPedido est = (Pedido.estadoPedido)0;
            
            foreach(var p in aux)
            {
                if(int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= aux.Count)
                {
                    Pedido pedidoSeleccionado = aux[indice-1];
                    Console.WriteLine("Seleccione un estado para cambiarlo:");
                    for(int i = 0; i < longitudEnum; i++)
                    {
                        Console.WriteLine($"{i+1}){est = (Pedido.estadoPedido)i}");
                    }
                    foreach(var pedi in ped)
                    {
                        if(pedidoSeleccionado.Nro == pedi.Nro)
                        {
                            
                            if(int.TryParse(Console.ReadLine(), out int opEstado) && opEstado >= 0 && opEstado < longitudEnum)
                            {
                                est = (Pedido.estadoPedido)opEstado-1;
                                pedi.Estado = est.ToString();
                                Console.WriteLine($"El pedidod Nro: {pedidoSeleccionado.Nro} cambio su estado a {pedidoSeleccionado.Estado}");
                            }
                            else
                            {
                                Console.WriteLine("Opcion de estado no válido, por favor seleccione una opcion válido.");
                            }
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Pedido no válido, por favor seleccione un pedido válido.");
                }
            }
        }
    }
}
