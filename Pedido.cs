using System;

namespace ServicioDeCadeteria
{
    public class Pedido
    {
    private int id;
    private string obs;
    private Cliente clientes;
    private string estado;
    //private Cadete cadete;

    public int Num { get => id; set => id = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Clientes { get => clientes; set => clientes = value; }
    public string Estado { get => estado; set => estado = value; }
    //public Cadete Cadete { get => cadete; set => cadete = value; }

    public Pedido(int _id, string _obs, string _estado, Cliente _cliente )
    {
        this.id = _id;
        this.obs = _obs;
        this.estado = _estado;
        this.clientes = _cliente;
        
    }
    }
     
}