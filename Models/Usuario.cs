using System;
using System.Collections.Generic;

namespace ProjetoForum.Models
{
    public class Usuario
    {
        public int Idusuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime Datacadastro { get; set; }

    }
}