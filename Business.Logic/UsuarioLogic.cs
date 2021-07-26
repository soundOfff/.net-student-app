using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic: BusinessLogic
    {
        private UsuarioAdapter _usuarioData;

        public UsuarioAdapter UsuarioData { get { return _usuarioData; } set { _usuarioData = value; } }

        public UsuarioLogic()
        {
            _usuarioData = new UsuarioAdapter();
        }


        public List<Usuario> GetAll()
        {
            return _usuarioData.GetAll();
        }

        public Usuario GetOne(int idUsuario)
        {
            return _usuarioData.GetOne(idUsuario);
        }
        
        public Usuario GetOne(string nombreUsuario, string clave)
        {
            return _usuarioData.GetOne(nombreUsuario, clave);
        }

        public void Delete(int idUsuario)
        {
            _usuarioData.Delete(idUsuario);
        }

        public void Save(Usuario usuario)
        {
            _usuarioData.Save(usuario);
        }

    }
}
