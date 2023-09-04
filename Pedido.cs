using System;
using spaceCadeteria;
using spaceCadete;
using spaceCliente;

namespace spacePedido
{
    public class Pedido
    {
        private int nro;
        private string obs;
        //Cliente cliente;
        private string estado;
       

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        //public Cliente Clientes { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }
       

        public Pedido(int _id, string _obs, string _estado)
        {
            this.nro = _id;
            this.obs = _obs;
            this.estado = _estado;
            
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

        public enum estadoPedido{
            SinAsignar,
            Entregado,
            EnCamino
        }
        
        
        public void altaPedido(){

        }
    }
     
     
}