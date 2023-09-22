using System.Text.Json;
using System.Text.Json.Serialization;
using spaceCadete;
using spaceCadeteria;
using spacePedido;


namespace spaceAccesoADatos
{
    public abstract class AccesoADatos
    {
        public Cadeteria Cadeteria { get; protected set; } = new Cadeteria();
        public abstract Cadeteria CargarInfoCadeteria();
        public abstract List<Cadete> DatosCadetes();
    }

    public class AccesoCsv : AccesoADatos
    {
        
        public override Cadeteria CargarInfoCadeteria()
        {
           List<Pedido> LisPedido = new List<Pedido>();
           string filePath = "Cadeteria.csv";
          
           try
           {
                string[] lines = File.ReadAllLines(filePath);
                foreach(string line in lines.Skip(1))
                {
                    string[] fields = line.Split(',');
                    if(fields.Length == 2)
                    {   
                        string nombre = fields[0];
                        string telf = fields[1];
                        
                        
                        Cadeteria = new Cadeteria(nombre, telf, DatosCadetes(), LisPedido);
                        
                    }
                    else
                    {
                        Console.WriteLine("Error: El formato de la línea no es válido.");

                    }
                    
                }
                return Cadeteria;
           }
           catch(Exception ex)
           {
                Console.WriteLine("Error: " + ex.Message);
                throw;
           }
        }

        public override List<Cadete> DatosCadetes()
        {
            string filePath = "Cadete.csv"; 
            List<Cadete> cad = new List<Cadete>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines.Skip(1)) // Saltamos la primera línea con los encabezados
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 4)
                    {
                        string nombre = fields[0];
                        int id = int.Parse(fields[1]);
                        string telefono = fields[2];
                        string direccion = fields[3];

                        cad.Add(new Cadete(id, nombre, telefono, direccion));
                    }
                    else
                    {
                        Console.WriteLine("Error: El formato de la línea no es válido.");
                    }
                }
                return cad;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }   
        }
    }
    public class AccesoJson : AccesoADatos
    {

        public override Cadeteria CargarInfoCadeteria()
        {
            
            try
            {
                string miJson = File.ReadAllText("Cadeteria.json");
                Cadeteria = JsonSerializer.Deserialize<Cadeteria>(miJson);
                return Cadeteria;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw; // Propagar la excepción hacia arriba
            }
        }
        

        public override List<Cadete> DatosCadetes()
        {
            List<Cadete> cad = new List<Cadete>();



            return cad;
        }
    }
}

