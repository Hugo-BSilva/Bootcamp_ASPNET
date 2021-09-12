using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        //Caso o usuário tente criar uma categoria sem descrição, vai retornar essa msn
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }

        // Remover essa lista para que não de problema(loop) quando essa classe
        // For chamada na API
        //public List<Produto> Produtos { get; set; }
    }
}
