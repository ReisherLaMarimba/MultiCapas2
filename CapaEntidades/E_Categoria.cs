using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Categoria
    {
        private int _idCategoria;
        private string _CodigoCategoria;
        private string _Nombre;
        private string _Descripcion;

        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string CodigoCategoria { get => _CodigoCategoria; set => _CodigoCategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
