// See https://aka.ms/new-console-template for more information
using System.Collections;
using ServicioDeCadeteria;


internal class Program
{
    private static void Main(string[] args)
    {
        var cadete = new Cadete("Mario", 123, "3814565", "Independencia 123");
        List<Cadete> cad = new List<Cadete>();
        var cadete2 = new Cadete("Luis", 123, "3814565", "Independencia 123");
        cad.Add(cadete);
        cad.Add(cadete2);
        var cadeteria = new Cadeteria("Rapi", "3816653", cad);



        //cadete.cargarCadete();
        cadete.verCadetes();
        while (true)
        {
            Console.WriteLine("1)Dar de alta pedidos.");
            Console.WriteLine("2)Asignarlos a cadetes");
            Console.WriteLine("3)Cambiarlos de estado");
            Console.WriteLine("4)Reasignar el pedido a otro cadete.");
            Console.WriteLine("5)Salir");

            
            Console.Write("Seleccione una opción: ");
            string? opc = Console.ReadLine();
            switch (opc?.ToLower())
            {
                case "1":
                    
                    break;
                case "2":
                    
                    break;
                case "3":
                    
                    break;
                case "4":
                    
                    break;
                case "5":
                    
                    break;
            }

        }
    }
}