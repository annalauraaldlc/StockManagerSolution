Feature: Cadastrar produto
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](StockManager.AdministrationContext.SpecUnitTests/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@produtos
Scenario: Criar produto com nome em branco
	Given o nome está em branco
	When o produto é criado
	Then não deve permitir criar o produto

Scenario: Criar produto duplicado
	Given o nome é ABC321
	And é igual à um produto existente
	When o produto é criado
	Then não deve permitir criar o produto

Scenario: Criar produto com dados válidos
	Given o nome é ABC321
	When o produto é criado
	Then deve criar produto com sucesso
	Then deve criar o produto como não removido
