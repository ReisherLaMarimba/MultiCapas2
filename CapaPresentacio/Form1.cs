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
        }
        public void Mostar(string buscar)
        {
            N_Categoria objNegocio = new N_Categoria();
            tabladatos.DataSource = objNegocio.ListCategoria(buscar);
        }
    }
}
