using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HESM.CONTROL;

namespace HESM.VIEW
{
    public partial class frmCadastroLogin : Form
    {
        public frmCadastroLogin()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //instancia uma classe Controll para controlar meu formulário
            Controll controle = new Controll();

            //pega os campos da tela
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            //chama a função para tentar inserir o usuario           
            controle.criarLogin(usuario, senha);

            MessageBox.Show(controle.mensagem,"Retorno",MessageBoxButtons.OK,MessageBoxIcon.Information);

            //Se conseguir criar o usuario, fecho a tela
            if (controle.loginInserido == true)
            {
                this.Close();
            }

            //se não limpa os campos para tentar + 1 vez
            else
            {
                txtSenha.Clear();
                txtUsuario.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //fecha a tela
            this.Close();
        }
    }
}
