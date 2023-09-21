using System;
using System.Globalization;
using System.Linq;
using spacePedido;
using spaceCadete;


namespace spaceCadeteria
{
    public class Cadeteria
    {
        private string? nombre;
        private string? telf;
        private List<Cadete> cadetes;
        private List<Pedido> pedidos;

        public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

        public Cadeteria(string nombreArchivoCSV, List<Pedido> _pedidos)
        {
            try
            {
                string[] lineas = File.ReadAllLines(nombreArchivoCSV);

                string[] lines = File.ReadAllLines(nombreArchivoCSV);
                if(lines.Length > 0)
                {
                    string[] values = lines[0].Split(',');
                    this.nombre = values[0];
                    this.telf = values[1];
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos desde el archivo CSV: " + ex.Message);
            }
            pedidos = _pedidos;
            cadetes = ListaDeCadetes("Cadete.csv");

        }


        List<Cadete> ListaDeCadetes(string cadeteCSV)
        {
            List<Cadete> lista = new List<Cadete>();
            try
            {
                string[] lines = File.ReadAllLines(cadeteCSV);

                // Inicializa la lista de cadetes y omite la primera línea (cabecera).
                
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    if (values.Length >= 4)
                    {
                        string nombre = values[0];
                        int id = int.Parse(values[1]);
                         string telf = values[2];
                        string direccion = values[3];
                       
                        // Crea una instancia de Cadete y agrégala a la lista de cadetes.
                        Cadete cadete = new Cadete(id, nombre, direccion, telf);
                        lista.Add(cadete);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos desde el archivo CSV: " + ex.Message);
                return lista;
            }
            
        }
        
        public void mostrarCadetes(List<Cadete> _cad)
        {
            foreach(var cad in _cad)
            {
                Console.WriteLine($"ID : {cad.Id}");
                Console.WriteLine($"Nombre : {cad.Nombre}");
                Console.WriteLine($"Telfono : {cad.Telf}");
            }
        }
        public void Datos(Cadeteria cad)
        {
            
            Console.WriteLine($"Cadeteria: {cad.nombre}");
            Console.WriteLine($"Telefono: {cad.telf}");
            
        }
        public int JornalACobrar(int _idCadete)
        {
            int total = 0;

            foreach(var ped in pedidos)
            {
                if(ped.IdCadete == _idCadete)
                {
                    total += 500;
                }
            }
            
            return total;
        }
        public int enviosEntregados(int _idCadete)
        {
            int contador = 0;
            foreach(var ped in pedidos)
            {
                if(ped.IdCadete == _idCadete)
                {
                    contador++;
                }
            }
            return contador;
        }
        public float promedioDeEnvios(int _idCadete)
        {
            float prom = (enviosEntregados(_idCadete) * 100)/pedidos.Count;


            return prom;
        }
        public void AsignarCadeteAPedido(int _idCadete, int _idPedido){
            for (int i = 0; i < pedidos.Count; i++)
            {
                if (pedidos[i].Nro == _idPedido)
                {
                    pedidos[i].IdCadete = _idCadete;
                    pedidos[i].Estado = "Enviado";
                }
            }
        }
        public void cambiarEstado(int _nroPedido, string _estado)
        {
            for(int i = 0; i < pedidos.Count; i++)
            {   
                if(pedidos[i].Nro == _nroPedido)
                {
                    if(_estado == "SinAsignar")
                    {
                        pedidos[i].IdCadete = 0;
                    }
                    pedidos[i].Estado = _estado;
                    break;
                }
            }
        }
        public void reasignarPedido(int _nroPedido, int _idCadete)
        {
            for(int i = 0; i < pedidos.Count; i++)
            {   
                if(pedidos[i].Nro == _nroPedido)
                {
                    pedidos[i].IdCadete = _idCadete;
                    break;
                }
            }
        }
        public List<Pedido> pedidosAsignado()
        {
            List<Pedido> asignados = new List<Pedido>();
            foreach(var ped in pedidos)
            {
                if(ped.Estado != "SinAsignar")
                {
                    asignados.Add(ped);
                }
            }
            return asignados;
        }
        public List<Pedido> pedidosSinAsignar()
        {
            List<Pedido> sinAsignar = new List<Pedido>();
            foreach(var ped in pedidos)
            {
                if(ped.Estado == "SinAsignar")
                {
                    sinAsignar.Add(ped);
                }
            }
            return sinAsignar;
        }
        public int selecionarPedido(int indice, List<Pedido> _pedidos)
        {
            int pedidoSeleccionado = _pedidos[indice].Nro;
            return pedidoSeleccionado;
        }
    }  
}