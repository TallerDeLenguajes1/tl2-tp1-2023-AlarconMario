using System;
using System.Globalization;
using System.Linq;
using spacePedido;
using spaceCadete;


namespace spaceCadeteria
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
        
        public void darAltaPedido(List<Pedido> ListaPedidos){
            //Muestro por pantalla los pedidos que no fueron entregados.
            int indice = 0;
            List<Pedido> pedAux = new List<Pedido>();
            for(int i= 0; i<ListaPedidos.Count; i++)
            {
                //Alamaceno los pedidos no entregados en una lista auxiliar.
                if(ListaPedidos[i].Estado != "Entregado")
                {
                    Console.WriteLine($"{indice+1})Pedido Nro {ListaPedidos[i].Nro}");
                    pedAux.Add(ListaPedidos[i]);
                    indice++;
                }
            }
            Console.WriteLine("Seleccione un pedido para dar Alta: ");

            if(int.TryParse(Console.ReadLine(), out int indicePedido) && indicePedido >= 1 && indicePedido <= pedAux.Count)
            {
                //Elimino el pedido de la lista de pedidos.
                Pedido pedidoSeleccionado = pedAux[indicePedido-1];
                ListaPedidos.Remove(pedidoSeleccionado);

                //Elimino el pedido de la lista del cadete.
                for(int i = 0; i < cadetes.Count; i++)
                {
                    for(int j = 0; j < cadetes[i].listPedidos.Count; j++)
                    {
                        if(pedidoSeleccionado.Nro == cadetes[i].listPedidos[j].Nro)
                        {
                            cadetes[i].listPedidos.RemoveAt(j);
                            
                        }
                    }
                }
                Console.WriteLine($"Se dio de Alta el pedido nro {pedidoSeleccionado.Nro} ");
            }
            else
            {
                Console.WriteLine("Pedido no válido, por favor seleccione un pedido válido");
            }
        }   
        public void asignarPedido(List<Pedido> listPedidos)
        {
            Console.WriteLine("Seleccione el pedido que quieres asignar:");
                    //Muestro la lista de pedidos sin asignar por pantalla.
                    List<Pedido> auxP = new List<Pedido>();
                    int ind = 0;
                    for (int i = 0; i < listPedidos.Count; i++)
                    {
                        
                        if(listPedidos[i].Estado == "SinAsignar")
                        {   
                            Console.WriteLine((ind + 1) +")Pedido Nro: "+ listPedidos[i].Nro);
                            ind++;
                            auxP.Add(listPedidos[i]);
                        }
                        
                    }
                    //elijo un pedido para asignarlo.
                    if (int.TryParse(Console.ReadLine(), out int indiceP) && indiceP >= 1 && indiceP <= auxP.Count)
                    {
                        
                        Pedido pedidoSeleccionado = auxP[indiceP - 1];

                        Console.WriteLine("Seleccione el cadete al que desea asignarlo:");
                        //Muestro los cadetes por Pantalla
                        for (int j = 0; j < cadetes.Count; j++)
                        {
                            Console.WriteLine((j + 1)+")Nombre del Cadete: "+ cadetes[j].Nombre +" - ID: "+ cadetes[j].Id);
                        }
                        //Selecciono al cadete para asignarle el pedido
                        if (int.TryParse(Console.ReadLine(), out int indiceC) && indiceC >= 1 && indiceC <= cadetes.Count)
                        {
                            Cadete cadeteSeleccionado = cadetes[indiceC - 1];

                            pedidoSeleccionado.Estado = "Enviado";
                            foreach(var l in listPedidos)
                            {
                                if(pedidoSeleccionado.Nro == l.Nro)
                                {
                                    l.Estado = pedidoSeleccionado.Estado;
                                }
                            }
                            cadeteSeleccionado.listPedidos.Add(pedidoSeleccionado);
                            
                            Console.WriteLine("El Pedido Nro "+ pedidoSeleccionado.Nro +" fue asignado a "+ cadeteSeleccionado.Nombre + " - ID: " + cadeteSeleccionado.Id);
                            listPedidos.RemoveAt(indiceP-1);
                        }
                        else
                        {
                            Console.WriteLine("Selección de cadete inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Selección de pedido inválida.");
                    }
        }

        public void Reasignar(List<Pedido> listPeididos)
        {
            int indice = 1;
            List<Pedido> listaux = new List<Pedido>();
            
            //Muestro por pantalla los pedidos y su estado.
            foreach (var pedido in listPeididos)
            {
                
                if(pedido.Estado == "EnCamino")
                {
                    Console.WriteLine(indice+") Pedido Nro: "+pedido.Nro+" - Estado: "+ pedido.Estado);
                    listaux.Add(pedido);
                    indice++;
                }
            } 
            
            Console.WriteLine("Seleccione un pedido para reasignarlo: ");
            indice = 0;
            if(int.TryParse(Console.ReadLine(), out int opcPedido)&& opcPedido >= 1 && opcPedido <= listaux.Count)
            {
                Pedido pedidoSeleccionado = listaux[opcPedido-1];
                Console.WriteLine("Seleccione el cadete para asignarle el pedido:");
                for(int i= 0; i< cadetes.Count; i++)
                {   
                    Console.WriteLine($"{i+1})Nombre del cadete: {cadetes[i].Nombre} - Id: {cadetes[i].Id}");
                    
                    //Elimino el pedido del la lista del cadete.
                    for(int j = 0; j< cadetes[i].listPedidos.Count; j++)
                    {
                        if(pedidoSeleccionado.Nro == cadetes[i].listPedidos[j].Nro)
                        {
                            cadetes[i].listPedidos.RemoveAt(j);
                            j--;
                        }
                    }   
                }
                if(int.TryParse(Console.ReadLine(), out int indCad) && indCad >= 1 && indCad <= cadetes.Count)
                {
                    Cadete cadeteSeleccionado = cadetes[indCad - 1];
                    // Asignar el pedido al cadete seleccionado
                    cadeteSeleccionado.listPedidos.Add(pedidoSeleccionado);
                    Console.WriteLine($"Pedido {pedidoSeleccionado.Nro} fue reasignado al cadete {cadeteSeleccionado.Nombre}");
                }
                else
                {
                    Console.WriteLine("Cadete no válido, por favor seleccione un cadete válido.");
                }
            }   
            else
            {
                Console.WriteLine("Pedido no válido, por favor seleccione un pedido válido");
            }                                
        }
    }  
}