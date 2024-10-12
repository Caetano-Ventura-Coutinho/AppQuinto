using AppQuinto.Models;
using AppQuinto.Repositorio.Concrect;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppQuinto.Repositorio
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _conexaoMySql;

        public ClienteRepository(IConfiguration conf)
        {
            _conexaoMySql = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Cadastrar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into cliente(NomeCli, Telefone, DataNasc, Email)" +
                                                    "values (@NomeCli, @Telefone, STR_TO_DATE(@DataNasc,'%d/%m/%Y'), @Email)", conexao);

                cmd.Parameters.Add("@NomeCli", MySqlDbType.VarChar).Value = cliente.NomeCli;
                cmd.Parameters.Add("@Telefone", MySqlDbType.Decimal).Value = cliente.Telefone;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = cliente.DataNasc.ToString("dd/MM/yyyy");
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }

        }

        public void Atualizar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update cliente set NomeCli=@NomeCli, Telefone=@Telefone," +
                                                    "DataNasc=@DataNasc, Email=@Email Where IdCli=@IdCli;", conexao);
                cmd.Parameters.Add("@NomeCli", MySqlDbType.VarChar).Value = cliente.NomeCli;
                cmd.Parameters.Add("@Telefone", MySqlDbType.Decimal).Value = cliente.Telefone;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = cliente.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@IdCli", MySqlDbType.VarChar).Value = cliente.IdCli;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from cliente where IdCli=@IdCli", conexao);
                cmd.Parameters.AddWithValue("@IdCli", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Cliente> ObterTodosCliente()
        {
            List<Cliente> clienteList = new List<Cliente>();
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from cliente", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);



                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    clienteList.Add(
                        new Cliente
                        {
                            IdCli = Convert.ToInt32(dr["IdCli"]),
                            NomeCli = (string)dr["NomeCli"],
                            Telefone = Convert.ToUInt64(dr["Telefone"]),
                            DataNasc = Convert.ToDateTime(dr["DataNasc"]),
                            Email = (string)dr["Email"]
                        });
                };
                return clienteList;
            }
        }
        public Cliente ObterCliente(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from cliente " +
                                                    " where IdCli =@IdCli", conexao);
                cmd.Parameters.AddWithValue("@IdCli", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    cliente.IdCli = Convert.ToInt32(dr["IdCli"]);
                    cliente.NomeCli = (string)dr["NomeCli"];
                    cliente.Telefone = Convert.ToUInt64(dr["Telefone"]);
                    cliente.DataNasc = Convert.ToDateTime(dr["DataNasc"]);
                    cliente.Email = (string)dr["Email"];
                };
                return cliente;
            }
        }
    }
}
