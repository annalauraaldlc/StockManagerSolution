using ElemarJR.FunctionalCSharp;
using Moq;
using NUnit.Framework;
using StockManager.AdministrationContext.Domain;
using StockManager.AdministrationContext.Domain.ProductAggregate;

namespace StockManager.AdministrationContext.SpecUnitTests.StepDefinitions
{
    [Binding]
    public class RemoverProdutoStepDefinitions
    {
        private Mock<IProductRepository> _repositoryFake;
        private ProductRemoveDomainService _productRemoveDomainService;
        private Try<Exception, Product> _removeResult;


        [Given(@"o produto está ativo")]
        public void GivenOProdutoEstaAtivo()
        {
            if (_repositoryFake == null)
                _repositoryFake = new Mock<IProductRepository>();

            var product = new Product("any name", "any description");
            _repositoryFake.Setup(y => y.GetById(It.IsAny<Guid>())).Returns(product);
        }

        [Given(@"há (.*) itens em inventário")]
        public void GivenHaItensEmInventario(int count)
        {
            if (_repositoryFake == null)
                _repositoryFake = new Mock<IProductRepository>();

            _repositoryFake.Setup(y => y.InventoryStatus(It.IsAny<Guid>())).Returns(count);
        }

        [Given(@"o produto está inativo")]
        public void GivenOProdutoEstaInativo()
        {
            if (_repositoryFake == null)
                _repositoryFake = new Mock<IProductRepository>();

            _repositoryFake.Setup(y => y.GetById(It.IsAny<Guid>())).Returns(default(Product));
        }

        [When(@"remover o produto")]
        public void WhenRemoverOProduto()
        {
            _productRemoveDomainService = new ProductRemoveDomainService(_repositoryFake.Object);
            _removeResult = _productRemoveDomainService.RemoveProduct(new Guid());
        }

        [Then(@"remover com sucesso")]
        public void ThenRemoverComSucesso()
        {
            Option<Product> a = _removeResult.OptionalSuccess;

            a.Match(
                some: (Product value) => Assert.Pass(),
                none: () => Assert.Fail()
                );
        }


        [Then(@"não deve permitir a remoção")]
        public void ThenNaoDevePermitirARemocao()
        {
            Assert.IsTrue(_removeResult.IsFailure);
        }

    }
}
