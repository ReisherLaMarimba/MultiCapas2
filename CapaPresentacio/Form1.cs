using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocion;
using CapaDatos;

namespace CapaPresentacio
{
    public partial class Form1 : Form
    {
        private string idcategoria;
        private bool editarse = false;
        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mostar("");
            accionesEnTabla();
        }
        public void accionesEnTabla()
        {
            tabladatos.Columns[0].Visible = false;
            tabladatos.ClearSelection();
        }
        public void Mostar(string buscar)
        {
            N_Categoria objNegocio = new N_Categoria();
            tabladatos.DataSource = objNegocio.ListCategoria(buscar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
                Mostar(txtBuscar.Text);
        }

        private void limpiarCampos()
        {
            editarse = false;
            txtcod.Text = "";
            txtName.Text = "";
            txtDesc.Text = "";
            txtName.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            limpiarCampos();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tabladatos.SelectedRows.Count > 0)
            {
                editarse = true;
                    idcategoria = tabladatos.CurrentRow.Cells[0].Value.ToString();
                txtcod.Text = tabladatos.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = tabladatos.CurrentRow.Cells[2].Value.ToString();
                txtDesc.Text = tabladatos.CurrentRow.Cells[3].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                if(editarse == false)
            {
                try
                {
                    objEntidad.Nombre = txtName.Text.ToUpper();
                   objEntidad.Descripcion = txtDesc.Text.ToUpper();
                    objNegocio.insercionCategoria(objEntidad);
                    MessageBox.Show("Registro guardado");
                    Mostar("");
                    limpiarCampos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo guardar" +ex);
                }
            }
                if(editarse == true)
            {
                try
                {
                    objEntidad.IdCategoria = Convert.ToInt32(idcategoria);
                    objEntidad.Nombre = txtName.Text.ToUpper();
                    objEntidad.Descripcion = txtDesc.Text.ToUpper();
                    objNegocio.insercionCategoria(objEntidad);
                    MessageBox.Show("Se edito el registro ");
                    Mostar("");
                    editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar " +ex);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tabladatos.SelectedRows.Count > 0)
            {
                objEntidad.IdCategoria = Convert.ToInt32(tabladatos.CurrentRow.Cells[0].Value.ToString());
                objNegocio.BorraCategorioa(objEntidad);
                MessageBox.Show("Elimino el registro corectamente");
                Mostar("");
            }
        }
    }
}
