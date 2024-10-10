using AppQuinto.Models;

namespace AppQuinto.Repositorio.Concrect
{
    public interface IUsuarioRepository
    {
        IEnumerable <usuario> ObterTodosUsuarios();

        void Cadastrar(usuario usuario);

        void Atualizar(usuario usuario);

        usuario ObterUsuario(int Id);

        void Excluir(int Id);

    }
}
