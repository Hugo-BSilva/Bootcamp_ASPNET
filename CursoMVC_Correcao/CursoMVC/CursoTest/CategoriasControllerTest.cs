using CursoAPI.Controllers;
using CursoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CursoTest
{
    public class CategoriasControllerTest
    {
        /* Para que não crie registros duplicados(ou indesejado) utilizaremos o 
         * Mock(instalar pacote moq) para fazer os testes da API */
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;
        public CategoriasControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { Id = 3, Descricao = "Teste" };
            

            _mockContext.Setup(m => m.Categorias).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.Categorias.FindAsync(3)).ReturnsAsync(_categoria);

            _mockContext.Setup(m => m.SetModified(_categoria));

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);
        }

        [Fact]
        public async Task Get_Categoria()
        {
            // Pega todos os métodos que tem no controller da API
            var service = new CategoriasController(_mockContext.Object);
            await service.GetCategoria(3);
            /* Verifica se o FindAsync foi executado uma vez só
             * (caso um dev inclua mais um FindAsync na controller da API) */
             _mockSet.Verify(m => m.FindAsync(3), Times.Once());
        }

        [Fact]
        public async Task Put_Categoria()
        {
            // Pega todos os métodos que tem no controller da API
            var service = new CategoriasController(_mockContext.Object);
            await service.PutCategoria(3, _categoria);
            /* Verifica se o FindAsync foi executado uma vez só
             * (caso um dev inclua mais um FindAsync na controller da API) */
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Post_Categoria()
        {
            // Pega todos os métodos que tem no controller da API
            var service = new CategoriasController(_mockContext.Object);
            await service.PostCategoria(_categoria);

            /* Verifica se o FindAsync foi executado uma vez só
             * (caso um dev inclua mais um FindAsync na controller da API) */
            _mockSet.Verify(x => x.Add(_categoria), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Delete_Categoria()
        {
            // Pega todos os métodos que tem no controller da API
            var service = new CategoriasController(_mockContext.Object);
            await service.DeleteCategoria(3);

            /* Verifica se o FindAsync foi executado uma vez só
             * (caso um dev inclua mais um FindAsync na controller da API) */
            _mockSet.Verify(m => m.FindAsync(3), Times.Once());
            _mockSet.Verify(x => x.Remove(_categoria), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
