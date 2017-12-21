using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using HESM.MODAL;
using BCrypt.Net;

namespace HESM.CONTROL
{
     public class Controll
    {

        #region Váriaveis gerais
        //senha que vai vir do banco de dados
        string senhaDB = "";

        //senha gerada o hash para verificação
        string senhaHash = "";

        //variavel para verificar se tem cadastro
        public bool verificaLogin = false;

        //variavel para verificar se usuario foi inserido
        public bool loginInserido = false;

        //mensagem para retornar ao usuário
        public string mensagem = "";
        #endregion

        #region acessar Login
        public bool acessarLogin(string usuario, string senha)
        {
            //instancia a classe para verificar login no banco de dados
            LoginDAOcommands loginDAO = new LoginDAOcommands();

            //verifica no banco de dados se o login foi encontrado
            senhaDB = loginDAO.verificarLogin(usuario);

            //se houver mensagem na variavel mensagem, é que ocorreu um erro
            if (!loginDAO.mensagem.Equals(""))
            {
                this.mensagem = loginDAO.mensagem;
            }
            //se o campo de senha que estava no banco de dados não estiver em branco
            if (!senhaDB.Equals(""))
            {
                //chama a função para ver se a senha corresponde ao hash do banco de dados
                if (verificarHash(senha, senhaDB))
                {
                   verificaLogin = true;
                }
                //se não corresponder
                else
                {
                    verificaLogin = false;
                }

            }
            //retorna SIM ou NÃO para a verificação do login no banco
            return verificaLogin;
        }
        #endregion

        #region criar login
        public bool criarLogin(string usuario, string senha)
        {   
            //instancia a classe LoginDAOcommands para fazer querys
            LoginDAOcommands loginDAO = new LoginDAOcommands();

            //chama a função para gerar uma criptografia hash
            string senhaHash = gerarHash(senha);

            //chama a função para cadastrar o usuario no banco de dados
            loginInserido = loginDAO.inserirLogin(usuario, senhaHash);

            this.mensagem = loginDAO.mensagem;

            //retorna se o cadastro foi inserido ou não
            return loginInserido;
        }
        #endregion

        #region Criptografia
        public string gerarHash(string senha)
        {
            //criptografa a senha digitada pelo usuario para cadastrar no banco de dados
            senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

            //retorna a senha já criptografada
            return senhaHash;
        }

        public bool verificarHash(string senha, string senhaDB)
        {
            //retorna a função para verificar se a senha corresponde ao hash salvo no banco de dados
            return BCrypt.Net.BCrypt.Verify(senha, senhaDB);
        }
        #endregion
    }
}
