// See https://aka.ms/new-console-template for more information
using System.Collections;
using System;
using spaceCadeteria;
using spacePedido;
using spaceCadete;



internal class Program
{
    private static void Main(string[] args)
    {
        //Leo el archivo Cadete.cvs Para cargar la lista de Empleados.
        string filePath = "Cadete.csv";
        List<Cadete> listCadetes = new List<Cadete>();
        
        if(File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            for(int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                string nombre = values[0];
                int id = int.Parse(values[1]);
                string telf = values[2];
                string direccion = values[3];

                var cad = new Cadete(nombre,id, telf, direccion);
                listCadetes.Add(cad);
            }
        }
        else
        {
            Console.WriteLine("El archivo no Existe.");
        }
        
        //Leo el Archivo cadeteria.cvs para cargar cadeteria.
        string filePath2 = "Cadeteria.csv";
        List<Cadeteria> cdt = new List<Cadeteria>();
        if(File.Exists(filePath2))
        {
            string[] lines = File.ReadAllLines(filePath2);
            for(int i = 1; i< lines.Length; i++){
                string[] values = lines[i].Split(",");
                string nomb = values[0];
                string telefono = values[1];
                
                var cadeteria = new Cadeteria(nomb, telefono, listCadetes);
                cdt.Add(cadeteria);
            }   
        }

        //Creo Pedidos Aleartorios.
        
        List<Pedido> listPedidos = new List<Pedido>();
        Random random = new Random();

        int numeroAleatorio = 0; 
        for(int i = 0; i< 10; i++)
        {
            int num = random.Next(1,999);
            numeroAleatorio = random.Next(0,3);
            Pedido.estadoPedido est = (Pedido.estadoPedido)numeroAleatorio;
            var p = new Pedido(num, "prueba", est.ToString());
            listPedidos.Add(p);
        }
        
        //Asigno pedidos al azar a los cadetes.
        int n;
        foreach(var l in listPedidos)
        {
            if(l.Estado != "SinAsignar")
            {
                n = random.Next(1,3);
                listCadetes[n].listPedidos.Add(l); 
            }
        }
        
        while (true)
        {
            Console.WriteLine("---GESTION DE CADETERIA---");
            Console.WriteLine("1)Dar de alta pedidos.");
            Console.WriteLine("2)Asignar pedido");
            Console.WriteLine("3)Cambiarlos de estado");
            Console.WriteLine("4)Reasignar el pedido a otro cadete.");
            

            
            Console.Write("Seleccione una opción: ");
            string? opc = Console.ReadLine();
            
            switch (opc?.ToLower())
            {
                case "1":
                    Console.WriteLine("----------Dar de alta un Peido----------");
                    cdt[0].darAltaPedido(listPedidos);

                    //int indice = int.Parse(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("--------Asignar Pedido a un cadete--------");
                    
                    cdt[0].asignarPedido(listPedidos);

                    break;
                case "3":
                    Console.WriteLine("-------Cambiar Estado del Pedido: -------");
                    
                    Cadete.cambiarEstado(listPedidos);
                    break;
                case "4":
                    Console.WriteLine("-------------Reasignar pedido-------------");
                    cdt[0].Reasignar(listPedidos);
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        }
    }
}