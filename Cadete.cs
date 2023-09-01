using System;

public enum listaDecadetes
{
    Luis,
    juan,
    Diego,
}

namespace ServicioDeCadeteria
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
       
        public Cadete(string _nombre, int _id, string _telf, string _direccion)
        {
            this.nombre = _nombre;
            this.id = _id;
            this.telf = _telf;
            this.direccion = _direccion;
            this.pedidos = new List<Pedido>();
            
        }

        public void crearCadete(){
            
        }

        public void cargarCadete()
        {
            string filePath = "Cadete.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("id,telf,direccion");
            writer.WriteLine("98,252342,New York");
            writer.WriteLine("21,301233,Los Angeles");
            writer.WriteLine("21,28455,Chicago");
    }

    Console.WriteLine("Archivo CSV creado exitosamente.");
        }
        
        public void verCadetes()
        {
            string filePath = "Cadete.csv";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    int id = int.Parse(values[0]);
                    string telf = values[1];
                    string direccion = values[2];

                    Console.WriteLine($"id: {id}, telf: {telf}, direccion: {direccion}");
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
    
        }
        public void jornalCobrar()
        {

        }
    
        
    }
}
