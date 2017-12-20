using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using HESM.CONTROL;

namespace HESM.MODAL
{
    class LoginDAOcommands
    {
        //variavel para verificar a resposta do banco de dados
        public bool verificaLogin = false;

        //variavel para guardar a mensagem caso haja erro
        public String mensagem = "";

        //variavel de comando sql
        MySqlCommand comandoSQL = new MySqlCommand();

        //instanciando a classe de conexão com o banco
        Connection mConn = new Connection();

        //uma variavel de tabela para armazenar os resultados
        MySqlDataReader dr;

        public bool verificarLogin(String usuario, String senha)
        {
            //comando sql que verifica se o usuario existe cadastrado no banco
            comandoSQL.CommandText = "SELECT * FROM tb_login WHERE nomeLogin = @usuario AND senhaLogin = @senha";

            //adiciona os parametros para os points do select
            comandoSQL.Parameters.AddWithValue("@usuario", usuario);
            comandoSQL.Parameters.AddWithValue("@senha", senha);

            try
            {
                //define que o camando sql é recebido da conexão, quando ela conectada
                comandoSQL.Connection = mConn.connect();

                //armazena os resultados do select na tabela
                dr = comandoSQL.ExecuteReader();

                //verifica se a tabela contem linhas do resultado
                if (dr.HasRows)
                {
                    verificaLogin = true;
                }
            }
            catch (MySqlException ex)
            {
                this.mensagem = ex.ToString();
            }
            return verificaLogin;
        }
    }
}
