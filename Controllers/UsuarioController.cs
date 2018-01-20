using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoForum.Models;

namespace ProjetoForum.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController:Controller
    {
        Usuario usuario = new Usuario();
        DAOUsuario dao = new DAOUsuario();
    
    [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return dao.Listar();
        }
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return dao.Listar().Where(x => x.Idusuario == id).FirstOrDefault();
        }
    }

}

      