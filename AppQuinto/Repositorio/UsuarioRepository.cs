using AppQuinto.Models;
using AppQuinto.Repositorio.Concrect;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppQuinto.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _conexaoMySql;

        public UsuarioRepository(IConfiguration conf)
        {
            _conexaoMySql = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Cadastrar(usuario usuario)
        {
            using( var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into usuario(nomeUsu, Cargo, DataNasc)" +
                                                    "values (@nomeUsu, @Cargo, (STR_TO_DATE('@DataNasc','%d/%m/%Y')))", conexao);

                cmd.Parameters.Add("@nomeUsu", MySqlDbType.VarChar).Value = usuario.nomeUsu;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = usuario.DataNasc;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
            throw new NotImplementedException();
        }

        public void Atualizar(usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<usuario> ObterTodosUsuarios()
        {
            throw new NotImplementedException();
        }

        public usuario ObterUsuario(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
