using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD2.Adm
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtNombreCompleto.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingresar el nombre completo...");
                this.txtNombreCompleto.Focus();
                return;
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            Encerar();
        }
        private void Encerar()
        {
            this.txtId.Text = "0";
            this.txtNombreCompleto.Text = String.Empty;
            this.txtNombreCompleto.Text = "Secretaria";

        }
    }
}
