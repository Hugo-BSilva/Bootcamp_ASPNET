using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }
        //Para o campo descrição aparecer com ç e pontuação
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        //Valor mínimo, máximo
        [Range(1, 10, ErrorMessage = "Valor acima de 10")]
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
