using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //1. validar si ingresa datos vacios
            if (TxtApellidos.Text.Trim().Length > 0 && TxtContraseña.Text.Trim().Length > 0 && TxtNombres.Text.Trim().Length > 0 && TxtUsuario.Text.Trim().Length > 0 && CbxRol.Text.Trim().Length > 0)
            {
                //encriptar MD5
                string md5 = ClaseUsuarios.GetMd5Hash(TxtContraseña.Text);
                //llamo la funcion insertar usuario
                if (ClaseUsuarios.Func_InsertarUsuario(TxtUsuario.Text, TxtNombres.Text, TxtApellidos.Text, md5, CbxRol.Text))
                {
                    MessageBox.Show("Usuario Agregado", "Felicitaciones!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    //muestre la excepcion
                    MessageBox.Show("Excepcion-->"+ClaseUsuarios.excepcion, "Excepcion!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Falta Ingresar Datos", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
