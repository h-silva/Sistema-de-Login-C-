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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Controll controle = new Controll();

            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            //faz a busca para verificar se o login é correto ou não
            controle.acessarLogin(usuario, senha);

            if (controle.verificaLogin == false)
            {
                MessageBox.Show("Erro de Login! Tente novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("BEM-VINDO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
