using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace Api.Models
{
    public class Cliente
    {
        public int CodigoInterno { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }

        public static List<Cliente> Lista(string sqlWhere = "")
        {
            var clientes = new List<Cliente>();
            using (var connection = new MySqlConnection("Server=localhost;User ID=root;Password=mysql;Database=isibank"))
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

                        Console.WriteLine(reader.GetString(0));

                    }
                }

            }
            

            return clientes;

        }
        public static Cliente BuscaPorId(int id)
        {
            return Cliente.Lista("where codcliente =" + id)[0];

        }



    }

}

