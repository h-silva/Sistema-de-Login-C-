using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HESM.MODAL
{
   public class Connection
    {
        #region Configuração banco de dados
        //instancia a conexão padrao do SQL
        private MySqlConnection mConn = new MySqlConnection(
             "Persist Security Info=False;" + //tira o pedido de senha/usuário toda hora
             "server=localhost;" + //local do banco
             "database=esmcontrol;" + //nome do banco de dados
             "uid=root;" +//usuário de acesso
             "pwd="//senha do usuário
             );
        #endregion
        //método para desconectar o banco de dados
        public MySqlConnection connect()
        {
            //verifica se a conexão está fechada antes de abrir
            if (mConn.State == System.Data.ConnectionState.Closed)
            {
                mConn.Open();
            }
            return mConn;
        }
        //método para desconectar o banco de dados
        public void disconnect()
        {
            //verifica se a conexão está aberta antes de fechar
            if (mConn.State == System.Data.ConnectionState.Open)
            {
                mConn.Close();
            }
        }
    }
}

