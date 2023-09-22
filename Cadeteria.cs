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
        private List<Cadete>? ListadoCadetes;
        private List<Pedido>? ListadoPedidos;

        public List<Cadete>? Cadetes { get => ListadoCadetes; set => ListadoCadetes = value; }
        public List<Pedido>? Pedidos { get => ListadoPedidos; set => ListadoPedidos = value; }

        public Cadeteria()
        {
            
        }
        public Cadeteria(string nombre, string telf, List<Cadete> cadetes, List<Pedido> pedidos)
        {
            this.nombre = nombre;
            this.telf = telf;
            this.Cadetes = cadetes;
            this.Pedidos = pedidos;

        }
      
        
        public void Datos(Cadeteria cad)
        {
            
            Console.WriteLine($"Cadeteria: {cad.nombre}");
            Console.WriteLine($"Telefono: {cad.telf}");
            
        }
        public int JornalACobrar(int _idCadete)
        {
            int total = 0;
            if(ListadoPedidos  != null)
            {
                foreach(var ped in ListadoPedidos)
                {
                    if(ped.IdCadete == _idCadete)
                    {
                        total += 500;
                    }
                }
                
            }
           
            
            
            return total;
        }
        public int enviosEntregados(int _idCadete)
        {
            int contador = 0;
            foreach(var ped in ListadoPedidos)
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
            float prom = 0;
            if(ListadoPedidos != null)
            {
                prom = (enviosEntregados(_idCadete) * 100)/ListadoPedidos.Count;
            }
            return prom;
        }
        public void AsignarCadeteAPedido(int _idCadete, int _idPedido){
            for (int i = 0; i < ListadoPedidos.Count; i++)
            {
                if (ListadoPedidos[i].Nro == _idPedido)
                {
                    ListadoPedidos[i].IdCadete = _idCadete;
                    ListadoPedidos[i].Estado = "Enviado";
                }
            }
        }
        public void cambiarEstado(int _nroPedido, string _estado)
        {
            if(ListadoPedidos != null)
            {
                for(int i = 0; i < ListadoPedidos.Count; i++)
            {   
                if(ListadoPedidos[i].Nro == _nroPedido)
                {
                    if(_estado == "SinAsignar")
                    {
                        ListadoPedidos[i].IdCadete = 0;
                    }
                    ListadoPedidos[i].Estado = _estado;
                    break;
                }
            }
            }
            
        }
        public void reasignarPedido(int _nroPedido, int _idCadete)
        {
            for(int i = 0; i < ListadoPedidos.Count; i++)
            {   
                if(ListadoPedidos[i].Nro == _nroPedido)
                {
                    ListadoPedidos[i].IdCadete = _idCadete;
                    break;
                }
            }
        }
        public List<Pedido> pedidosAsignado()
        {
            List<Pedido> asignados = new List<Pedido>();
            foreach(var ped in ListadoPedidos)
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
            foreach(var ped in ListadoPedidos)
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