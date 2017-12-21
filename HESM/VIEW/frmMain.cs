using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HESM.VIEW
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin abrirLogin = new frmLogin();
            abrirLogin.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCadastroLogin abrirCadastroLogin = new frmCadastroLogin();
            abrirCadastroLogin.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            panel1.Focus();
        }
    }
}
