using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocion
{
    public class N_Categoria
    {
        D_Categoria Objdato = new D_Categoria();
        public List<E_Categoria>ListCategoria(string buscar)
        {
            return Objdato.ListCategoria(buscar);
        }
        public void insercionCategoria(E_Categoria categoria)
        {
            Objdato.InsertarCat(categoria);
        }

        public void EdicionCategoria(E_Categoria categoria)
        {
            Objdato.EditarCat(categoria);
        }
        public void BorraCategorioa(E_Categoria categoria)
        {
            Objdato.EliminarCat(categoria);
        }
    }
}
