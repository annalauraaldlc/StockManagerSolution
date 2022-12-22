using ElemarJR.FunctionalCSharp;
using Moq;
using NUnit.Framework;
using StockManager.AdministrationContext.Domain;
using StockManager.AdministrationContext.Domain.ProductAggregate;

namespace StockManager.AdministrationContext.SpecUnitTests.StepDefinitions
{
    [Binding]
    public sealed class CreateProductStepDefinitions
    {
        string? _productName;
        private Mock<IProductRepository> _repositoryFake = new Mock<IProductRepository>();
        private Try<Exception, Product> _creationResult;

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("o nome está em branco")]
        public void GivenNameIsEmpty()
        {
            _productName = "";
        }

        [Given("o nome é (.*)")]
        public void GivenNameIs(string productName)
        {
            _productName = productName;
        }

        [Given("é igual à um produto existente")]
        public void GivenNameIsEqualAnOther()
        {
            var similarProduct = new Product(_productName, "some description");

            _repositoryFake.Setup(y => y.GetByName(_productName)).Returns(similarProduct);
        }

        [When("o produto é criado")]
        public void WhenProductIsCreated()
        {
            var factory = new ProductFactory(_repositoryFake.Object);

            _creationResult = factory.Create(_productName, "any description");
        }

        [Then("não deve permitir criar o produto")]
        public void ThenCantCreateProduct()
        {
            Assert.IsTrue(_creationResult.IsFailure);
        }

        [Then("deve criar produto com sucesso")]
        public void ThenCreateProductWithSuccess()
        {
            Assert.IsTrue(_creationResult.IsSucess);

        }

        [Then("deve criar o produto como não removido")]
        public void ThenCreateProductAsNotRemoved()
        {
            bool isRemoved = true;

            Option<Product> a = _creationResult.OptionalSuccess;

            a.Match(
                some: (Product value) => isRemoved = value.IsRemoved,
                none: () => new Unit()
                );

            Assert.IsFalse(isRemoved);
        }
    }
}