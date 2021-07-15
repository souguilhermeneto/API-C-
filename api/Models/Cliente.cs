using Newtonsoft.Json.Linq;
using System.IO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace Api.Models //Indica que a classe está na pasta models
{
    public class Cliente //Classe chamada no controller
    {
        public int CodigoInterno { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public List<Conta> Contas { get{return Conta.BuscaPorCliente(this.CodigoInterno);} }

        public static List<Cliente> Lista(string sqlWhere = "")
        {
            var clientes = new List<Cliente>(); 
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            string sqlCnn = jAppSettings["ConexaoMysql"].ToString(); 
            
            using (var connection = new MySqlConnection(sqlCnn))
            {
                connection.Open();

                using (var command = new MySqlCommand($"SELECT * FROM tbcliente {sqlWhere}", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            clientes.Add(new Cliente()
                            {
                                CodigoInterno = Convert.ToInt32(reader["codcliente"]),
                                Nome = reader["nome"].ToString(),
                                Email = reader["email"].ToString(),
                                Cpf = reader["cpf"].ToString(),
                                Nascimento = Convert.ToDateTime(reader["datanasc"]),
                                Telefone = reader["telefone"].ToString(),
                            });

                        }

                    }
                }

            }
            

            return clientes;

        }
        public static Cliente BuscaPorId(int id)
        {
            var clientes2 = Cliente.Lista("where codcliente =" + id);
            return clientes2.Count > 0 ? clientes2[0] : null;
        }
    }
}

