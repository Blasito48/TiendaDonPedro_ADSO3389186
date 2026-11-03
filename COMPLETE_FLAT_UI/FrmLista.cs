using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace COMPLETE_FLAT_UI
{
    public partial class FrmLista : Form
    {
        public FrmLista()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (LblTitulo.Text == "Lista de Usuarios")
            {
                long Id = 0;
                string alias = "";
                string nombre = "";
                string apellido = "";
                string contra = "";
                string rol = "";
                Id = Convert.ToInt64(DGVDatos.CurrentRow.Cells["ID_USUARIO"].Value);
                alias = DGVDatos.CurrentRow.Cells["ALIAS_USUARIO"].Value.ToString();
                nombre = DGVDatos.CurrentRow.Cells["NOMBRE_USUARIO"].Value.ToString();
                apellido = DGVDatos.CurrentRow.Cells["APELLIDO_USUARIO"].Value.ToString();
                contra = DGVDatos.CurrentRow.Cells["PASSWORD_USUARIO"].Value.ToString();
                rol = DGVDatos.CurrentRow.Cells["ROL_USUARIO"].Value.ToString();
                FrmUsuarios f = new FrmUsuarios();
                f.TxtApellidos.Text = apellido;
                f.TxtContraseña.Text = contra;
                f.TxtNombres.Text = nombre;
                f.TxtUsuario.Text = alias;
                f.CbxRol.Text = rol;
                f.TxtIDUsuario.Text = Id.ToString();
                f.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (LblTitulo.Text == "Lista de Usuarios")
            {
                FrmUsuarios f = new FrmUsuarios();
                f.ShowDialog();
            }

        }

        private void FrmLista_Activated(object sender, EventArgs e)
        {

        }

        private void FrmLista_Load(object sender, EventArgs e)
        {
            if (this.LblTitulo.Text == "Lista de Usuarios")
            {
                DGVDatos.DataSource = ClaseUsuarios.Func_TraerTodo();
                //oculto columna password
                this.DGVDatos.Columns["PASSWORD_USUARIO"].Visible = false;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.LblTitulo.Text == "Lista de Usuarios")
            {
                long ideliminar = int.Parse(DGVDatos.CurrentRow.Cells["ID_USUARIO"].Value.ToString());
                DialogResult rpta = new DialogResult();
                rpta = MessageBox.Show("Desea Eliminar el ID-->" + ideliminar, "Advertencia!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rpta == DialogResult.OK)
                {
                    //llamo la funcion eliminar usuario
                    if (ClaseUsuarios.Func_EliminarUsuario(ideliminar))
                    {
                        MessageBox.Show("Usuario Eliminado", "Felicitaciones!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Excepion-->" + ClaseUsuarios.excepcion, "Excepion!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
