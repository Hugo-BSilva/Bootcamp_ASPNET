using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Context : DbContext
    {
        /* VIRTUAL PARA QUE OS TESTES UNITÁRIOS FUNCIONEM NO MÉTODO SetModified */
        //Tabela com nome Categorias, realizar Add-Migration InitialCreate
        public virtual DbSet<Categoria> Categorias { get; set; }

        //Tabela com nome Produtos, realizar Add-Migration TabelaProduto
        public virtual DbSet<Produto> Produtos { get; set; }

        //Configura o EntityFramework
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Passo qual o banco de dados vou utilizar
            optionsBuilder.UseSqlServer(connectionString:@"Server=(localdb)\mssqllocaldb;Database=Cursomvc;Integrated Security=True");
        }

        public virtual void SetModified(object entity)
        {
            //Para que funcione os testes unitario
            Entry(entity).State = EntityState.Modified;
        }
    }
}
