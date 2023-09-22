// See https://aka.ms/new-console-template for more information
using System.Collections;
using System;
using spaceCadeteria;
using spacePedido;
using spaceCadete;
using System.Text.Json;
using Newtonsoft.Json;
using spaceAccesoADatos;



internal class Program
{
    private static void Main(string[] args)
    {
        
        
        
        Random random = new Random();
        
        Console.WriteLine("Cargar Datos: \n1)JSON \n2)CSV");
        AccesoJson json = new AccesoJson();
        AccesoCsv cvs = new AccesoCsv();
        Cadeteria cadeteria = new Cadeteria();
        if(int.TryParse(Console.ReadLine(), out int opcAcceso) && opcAcceso >0 & opcAcceso <= 2)
        {
            if(opcAcceso == 1)
            {
                cadeteria = json.CargarInfoCadeteria();
            }
            else
            {
                cadeteria = cvs.CargarInfoCadeteria();
            }
        }
        
       
        int numeroAleatorio = 0;
        int num = 0; 
        
        while (true)
        {
            Console.WriteLine("---GESTION DE CADETERIA---");
            Console.WriteLine("1)Dar de alta pedidos.");
            Console.WriteLine("2)Asignar pedido");
            Console.WriteLine("3)Cambiarlos de estado");
            Console.WriteLine("4)Reasignar el pedido a otro cadete.");
            Console.WriteLine("5)Informe.");
            

            
            Console.Write("Seleccione una opción: ");
            string? opc = Console.ReadLine();
            
            switch (opc?.ToLower())
            {
                case "1":
                    Console.WriteLine("--------Crear Pedido--------");
                    //Creo un Pedidos Aleartorios.
                    int idC = random.Next(1, 4);
                    numeroAleatorio = random.Next(0,3);
                    num = random.Next(1, 500);
                    Pedido.estadoPedido est = (Pedido.estadoPedido)numeroAleatorio;
                    var p = new Pedido(num, "prueba", est.ToString(), idC);
                    if(est == 0){
                        p.IdCadete = 0;
                    }
                    cadeteria.Pedidos.Add(p);
                    Console.WriteLine($"El Pedido N° {p.Nro} fue creado - Estado {p.Estado} ");

                    break;
                case "2":
                    Console.WriteLine("--------Asignar Pedido a un cadete--------");
                    Console.WriteLine("Seleccione el Pedido para asignarlo: ");
                    int j = 0;
                    List<int> pedidoNro = new List<int>();
                    for(int i = 0; i< cadeteria.Pedidos.Count; i++)
                        if(cadeteria.Pedidos[i].Estado == "SinAsignar")
                        {
                            j++;
                            Console.WriteLine($"{j})Pedido Nro: {cadeteria.Pedidos[i].Nro} - Estado: {cadeteria.Pedidos[i].Estado}");
                            pedidoNro.Add(cadeteria.Pedidos[i].Nro);
                        }
                        if(int.TryParse(Console.ReadLine(), out int nroPedido) && nroPedido >= 1 && nroPedido <= pedidoNro.Count)
                        {
                            int pedidoSeleccionado = pedidoNro[nroPedido - 1];
                            Console.WriteLine("Seleccione un cadete: ");
                            for(int i = 0; i < cadeteria.Cadetes.Count; i++)
                            {
                                Console.WriteLine($"{i+1})ID = {cadeteria.Cadetes[i].Id} - {cadeteria.Cadetes[i].Nombre}");
                            }
                            if(int.TryParse(Console.ReadLine(), out int idCadete) && idCadete >= 1 && idCadete <= cadeteria.Cadetes.Count)
                            {
                                int cadeteSelecionado = cadeteria.Cadetes[idCadete-1].Id;
                                cadeteria.AsignarCadeteAPedido(cadeteSelecionado, pedidoSeleccionado);
                                Console.WriteLine($"El peidod {pedidoSeleccionado} fua asiganado al cadete {cadeteria.Cadetes[idCadete-1].Nombre} - ID: {cadeteria.Cadetes[idCadete-1].Id}");
                                
                            }
                            else
                            {
                                Console.WriteLine("Cadete no válido, por favor seleccione un cadete válido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pedido no válido, por favor seleccione un pedido válido.");
                        }
                    break;
                case "3":
                    Console.WriteLine("-------Cambiar Estado del Pedido: -------");
                    Console.WriteLine("Seleccione el pedido para cambiar el estado: ");
                    List<int> nroPedidos = new List<int>();
                    j = 0;
                    for(int i = 0; i < cadeteria.Pedidos.Count; i++)
                    {
                        if(cadeteria.Pedidos[i].Estado != "SinAsignar")
                        {
                            Console.WriteLine($"{j+1})Pedido Nro: {cadeteria.Pedidos[i].Nro} - Estado: {cadeteria.Pedidos[i].Estado}");
                            nroPedidos.Add(cadeteria.Pedidos[i].Nro);
                            j++;
                        }
                    }
                    int longitudEnum = Enum.GetValues(typeof(Pedido.estadoPedido)).Length;
                    if(int.TryParse(Console.ReadLine(), out int indicePed) && indicePed >= 1 && indicePed <= nroPedidos.Count)
                    {
                        int pedidoSeleccionado = nroPedidos[indicePed-1];
                        Console.WriteLine("Seleccione un estado: ");
                        for(int i = 0; i < longitudEnum; i++)
                        {
                        Console.WriteLine($"{i+1}){est = (Pedido.estadoPedido)i}");
                        }
                        if(int.TryParse(Console.ReadLine(), out int inidiceEstado) && inidiceEstado >= 1 && inidiceEstado <= longitudEnum)
                        {
                            cadeteria.cambiarEstado(pedidoSeleccionado, ((Pedido.estadoPedido)inidiceEstado-1).ToString());
                            Console.WriteLine($"El pedido Nro: {pedidoSeleccionado} cambio su estado a {((Pedido.estadoPedido)inidiceEstado-1).ToString()}");
                        }
                        else
                        {
                            Console.WriteLine("Seleccionaste un estado inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Seleccionaste un pedido inválido.");
                    }
                    
                    break;
                case "4":
                    Console.WriteLine("-------------Reasignar pedido-------------");
                    Console.WriteLine("Seleccione el Pedido para Reasignarlo: ");
                    List<Pedido> pedAsig = cadeteria.pedidosAsignado();
                    j = 0;
                    foreach(var ped in pedAsig)
                    {
                        Console.WriteLine($"{j+1}) Pedido Nro: {ped.Nro} - ID del Cadete asignado: {ped.IdCadete}");
                        j++;
                    }
                    if(int.TryParse(Console.ReadLine(), out int indi) && indi >= 1 && indi <= pedAsig.Count)
                    {
                        int pedidoSeleccionado = cadeteria.selecionarPedido(indi-1, pedAsig);
                        Console.WriteLine("Selecciona un cadete: ");
                        for(int i = 0; i < cadeteria.Cadetes.Count; i++)
                        {
                            Console.WriteLine($"{i+1})ID : {cadeteria.Cadetes[i].Id}- Nombre: {cadeteria.Cadetes[i].Nombre}");
                        }
                        if(int.TryParse(Console.ReadLine(), out int cadeteInd) && cadeteInd >= 1 && cadeteInd <= cadeteria.Cadetes.Count)
                        {
                            int cadeteSeleccionado = cadeteria.Cadetes[cadeteInd -1 ].Id;
                            cadeteria.reasignarPedido(pedidoSeleccionado, cadeteSeleccionado);
                            
                            Console.WriteLine($"El pedido Nro {pedidoSeleccionado} fue reasignado al cadete {cadeteria.Cadetes[cadeteInd-1].Nombre} - ID: {cadeteSeleccionado}");
                        }
                        else
                        {
                            Console.WriteLine("Seleccionaste un cadete inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Seleccionaste un pedido inválido.");
                    }
                   
                    break;
                case "5":
                    Console.WriteLine("----------INFORME----------");
                    
                    foreach(var cad in cadeteria.Cadetes)
                    {
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine($"Informe Cadete {cad.Nombre} - ID: {cad.Id}");
                        Console.WriteLine($"Pedidos entregados: {cadeteria.enviosEntregados(cad.Id)}");
                        Console.WriteLine($"Promedio de envios: {cadeteria.promedioDeEnvios(cad.Id)}%");
                        Console.WriteLine($"Paga: ${cadeteria.JornalACobrar(cad.Id)}");
        
                    }
                    Console.WriteLine("///////////////////////////////////");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        }
    }
}