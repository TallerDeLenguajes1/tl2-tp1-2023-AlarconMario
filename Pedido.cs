using System;

namespace ServicioDeCadeteria
{
    public class Pedido
    {
        private int id;
        private string obs;
        private Cliente clientes;
        private string estado;
        private Cadete cadetes;

        public int Num { get => id; set => id = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Clientes { get => clientes; set => clientes = value; }
        public string Estado { get => estado; set => estado = value; }
        public Cadete Cadete { get => cadetes; set => cadetes = value; }

        public Pedido(int _id, string _obs, string _estado, Cliente _cliente, Cadete _cadetes )
        {
            this.id = _id;
            this.obs = _obs;
            this.estado = _estado;
            this.clientes = _cliente;
            this.cadetes = _cadetes;
            
        }

        public void AgregarPeido(Cliente cliente, Cadete cadete)
        {
            
        }
        public void verdireccionCliente(Cliente cliente)
        {
            Console.WriteLine("Direccion: "+ cliente.Direccion);
        }
        public void verDatosClientes(Cliente c)
        {  
            Console.WriteLine("INFORMACION DEL CLIENTE");
            Console.WriteLine("Nombre: "+ c.Nombre);
            Console.WriteLine("Direccion: "+ c.Direccion);
            Console.WriteLine("Telefono: "+ c.Telf);
            Console.WriteLine("Dato de Referencia: "+ c.DatoReferencia);

        }
    }
     
     
}