using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using HESM.MODAL;

namespace HESM.CONTROL
{
     public class Controll
    {
        #region acessar Login

        //variavel para verificar se tem cadastro
        public bool verificaLogin = false;

        //mensagem para retornar ao usuário
        public String mensagem = "";


        public bool acessarLogin(String usuario, String senha)
        {
            //instancia a classe para verificar login no banco de dados
            LoginDAOcommands loginDAO = new LoginDAOcommands();

            //verifica no banco de dados se o login foi encontrado
            verificaLogin = loginDAO.verificarLogin(usuario, senha);

            //se houver mensagem na variavel mensagem, é que ocorreu um erro
            if (!loginDAO.mensagem.Equals(""))
            {
                this.mensagem = loginDAO.mensagem;
            }
            //retorna SIM ou NÃO para a verificação do login no banco
            return verificaLogin;
        }
        #endregion
    }
}
