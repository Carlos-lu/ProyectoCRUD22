﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           bool existe = Academico.UsuariosDAO.validaUsuario(this.txtUsuario.Text, this.txtClave.Text);
            if (existe)
            {
                this.Visible = false;
                frmMenu frm1 = new frmMenu();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Usuarios y/o la clave incorrectas");
            }
        }
    }
}
