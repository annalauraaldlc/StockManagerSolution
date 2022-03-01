using Moq;
using NUnit.Framework;
using StockManager.AdministrationContext.Domain;
using System;

namespace StockManager.AdministrationContext.UnitTests.Features
{
    [TestFixture]
    public class CreateProductUnitTests
    {
        [Test]
        public void Quando_CriarProduto_Com_NomeEmBranco_NaoDeve_PermitirCriacao()
        {
            Assert.Throws<Exception>(() => new Product("", "any description"));
        }

        [Test]
        public void Quando_CriarProduto_Deve_CriarComoNaoRemovido()
        {
            var product = new Product("any name", "any description");

            Assert.That(product.IsRemoved, Is.EqualTo(false));
        }

        [Test]
        public void Quando_CriarProdutoComMesmoNomeDeExistente_NaoDeve_PermitirCriacao()
        {
            var similarProduct = new Product("any name", "some description");

            var repositoryFake = new Mock<IProductRepository>();
            repositoryFake.Setup(y => y.GetByName("any name")).Returns(similarProduct);

            var factory = new ProductFactory(repositoryFake.Object);

            Assert.Throws<Exception>(() => factory.Create("any name", "any description"));
        }

        [Test]
        public void Quando_CriarProdutoUnico_Deve_PermitirCriacao()
        {
            var repositoryFake = new Mock<IProductRepository>();
            repositoryFake.Setup(y => y.GetByName("any name")).Returns((Product)null);

            var factory = new ProductFactory(repositoryFake.Object);
            var newProduct = factory.Create("any name", "any description");

            Assert.IsNotNull(newProduct);
            Assert.That(newProduct.Name, Is.EqualTo("any name"));
            Assert.That(newProduct.Description, Is.EqualTo("any description"));
        }
    }
}
