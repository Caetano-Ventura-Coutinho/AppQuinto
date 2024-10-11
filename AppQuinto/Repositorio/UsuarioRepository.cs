using AppQuinto.Models;
using AppQuinto.Repositorio.Concrect;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
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
                                                    "values (@nomeUsu, @Cargo, STR_TO_DATE(@DataNasc,'%d/%m/%Y'))", conexao);

                cmd.Parameters.Add("@nomeUsu", MySqlDbType.VarChar).Value = usuario.nomeUsu;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = usuario.DataNasc.ToString("dd/MM/yyyy");

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
            
        }

        public void Atualizar(usuario Usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update usuario set nomeUsu=@nomeUsu, Cargo=@Cargo," +
                                                    "DataNasc=@DataNasc Where IdUsu=@IdUsu;", conexao);
                cmd.Parameters.Add("@nomeUsu", MySqlDbType.VarChar).Value = Usuario.nomeUsu;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = Usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = Usuario.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@IdUsu", MySqlDbType.VarChar).Value = Usuario.IdUsu;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from usuario where IdUsu=@IdUsu", conexao);
                cmd.Parameters.AddWithValue("@IdUsu", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<usuario> ObterTodosUsuarios()
        {
            List<usuario> UsuarioList = new List<usuario>();
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                        conexao.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from usuario");

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                cmd.Connection = conexao;
                using (da)
                {
                    da.Fill(dt);
                }


                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    UsuarioList.Add(
                        new usuario
                        {
                            IdUsu = Convert.ToInt32(dr["IdUsu"]),
                            nomeUsu = (string)dr["nomeUsu"],
                            Cargo = (string)dr["Cargo"],
                            DataNasc = Convert.ToDateTime(dr["DataNasc"])
                        });
                };
                return UsuarioList;
            }
        }
        public usuario ObterUsuario(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from usuario " +
                                                    " where IdUsu =@IdUsu", conexao);
                cmd.Parameters.AddWithValue("@idUsu", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                usuario Usuario = new usuario();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read()) {
                    Usuario.IdUsu = Convert.ToInt32(dr["IdUsu"]);
                    Usuario.nomeUsu = (string)dr["nomeUsu"];
                    Usuario.Cargo = (string)dr["Cargo"];
                    Usuario.DataNasc = Convert.ToDateTime(dr["DataNasc"]);
                };
                return Usuario;
            }
        }
    }
}
