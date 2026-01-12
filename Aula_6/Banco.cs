using System;
using System.Linq;

namespace Aula_6;

public class Banco
{
    private readonly List<Cliente> listaDeClientes = [];

    public void AdicionarCliente(Cliente novoCliente)
    {
        listaDeClientes.Add(novoCliente);
    }

    public Cliente? BuscarPorCpf(string cpfBusca)
    {
        return listaDeClientes.Find(c => c.Cpf == cpfBusca);
    }

    public List<Cliente> ObterTodosClientes()
    {
        return listaDeClientes;    
    }

}