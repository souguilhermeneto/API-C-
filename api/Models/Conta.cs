using Newtonsoft.Json.Linq;
using System.IO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace Api.Models
{
    public class Conta
    {
        public int Numero { get; set; }
        public int Tipo { get; set; }
        public int Agencia { get; set; }
        public int Saldo { get; set; }
        public int Codigo { get; set; }

        public static List<Conta> BuscaPorCliente(int CodigoInterno)
        {
            return Conta.Lista("Where codigo =" + CodigoInterno);
        }
        public static List<Conta> Lista(string sqlWhere = "") //O método é estatico, porque no controller não será instanciado.
        {
            var contas = new List<Conta>(); //Passa cada item da lista para a variavel contas
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            string sqlCnn = jAppSettings["ConexaoMysql"].ToString(); //Objeto que faz a leitura de arquivos json

            using (var connection = new MySqlConnection(sqlCnn))
            {
                connection.Open();

                using (var command = new MySqlCommand($"SELECT * FROM tbconta {sqlWhere}", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            contas.Add(new Conta()
                            {
                                Numero = Convert.ToInt32(reader["numero"]),
                                Tipo = Convert.ToInt32(reader["tipo"]),
                                Agencia = Convert.ToInt32(reader["agencia"]),
                                Saldo = Convert.ToInt32(reader["saldo"]),
                                Codigo = Convert.ToInt32(reader["codigo"]),

                            });

                        }

                    }
                }

            }


            return contas;

        }
        public static Conta BuscaPorId(int id)
        {
            var contas2 = Conta.Lista("where numero =" + id);
            return contas2.Count > 0 ? contas2[0] : null;
        }
    }

}

