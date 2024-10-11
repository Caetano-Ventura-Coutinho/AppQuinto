using AppQuinto.Models;

namespace AppQuinto.Repositorio.Concrect
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObterTodosCliente();

        void Cadastrar(Cliente cliente);

        void Atualizar(Cliente cliente);

        Cliente ObterCliente(int Id);

        void Excluir(int Id);

    }
}
