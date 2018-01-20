using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoForum.Models;

namespace ProjetoForum.Controllers
{
    [Route("api/[controller]")]
    public class PostagemController:Controller
    {
        Postagem postagem = new Postagem();
        DAOPostagem dao = new DAOPostagem();
    
    [HttpGet]
        public IEnumerable<Postagem> Get()
        {
            return dao.Listar();
        }
        [HttpGet("{id}")]
        public Postagem Get(int id)
        {
            return dao.Listar().Where(x => x.Id == id).FirstOrDefault();
        }
        [HttpPost]
        public IActionResult Post([FromBody]Postagem postagem) //cidades vem do corp do front end
        {
            dao.Cadastrar(postagem);
            return CreatedAtRoute("NovaPostagem", new{id=postagem.Id},postagem);
        }
    }
}

      