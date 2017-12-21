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
        #region Variaveis gerais
        //variavel para armazenar a senha do banco de dados
        public string senhaBD = "";

        //variavel para guardar a mensagem caso haja erro
        public string mensagem = "";

        //variavel de comando sql
        MySqlCommand comandoSQL = new MySqlCommand();

        //instanciando a classe de conexão com o banco
        Connection mConn = new Connection();

        //uma variavel de tabela para armazenar os resultados
        MySqlDataReader dr;
        #endregion

        public string verificarLogin(string usuario)
        {
            //comando sql que verifica se o usuario existe cadastrado no banco
            comandoSQL.CommandText = "SELECT senhaLogin FROM tb_login WHERE nomeLogin = @usuario";

            //adiciona os parametros para os points do select
            comandoSQL.Parameters.AddWithValue("@usuario", usuario);

            //tento fazer o select
            try
            {
                //define que o camando sql é recebido da conexão, quando ela conectada
                comandoSQL.Connection = mConn.connect();

                //fasso a leitura da query
                dr = comandoSQL.ExecuteReader();

                //se conter linhas no resultado da leitura
                if (dr.HasRows)
                {
                    //armazena os resultados do select na tabela                   
                    while (dr.Read())
                    {
                        senhaBD = dr.GetString(0);
                    }
                }

                //se não conter
                else
                {
                    this.mensagem = "Usuário Invalido";
                }
            }
            //se eu não conseguir fazer o select
            catch (MySqlException ex)
            {
                this.mensagem = ex.ToString();
            }
            //retorno o hash salvo no banco de dados
            return senhaBD;
        }

        public bool inserirLogin(string usuario, string senha)
        {
            bool loginInserido = false;

            //tento executar a query
            try
            {
                //Verifica se o usuario que esta tentando cadastrar já existe
                comandoSQL.CommandText = "SELECT * FROM tb_login WHERE nomeLogin = @usuario";

                //adiciona os parametros para os points do select
                comandoSQL.Parameters.AddWithValue("@usuario", usuario);

                //define que o camando sql é recebido da conexão, quando ela conectada
                comandoSQL.Connection = mConn.connect();

                //executo a query
                dr = comandoSQL.ExecuteReader();

                //fecho a conexão com o banco de dados
                mConn.disconnect();

                //se estiver usuario já cadastrado
                if (dr.HasRows)
                {
                    this.mensagem = "Já existe um cadastro com este usuario!";
                }
                //se não tiver
                else                   
                {
                    //tenta inserir o usuario
                    try
                    {
                        comandoSQL.CommandText = "INSERT INTO tb_login" +
                          "(nomeLogin,senhaLogin)" +
                          "VALUES" +
                          "('" + usuario +
                          "','" + senha + "')";

                        //define que o camando sql é recebido da conexão, quando ela conectada
                        comandoSQL.Connection = mConn.connect();

                        //executa a query
                        comandoSQL.ExecuteNonQuery();

                        //fecha a conexão com o banco de dados
                        mConn.disconnect();

                        //aqui fala que o usuario foi inserido com sucesso
                        loginInserido = true;

                        this.mensagem = "Login Cadastrado com sucesso!";
                    }
                    catch (MySqlException mex)
                    {
                        loginInserido = false;
                        this.mensagem = "Erro ao cadastrar \n " + mex.ToString();
                    }
                }
            }
            catch (MySqlException mex)
            {
                this.mensagem = "Erro com o banco de dados \n " + mex.ToString();
            }

            //retorna se o usuario foi inserido ou não
            return loginInserido;
        }
    }
}
