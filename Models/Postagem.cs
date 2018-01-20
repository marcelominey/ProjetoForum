using System;
using System.Collections.Generic;

namespace ProjetoForum.Models
{
    public class Postagem
    {
        public int Id { get; set; }
        public int Idtopico { get; set; }
        public int Idusuario { get; set; }
        public string Mensagem { get; set; }
        public DateTime Datapublicacao { get; set; }
        

    }
}
