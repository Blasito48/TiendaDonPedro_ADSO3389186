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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (TxtContraseña.PasswordChar == '*')
            {
                TxtContraseña.PasswordChar = '\0';
            }
            else
            {
                TxtContraseña.PasswordChar = '*';
            }
            TxtContraseña.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            //encriptar MD5
            string md5 = ClaseUsuarios.GetMd5Hash(TxtContraseña.Text);
            //traer el MD5 de la base de datos
            DataTable DtUsuario = new DataTable();
            DtUsuario=ClaseUsuarios.Func_TraerPasswordUsuario(TxtUsuario.Text);
            //pregunto si el DT esta vacio (No tiene filas)
            if (DtUsuario.Rows.Count > 0)
            {
                string md5bd = DtUsuario.Rows[0]["PASSWORD_USUARIO"].ToString();
                //comparo el hash generado contra el de la base de datos
                if (md5 == md5bd)
                {
                    this.Hide();
                    FrmMenuPrincipal f = new FrmMenuPrincipal();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Password Incorrecto", "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Usuario NO Existe", "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
           
        }

        private void FrmLogin_Activated(object sender, EventArgs e)
        {
            TxtUsuario.Focus();
        }
    }
}
